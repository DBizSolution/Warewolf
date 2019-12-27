﻿using System;
using Dev2.Activities.DropBox2016.DeleteActivity;
using Dev2.Activities.DropBox2016.Result;
using Dev2.Common.Interfaces.Wrappers;
using Dropbox.Api.Files;
using NUnit.Framework;
using Moq;



namespace Dev2.Tests.Activities.ActivityTests.DropBox2016.Delete
{
    [TestFixture]
    public class DropBoxDeleteTests
    {
        Mock<IDropBoxDelete> CreateDropboxDeleteMock()
        {
            var mock = new Mock<IDropBoxDelete>();
            var fileMetadata = new DropboxDeleteSuccessResult(new FileMetadata());
            mock.Setup(upload => upload.ExecuteTask(It.IsAny<IDropboxClient>()))
                 .Returns(fileMetadata);
            return mock;
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category("DropboxDelete_CreateDropboxActivity")]
        public void DropboxDelete_CreateDropboxActivity_GivenIsNew_ShouldNotBeNull()
        {
            //------------Setup for test--------------------------
            var dropBoxDelete = CreateDropboxDeleteMock().Object;

            //------------Execute Test---------------------------

            //------------Assert Results-------------------------
            Assert.IsNotNull(dropBoxDelete);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category("DropboxDelete_ExecuteTask")]
        public void DropboxDelete_ExecuteTask_GivenDropBoxDelete_ShouldReturnFileMetadata()
        {
            //------------Setup for test--------------------------
            var dropBoxDelete = CreateDropboxDeleteMock();

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropBoxDelete);
            //------------Execute Test---------------------------
            dropBoxDelete.Object.ExecuteTask(It.IsAny<IDropboxClient>());
            //------------Assert Results-------------------------
            dropBoxDelete.Verify(upload => upload.ExecuteTask(It.IsAny<IDropboxClient>()));
        }
        

        [Test]
        [Author("Pieter Terblanche")]
        [Category("DropboxDelete_CreateDropboxActivity")]
        [ExpectedException(typeof(ArgumentException))]
        public void DropboxDelete_CreateDropboxActivity_GivenMissingDeletePath_ShouldBeInValid()
        {
            //---------------Set up test pack-------------------
            var dropBoxDelete = new DropboxDelete("");
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category("DropboxDelete_CreateDropboxActivity")]
        [ExpectedException(typeof(ArgumentException))]
        public void DropboxDelete_CreateDropboxActivity_GivenInvalidThenExecute_ShouldReturnFailureResult()
        {
            //---------------Set up test pack-------------------
            var dropBoxDelete = new DropboxDelete("");
        }
    }
}
