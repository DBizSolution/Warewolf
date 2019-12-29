﻿using System;
using System.Collections.Generic;
using System.Windows.Media;

using Dev2.Common.Interfaces.Help;

using NUnit.Framework;
using Moq;
using Warewolf.UnitTestAttributes;

namespace Warewolf.Studio.ViewModels.Help.Tests
{
    [TestFixture]
    public class HelpDescriptorViewModelTests
    {
        #region Fields

        Mock<IHelpDescriptor> _descriptorMock;

        List<string> _changedProperties;

        HelpDescriptorViewModel _target;

        #endregion Fields

        #region Test initialize

        [SetUp]
        public void TestInitialize()
        {
            _descriptorMock = new Mock<IHelpDescriptor>();
            _target = new HelpDescriptorViewModel(_descriptorMock.Object);
            _changedProperties = new List<string>();
            _target.PropertyChanged += _target_PropertyChanged;
        }

        #endregion Test initialize

        #region Test construction

        [Test]
        [Timeout(60000)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHelpDescriptorViewModel()
        {
            new HelpDescriptorViewModel(null);
        }

        #endregion Test construction

        #region Test properties

        [Test]
        [Timeout(60000)]
        public void TestName()
        {
            //arrange
            var nameText = "someName";
            _descriptorMock.SetupGet(it => it.Name).Returns(nameText);

            //act
            var value = _target.Name;

            //assert
            Assert.AreEqual(nameText, value);
        }

        [Test]
        [Timeout(60000)]
        public void TestDescription()
        {
            //arrange
            var descriptionText = "someDescription";
            _descriptorMock.SetupGet(it => it.Description).Returns(descriptionText);

            //act
            var value = _target.Description;

            //assert
            Assert.AreEqual(descriptionText, value);
        }

        [Test]
        [Timeout(60000)]
        public void TestIcon()
        {
            //arrange
            var expectedIcon = new DrawingImage();
            _descriptorMock.SetupGet(it => it.Icon).Returns(expectedIcon);

            //act
            var value = _target.Icon;

            //assert
            Assert.AreSame(expectedIcon, value);
        }

        [Test]
        [Timeout(60000)]
        public void TestIsEnabled()
        {
            //arrange
            var expectedValue = true;
            _changedProperties.Clear();

            //act
            _target.IsEnabled = expectedValue;
            var value = _target.IsEnabled;

            //assert
            Assert.IsTrue(_changedProperties.Contains("IsEnabled"));
            Assert.AreEqual(expectedValue, value);
        }

        #endregion Test properties

        #region Private helper methods

        void _target_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _changedProperties.Add(e.PropertyName);
        }

        #endregion Private helper methods
    }
}