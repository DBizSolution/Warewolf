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
using Dev2.Studio.Core.Activities.Services;
using Dev2.Studio.Interfaces;
using Dev2.Util;
using NUnit.Framework;
using Moq;
using Warewolf.UnitTestAttributes;

namespace Dev2.Core.Tests.Activities.Services
{
    [TestFixture]
    public class DesignerManagementServiceTests
    {

        [SetUp]
        public void Initialize()
        {
            AppUsageStats.LocalHost = "http://localhost:3142";
        }

        [Test]
        [Category("DesignerManagementService_Constructor")]
        [Description("DesignerManagementService must throw null argument exception if root model is null.")]
        [Author("Trevor Williams-Ros")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DesignerManagementService_UnitTest_ConstructorWithNullRootModel_ThrowsArgumentNullException()
        {
            new DesignerManagementService(null, null);
        }

        [Test]
        [Category("DesignerManagementService_Constructor")]
        [Description("DesignerManagementService must throw null argument exception if resource repository is null.")]
        [Author("Trevor Williams-Ros")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DesignerManagementService_UnitTest_ConstructorWithNullResourceRepository_ThrowsArgumentNullException()
        {
            var rootModel = new Mock<IContextualResourceModel>();
            new DesignerManagementService(rootModel.Object, null);
        }


        [Test]
        [Category("DesignerManagementService_GetRootResourceModel")]
        [Description("DesignerManagementService GetRootResourceModel must return the same root model given to its constructor.")]
        [Author("Trevor Williams-Ros")]
        public void DesignerManagementService_UnitTest_GetResourceModel_SameAsConstructorInstance()
        {
            var resourceModel = Dev2MockFactory.SetupResourceModelMock();
            var resourceRepository = Dev2MockFactory.SetupFrameworkRepositoryResourceModelMock(resourceModel, new List<IResourceModel>());

            var designerManagementService = new DesignerManagementService(resourceModel.Object, resourceRepository.Object);

            var expected = resourceModel.Object;
            var actual = designerManagementService.GetRootResourceModel();

            Assert.AreEqual(expected, actual);
        }
    }
}
