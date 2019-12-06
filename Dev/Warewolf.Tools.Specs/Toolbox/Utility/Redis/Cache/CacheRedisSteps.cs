﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


using Dev2.Activities.Redis;
using Dev2.Common.Serializers;
using Dev2.Interfaces;
using Dev2.Runtime.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Driver.Redis;
using Warewolf.Storage;

namespace Warewolf.Tools.Specs.Toolbox.Utility.Redis.Cache
{
    [Binding]
    public class RedisCacheSteps
    {

        readonly ScenarioContext _scenarioContext;
        private Depends _containerOps;

        public RedisCacheSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
        public static Stopwatch Stoptime { get; set; }

        [Given(@"Redis source ""(.*)"" with password ""(.*)"" and port ""(.*)""")]
        public void GivenRedisSourceWithPasswordAndPort(string hostName, string password, int port)
        {
            SetUpRedisClientConnection(hostName, password, port);
        }

        [Given(@"valid Redis source")]
        public void GivenValidRedisSource()
        {
            _containerOps = new Depends(Depends.ContainerType.AnonymousRedis);
            SetUpRedisClientConnection(Depends.RigOpsIP, "", 6380);
        }

        [Given(@"I have a key ""(.*)"" and ttl of ""(.*)"" milliseconds")]
        public void GivenIHaveAKeyAndTtlOfMilliseconds(string key, int ttl) => GenerateResourceAndDataObject(key, ttl);

        private void GenerateResourceAndDataObject(string myKey, int ttl)
        {
            var hostName = _scenarioContext.Get<string>("hostName");
            var password = _scenarioContext.Get<string>("password");
            var port = _scenarioContext.Get<int>("port");
            var redisImpl = GetRedisCacheImpl(hostName, password, port);

            GenResourceAndDataobject(myKey, hostName, password, port, out Mock<IResourceCatalog> mockResourceCatalog, out Mock<IDSFDataObject> mockDataobject, out ExecutionEnvironment environment);

            var assignActivity = new DsfMultiAssignActivity();
            var redisActivityNew = GetRedisActivity(mockResourceCatalog.Object, myKey, ttl, hostName, redisImpl, assignActivity);

            _scenarioContext.Add(nameof(RedisActivity), redisActivityNew);
            _scenarioContext.Add(nameof(RedisCacheImpl), redisImpl);
            _scenarioContext.Add(nameof(ttl), ttl);

            Assert.IsNotNull(redisActivityNew.Key);
        }

        [Given(@"I have a key ""(.*)"" with GUID and ttl of ""(.*)"" milliseconds")]
        public void GivenIHaveAKeyWithGUIDAndTtlOfMilliseconds(string key, int ttl)
        {
            var myNewKey = key + Guid.NewGuid();
            GenerateResourceAndDataObject(myNewKey, ttl);
            _scenarioContext.Add("key", myNewKey);
        }

        [Given(@"No data in the cache")]
        public void GivenNoDataInTheCache()
        {
            var redisActivityOld = _scenarioContext.Get<SpecRedisActivity>(nameof(RedisActivity));
            var impl = _scenarioContext.Get<RedisCacheImpl>(nameof(RedisCacheImpl));
            var ttl = _scenarioContext.Get<int>("ttl");

            var environment = new ExecutionEnvironment();

            var key = environment.EvalToExpression(redisActivityOld.Key, 0);

            do
            {
                Thread.Sleep(1000);
            } while (Stoptime.ElapsedMilliseconds < ttl);

            var actualCachedData = GetCachedData(impl, key);
            Assert.IsNull(actualCachedData);
        }

        [Given(@"an assign ""(.*)"" as")]
        [Then(@"an assign ""(.*)"" as")]
        public void GivenAnAssignAs(string data, Table table)
        {
            var redisActivity = _scenarioContext.Get<SpecRedisActivity>(nameof(RedisActivity));

            var assignActivity = GetDsfMultiAssignActivity("[[Var1]]", "Test1");

            redisActivity.ActivityFunc = new ActivityFunc<string, bool> { Handler = assignActivity };

            var assignOutputs = assignActivity.GetForEachOutputs();

            GetExpectedTableData(table, 0, out string expectedKey, out string expectedValue);

            Assert.AreEqual(expectedKey, assignOutputs[0].Value);
            Assert.IsTrue(expectedValue.Contains(assignOutputs[0].Name));

            var dic = new Dictionary<string, string> { { assignOutputs[0].Value, assignOutputs[0].Name } };

            _scenarioContext.Remove(nameof(RedisActivity));
            _scenarioContext.Add(nameof(RedisActivity), redisActivity);
            _scenarioContext.Add(data, dic);
            _scenarioContext.Add(nameof(DsfMultiAssignActivity), assignActivity);

        }

        [Then(@"I execute the cache tool")]
        [When(@"I execute the cache tool")]
        public void WhenIExecuteThecacheTool()
        {
            var redisActivityOld = _scenarioContext.Get<SpecRedisActivity>(nameof(RedisActivity));
            var dataToStore = _scenarioContext.Get<Dictionary<string, string>>("dataToStore");
            var assignActivity = _scenarioContext.Get<DsfMultiAssignActivity>(nameof(DsfMultiAssignActivity));
            var hostName = _scenarioContext.Get<string>("hostName");
            var password = _scenarioContext.Get<string>("password");
            var port = _scenarioContext.Get<int>("port");
            var impl = _scenarioContext.Get<RedisCacheImpl>(nameof(RedisCacheImpl));

            GenResourceAndDataobject(redisActivityOld.Key, hostName, password, port, out Mock<IResourceCatalog> mockResourceCatalog, out Mock<IDSFDataObject> mockDataobject, out ExecutionEnvironment environment);

            ExecuteCacheTool(redisActivityOld, mockDataobject);
        }

        [Then(@"the cache will contain")]
        public void ThenTheCacheWillContain(Table table)
        {
            var redisActivity = _scenarioContext.Get<SpecRedisActivity>(nameof(RedisActivity));
            var impl = _scenarioContext.Get<RedisCacheImpl>(nameof(RedisCacheImpl));

            var actualCacheData = GetCachedData(impl, redisActivity.Key);

            GetExpectedTableData(table, 0, out string expectedKey, out string expectedValue);

            Assert.IsTrue(expectedValue.Contains(actualCacheData.Keys.ToList()[0]));
            Assert.IsTrue(expectedValue.Contains(actualCacheData.Values.ToList()[0]));

            _scenarioContext.Add(redisActivity.Key, actualCacheData);
        }

        [Then(@"output variables have the following values")]
        public void ThenOutputVariablesHaveTheFollowingValues(Table table)
        {
            var redisActivity = _scenarioContext.Get<RedisActivity>(nameof(RedisActivity));
            var impl = _scenarioContext.Get<RedisCacheImpl>(nameof(RedisCacheImpl));
            var actualCacheData = GetCachedData(impl, redisActivity.Key);

            GetExpectedTableData(table, 0, out string expectedKey, out string expectedValue);

            Assert.AreEqual(expected: expectedKey, actual: actualCacheData.Keys.ToArray()[0]);
            Assert.IsTrue(expectedValue.Contains(actualCacheData.Values.ToArray()[0]));

        }

        void SetUpRedisClientConnection(string hostName, string password, int port)
        {
            _scenarioContext.Add("hostName", hostName);
            _scenarioContext.Add("password", password);
            _scenarioContext.Add("port", port);
        }

        [Given(@"data exists \(TTL not hit\) for key ""(.*)"" with GUID as")]
        public void GivenDataExistsTTLNotHitForKeyWithGUIDAs(string key, Table table)
        {
            var myKey = _scenarioContext.Get<string>("key");
            if (!string.IsNullOrEmpty(myKey))
            {
                GetExpectedTableData(table, 0, out string expectedKey, out string expectedValue);
                if (expectedKey == key)
                {
                    expectedKey = myKey;
                }
                VerifyKey(myKey, expectedKey, expectedValue);
            }
            else
            {
                GetExpectedTableData(table, 0, out string expectedKey, out string expectedValue);
                VerifyKey(key, expectedKey, expectedValue);
            }
        }


        [Given(@"data exists \(TTL not hit\) for key ""(.*)"" as")]
        public void GivenDataExistsTTLNotHitForKeyAs(string key, Table table)
        {
            GetExpectedTableData(table, 0, out string expectedKey, out string expectedValue);
            VerifyKey(key, expectedKey, expectedValue);
        }

        void VerifyKey(string myKey, string expectedKey, string expectedValue)
        {
            var hostName = _scenarioContext.Get<string>("hostName");
            var password = _scenarioContext.Get<string>("password");
            var port = _scenarioContext.Get<int>("port");
            var ttl = _scenarioContext.Get<int>("ttl");
            var redisImpl = GetRedisCacheImpl(hostName, password, port);

            GenResourceAndDataobject(myKey, hostName, password, port, out Mock<IResourceCatalog> mockResourceCatalog, out Mock<IDSFDataObject> mockDataobject, out ExecutionEnvironment environment);

            var dataStored = new Dictionary<string, string> { { "[[Var1]]", "Data in cache" } };

            var assignActivity = GetDsfMultiAssignActivity(dataStored.Keys.ToArray()[0], dataStored.Values.ToArray()[0]);

            var redisActivityNew = GetRedisActivity(mockResourceCatalog.Object, myKey, ttl, hostName, redisImpl, assignActivity);

            ExecuteCacheTool(redisActivityNew, mockDataobject);

            var sdfsf = redisActivityNew.SpecPerformExecution(dataStored);

            var actualDataStored = GetCachedData(redisImpl, myKey);


            Assert.AreEqual(expectedKey, myKey);
            Assert.IsTrue(expectedValue.Contains(actualDataStored.Keys.ToArray()[0]), $"Actual key {actualDataStored.Keys.ToArray()[0]} is not in expected {expectedValue}");
            Assert.IsTrue(expectedValue.Contains(actualDataStored.Values.ToArray()[0]), $"Actual value {actualDataStored.Values.ToArray()[0]} is not in expected {expectedValue}");

            _scenarioContext.Add(redisActivityNew.Key, actualDataStored);
            _scenarioContext.Remove(nameof(RedisActivity));
            _scenarioContext.Add(nameof(RedisActivity), redisActivityNew);
        }

        [Then(@"the assign ""(.*)"" is not executed")]
        public void ThenTheAssignIsNotExecuted(string key)
        {
            var dataToStore = _scenarioContext.Get<IDictionary<string, string>>(key);

            Assert.IsNotNull(dataToStore);
        }

        [Given(@"data does not exist \(TTL exceeded\) for key ""(.*)"" as")]
        public void GivenDataDoesNotExistTTLExceededForKeyAs(string key, Table table)
        {
            var ttl = _scenarioContext.Get<int>("ttl");

            var impl = _scenarioContext.Get<RedisCacheImpl>(nameof(RedisCacheImpl));

            do
            {
                Thread.Sleep(1000);
            } while (Stoptime.ElapsedMilliseconds < ttl);

            var guidKey = _scenarioContext.Get<string>("key");
            if (!string.IsNullOrEmpty(guidKey))
            {
                key = guidKey;
            }
            var actualCachedData = GetCachedData(impl, key);

            Assert.AreEqual(0, table.RowCount);
            Assert.IsNull(actualCachedData, $"Key=Value exists: {actualCachedData?.Keys?.FirstOrDefault()}={actualCachedData?.Values?.FirstOrDefault()}");
        }

        [Then(@"the assign ""(.*)"" is executed")]
        public void ThenTheAssignIsExecuted(string dataToStoreKey)
        {
            var dataToStore = _scenarioContext.Get<Dictionary<string, string>>(dataToStoreKey);
            var redisActivity = _scenarioContext.Get<SpecRedisActivity>(nameof(RedisActivity));

            var executioResult = redisActivity.SpecPerformExecution(dataToStore);

            Assert.AreEqual("Success", executioResult[0]);
        }


        private static void ExecuteCacheTool(SpecRedisActivity redisActivity, Mock<IDSFDataObject> mockDataobject)
        {
            redisActivity.SpecExecuteTool(mockDataobject.Object);
        }

        private RedisCacheImpl GetRedisCacheImpl(string hostName, string password, int port)
        {
            return new RedisCacheImpl(hostName: hostName, password: password, port: port);
        }

        private DsfMultiAssignActivity GetDsfMultiAssignActivity(string fieldName, string fieldValue)
        {
            return new DsfMultiAssignActivity() { FieldsCollection = new List<ActivityDTO> { new ActivityDTO(fieldName, fieldValue, 1) } };
        }

        static void GetExpectedTableData(Table table, int rowNumber, out string expectedKey, out string expectedValue)
        {
            var expectedRow = table.Rows[rowNumber].Values.ToList();

            expectedKey = expectedRow[0];
            expectedValue = expectedRow[1];
        }

        private IDictionary<string, string> GetCachedData(RedisCacheImpl impl, string key)
        {
            var actualCacheData = impl.Get(key);

            if (actualCacheData != null)
            {
                var serializer = new Dev2JsonSerializer();
                return serializer.Deserialize<IDictionary<string, string>>(actualCacheData);
            }
            return null;
        }

        private static void GenResourceAndDataobject(string key, string hostName, string password, int port, out Mock<IResourceCatalog> mockResourceCatalog, out Mock<IDSFDataObject> mockDataobject, out ExecutionEnvironment environment)
        {
            mockResourceCatalog = new Mock<IResourceCatalog>();
            mockDataobject = new Mock<IDSFDataObject>();
            var redisSource = new Dev2.Data.ServiceModel.RedisSource { HostName = hostName, Password = password, Port = port.ToString() };
            mockResourceCatalog.Setup(o => o.GetResource<Dev2.Data.ServiceModel.RedisSource>(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(redisSource);

            environment = new ExecutionEnvironment();
            environment.Assign(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>());
            environment.EvalToExpression(key, 0);

            mockDataobject.Setup(o => o.IsDebugMode()).Returns(true);
            mockDataobject.Setup(o => o.Environment).Returns(environment);
        }

        private static SpecRedisActivity GetRedisActivity(IResourceCatalog resourceCatalog, string key, int ttl, string hostName, RedisCacheImpl impl, DsfMultiAssignActivity assignActivity)
        {
            Stoptime = Stopwatch.StartNew();
            return new SpecRedisActivity(resourceCatalog, impl)
            {
                Key = key,
                ActivityFunc = new ActivityFunc<string, bool> { Handler = assignActivity },
                TTL = ttl,
                RedisSource = new Dev2.Data.ServiceModel.RedisSource { HostName = hostName },
            };
        }

        [AfterScenario(@"RedisCache")]
        public void Cleanup()
        {

            _scenarioContext.Remove("hostName");
            _scenarioContext.Remove("password");
            _scenarioContext.Remove("port");

            _scenarioContext.Remove(nameof(RedisActivity));
            _scenarioContext.Remove(nameof(RedisCacheImpl));
            _scenarioContext.Remove("ttl");

            _scenarioContext.Remove(nameof(RedisActivity));
            _scenarioContext.Remove("dataToStore");
            _scenarioContext.Remove(nameof(DsfMultiAssignActivity));
        }

    }
}