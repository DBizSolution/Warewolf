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
using System.Globalization;
using System.Threading;
using Dev2.Intellisense.Helper;
using Dev2.Intellisense.Provider;
using Dev2.Studio.Core;
using Dev2.Studio.Core.Models;
using Dev2.Studio.Interfaces;
using Dev2.Studio.Interfaces.DataList;
using Dev2.Studio.Interfaces.Enums;
using Dev2.Studio.ViewModels.DataList;
using NUnit.Framework;
using Warewolf.UnitTestAttributes;

namespace Dev2.Core.Tests.IntellisenseProvider
{
    [TestFixture]
    [Category("Intellisense Provider Core")]
    public class FileSystemIntellisenseProviderTest
    {
        IResourceModel _resourceModel;

        #region Test Initialization

        [SetUp]
        public void Init()
        {
            var testEnvironmentModel = ResourceModelTest.CreateMockEnvironment();

            _resourceModel = new ResourceModel(testEnvironmentModel.Object)
            {
                ResourceName = "test",
                ResourceType = ResourceType.Service,
                DataList = @"
            <DataList>
                    <Scalar/>
                    <Country/>
                    <State />
                    <City>
                        <Name/>
                        <GeoLocation />
                    </City>
             </DataList>
            "
            };

            IDataListViewModel setupDatalist = new DataListViewModel();
            DataListSingleton.SetDataList(setupDatalist);
            DataListSingleton.ActiveDataList.InitializeDataListViewModel(_resourceModel);
        }

        #endregion Test Initialization


        [Test]
        public void GetIntellisenseResultsWhereNothingPassedExpectListOfDrives()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 0,
                InputText = "",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(8, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereDrivePassedExpectFoldersAndFilesOnDrive()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 2,
                InputText = "C:",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(31, intellisenseProviderResults.Count);

        }

        [Test]
        public void GetIntellisenseResultsWhereDriveAndFolderPassedNoSlashExpectFolder()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 9,
                InputText = @"C:\Users",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(9, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereDriveAndFolderWithStartOfFileNamePassedExpectFileName()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 13,
                InputText = @"C:\Users\des",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereDriveAndFolderWithPartOfFileNamePassedExpectFileName()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 13,
                InputText = @"C:\Users\skt",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereNoNetworkExpectFolderNetworkShareInformation()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 2,
                InputText = @"\\",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(40, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereNetworkPathExpectFolderNetworkShareInformation()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 18,
                InputText = @"\\TFSBLD.premier.local\",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(6, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereNetworkPathHasFilesExpectFolderWithFilesNetworkShareInformation()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 36,
                InputText = @"\\TFSBLD.premier.local\DevelopmentDropOff",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(16, intellisenseProviderResults.Count);
        }


        [Test]
        public void GetIntellisenseResultsWhereNetworkPathHasFolderExpectFolderInformation()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 41,
                InputText = @"\\TFSBLD.premier.local\DevelopmentDropOff\_Arch",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereNetworkPathHasFileExpectFileInformation()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 44,
                InputText = @"\\TFSBLD.premier.local\DevelopmentDropOff\LoadTest",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();
            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, intellisenseProviderResults.Count);
        }

        [Test]
        public void GetIntellisenseResultsWhereNetworkPathHasMiddleOfFileExpectFileInformation()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 39,
                InputText = @"\\TFSBLD.premier.local\DevelopmentDropOff\Runt",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();

            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, intellisenseProviderResults.Count);
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("FileSystemIntellisenseProvider_PerformMethodInsertion")]
        public void FileSystemIntellisenseProvider_GetIntellisenseResults_EntireSet_ExpectCorrectOutput()
        {
            //------------Setup for test--------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 39,
                InputText = @"\\TFSBLD.premier.local\DevelopmentDropOff\Runt",
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.EntireSet
            };
            //------------Setup for test--------------------------
            var intellisenseProvider = CreateIntellisenseProvider();

            //------------Execute Test---------------------------
            var intellisenseProviderResults = intellisenseProvider.GetIntellisenseResults(context);
            //------------Assert Results-------------------------
            Assert.AreEqual(8, intellisenseProviderResults.Count);
        }

        public void FileSystemIntellisenseProvider_ExecuteInsertion(int caretPosition, string inputText, string inserted, string expected)
        {
            //------------Setup for test--------------------------
            var fileSystemIntellisenseProvider = new FileSystemIntellisenseProvider();
            
            //------------Execute Test---------------------------
            var context = new IntellisenseProviderContext
            {
                CaretPosition = caretPosition,
                InputText = inputText,
                IsInCalculateMode = false,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };

           var resp =  fileSystemIntellisenseProvider.PerformResultInsertion(inserted, context);
            //------------Assert Results-------------------------
            Assert.AreEqual(resp, expected);
        }

        [Test]
        [Author("Tshepo Ntlhokoa")]
        [Category("FileSystemIntellisenseProvider_PerformResultInsertion")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileSystemIntellisenseProvider_PerformResultInsertion_ContextIsNull_ThrowsException()
        {
            //------------Setup for test--------------------------
            var fileSystemIntellisenseProvider = new FileSystemIntellisenseProvider();
            //------------Execute Test---------------------------
            fileSystemIntellisenseProvider.PerformResultInsertion("", null);
        }

        [Test]
        [Author("Tshepo Ntlhokoa")]
        [Category("DefaultIntellisenseProvider_FileSystemIntellisenseProvider")]
        public void FileSystemIntellisenseProvider_GetIntellisenseResults_ContextIsNull_ResultCountIsZero()
        {
            //------------Execute Test---------------------------
            var getResults = new FileSystemIntellisenseProvider().GetIntellisenseResults(null);
            //------------Assert Results-------------------------
            Assert.AreEqual(0, getResults.Count);
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("FileSystemIntellisenseProvider_PerformMethodInsertion")]
        public void FileSystemIntellisenseProvider_PerformMethodInsertion_InsertPath_ExpectCorrectOutput()
        {
            FileSystemIntellisenseProvider_ExecuteInsertion(2, "a ", @"c:\", @"a c:\");
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("FileSystemIntellisenseProvider_PerformMethodInsertion")]
        public void FileSystemIntellisenseProvider_PerformMethodInsertion_InsertPathAfterLanguageElement_ExpectCorrectOutput()
        {
            FileSystemIntellisenseProvider_ExecuteInsertion(2, "[[a]] ", @"c:\", @"c:\");
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("FileSystemIntellisenseProvider_PerformMethodInsertion")]
        public void FileSystemIntellisenseProvider_PerformMethodInsertion_EmptyInput_ExpectCorrectOutput()
        {
            FileSystemIntellisenseProvider_ExecuteInsertion(0, "", @"c:\", @"c:\");
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("FileSystemIntellisenseProvider_PerformMethodInsertion")]
        public void FileSystemIntellisenseProvider_PerformMethodInsertion_NegativeCaret_ExpectEmptyOutput()
        {
            FileSystemIntellisenseProvider_ExecuteInsertion(-1, "", @"c:\", @"");
        }
        
        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("FileSystemIntellisenseProvider_PerformMethodInsertion")]
        public void FileSystemIntellisenseProvider_PerformMethodInsertion_InsertPathinsideText_ExpectCorrectOutput()
        {
            FileSystemIntellisenseProvider_ExecuteInsertion(2, "bobthebuilder", @"c:\", @"c:\");
            FileSystemIntellisenseProvider_ExecuteInsertion(2, "bobthebuilder doratheexplorer", @"c:\", @"c:\ doratheexplorer");
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("FileSystemIntellisenseProvider_Dispose")]
        public void FileSystemIntellisenseProvider_PerformMethodInsertion_Dispose()
        {

            var intellisenseProvider = CreateIntellisenseProvider();
            Assert.IsNotNull(intellisenseProvider.IntellisenseResults);
            intellisenseProvider.Dispose();
            Assert.IsNull(intellisenseProvider.IntellisenseResults);

        }
        static FileSystemIntellisenseProvider CreateIntellisenseProvider()
        {
            var intellisenseProvider = new FileSystemIntellisenseProvider { FileSystemQuery = new FileSystemQueryForTest() };
            return intellisenseProvider;
        }
    }


    class FileSystemQueryForTest : IFileSystemQuery
    {

        #region Implementation of IFileSystemQuery

        public List<string> QueryCollection { get; private set; }
        public void QueryList(string searchPath)
        {
            QueryCollection = new List<string>();
            switch (searchPath)
            {
                case @"\\TFSBLD.premier.local\DevelopmentDropOff\Runt":
                    AddToList(1);
                    break;
                case @"\\TFSBLD.premier.local\DevelopmentDropOff\LoadTest":
                    AddToList(1);
                    break;
                case @"\\TFSBLD.premier.local\DevelopmentDropOff\_Arch":
                    AddToList(1);
                    break;
                case @"\\TFSBLD.premier.local\DevelopmentDropOff":
                    AddToList(16);
                    break;
                case @"\\TFSBLD.premier.local\":
                    AddToList(6);
                    break;
                case @"\\":
                    AddToList(40);
                    break;
                case @"C:\Users\skt":
                    AddToList(1);
                    break;
                case @"C:\Users\des":
                    AddToList(1);
                    break;
                case @"C:\Users":
                    AddToList(9);
                    break;
                case @"C:":
                    AddToList(31);
                    break;
                case "":
                    AddToList(8);
                    break;
                default:
                    break;
            }
        }

        void AddToList(int times)
        {
            for(int i = 0; i < times; i++)
            {
                QueryCollection.Add(i.ToString(CultureInfo.InvariantCulture));
            }
        }

        #endregion
    }
}
