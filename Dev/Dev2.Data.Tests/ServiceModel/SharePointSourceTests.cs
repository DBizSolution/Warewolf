/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Xml.Linq;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Infrastructure.SharedModels;
using Dev2.Data.ServiceModel;
using Dev2.Runtime.ServiceModel.Data;
using NUnit.Framework;
using Moq;

namespace Dev2.Data.Tests.ServiceModel
{
    [TestFixture]
    public class SharePointSourceTests
    {
        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(SharepointSource))]
        public void SharePointSource_Validate_DefaultValues()
        {
            var sharepointSource = new SharepointSource();

            NUnit.Framework.Assert.IsTrue(sharepointSource.IsSource);
            NUnit.Framework.Assert.IsFalse(sharepointSource.IsService);
            NUnit.Framework.Assert.IsFalse(sharepointSource.IsFolder);
            NUnit.Framework.Assert.IsFalse(sharepointSource.IsReservedService);
            NUnit.Framework.Assert.IsFalse(sharepointSource.IsServer);
            NUnit.Framework.Assert.IsFalse(sharepointSource.IsResourceVersion);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(SharepointSource))]
        [Ignore("Incompatible with the latest version of Moq.")]
        public void SharePointSource_Validate_LoadLists()
        {
            var expectedSharepointList = new System.Collections.Generic.List<ISharepointListTo>
            {
                new SharepointListTo { FullName = "SharepointFullName" },
                new SharepointListTo { FullName = "SharepointFullNameDup" }
            };

            const string server = "localhost";
            const string userName = "testuser";
            const string password = "test123";
            const bool isSharepointOnline = false;

            var mockSharepointHelperFactory = new Mock<ISharepointHelperFactory>();
            mockSharepointHelperFactory.Setup(sharepointHelperFactory => sharepointHelperFactory.New(server, userName, password, isSharepointOnline).LoadLists()).Returns(expectedSharepointList);

            var sharepointSource = new SharepointSource(mockSharepointHelperFactory.Object);

            var sharepointList = sharepointSource.LoadLists();
            NUnit.Framework.Assert.AreEqual(2, sharepointList.Count);
            NUnit.Framework.Assert.AreEqual("SharepointFullName", sharepointList[0].FullName);
            NUnit.Framework.Assert.AreEqual("SharepointFullNameDup", sharepointList[1].FullName);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(SharepointSource))]
        [Ignore("Incompatible with the latest version of Moq.")]
        public void SharePointSource_Validate_LoadFieldsForList()
        {
            const string listName = "sharepointList";
            const bool editableFieldsOnly = false;

            var expectedSharepointList = new System.Collections.Generic.List<ISharepointFieldTo>
            {
                new SharepointFieldTo { Name = "SharepointName" },
                new SharepointFieldTo { Name = "SharepointNameDup" }
            };

            const string server = "localhost";
            const string userName = "testuser";
            const string password = "test123";
            const bool isSharepointOnline = false;

            var mockSharepointHelperFactory = new Mock<ISharepointHelperFactory>();
            mockSharepointHelperFactory.Setup(sharepointHelperFactory => sharepointHelperFactory.New(server, userName, password, isSharepointOnline).LoadFieldsForList(listName, editableFieldsOnly)).Returns(expectedSharepointList);

            var sharepointSource = new SharepointSource(mockSharepointHelperFactory.Object);

            var sharepointList = sharepointSource.LoadFieldsForList(listName);
            NUnit.Framework.Assert.AreEqual(2, sharepointList.Count);
            NUnit.Framework.Assert.AreEqual("SharepointName", sharepointList[0].Name);
            NUnit.Framework.Assert.AreEqual("SharepointNameDup", sharepointList[1].Name);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(SharepointSource))]
        public void SharePointSource_ShouldHaveConstructorAndSetDefaultValues()
        {
            var sharepointSource = new SharepointSource();
            NUnit.Framework.Assert.IsNotNull(sharepointSource);
            NUnit.Framework.Assert.AreEqual("SharepointServerSource", sharepointSource.ResourceType);
            sharepointSource.AuthenticationType = AuthenticationType.User;
            var xElement = sharepointSource.ToXml();
            NUnit.Framework.Assert.IsNotNull(xElement);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(SharepointSource))]
        public void SharePointSource_GivenNoURL_TestConnection_ShouldReturn()
        {
            var sharepointSource = new SharepointSource();
            NUnit.Framework.Assert.IsNotNull(sharepointSource);
            NUnit.Framework.Assert.AreEqual("SharepointServerSource", sharepointSource.ResourceType);
            sharepointSource.AuthenticationType = AuthenticationType.User;
            var testConnection = sharepointSource.TestConnection();
            NUnit.Framework.Assert.IsTrue(testConnection.Contains("Test Failed"));
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(SharepointSource))]
        public void SharePointSource_GivenXelement_ShouldHaveConstructorAndSetDefaultValues()
        {
            const string conStr = @"<Source ID=""2aa3fdba-e0c3-47dd-8dd5-e6f24aaf5c7a"" Name=""test server"" Type=""Dev2Server"" ConnectionString=""AppServerUri=http://178.63.172.163:3142/dsf;WebServerPort=3142;AuthenticationType=Public;UserName=;Password="" Version=""1.0"" ResourceType=""Server"" ServerID=""51a58300-7e9d-4927-a57b-e5d700b11b55"">
                                      <TypeOf>Dev2Server</TypeOf>
                                      <DisplayName>test server</DisplayName>
                                      <Category>WAREWOLF SERVERS</Category>
                                      <Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">
                                        <SignedInfo>
                                          <CanonicalizationMethod Algorithm=""http://www.w3.org/TR/2001/REC-xml-c14n-20010315"" />
                                          <SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1"" />
                                          <Reference URI="""">
                                            <Transforms>
                                              <Transform Algorithm=""http://www.w3.org/2000/09/xmldsig#enveloped-signature"" />
                                            </Transforms>
                                            <DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1"" />
                                            <DigestValue>1ia51dqx+BIMQ4QgLt+DuKtTBUk=</DigestValue>
                                          </Reference>
                                        </SignedInfo>
                                        <SignatureValue>Wqd39EqkFE66XVETuuAqZveoTk3JiWtAk8m1m4QykeqY4/xQmdqRRSaEfYBr7EHsycI3STuILCjsz4OZgYQ2QL41jorbwULO3NxAEhu4nrb2EolpoNSJkahfL/N9X5CvLNwpburD4/bPMG2jYegVublIxE50yF6ZZWG5XiB6SF8=</SignatureValue>
                                      </Signature>
                                    </Source>";

            var xElement = XElement.Parse(conStr);
            var sharepointSource = new SharepointSource(xElement);
            NUnit.Framework.Assert.IsNotNull(sharepointSource);
            NUnit.Framework.Assert.IsNotNull(sharepointSource.ResourceID);
            NUnit.Framework.Assert.AreEqual("SharepointServerSource", sharepointSource.ResourceType);
        }
    }
}
