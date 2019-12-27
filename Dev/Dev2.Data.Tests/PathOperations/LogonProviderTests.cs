﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Data.PathOperations;
using Dev2.Infrastructure.Tests;
using Dev2.PathOperations;
using NUnit.Framework;
using Moq;
using System;
using System.IO;
using Warewolf.Resource.Errors;

namespace Dev2.Data.Tests.PathOperations
{
    [TestFixture]
    public class LogonProviderTests
    {
        [Test]
        [Author("Rory McGuire")]
        [Category("LogonProvider")]
        public void LogonProvider_Construct()
        {
            var provider = new LogonProvider();

            var ioPath = new Dev2ActivityIOPath(Interfaces.Enums.enActivityIOPathType.FileSystem, @"C:\", @".\LocalSchedulerAdmin", "987Sched#@!", false, null);
            provider.DoLogon(ioPath);
        }

        [Test]
        [Author("Rory McGuire")]
        [Category("LogonProvider")]
        public void LogonProvider_DoLogon_LogonInteractive()
        {
            bool loginReturnStatus = true;

            var mockLoginImpl = new Mock<ILoginApi>();

            var provider = new LogonProvider(mockLoginImpl.Object);

            var username = @"dev2\IntegrationTester";
            var password = TestEnvironmentVariables.GetVar(username);

            var v = It.IsAny<SafeTokenHandle>();
            mockLoginImpl.Setup(o => o.LogonUser("IntegrationTester", "dev2", password, 2, 0, out v))
                .Returns(loginReturnStatus);


            var ioPath = new Dev2ActivityIOPath(Interfaces.Enums.enActivityIOPathType.FileSystem, @"C:\", username, password, false, null);
            provider.DoLogon(ioPath);

            mockLoginImpl.Verify(o => o.LogonUser("IntegrationTester", "dev2", password, 2, 0, out v), Times.Once);
        }

        [Test]
        [Author("Rory McGuire")]
        [Category("LogonProvider")]
        public void LogonProvider_DoLogon_LogonNetwork()
        {
            bool loginReturnStatus = true;

            var mockLoginImpl = new Mock<ILoginApi>();

            var provider = new LogonProvider(mockLoginImpl.Object);

            var username = @"dev2\IntegrationTester";
            var password = TestEnvironmentVariables.GetVar(username);

            var v = It.IsAny<SafeTokenHandle>();
            mockLoginImpl.Setup(o => o.LogonUser("IntegrationTester", "dev2", password, 3, 3, out v))
                .Returns(loginReturnStatus);


            var ioPath = new Dev2ActivityIOPath(Interfaces.Enums.enActivityIOPathType.FileSystem, @"C:\", username, password, false, null);
            provider.DoLogon(ioPath);

            mockLoginImpl.Verify(o => o.LogonUser("IntegrationTester", "dev2", password, 3, 3, out v), Times.Once);
        }

        [Test]
        [Author("Rory McGuire")]
        [Category("LogonProvider")]
        public void LogonProvider_DoLogon_ErrorThrowsMessage()
        {
            var mockLoginImpl = new Mock<ILoginApi>();

            var provider = new LogonProvider(mockLoginImpl.Object);

            var username = @"dev2\IntegrationTester";
            var password = TestEnvironmentVariables.GetVar(username);

            var v = It.IsAny<SafeTokenHandle>();
            mockLoginImpl.Setup(o => o.LogonUser("IntegrationTester", "DEV2", password, 3, 3, out v))
                .Throws(new Exception("some exception"));


            var ioPath = new Dev2ActivityIOPath(Interfaces.Enums.enActivityIOPathType.FileSystem, @"C:\", @"DEV2\IntegrationTester", password, false, null);
            var expectedMessage = string.Format(ErrorResource.FailedToAuthenticateUser, "IntegrationTester", ioPath.Path);

            var hadException = false;
            try
            {
                provider.DoLogon(ioPath);
            }
            catch (Exception e)
            {
                hadException = true;
                NUnit.Framework.Assert.AreEqual(expectedMessage, e.Message);
            }
            NUnit.Framework.Assert.IsTrue(hadException, "expected exception");

            mockLoginImpl.Verify(o => o.LogonUser("IntegrationTester", "DEV2", password, 3, 3, out v), Times.Once);
        }
    }
}
