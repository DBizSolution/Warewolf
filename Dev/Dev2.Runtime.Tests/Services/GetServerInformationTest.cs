﻿using System;
using System.Collections.Generic;
using System.Text;
using Dev2.Common.Interfaces.Enums;
using Dev2.Communication;
using Dev2.Runtime.ESB.Management.Services;
using NUnit.Framework;

namespace Dev2.Tests.Runtime.Services
{
    [TestFixture]
    public class GetServerInformationTest
    {
        [Test]
        [Author("Peter Bezuidenhout")]
        [Category("GetResourceID")]
        public void GetResourceID_ShouldReturnEmptyGuid()
        {
            //------------Setup for test--------------------------
            var serverInformation = new GetServerInformation();

            //------------Execute Test---------------------------
            var resId = serverInformation.GetResourceID(new Dictionary<string, StringBuilder>());
            //------------Assert Results-------------------------
            Assert.AreEqual(Guid.Empty, resId);
        }

        [Test]
        [Author("Peter Bezuidenhout")]
        [Category("GetResourceID")]
        public void GetAuthorizationContextForService_ShouldReturnContext()
        {
            //------------Setup for test--------------------------
            var serverInformation = new GetServerInformation();

            //------------Execute Test---------------------------
            var resId = serverInformation.GetAuthorizationContextForService();
            //------------Assert Results-------------------------
            Assert.AreEqual(AuthorizationContext.Any, resId);
        }

        [Test]
        [Author("Peter Bezuidenhout")]
        [Category("GetServerInformation_HandlesType")]
        
        public void GetServerInformation_HandlesType_ExpectName()

        {
            //------------Setup for test--------------------------
            var getInformation = new GetServerInformation();


            //------------Execute Test---------------------------

            //------------Assert Results-------------------------
            Assert.AreEqual("GetServerInformation", getInformation.HandlesType());
        }

        [Test]
        [Author("Peter Bezuidenhout")]
        [Category("GetServerInformation_Execute")]
        public void GetServerInformation_Execute_NullValuesParameter_ErrorResult()
        {
            //------------Setup for test--------------------------
            var getInformation = new GetServerInformation();
            var serializer = new Dev2JsonSerializer();
            //------------Execute Test---------------------------
            var jsonResult = getInformation.Execute(null, null);
            var result = serializer.Deserialize<Dictionary<string, string>>(jsonResult);
            //------------Assert Results-------------------------
            Assert.IsNotNull(result);
        }
    }
}


