﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Activities;
using Dev2.Runtime;
using Dev2.Runtime.ESB.Execution;

namespace Dev2.ServerLifeCycleWorkers
{
    public class RegisterDependenciesWorker : IServerLifecycleWorker
    {
        public void Execute()
        {
            CustomContainer.Register<IActivityParser>(new ActivityParser());
            CustomContainer.Register<IExecutionManager>(new ExecutionManager());
            CustomContainer.Register<IResumableExecutionContainerFactory>(new ResumableExecutionContainerFactory());
        }
    }
}