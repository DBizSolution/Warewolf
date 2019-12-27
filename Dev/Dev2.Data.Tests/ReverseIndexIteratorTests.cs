/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Data.Binary_Objects;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dev2.Data.Tests
{
    [TestFixture]
    public class ReverseIndexIteratorTests
    {
        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(ReverseIndexIterator))]
        public void ReverseIndexIterator_IndexList_AreEqual_ExpectTrue()
        {
            //---------------------------Arrange--------------------------
            var hashSet = new HashSet<int>();
            var indexList = new IndexList(new HashSet<int>(), 0) { MinValue = 1, MaxValue = 4 };

            var reverseIndexIterator = new ReverseIndexIterator(hashSet, 2)
            {
                 IndexList = indexList
            };
            //---------------------------Act------------------------------
            var fetchNextIndex = reverseIndexIterator.FetchNextIndex();

            //---------------------------Assert---------------------------
            NUnit.Framework.Assert.IsFalse(reverseIndexIterator.IsEmpty);
            NUnit.Framework.Assert.AreEqual(4, reverseIndexIterator.IndexList.Count());
            NUnit.Framework.Assert.AreEqual(1, fetchNextIndex);
            NUnit.Framework.Assert.AreEqual(4, reverseIndexIterator.IndexList.Count());
            NUnit.Framework.Assert.AreEqual(4, reverseIndexIterator.MaxIndex());
            NUnit.Framework.Assert.IsFalse(reverseIndexIterator.HasMore());
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(ReverseIndexIterator))]
        public void ReverseIndexIterator_FetchNextIndex_HashSet_IsNotZero_AreEqual_ExpectTrue()
        {
            //---------------------------Arrange--------------------------
            var hashSet = new HashSet<int>();
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(3);
            var indexList = new IndexList(hashSet, 0) { MinValue = 1, MaxValue = 4 };

            var reverseIndexIterator = new ReverseIndexIterator(hashSet, 2)
            {
                IndexList = indexList
            };
            //---------------------------Act------------------------------
            var fetchNextIndex = reverseIndexIterator.FetchNextIndex();
            //---------------------------Assert---------------------------
            NUnit.Framework.Assert.IsFalse(reverseIndexIterator.IsEmpty);
            NUnit.Framework.Assert.AreEqual(1, reverseIndexIterator.IndexList.Count());
            NUnit.Framework.Assert.AreEqual(0, fetchNextIndex);
            NUnit.Framework.Assert.AreEqual(1, reverseIndexIterator.IndexList.Count());
            NUnit.Framework.Assert.AreEqual(4, reverseIndexIterator.MaxIndex());
            NUnit.Framework.Assert.IsFalse(reverseIndexIterator.HasMore());
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(ReverseIndexIterator))]
        public void ReverseIndexIterator_HasMore_HashSet_IsNull_IsFalse_ExpectFalse()
        {
            //---------------------------Arrange--------------------------
            var hashSet = new HashSet<int>();
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(3);
            var indexList = new IndexList(hashSet, 0) { MinValue = 1, MaxValue = 4 };

            var reverseIndexIterator = new ReverseIndexIterator(hashSet, 2)
            {
                IndexList = indexList
            };
            //---------------------------Act------------------------------
            var fetchNextIndex = reverseIndexIterator.HasMore();
            //---------------------------Assert---------------------------
            NUnit.Framework.Assert.IsTrue(reverseIndexIterator.IsEmpty);
            NUnit.Framework.Assert.AreEqual(1, reverseIndexIterator.IndexList.Count());
            NUnit.Framework.Assert.IsFalse(fetchNextIndex);
            NUnit.Framework.Assert.AreEqual(1, reverseIndexIterator.IndexList.Count());
            NUnit.Framework.Assert.AreEqual(4, reverseIndexIterator.MaxIndex());
            NUnit.Framework.Assert.IsFalse(reverseIndexIterator.HasMore());
        }
    }
}
