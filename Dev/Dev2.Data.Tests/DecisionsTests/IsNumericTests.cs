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
    public class IsNumericTests
    {
        [Test]
        [Author("Sanele Mthembu")]
        [Category("IsNumeric_Invoke")]
        public void GivenSomeString_IsNumeric_Invoke_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var isNumeric = new IsNumeric();
            var cols = new string[2];
            cols[0] = "Eight";
            //------------Execute Test---------------------------
            var result = isNumeric.Invoke(cols);
            //------------Assert Results-------------------------
            NUnit.Framework.Assert.IsFalse(result);
        }

        [Test]
        [Author("Sanele Mthembu")]
        [Category("IsNumeric_Invoke")]
        public void IsNumeric_Invoke_IsNumeric_ReturnsTrue()
        {
            //------------Setup for test--------------------------
            var notStartsWith = new IsNumeric();
            var cols = new string[2];
            cols[0] = "324";
            //------------Execute Test---------------------------
            var result = notStartsWith.Invoke(cols);
            //------------Assert Results-------------------------
            NUnit.Framework.Assert.IsTrue(result);
        }

        [Test]
        [Author("Sanele Mthmembu")]
        [Category("IsNumeric_HandlesType")]
        public void IsNumeric_HandlesType_ReturnsIsNumericType()
        {
            var decisionType = enDecisionType.IsNumeric;
            //------------Setup for test--------------------------
            var isNumeric = new IsNumeric();
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            NUnit.Framework.Assert.AreEqual(decisionType, isNumeric.HandlesType());
        }
    }
}
