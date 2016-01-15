﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox.Utility.GatherSystemInformation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GatherSystemInformationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GatherSystemInformation.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GatherSystemInformation", "In order to use system information\r\nAs a warewolf user\r\nI want a tool that I retr" +
                    "ieve system info", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "GatherSystemInformation")))
            {
                Dev2.Activities.Specs.Toolbox.Utility.GatherSystemInformation.GatherSystemInformationFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system operating system into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemOperatingSystemIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system operating system into a scalar", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"OperatingSystem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table1.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 12
 testRunner.And("the debug output as", ((string)(null)), table1, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system service pack into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemServicePackIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system service pack into a scalar", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"ServicePack\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table2.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 21
 testRunner.And("the debug output as", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system OS Bit Value into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemOSBitValueIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system OS Bit Value into a scalar", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"OSBitValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"Int32\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table3.AddRow(new string[] {
                        "1",
                        "[[testvar]] = Int32"});
#line 30
 testRunner.And("the debug output as", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system date time into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemDateTimeIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system date time into a scalar", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"FullDateTime\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"DateTime\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table4.AddRow(new string[] {
                        "1",
                        "[[testvar]] = DateTime"});
#line 39
 testRunner.And("the debug output as", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Date Time Format into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemDateTimeFormatIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Date Time Format into a scalar", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"DateTimeFormat\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table5.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 48
 testRunner.And("the debug output as", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Disk Available into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemDiskAvailableIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Disk Available into a scalar", ((string[])(null)));
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"DiskAvailable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table6.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 57
 testRunner.And("the debug output as", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Disk Total into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemDiskTotalIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Disk Total into a scalar", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"DiskTotal\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table7.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 66
 testRunner.And("the debug output as", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Physical Memory Available into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemPhysicalMemoryAvailableIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Physical Memory Available into a scalar", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line 71
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"PhysicalMemoryAvailable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"Int32\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table8.AddRow(new string[] {
                        "1",
                        "[[testvar]] = Int32"});
#line 75
 testRunner.And("the debug output as", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Physical Memory Total into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemPhysicalMemoryTotalIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Physical Memory Total into a scalar", ((string[])(null)));
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"PhysicalMemoryTotal\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"Int32\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table9.AddRow(new string[] {
                        "1",
                        "[[testvar]] = Int32"});
#line 84
 testRunner.And("the debug output as", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system CPU Available into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemCPUAvailableIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system CPU Available into a scalar", ((string[])(null)));
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"CPUAvailable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table10.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 93
 testRunner.And("the debug output as", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system CPU Total into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemCPUTotalIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system CPU Total into a scalar", ((string[])(null)));
#line 97
this.ScenarioSetup(scenarioInfo);
#line 98
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"CPUTotal\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table11.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 102
 testRunner.And("the debug output as", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Language into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemLanguageIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Language into a scalar", ((string[])(null)));
#line 106
this.ScenarioSetup(scenarioInfo);
#line 107
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"Language\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 108
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table12.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 111
 testRunner.And("the debug output as", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Region into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemRegionIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Region into a scalar", ((string[])(null)));
#line 115
this.ScenarioSetup(scenarioInfo);
#line 116
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"Region\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 117
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table13.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 120
 testRunner.And("the debug output as", ((string)(null)), table13, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system User Roles into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemUserRolesIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system User Roles into a scalar", ((string[])(null)));
#line 124
this.ScenarioSetup(scenarioInfo);
#line 125
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"UserRoles\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 126
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table14.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 129
 testRunner.And("the debug output as", ((string)(null)), table14, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system User Name into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemUserNameIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system User Name into a scalar", ((string[])(null)));
#line 133
this.ScenarioSetup(scenarioInfo);
#line 134
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"UserName\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 135
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table15.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 138
 testRunner.And("the debug output as", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Domain into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemDomainIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Domain into a scalar", ((string[])(null)));
#line 142
this.ScenarioSetup(scenarioInfo);
#line 143
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"Domain\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 144
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 146
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table16.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 147
 testRunner.And("the debug output as", ((string)(null)), table16, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Number Of Warewolf Agents into a scalar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemNumberOfWarewolfAgentsIntoAScalar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Number Of Warewolf Agents into a scalar", ((string[])(null)));
#line 151
this.ScenarioSetup(scenarioInfo);
#line 152
 testRunner.Given("I have a variable \"[[testvar]]\" and I selected \"NumberOfWarewolfAgents\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 153
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
 testRunner.Then("the value of the variable \"[[testvar]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table17.AddRow(new string[] {
                        "1",
                        "[[testvar]] = String"});
#line 156
 testRunner.And("the debug output as", ((string)(null)), table17, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign User Roles into a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignUserRolesIntoARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign User Roles into a recordset", ((string[])(null)));
#line 160
this.ScenarioSetup(scenarioInfo);
#line 161
 testRunner.Given("I have a variable \"[[my(2).roles]]\" and I selected \"UserRoles\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 162
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 163
 testRunner.Then("the value of the variable \"[[my(2).roles]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table18.AddRow(new string[] {
                        "1",
                        "[[my(2).roles]] = String"});
#line 165
 testRunner.And("the debug output as", ((string)(null)), table18, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign User Roles into a multiple fields in recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignUserRolesIntoAMultipleFieldsInRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign User Roles into a multiple fields in recordset", ((string[])(null)));
#line 169
this.ScenarioSetup(scenarioInfo);
#line 170
 testRunner.Given("I have a variable \"[[my().roles]]\" and I selected \"UserRoles\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 171
 testRunner.And("I have a variable \"[[my().ram]]\" and I selected \"PhysicalMemoryAvailable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.And("I have a variable \"[[my().ramtot]]\" and I selected \"PhysicalMemoryTotal\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
 testRunner.Then("the value of the variable \"[[my(1).roles]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 175
 testRunner.Then("the value of the variable \"[[my(1).ram]]\" is a valid \"Int32\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
 testRunner.Then("the value of the variable \"[[my(1).ramtot]]\" is a valid \"Int32\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 177
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table19.AddRow(new string[] {
                        "1",
                        "[[my(1).roles]] = String"});
            table19.AddRow(new string[] {
                        "2",
                        "[[my(1).ram]] = Int32"});
            table19.AddRow(new string[] {
                        "3",
                        "[[my(1).ramtot]] = Int32"});
#line 178
 testRunner.And("the debug output as", ((string)(null)), table19, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign a system Domain into a negative recordset index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignASystemDomainIntoANegativeRecordsetIndex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a system Domain into a negative recordset index", ((string[])(null)));
#line 185
this.ScenarioSetup(scenarioInfo);
#line 186
 testRunner.Given("I have a variable \"[[rec(-1).set]]\" and I selected \"Domain\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 187
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 188
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table20.AddRow(new string[] {
                        "1",
                        "[[rec(-1).set]] ="});
#line 189
 testRunner.And("the debug output as", ((string)(null)), table20, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign Disk Total into a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignDiskTotalIntoARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign Disk Total into a recordset", ((string[])(null)));
#line 194
this.ScenarioSetup(scenarioInfo);
#line 195
 testRunner.Given("I have a variable \"[[my().disks]]\" and I selected \"DiskTotal\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 196
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 197
 testRunner.Then("the value of the variable \"[[my(1).disks]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 198
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table21.AddRow(new string[] {
                        "1",
                        "[[my(1).disks]] = String"});
#line 199
 testRunner.And("the debug output as", ((string)(null)), table21, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign Disk Available into a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GatherSystemInformation")]
        public virtual void AssignDiskAvailableIntoARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign Disk Available into a recordset", ((string[])(null)));
#line 204
this.ScenarioSetup(scenarioInfo);
#line 205
 testRunner.Given("I have a variable \"[[my().disks]]\" and I selected \"DiskAvailable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 206
 testRunner.When("the gather system infomartion tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 207
 testRunner.Then("the value of the variable \"[[my(1).disks]]\" is a valid \"String\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table22.AddRow(new string[] {
                        "1",
                        "[[my(1).disks]] =  String"});
#line 209
 testRunner.And("the debug output as", ((string)(null)), table22, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
