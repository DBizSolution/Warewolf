﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.UIBindingTests.RabbitMqSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("RabbitMq Source")]
    [NUnit.Framework.CategoryAttribute("RabbitMqSource")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
        "1.dll")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:InfragisticsWPF4.Controls.Grids.XamGrid.v15.1.dll")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:InfragisticsWPF4.DataPresenter.v15.1.dll")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:Warewolf_Studio.exe")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:Newtonsoft.Json.dll")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:System.Windows.Interactivity.dll")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:Warewolf.Studio.Themes.Luna.dll")]
    [NUnit.Framework.CategoryAttribute("MSTest:DeploymentItem:EnableDocker.txt")]
    public partial class RabbitMqSourceFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RabbitMq Source.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RabbitMq Source", "\tIn order to share settings\r\n\tI want to save my RabbitMq source Settings\r\n\tSo tha" +
                    "t I can reuse them", ProgrammingLanguage.CSharp, new string[] {
                        "RabbitMqSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Grids.XamGrid.v15.1.dll",
                        "MSTest:DeploymentItem:InfragisticsWPF4.DataPresenter.v15.1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll",
                        "MSTest:DeploymentItem:Warewolf.Studio.Themes.Luna.dll",
                        "MSTest:DeploymentItem:EnableDocker.txt"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create New RabbitMq source")]
        public virtual void CreateNewRabbitMqSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create New RabbitMq source", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I open New RabbitMq Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Then("\"New RabbitMQ Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("the title is \"New RabbitMQ Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("\"Host\" input is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("\"Port\" input is \"5672\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("\"User Name\" input is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("\"Password\" input is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("\"Virtual Host\" input is \"/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("\"Test Connection\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Enable Send and Enable Save")]
        public virtual void EnableSendAndEnableSave()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enable Send and Enable Save", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I open New RabbitMq Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.Then("\"New RabbitMQ Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.And("I type Host as \"test-rabbitmq\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("\"Port\" input is \"5672\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I type Password as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("I click \"Test Connection\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.And("Send is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.When("I save as \"TestRabbitMq\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.And("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Fail Send Rabbit Mq Message Shows correct error message")]
        public virtual void FailSendRabbitMqMessageShowsCorrectErrorMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fail Send Rabbit Mq Message Shows correct error message", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("I open New RabbitMq Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.Then("\"New RabbitMQ Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.And("I type Host as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("\"Port\" input is \"5672\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I type Password as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("Send is \"Unsuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.Then("Send is \"Failed: None of the specified endpoints were reachable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("the error message is \"Failed: None of the specified endpoints were reachable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
