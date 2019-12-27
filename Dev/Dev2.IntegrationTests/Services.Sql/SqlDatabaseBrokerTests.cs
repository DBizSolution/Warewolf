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
using System.Data.SqlClient;
using Dev2.Common.Interfaces.Core.Graph;
using Dev2.Common.Interfaces.Data;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Runtime.ServiceModel.Esb.Brokers;
using Dev2.Services.Sql;
using NUnit.Framework;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using Warewolf.Security.Encryption;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using Warewolf.Test.Agent;
using System.IO;
using Dev2.Infrastructure.Tests;

namespace Dev2.Integration.Tests.Services.Sql
{
    [TestFixture]
    public class SqlDatabaseBrokerTests
    {
        static Depends _containerOps;

        [OneTimeSetUp]
        public static void MyClassInitialize(TestContext testContext)
        {
            _containerOps = new Depends(Depends.ContainerType.MSSQL);
            if (_containerOps != null)
            {
                Thread.Sleep(10000);
            }
        }

        [OneTimeTearDown]
        public static void CleanupContainer() => _containerOps?.Dispose();

        [Test]
        [Author("Ashley Lewis")]
        public void SqlDatabaseBroker_GetServiceMethods_WindowsUserWithDbAccess_GetsMethods()
        {
            RunAs("IntegrationTester", "dev2", () =>
            {
                var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource(AuthenticationType.Windows, Depends.SVRDEVIP);
                var broker = new SqlDatabaseBroker();
                var result = broker.GetServiceMethods(dbSource);
                Assert.AreEqual(true, result.Count > 0);
            });
        }
        
        [Test]
        [Author("Ashley Lewis")]
        public void SqlDatabaseBroker_GetServiceMethods_WindowsUserWithoutDbAccess_ThrowsLoginFailedException()
        {
            RunAs("NoDBAccessTest", "DEV2", () =>
            {
                var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource(AuthenticationType.Windows);
                var broker = new SqlDatabaseBroker();
                try
                {
                    broker.GetServiceMethods(dbSource);
                    Assert.Fail();
                }
                catch(Exception ex)
                {
                    Assert.IsNotNull(ex);
                    Assert.IsInstanceOf(typeof(SqlException), ex);
                    Assert.AreEqual("Login failed for user 'DEV2\\NoDBAccessTest'.", ex.Message);
                }
            });
        }

        [Test]
        [Author("Ashley Lewis")]
        [ExpectedException(typeof(WarewolfDbException))]        
        public void SqlDatabaseBroker_GetServiceMethods_SqlUserWithInvalidUsername_ThrowsLoginFailedException()
        {
            var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource();
            dbSource.UserID = "Billy.Jane";
            dbSource.Password = "invalidPassword";

            var broker = new SqlDatabaseBroker();
            broker.GetServiceMethods(dbSource);
        }

        [Test]
        [Author("Ashley Lewis")]
        public void SqlDatabaseBroker_GetServiceMethods_SqlUserWithValidUsername_GetsMethods()
        {
            var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource();
            var broker = new SqlDatabaseBroker();
            var result = broker.GetServiceMethods(dbSource);
            Assert.AreEqual(true, result.Count > 0);
        }
        
        [Test]
        [Author("Massimo.Guerrera")]
        [Category("SqlDatabaseBroker")]
        public void SqlDatabaseBroker_TestService_WindowsUserWithDbAccess_ReturnsValidResult()
        {
            RunAs("IntegrationTester", "dev2", () =>
            {
                var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource(AuthenticationType.Windows, "172.27.14.50");
                var serviceConn = new DbService
                {
                    ResourceID = Guid.NewGuid(),
                    ResourceName = "DatabaseService",
                    ResourceType = "DbService",
                    AuthorRoles = "",
                    Dependencies = new List<IResourceForTree>(),
                    FilePath = null,
                    IsUpgraded = true,
                    Method = new ServiceMethod("dbo.fn_diagramobjects", "\r\n\tCREATE FUNCTION dbo.fn_diagramobjects() \r\n\tRETURNS int\r\n\tWITH EXECUTE AS N'dbo'\r\n\tAS\r\n\tBEGIN\r\n\t\tdeclare @id_upgraddiagrams\t\tint\r\n\t\tdeclare @id_sysdiagrams\t\t\tint\r\n\t\tdeclare @id_helpdiagrams\t\tint\r\n\t\tdeclare @id_helpdiagramdefinition\tint\r\n\t\tdeclare @id_creatediagram\tint\r\n\t\tdeclare @id_renamediagram\tint\r\n\t\tdeclare @id_alterdiagram \tint \r\n\t\tdeclare @id_dropdiagram\t\tint\r\n\t\tdeclare @InstalledObjects\tint\r\n\r\n\t\tselect @InstalledObjects = 0\r\n\r\n\t\tselect \t@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),\r\n\t\t\t@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),\r\n\t\t\t@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),\r\n\t\t\t@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),\r\n\t\t\t@id_creatediagram = object_id(N'dbo.sp_creatediagram'),\r\n\t\t\t@id_renamediagram = object_id(N'dbo.sp_renamediagram'),\r\n\t\t\t@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), \r\n\t\t\t@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')\r\n\r\n\t\tif @id_upgraddiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 1\r\n\t\tif @id_sysdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 2\r\n\t\tif @id_helpdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 4\r\n\t\tif @id_helpdiagramdefinition is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 8\r\n\t\tif @id_creatediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 16\r\n\t\tif @id_renamediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 32\r\n\t\tif @id_alterdiagram  is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 64\r\n\t\tif @id_dropdiagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 128\r\n\t\t\r\n\t\treturn @InstalledObjects \r\n\tEND\r\n\t", null, null, null, "dbo.fn_diagramobjects"),
                    Recordset = new Recordset(),
                    Source = dbSource
                };
                var broker = new SqlDatabaseBroker();
                var result = broker.TestService(serviceConn);
                Assert.AreEqual(OutputFormats.ShapedXML, result.Format);
            });
        }
        
        [Test]
        [Author("Massimo.Guerrera")]
        public void SqlDatabaseBroker_TestService_WindowsUserWithoutDbAccess_ReturnsInvalidResult()
        {
            Exception exception = null;
            RunAs("NoDBAccessTest", "DEV2", () =>
            {
                var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource(AuthenticationType.Windows);

                var serviceConn = new DbService
                {
                    ResourceID = Guid.NewGuid(),
                    ResourceName = "DatabaseService",
                    ResourceType = "DbService",
                    AuthorRoles = "",
                    Dependencies = new List<IResourceForTree>(),
                    FilePath = null,
                    IsUpgraded = true,
                    Method = new ServiceMethod("dbo.fn_diagramobjects", "\r\n\tCREATE FUNCTION dbo.fn_diagramobjects() \r\n\tRETURNS int\r\n\tWITH EXECUTE AS N'dbo'\r\n\tAS\r\n\tBEGIN\r\n\t\tdeclare @id_upgraddiagrams\t\tint\r\n\t\tdeclare @id_sysdiagrams\t\t\tint\r\n\t\tdeclare @id_helpdiagrams\t\tint\r\n\t\tdeclare @id_helpdiagramdefinition\tint\r\n\t\tdeclare @id_creatediagram\tint\r\n\t\tdeclare @id_renamediagram\tint\r\n\t\tdeclare @id_alterdiagram \tint \r\n\t\tdeclare @id_dropdiagram\t\tint\r\n\t\tdeclare @InstalledObjects\tint\r\n\r\n\t\tselect @InstalledObjects = 0\r\n\r\n\t\tselect \t@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),\r\n\t\t\t@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),\r\n\t\t\t@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),\r\n\t\t\t@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),\r\n\t\t\t@id_creatediagram = object_id(N'dbo.sp_creatediagram'),\r\n\t\t\t@id_renamediagram = object_id(N'dbo.sp_renamediagram'),\r\n\t\t\t@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), \r\n\t\t\t@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')\r\n\r\n\t\tif @id_upgraddiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 1\r\n\t\tif @id_sysdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 2\r\n\t\tif @id_helpdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 4\r\n\t\tif @id_helpdiagramdefinition is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 8\r\n\t\tif @id_creatediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 16\r\n\t\tif @id_renamediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 32\r\n\t\tif @id_alterdiagram  is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 64\r\n\t\tif @id_dropdiagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 128\r\n\t\t\r\n\t\treturn @InstalledObjects \r\n\tEND\r\n\t", null, null, null, null),
                    Recordset = new Recordset(),
                    Source = dbSource
                };
                var broker = new SqlDatabaseBroker();
                try
                {
                    broker.TestService(serviceConn);
                }
                catch(Exception ex)
                {
                    // Need to do this because exceptions get swallowed by impersonator
                    exception = ex;
                }

                Assert.IsNotNull(exception);
                Assert.IsInstanceOf(typeof(SqlException), exception);
                Assert.AreEqual("Login failed for user 'DEV2\\NoDBAccessTest'.", exception.Message);
            });
        }

        [Test]
        [Author("Massimo.Guerrera")]
        [ExpectedException(typeof(WarewolfDbException))]        
        public void SqlDatabaseBroker_TestService_SqlUserWithInvalidUsername_ReturnsInvalidResult()

        {
            var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource();
            dbSource.UserID = "Billy.Jane";
            dbSource.Password = "invalidPassword";

            var serviceConn = new DbService
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "DatabaseService",
                ResourceType = "DbService",
                AuthorRoles = "",
                Dependencies = new List<IResourceForTree>(),
                FilePath = null,
                IsUpgraded = true,
                Method = new ServiceMethod("dbo.fn_diagramobjects", "\r\n\tCREATE FUNCTION dbo.fn_diagramobjects() \r\n\tRETURNS int\r\n\tWITH EXECUTE AS N'dbo'\r\n\tAS\r\n\tBEGIN\r\n\t\tdeclare @id_upgraddiagrams\t\tint\r\n\t\tdeclare @id_sysdiagrams\t\t\tint\r\n\t\tdeclare @id_helpdiagrams\t\tint\r\n\t\tdeclare @id_helpdiagramdefinition\tint\r\n\t\tdeclare @id_creatediagram\tint\r\n\t\tdeclare @id_renamediagram\tint\r\n\t\tdeclare @id_alterdiagram \tint \r\n\t\tdeclare @id_dropdiagram\t\tint\r\n\t\tdeclare @InstalledObjects\tint\r\n\r\n\t\tselect @InstalledObjects = 0\r\n\r\n\t\tselect \t@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),\r\n\t\t\t@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),\r\n\t\t\t@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),\r\n\t\t\t@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),\r\n\t\t\t@id_creatediagram = object_id(N'dbo.sp_creatediagram'),\r\n\t\t\t@id_renamediagram = object_id(N'dbo.sp_renamediagram'),\r\n\t\t\t@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), \r\n\t\t\t@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')\r\n\r\n\t\tif @id_upgraddiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 1\r\n\t\tif @id_sysdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 2\r\n\t\tif @id_helpdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 4\r\n\t\tif @id_helpdiagramdefinition is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 8\r\n\t\tif @id_creatediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 16\r\n\t\tif @id_renamediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 32\r\n\t\tif @id_alterdiagram  is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 64\r\n\t\tif @id_dropdiagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 128\r\n\t\t\r\n\t\treturn @InstalledObjects \r\n\tEND\r\n\t", null, null, null, null),
                Recordset = new Recordset(),
                Source = dbSource
            };
            var broker = new SqlDatabaseBroker();
            broker.TestService(serviceConn);
        }

        [Test]
        [Author("Massimo.Guerrera")]
        [Category("SqlDatabaseBroker")]
        public void SqlDatabaseBroker_TestService_SqlUserWithValidUsername_ReturnsValidResult()
        {
            var dbSource = SqlServerTestUtils.CreateDev2TestingDbSource();
            var serviceConn = new DbService
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "DatabaseService",
                ResourceType = "DbService",
                AuthorRoles = "",
                Dependencies = new List<IResourceForTree>(),
                FilePath = null,
                IsUpgraded = true,
                Method = new ServiceMethod("dbo.fn_diagramobjects", "\r\n\tCREATE FUNCTION dbo.fn_diagramobjects() \r\n\tRETURNS int\r\n\tAS\r\n\tBEGIN\r\n\t\tdeclare @id_upgraddiagrams\t\tint\r\n\t\tdeclare @id_sysdiagrams\t\t\tint\r\n\t\tdeclare @id_helpdiagrams\t\tint\r\n\t\tdeclare @id_helpdiagramdefinition\tint\r\n\t\tdeclare @id_creatediagram\tint\r\n\t\tdeclare @id_renamediagram\tint\r\n\t\tdeclare @id_alterdiagram \tint \r\n\t\tdeclare @id_dropdiagram\t\tint\r\n\t\tdeclare @InstalledObjects\tint\r\n\r\n\t\tselect @InstalledObjects = 0\r\n\r\n\t\tselect \t@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),\r\n\t\t\t@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),\r\n\t\t\t@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),\r\n\t\t\t@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),\r\n\t\t\t@id_creatediagram = object_id(N'dbo.sp_creatediagram'),\r\n\t\t\t@id_renamediagram = object_id(N'dbo.sp_renamediagram'),\r\n\t\t\t@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), \r\n\t\t\t@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')\r\n\r\n\t\tif @id_upgraddiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 1\r\n\t\tif @id_sysdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 2\r\n\t\tif @id_helpdiagrams is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 4\r\n\t\tif @id_helpdiagramdefinition is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 8\r\n\t\tif @id_creatediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 16\r\n\t\tif @id_renamediagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 32\r\n\t\tif @id_alterdiagram  is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 64\r\n\t\tif @id_dropdiagram is not null\r\n\t\t\tselect @InstalledObjects = @InstalledObjects + 128\r\n\t\t\r\n\t\treturn @InstalledObjects \r\n\tEND\r\n\t", null, null, null, "dbo.fn_diagramobjects"),
                Recordset = new Recordset(),
                Source = dbSource
            };
            var broker = new SqlDatabaseBroker();
            var result = broker.TestService(serviceConn);
            Assert.AreEqual(OutputFormats.ShapedXML, result.Format);
        }

        [Test]
        [Author("Hagashen Naidu")]
        public void SqlDatabaseBroker_TestService_ValidDbServiceThatReturnsNull_RecordsetWithNullColumn()
        {
            var service = new DbService
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "NullService",
                ResourceType = "DbService",
                Method = new ServiceMethod
                {
                    Name = "Pr_GeneralTestColumnData",
                    Parameters = new List<MethodParameter>(),
                    ExecuteAction = "Pr_GeneralTestColumnData"
                },
                Recordset = new Recordset
                {
                    Name = "Collections",
                },
                Source = SqlServerTestUtils.CreateDev2TestingDbSource()
            };

            var broker = new SqlDatabaseBroker();
            var outputDescription = broker.TestService(service);
            Assert.AreEqual(1, outputDescription.DataSourceShapes.Count);
            var dataSourceShape = outputDescription.DataSourceShapes[0];
            Assert.IsNotNull(dataSourceShape);
            Assert.AreEqual(3, dataSourceShape.Paths.Count);
            StringAssert.Contains(dataSourceShape.Paths[2].DisplayPath, "TestTextNull"); //This is the field that contains a null value. Previously this column would not have been returned.
        }

        public static bool RunAs(string userName, string domain, Action action)
        {
            var result = false;
            using (var impersonator = new Impersonator())
            {
                if (impersonator.Impersonate(userName, domain))
                {
                    action?.Invoke();
                    result = true;
                }
            }

            return result;
        }

        public interface IImpersonator
        {
            bool Impersonate(string userName, string domain);
            void Undo();
            bool ImpersonateForceDecrypt(string userName, string domain, string decryptIfEncrypted);
        }

        public class Impersonator : IDisposable, IImpersonator
        {
            const int LOGON32_PROVIDER_DEFAULT = 0;
            const int LOGON32_LOGON_INTERACTIVE = 2;

            #region DllImports

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, out IntPtr hNewToken);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool RevertToSelf();

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool CloseHandle(IntPtr handle);

            #endregion

            WindowsImpersonationContext _impersonationContext;

            #region Impersonate

            public bool Impersonate(string username, string domain)
            {
                var token = IntPtr.Zero;
                var tokenDuplicate = IntPtr.Zero;
                var password = TestEnvironmentVariables.GetVar(domain + "\\" + username);
                if (RevertToSelf() && LogonUser(username, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out token) && DuplicateToken(token, 2, out tokenDuplicate) != 0)
                {
                    var tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                    _impersonationContext = tempWindowsIdentity.Impersonate();
                    if (_impersonationContext != null)
                    {
                        ClaimsPrincipal principal = new WindowsPrincipal(tempWindowsIdentity);
                        Thread.CurrentPrincipal = principal;
                        CloseHandle(token);
                        CloseHandle(tokenDuplicate);
                        return true;
                    }
                }
                if (token != IntPtr.Zero)
                {
                    CloseHandle(token);
                }
                if (tokenDuplicate != IntPtr.Zero)
                {
                    CloseHandle(tokenDuplicate);
                }
                return false;
            }

            #endregion

            #region Undo

            public void Undo()
            {
                if (_impersonationContext != null)
                {
                    _impersonationContext.Undo();
                    _impersonationContext.Dispose();
                }
            }

            public bool ImpersonateForceDecrypt(string userName, string domain, string decryptIfEncrypted)
            {
                return Impersonate(userName, domain);
            }

            #endregion

            #region IDisposable

            ~Impersonator()
            {
                Dispose(false);
            }

            bool _disposed;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        Undo();
                    }

                    _disposed = true;
                }
            }

            #endregion
        }
    }
}
