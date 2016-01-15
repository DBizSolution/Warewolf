
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
// ReSharper disable CheckNamespace
namespace Dev2.DataList
{
    /// <summary>
    /// Class for the "ends with" recordset search option 
    /// </summary>
    public class RsOpNotEndsWith : AbstractRecsetSearchValidation
    {
        public override Func<DataASTMutable.WarewolfAtom, bool> CreateFunc(IEnumerable<DataASTMutable.WarewolfAtom> values, IEnumerable<DataASTMutable.WarewolfAtom> warewolfAtoms, IEnumerable<DataASTMutable.WarewolfAtom> to, bool all)
        {
            if (all)
                return a => values.All(x => !a.ToString().ToLower(CultureInfo.InvariantCulture).EndsWith(x.ToString().ToLower(CultureInfo.InvariantCulture)));
            return a => values.Any(x => !a.ToString().ToLower(CultureInfo.InvariantCulture).EndsWith(x.ToString().ToLower(CultureInfo.InvariantCulture)));
        }
        public override string HandlesType()
        {
            return "Doesn't End With";
        }
    }
}
