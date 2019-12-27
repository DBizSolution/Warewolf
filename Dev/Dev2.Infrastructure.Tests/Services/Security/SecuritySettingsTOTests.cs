/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Collections.Generic;
using Dev2.Services.Security;
using NUnit.Framework;

namespace Dev2.Infrastructure.Tests.Services.Security
{
    /// <summary>
    /// Summary description for SecuritySettingsTOTests
    /// </summary>
    [TestFixture]
    public class SecuritySettingsTOTests
    {
        [Test]
        [Author("Massimo Guerrera")]
        [Category("SecuritySettingsTO_Contructor")]
        public void SecuritySettingsTO_Contructor_CallBasicCtor_WindowsGroupPermissionsEmpty()
        {
            //------------Execute Test---------------------------
            var securitySettingsTO = new SecuritySettingsTO();
            //------------Assert Results-------------------------
            Assert.IsNotNull(securitySettingsTO.WindowsGroupPermissions);
            Assert.AreEqual(0, securitySettingsTO.WindowsGroupPermissions.Count);
        }

        [Test]
        [Author("Massimo Guerrera")]
        [Category("SecuritySettingsTO_Contructor")]
        public void SecuritySettingsTO_Contructor_CallOverloadedCtor_WindowsGroupPermissionsEmpty()
        {
            //------------Setup for test--------------------------
            var permissions = new List<WindowsGroupPermission>();
            permissions.Add(new WindowsGroupPermission());
            permissions.Add(new WindowsGroupPermission());
            //------------Execute Test---------------------------
            var securitySettingsTO = new SecuritySettingsTO(permissions);
            //------------Assert Results-------------------------
            Assert.IsNotNull(securitySettingsTO.WindowsGroupPermissions);
            Assert.AreEqual(2, securitySettingsTO.WindowsGroupPermissions.Count);
        }
    }
}
