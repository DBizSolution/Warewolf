﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using Dev2.Common.Interfaces.Wrappers;
using Dev2.Data.Interfaces;
using Dev2.Data.PathOperations;
using Dev2.Data.PathOperations.Operations;
using NUnit.Framework;
using Moq;

namespace Dev2.Data.Tests.PathOperations
{
    [TestFixture]
    public class DoGetActionTests
    {
        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(DoGetAction))]
        public void DoGetAction_ExecuteOperation__ImpersonatedUser_IsNull_ExpectException()
        {
            //------------------------Arrange--------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();

            var doGetAction = new DoGetAction(mockActivityIOPath.Object);
            //------------------------Act------------------------------
            //------------------------Assert---------------------------
            NUnit.Framework.Assert.Throws<Exception>(()=> doGetAction.ExecuteOperation());
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(DoGetAction))]
        public void DoGetAction_ExecuteOperation__ImpersonatedUser_IsNotNull_IsTrue_ExpectTrue()
        {
            //------------------------Arrange--------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockDev2LogonProvider = new Mock<IDev2LogonProvider>();
            var mockFileWrapper = new Mock<IFile>();
            var mockWindowsImpersonationContext = new Mock<IWindowsImpersonationContext>();

            var doGetAction = new DoGetAction(mockActivityIOPath.Object, mockDev2LogonProvider.Object, mockFileWrapper.Object, (arg1, arg2)=> mockWindowsImpersonationContext.Object);
            //------------------------Act------------------------------
            var executeOperation = doGetAction.ExecuteOperation();
            //------------------------Assert---------------------------
            NUnit.Framework.Assert.IsTrue(executeOperation.CanRead);
            NUnit.Framework.Assert.IsTrue(executeOperation.CanSeek);
            NUnit.Framework.Assert.IsFalse(executeOperation.CanTimeout);
            NUnit.Framework.Assert.IsTrue(executeOperation.CanWrite);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(DoGetAction))]
        public void DoGetAction_ExecuteOperation__ImpersonatedUser_IsNull_ExpectTrue()
        {
            //------------------------Arrange--------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockDev2LogonProvider = new Mock<IDev2LogonProvider>();
            var mockFileWrapper = new Mock<IFile>();

            mockFileWrapper.Setup(o => o.Exists(It.IsAny<string>())).Returns(true);

            var doGetAction = new DoGetAction(mockActivityIOPath.Object, mockDev2LogonProvider.Object, mockFileWrapper.Object, (arg1, arg2) => null);
            //------------------------Act------------------------------
            var executeOperation = doGetAction.ExecuteOperation();
            //------------------------Assert---------------------------
            mockFileWrapper.VerifyAll();
            NUnit.Framework.Assert.IsTrue(executeOperation.CanRead);
            NUnit.Framework.Assert.IsTrue(executeOperation.CanSeek);
            NUnit.Framework.Assert.IsFalse(executeOperation.CanTimeout);
            NUnit.Framework.Assert.IsTrue(executeOperation.CanWrite);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(DoGetAction))]
        public void DoGetAction_ExecuteOperation__ImpersonatedUser_IsNotNull_Catch_ExpectTrue()
        {
            //------------------------Arrange--------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockDev2LogonProvider = new Mock<IDev2LogonProvider>();
            var mockFileWrapper = new Mock<IFile>();
            var mockWindowsImpersonationContext = new Mock<IWindowsImpersonationContext>();

            mockActivityIOPath.Setup(o => o.Path).Throws<Exception>();

            var doGetAction = new DoGetAction(mockActivityIOPath.Object, mockDev2LogonProvider.Object, mockFileWrapper.Object, (arg1, arg2) => mockWindowsImpersonationContext.Object);
            //------------------------Act------------------------------
            //------------------------Assert---------------------------
            NUnit.Framework.Assert.Throws<Exception>(()=> doGetAction.ExecuteOperation());
        }
    }
}
