/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Enums;
using Dev2.Communication;
using Dev2.Runtime.ESB.Management.Services;
using Dev2.Workspaces;
using NUnit.Framework;
using Moq;

namespace Dev2.Tests.Runtime.Services
{
    [TestFixture]
    public class DeleteLogTests
    {
        readonly static object MonitorLock = new object();
        readonly static object SyncRoot = new object();

        #region TestInitialize/Cleanup

        [SetUp]
        public void MyTestInitialize()
        {
            Monitor.Enter(MonitorLock);
        }

        [TearDown]
        public void MyTestCleanup()
        {
            Monitor.Exit(MonitorLock);
        }

        #endregion

        ExecuteMessage ConvertToMsg(StringBuilder msg)
        {
            var serialier = new Dev2JsonSerializer();
            var result = serialier.Deserialize<ExecuteMessage>(msg);
            return result;
        }

        #region Execute

        [Test]
        [Author("Hagashen Naidu")]
        [Category("GetResourceID")]
        public void GetResourceID_ShouldReturnEmptyGuid()
        {
            //------------Setup for test--------------------------
            var deleteLog = new DeleteLog();

            //------------Execute Test---------------------------
            var resId = deleteLog.GetResourceID(new Dictionary<string, StringBuilder>());
            //------------Assert Results-------------------------
            Assert.AreEqual(Guid.Empty, resId);
        }

        [Test]
        [Author("Hagashen Naidu")]
        [Category("GetResourceID")]
        public void GetAuthorizationContextForService_ShouldReturnContext()
        {
            //------------Setup for test--------------------------
            var deleteLog = new DeleteLog();

            //------------Execute Test---------------------------
            var resId = deleteLog.GetAuthorizationContextForService();
            //------------Assert Results-------------------------
            Assert.AreEqual(AuthorizationContext.Administrator, resId);
        }

        [Test]
        public void DeleteLogExecuteWithNullFilePathExpectedReturnsError()
        {
            var workspace = new Mock<IWorkspace>();

            var values = new Dictionary<string, StringBuilder> { { "ResourcePath", new StringBuilder() }, { "Directory", new StringBuilder("xyz") } };
            var esb = new DeleteLog();
            var result = esb.Execute(values, workspace.Object);
            var msg = ConvertToMsg(result);
            Assert.IsTrue(msg.Message.ToString().StartsWith("DeleteLog: Error"));
        }

        [Test]
        public void DeleteLogExecuteWithNullDirectoryExpectedReturnsError()
        {
            var workspace = new Mock<IWorkspace>();

            var values = new Dictionary<string, StringBuilder> { { "ResourcePath", new StringBuilder("abc") }, { "Directory", new StringBuilder() } };
            var esb = new DeleteLog();
            var result = esb.Execute(values, workspace.Object);
            var msg = ConvertToMsg(result);
            Assert.IsTrue(msg.Message.ToString().StartsWith("DeleteLog: Error"));
        }

        [Test]
        public void DeleteLogExecuteWithNonExistingDirectoryExpectedReturnsError()
        {
            var workspace = new Mock<IWorkspace>();

            var values = new Dictionary<string, StringBuilder> { { "ResourcePath", new StringBuilder("abc") }, { "Directory", new StringBuilder("xyz") } };
            var esb = new DeleteLog();
            var result = esb.Execute(values, workspace.Object);
            var msg = ConvertToMsg(result);
            Assert.IsTrue(msg.Message.ToString().StartsWith("DeleteLog: Error"));
        }

        [Test]
        public void DeleteLogExecuteWithNonExistingPathExpectedReturnsError()
        {
            var workspace = new Mock<IWorkspace>();

            var values = new Dictionary<string, StringBuilder> { { "ResourcePath", new StringBuilder(Guid.NewGuid().ToString()) }, { "Directory", new StringBuilder("C:") } };
            var esb = new DeleteLog();
            var result = esb.Execute(values, workspace.Object);
            var msg = ConvertToMsg(result);
            Assert.IsTrue(msg.Message.ToString().StartsWith("DeleteLog: Error"));
        }


        [Test]
        public void DeleteLogExecuteWithValidPathAndLockedExpectedReturnsError()
        {
            //Lock because of access to file system
            lock(SyncRoot)
            {
                var fileName = Guid.NewGuid().ToString() + "_Test.log";
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, fileName);
                File.WriteAllText(path, "hello test");

                Assert.IsTrue(File.Exists(path));

                var fs = File.OpenRead(path);

                try
                {
                    var workspace = new Mock<IWorkspace>();

                    var values = new Dictionary<string, StringBuilder> { { "ResourcePath", new StringBuilder(fileName) }, { "Directory", new StringBuilder(TestContext.CurrentContext.TestDirectory) } };
                    var esb = new DeleteLog();
                    var result = esb.Execute(values, workspace.Object);
                    var msg = ConvertToMsg(result);
                    Assert.IsTrue(msg.Message.ToString().StartsWith("DeleteLog: Error"));
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        #endregion

        #region HandlesType

        [Test]
        public void DeleteLogHandlesTypeExpectedReturnsDeleteLogService()
        {
            var esb = new DeleteLog();
            var result = esb.HandlesType();
            Assert.AreEqual("DeleteLogService", result);
        }

        #endregion

        #region CreateServiceEntry

        [Test]
        public void DeleteLogCreateServiceEntryExpectedReturnsDynamicService()
        {
            var esb = new DeleteLog();
            var result = esb.CreateServiceEntry();
            Assert.AreEqual(esb.HandlesType(), result.Name);
            Assert.AreEqual("<DataList><Directory ColumnIODirection=\"Input\"/><ResourcePath ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>", result.DataListSpecification.ToString());
            Assert.AreEqual(1, result.Actions.Count);

            var serviceAction = result.Actions[0];
            Assert.AreEqual(esb.HandlesType(), serviceAction.Name);
            Assert.AreEqual(enActionType.InvokeManagementDynamicService, serviceAction.ActionType);
            Assert.AreEqual(esb.HandlesType(), serviceAction.SourceMethod);
        }

        #endregion
    }
}
