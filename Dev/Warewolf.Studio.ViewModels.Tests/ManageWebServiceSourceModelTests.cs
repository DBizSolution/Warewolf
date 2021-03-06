﻿using System;

using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.ServerProxyLayer;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Warewolf.Studio.ViewModels.Tests
{
    [TestClass]
    public class ManageWebServiceSourceModelTests
    {
        #region Fields

        Mock<IStudioUpdateManager> _updateRepositoryMock;

        string _serverName;

        ManageWebServiceSourceModel _target;
        Mock<IQueryManager> _queryManager;

        #endregion Fields

        #region Test initialize

        [TestInitialize]
        public void TestInitialize()
        {
            _updateRepositoryMock = new Mock<IStudioUpdateManager>();
            _queryManager = new Mock<IQueryManager>();
            _serverName = Guid.NewGuid().ToString();
            _target = new ManageWebServiceSourceModel(_updateRepositoryMock.Object,_queryManager.Object, _serverName);
        }

        #endregion Test initialize

        #region Test methods

        [TestMethod,Timeout(60000)]
        public void TestTestConnection()
        {
            //arrange
            var resourceMock = new Mock<IWebServiceSource>();

            //act
            _target.TestConnection(resourceMock.Object);

            //assert
            _updateRepositoryMock.Verify(it => it.TestConnection(resourceMock.Object));
        }

        [TestMethod,Timeout(60000)]
        public void TestSave()
        {
            //arrange
            var resourceMock = new Mock<IWebServiceSource>();

            //act
            _target.Save(resourceMock.Object);

            //assert
            _updateRepositoryMock.Verify(it => it.Save(resourceMock.Object));
        }

        #endregion Test methods

        #region Test properties

        [TestMethod,Timeout(60000)]
        public void TestServerName()
        {
            //act
            var value = _target.ServerName;

            //assert
            Assert.AreEqual(_serverName, value);
        }

        [TestMethod,Timeout(60000)]
        public void TestWebServiceServerNameBrackets()
        {
            //arrange  
            _target = new ManageWebServiceSourceModel(_updateRepositoryMock.Object,_queryManager.Object, _serverName + "(sthInBrackets)");

            //act
            var value = _target.ServerName;

            //assert
            Assert.AreEqual(_serverName, value);
        }

        #endregion Test properties

    }
}