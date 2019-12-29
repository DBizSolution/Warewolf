﻿using System;
using System.Activities;
using Dev2;
using Dev2.Activities;
using NUnit.Framework;
using Moq;
using Warewolf.UnitTestAttributes;

namespace Warewolf.ResourceManagement.Tests
{
    [TestFixture]
    public class ResourceActivityCacheTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullParser_ShouldThrowException()
        {
            var resourceActivityCache = new ResourceActivityCache(null, new System.Collections.Concurrent.ConcurrentDictionary<Guid, Dev2.IDev2Activity>());
            Assert.IsNull(resourceActivityCache);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullCache_ShouldThrowException()
        {
            var resourceActivityCache = new ResourceActivityCache(new ActivityParser(), null);
            Assert.IsNull(resourceActivityCache);
        }

        [Test]
        public void Parse_WhenNotInCache_ShouldAdd()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            var resourceActivityCache = new ResourceActivityCache(parser.Object, new System.Collections.Concurrent.ConcurrentDictionary<Guid, Dev2.IDev2Activity>());
            var resourceId = Guid.NewGuid();
            resourceActivityCache.Parse(new DynamicActivity(), resourceId);

            Assert.IsNotNull(resourceActivityCache);
            Assert.AreEqual(1, resourceActivityCache.Cache.Count);
            Assert.IsTrue(resourceActivityCache.Cache.ContainsKey(resourceId));
        }

        [Test]
        public void HasInCache_WhenInCache_ShouldReturnTrue()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            var resourceActivityCache = new ResourceActivityCache(parser.Object, new System.Collections.Concurrent.ConcurrentDictionary<Guid, Dev2.IDev2Activity>());
            var resourceId = Guid.NewGuid();
            resourceActivityCache.Parse(new DynamicActivity(), resourceId);

            Assert.IsTrue(resourceActivityCache.HasActivityInCache(resourceId));            
        }

        [Test]
        public void HasInCache_WhenNotInCache_ShouldReturnFalse()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            var resourceActivityCache = new ResourceActivityCache(parser.Object, new System.Collections.Concurrent.ConcurrentDictionary<Guid, Dev2.IDev2Activity>());
            var resourceId = Guid.NewGuid();
            resourceActivityCache.Parse(new DynamicActivity(), resourceId);

            Assert.IsFalse(resourceActivityCache.HasActivityInCache(Guid.NewGuid()));
        }

        [Test]
        public void Parse_WhenInCache_ShouldNotAdd()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            var resourceActivityCache = new ResourceActivityCache(parser.Object, new System.Collections.Concurrent.ConcurrentDictionary<Guid, Dev2.IDev2Activity>());
            var resourceId = Guid.NewGuid();
            resourceActivityCache.Parse(new DynamicActivity(), resourceId);

            Assert.IsNotNull(resourceActivityCache);
            Assert.AreEqual(1, resourceActivityCache.Cache.Count);
            Assert.IsTrue(resourceActivityCache.Cache.ContainsKey(resourceId));

            resourceActivityCache.Parse(new DynamicActivity(), resourceId);
            Assert.AreEqual(1, resourceActivityCache.Cache.Count);
            Assert.IsTrue(resourceActivityCache.Cache.ContainsKey(resourceId));
        }

        [Test]
        public void Remove_WhenInCache_ShouldRemove()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            var resourceActivityCache = new ResourceActivityCache(parser.Object, new System.Collections.Concurrent.ConcurrentDictionary<Guid, Dev2.IDev2Activity>());
            var resourceId = Guid.NewGuid();
            resourceActivityCache.Parse(new DynamicActivity(), resourceId);

            Assert.AreEqual(1, resourceActivityCache.Cache.Count);
            Assert.IsTrue(resourceActivityCache.Cache.ContainsKey(resourceId));

            resourceActivityCache.RemoveFromCache(resourceId);
            Assert.AreEqual(0, resourceActivityCache.Cache.Count);
            Assert.IsFalse(resourceActivityCache.Cache.ContainsKey(resourceId));
        }
    }  
}
