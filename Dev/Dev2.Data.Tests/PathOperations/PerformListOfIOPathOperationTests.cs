﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Interfaces.Wrappers;
using Dev2.Data.Interfaces;
using Dev2.Data.Interfaces.Enums;
using Dev2.Data.PathOperations;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dev2.Data.Tests.PathOperations
{
    [TestFixture]
    public class PerformListOfIOPathOperationTests
    {
        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AppendBackSlashes_Path_Null_ExpectNullReferenceException()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockFileWrapper = new Mock<IFile>();
            var mockDirectory = new Mock<IDirectory>();
            //-----------------------Act----------------------------
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.Throws<NullReferenceException>(()=> PerformListOfIOPathOperation.AppendBackSlashes(mockActivityIOPath.Object, mockFileWrapper.Object, mockDirectory.Object));
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AppendBackSlashes_With_CTOR_Path_Null_ExpectNullReferenceException()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockFileWrapper = new Mock<IFile>();
            var mockDirectory = new Mock<IDirectory>();
            var mockWindowsImpersonationContext = new Mock<IWindowsImpersonationContext>();

            var performListOfIOPathOperation = new TestPerformListOfIOPathOperation((arg1, arg2) => mockWindowsImpersonationContext.Object);
            //-----------------------Act----------------------------
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.Throws<NullReferenceException>(() => PerformListOfIOPathOperation.AppendBackSlashes(mockActivityIOPath.Object, mockFileWrapper.Object, mockDirectory.Object));
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AppendBackSlashes_Path_IsNotNull_ExpectNullReferenceException()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockFileWrapper = new Mock<IFile>();
            var mockDirectory = new Mock<IDirectory>();

            var path = "TestPath";

            mockActivityIOPath.Setup(o => o.Path).Returns(path);
            //-----------------------Act----------------------------
            var appendBackSlashes = PerformListOfIOPathOperation.AppendBackSlashes(mockActivityIOPath.Object, mockFileWrapper.Object, mockDirectory.Object);
            //-----------------------Assert-------------------------
            mockActivityIOPath.VerifyAll();
            NUnit.Framework.Assert.AreEqual(path+"\\", appendBackSlashes);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AppendBackSlashes_Path_IsNotDirectory_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockFileWrapper = new Mock<IFile>();
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger.log";

            mockActivityIOPath.Setup(o => o.Path).Returns(path);
            //-----------------------Act----------------------------
            var appendBackSlashes = PerformListOfIOPathOperation.AppendBackSlashes(mockActivityIOPath.Object, mockFileWrapper.Object, mockDirectory.Object);
            //-----------------------Assert-------------------------
            mockActivityIOPath.VerifyAll();
            NUnit.Framework.Assert.AreEqual(path, appendBackSlashes);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AppendBackSlashes_Path_IsDirectory_DirectoryExist_And_IsNotStarWildCard_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockFileWrapper = new Mock<IFile>();
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger.log";

            mockActivityIOPath.Setup(o => o.Path).Returns(path);
            mockFileWrapper.Setup(o => o.Exists(It.IsAny<string>())).Returns(true);
            mockFileWrapper.Setup(o => o.GetAttributes(It.IsAny<string>())).Returns(FileAttributes.Directory);
            //-----------------------Act----------------------------
            var appendBackSlashes = PerformListOfIOPathOperation.AppendBackSlashes(mockActivityIOPath.Object, mockFileWrapper.Object, mockDirectory.Object);
            //-----------------------Assert-------------------------
            mockActivityIOPath.VerifyAll();
            mockFileWrapper.VerifyAll();
            NUnit.Framework.Assert.AreEqual(path+"\\", appendBackSlashes);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AppendBackSlashes_Path_IsDirectory_DirectoryExist_And_IsNotStarWildCard_EndsWithBackSlash_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var mockFileWrapper = new Mock<IFile>();
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger.log\\";

            mockActivityIOPath.Setup(o => o.Path).Returns(path);
            //-----------------------Act----------------------------
            var appendBackSlashes = PerformListOfIOPathOperation.AppendBackSlashes(mockActivityIOPath.Object, mockFileWrapper.Object, mockDirectory.Object);
            //-----------------------Assert-------------------------
            mockActivityIOPath.VerifyAll();
            NUnit.Framework.Assert.AreEqual(path, appendBackSlashes);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AddDirsToResults_DirsToAdd_NoDirs_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var enumerableString = new List<string>();
            //-----------------------Act----------------------------
            var appendBackSlashes = PerformListOfIOPathOperation.AddDirsToResults(enumerableString, mockActivityIOPath.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.AreEqual(0, appendBackSlashes.Count);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AddDirsToResults_DirsToAdd_WithInValidDirs_ExpectIOException()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var enumerableString = new List<string>();
            enumerableString.Add("testDir1");
            enumerableString.Add("testDir2");
            //-----------------------Act----------------------------
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.Throws<IOException>(() => PerformListOfIOPathOperation.AddDirsToResults(enumerableString, mockActivityIOPath.Object));
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_AddDirsToResults_DirsToAdd_WithValidDirs_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockActivityIOPath = new Mock<IActivityIOPath>();
            var enumerableString = new List<string>();
            enumerableString.Add("ftp://testParth/logger1.log");
            enumerableString.Add("c://testParth/logger2.log");
            //-----------------------Act----------------------------
            var addDirsToResults = PerformListOfIOPathOperation.AddDirsToResults(enumerableString, mockActivityIOPath.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.AreEqual(2,addDirsToResults.Count);
            NUnit.Framework.Assert.AreEqual("ftp://testParth/logger1.log", addDirsToResults[0].Path);
            NUnit.Framework.Assert.AreEqual("c://testParth/logger2.log", addDirsToResults[1].Path);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_GetDirectoriesForType_Pattern_IsNullOrEmpty_IsNotNull_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger1.log";
            var pattern = "testPattern";
            //-----------------------Act----------------------------
            var getDirectoriesForType = PerformListOfIOPathOperation.GetDirectoriesForType(path, pattern, ReadTypes.Files, mockDirectory.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.IsNotNull(getDirectoriesForType);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_GetDirectoriesForType_Pattern_IsNotNullOrEmpty_And_ReadTypesFolders_IsNotNull_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger1.log";
            var pattern = "testPattern";
            //-----------------------Act----------------------------
            var getDirectoriesForType = PerformListOfIOPathOperation.GetDirectoriesForType(path, pattern, ReadTypes.Folders, mockDirectory.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.IsNotNull(getDirectoriesForType);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_GetDirectoriesForType_Pattern_IsNotNullOrEmpty_And_ReadTypesFilesAndFolders_IsNotNull_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger1.log";
            var pattern = "testPattern";
            //-----------------------Act----------------------------
            var getDirectoriesForType = PerformListOfIOPathOperation.GetDirectoriesForType(path, pattern, ReadTypes.FilesAndFolders, mockDirectory.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.IsNotNull(getDirectoriesForType);
        }


        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_GetDirectoriesForType_Pattern_IsNullOrEmpty_And_ReadTypesFiles_IsNotNull_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger1.log";
            //-----------------------Act----------------------------
            var getDirectoriesForType = PerformListOfIOPathOperation.GetDirectoriesForType(path, string.Empty, ReadTypes.Files, mockDirectory.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.IsNotNull(getDirectoriesForType);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_GetDirectoriesForType_Pattern_IsNullOrEmpty_And_ReadTypesFolders_IsNotNull_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger1.log";
            //-----------------------Act----------------------------
            var getDirectoriesForType = PerformListOfIOPathOperation.GetDirectoriesForType(path, string.Empty, ReadTypes.Folders, mockDirectory.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.IsNotNull(getDirectoriesForType);
        }

        [Test]
        [Author("Siphamandla Dube")]
        [Category(nameof(PerformListOfIOPathOperation))]
        public void PerformListOfIOPathOperation_GetDirectoriesForType_Pattern_IsNullOrEmpty_And_ReadTypesFilesAndFolders_IsNotNull_ExpectTrue()
        {
            //-----------------------Arrange------------------------
            var mockDirectory = new Mock<IDirectory>();

            var path = "ftp://testParth/logger1.log";
            //-----------------------Act----------------------------
            var getDirectoriesForType = PerformListOfIOPathOperation.GetDirectoriesForType(path, string.Empty, ReadTypes.FilesAndFolders, mockDirectory.Object);
            //-----------------------Assert-------------------------
            NUnit.Framework.Assert.IsNotNull(getDirectoriesForType);
        }

        class TestPerformListOfIOPathOperation : PerformListOfIOPathOperation
        {
            public TestPerformListOfIOPathOperation(ImpersonationDelegate impersonationDelegate) : base(impersonationDelegate)
            {
            }

            public override IList<IActivityIOPath> ExecuteOperation()
            {
                throw new NotImplementedException();
            }

            public override IList<IActivityIOPath> ExecuteOperationWithAuth()
            {
                throw new NotImplementedException();
            }
        }
    }
}
