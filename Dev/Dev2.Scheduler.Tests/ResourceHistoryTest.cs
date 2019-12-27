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
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Scheduler.Interfaces;
using NUnit.Framework;

namespace Dev2.Scheduler.Test
{

    [TestFixture]
    public class ResourceHistoryTest
    {
        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("TaskSheduler_ResourceHistoryTest_Construct")]
        
        public void TaskSheduler_ResourceHistory_ShouldConstructCorrectly()

        {
            var a = new List<IDebugState>();
            var b = new EventInfo(new DateTime(2001, 01, 01), new TimeSpan(1, 0, 0), new DateTime(2001, 01, 01), ScheduleRunStatus.Error, "sdf");
            var res = new ResourceHistory("output", a, b, "bob");
            Assert.AreEqual(a, res.DebugOutput);
            Assert.AreEqual(b, res.TaskHistoryOutput);
            Assert.AreEqual("bob", res.UserName);

        }
    }
}
