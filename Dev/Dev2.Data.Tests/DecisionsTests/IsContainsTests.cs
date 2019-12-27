/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Data.Decisions.Operations;
using NUnit.Framework;

namespace Dev2.Data.Tests.DecisionsTests
{
    [TestFixture]
    public class ContainsTests
    {
        [Test]
        [Author("Massimo Guerrera")]
        [Category("IsContains_Invoke")]
        public void IsContains_Invoke_DoesContain_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var isContains = new IsContains();
            var cols = new string[2];
            cols[0] = "TestData";
            cols[1] = "Test";
            //------------Execute Test---------------------------
            var result = isContains.Invoke(cols);
            //------------Assert Results-------------------------
            NUnit.Framework.Assert.IsTrue(result);
        }

        [Test]
        [Author("Massimo Guerrera")]
        [Category("IsContains_Invoke")]
        public void IsContains_Invoke_DoesntContain_ReturnsTrue()
        {
            //------------Setup for test--------------------------
            var notStartsWith = new IsContains();
            var cols = new string[2];
            cols[0] = "TestData";
            cols[1] = "No";
            //------------Execute Test---------------------------
            var result = notStartsWith.Invoke(cols);
            //------------Assert Results-------------------------
            NUnit.Framework.Assert.IsFalse(result);
        }

        [Test]
        [Author("Sanele Mthmembu")]
        [Category("IsContains_HandlesType")]
        public void IsContains_HandlesType_ReturnsIsContainsType()
        {
            var decisionType = enDecisionType.IsContains;
            //------------Setup for test--------------------------
            var isContains = new IsContains();
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            NUnit.Framework.Assert.AreEqual(decisionType, isContains.HandlesType());
        }
    }
}
