﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Studio.UI.Specs.Tools
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class FileAndFolder_ReadFolderFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FileAndFolder-ReadFolder.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FileAndFolder-ReadFolder", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "FileAndFolder-ReadFolder")))
            {
                Dev2.Studio.UI.Specs.Tools.FileAndFolder_ReadFolderFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ReadFolder Tool Large View And Invalid Variables Expected Error On Done Button")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileAndFolder-ReadFolder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ReadFolder")]
        public virtual void ReadFolderToolLargeViewAndInvalidVariablesExpectedErrorOnDoneButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ReadFolder Tool Large View And Invalid Variables Expected Error On Done Button", new string[] {
                        "ReadFolder"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.Given("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Given("I click \"EXPLORERCONNECTCONTROL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.Given("I click \"U_UI_ExplorerServerCbx_AutoID_localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.And("I click \"RIBBONNEWENDPOINT\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Given("I send \"Read\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
    testRunner.Given("I drag \"TOOLREADFOLDER\" onto \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Given("I double click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Read Folder(ReadFol" +
                    "derDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.Given("I type \"[[rec@(1).a]]\" in \"WORKSURFACE,Read Folder(ReadFolderDesigner),LargeViewC" +
                    "ontent,UI__Directorytxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Read Folder(ReadFolderDesi" +
                    "gner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.Given("I type \"[[Var#]]\" in \"WORKSURFACE,Read Folder(ReadFolderDesigner),LargeViewConten" +
                    "t,UI__Directorytxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Read Folder(ReadFolderDesi" +
                    "gner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.Given("I type \"[[rec(1).a]]\" in \"WORKSURFACE,Read Folder(ReadFolderDesigner),LargeViewCo" +
                    "ntent,UI__Directorytxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Read Folder(ReadFolderDesi" +
                    "gner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is invisible within \"1\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.Given("\"WORKSURFACE,Read Folder(ReadFolderDesigner),SmallViewContent\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.Given("I double click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Read Folder(ReadFol" +
                    "derDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.Given("I type \"TestingDelete\" in \"WORKSURFACE,Read Folder(ReadFolderDesigner),LargeViewC" +
                    "ontent,UI__UserNametxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Read Folder(ReadFolderDesi" +
                    "gner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.Given("I send \"{TAB}\" to \"WORKSURFACE,Read Folder(ReadFolderDesigner),LargeViewContent,U" +
                    "I__UserNametxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.Given("I send \"Password\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Read Folder(ReadFolderDesi" +
                    "gner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is invisible within \"1\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.Given("\"WORKSURFACE,Read Folder(ReadFolderDesigner),SmallViewContent\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
