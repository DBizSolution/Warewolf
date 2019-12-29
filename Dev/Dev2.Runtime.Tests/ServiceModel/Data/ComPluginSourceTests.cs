using System;
using System.Xml.Linq;
using Dev2.Runtime.ServiceModel.Data;
using NUnit.Framework;
using Warewolf.UnitTestAttributes;


namespace Dev2.Tests.Runtime.ServiceModel
{
    [TestFixture]
    [Category("Runtime Hosting")]
    public class ComPluginSourceTests
    {
  
        #region CTOR

        [Test]
        public void ComPluginSourceContructorWithDefaultExpectedInitializesProperties()
        {
            var source = new ComPluginSource();
            Assert.AreEqual(Guid.Empty, source.ResourceID);
            Assert.AreEqual("ComPluginSource", source.ResourceType);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComPluginSourceContructorWithNullXmlExpectedThrowsArgumentNullException()
        {
            var source = new ComPluginSource(null);
        }

        [Test]
        public void ComPluginSourceContructorWithInvalidXmlExpectedDoesNotThrowExceptionAndInitializesProperties()
        {
            var xml = new XElement("root");
            var source = new ComPluginSource(xml);
            Assert.AreNotEqual(Guid.Empty, source.ResourceID);
            Assert.IsTrue(source.IsUpgraded);
            Assert.AreEqual("ComPluginSource", source.ResourceType);
        }

        #endregion

        #region ToXml

        [Test]
        public void ComPluginSourceToXmlExpectedSerializesProperties()
        {
            var expected = new ComPluginSource
            {
                ClsId = "Plugins\\someDllIMadeUpToTest.dll",
                Is32Bit = false,
            };

            var xml = expected.ToXml();

            var actual = new ComPluginSource(xml);

            Assert.AreEqual(expected.ResourceType, actual.ResourceType);
            Assert.AreEqual(expected.ClsId, actual.ClsId);
            Assert.AreEqual(expected.Is32Bit, actual.Is32Bit);
        }

        [Test]
        public void ComPluginSourceToXmlWithNullPropertiesExpectedSerializesPropertiesAsEmpty()
        {
            var expected = new ComPluginSource
            {
                ClsId = null,
                Is32Bit = false,
            };

            var xml = expected.ToXml();

            var actual = new ComPluginSource(xml);

            Assert.AreEqual(expected.ResourceType, actual.ResourceType);
            Assert.AreEqual("", actual.ClsId);
            Assert.AreEqual(false, actual.Is32Bit);
        }

        #endregion
    }
}