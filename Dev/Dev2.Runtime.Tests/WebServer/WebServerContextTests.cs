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
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using Dev2.Runtime.WebServer;
using Dev2.Runtime.WebServer.Responses;
using NUnit.Framework;
using Moq;
using System.IO;
using Warewolf.UnitTestAttributes;

namespace Dev2.Tests.Runtime.WebServer
{
    [TestFixture]
    [Category("Runtime WebServer")]
    public class WebServerContextTests
    {
        [Test]
        [Author("Trevor Williams-Ros")]
        [Category("WebServerContext")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WebServerContext_Constructor_NullRequest_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            var context = new WebServerContext(null, null);

            //------------Assert Results-------------------------
        }

        [Test]
        [Author("Trevor Williams-Ros")]
        [Category("WebServerContext")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WebServerContext_Constructor_NullRequestPaths_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            var context = new WebServerContext(new HttpRequestMessage(), null);

            //------------Assert Results-------------------------
        }

        [Test]
        [Author("Trevor Williams-Ros")]
        [Category("WebServerContext")]
        public void WebServerContext_Constructor_PropertiesInitialized()
        {
            var request = WebServerRequestTests.CreateHttpRequest(out string content, out NameValueCollection boundVars, out NameValueCollection queryStr, out NameValueCollection headers);

            //------------Execute Test---------------------------
            var context = new WebServerContext(request, boundVars);

            //------------Assert Results-------------------------
            Assert.IsNotNull(context.ResponseMessage);
            Assert.IsNotNull(context.Request);
            Assert.IsNotNull(context.Response);
            CollectionAssert.AreEqual(headers, context.FetchHeaders());

            WebServerRequestTests.VerifyProperties(request, (WebServerRequest)context.Request, content, queryStr, boundVars);
        }

        [Test]
        [Author("Trevor Williams-Ros")]
        [Category("WebServerContext")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WebServerContext_Send_ResponseIsNull_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------            
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/services")
            {
                Content = new StringContent("", Encoding.UTF8)
            };
            var context = new WebServerContext(request, new NameValueCollection());

            //------------Execute Test---------------------------
            context.Send(null);

            //------------Assert Results-------------------------
        }

        [Test]
        [Author("Trevor Williams-Ros")]
        [Category("WebServerContext")]
        public void WebServerContext_Send_ResponseIsNotNull_InvokesWriteOnResponse()
        {
            //------------Setup for test--------------------------            
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/services")
            {
                Content = new StringContent("", Encoding.UTF8)
            };
            var context = new WebServerContext(request, new NameValueCollection());

            var response = new Mock<IResponseWriter>();
            response.Setup(r => r.Write(It.IsAny<WebServerContext>())).Verifiable();         

            //------------Execute Test---------------------------
            context.Send(response.Object);

            //------------Assert Results-------------------------
            response.Verify(r => r.Write(It.IsAny<WebServerContext>()));
        }

        [Test]
        [Author("Ashley Lewis")]
        [Category("WebServerContext")]
        public void WebServerContext_Dispose_InputStreamIsClosed()
        {
            //------------Setup for test--------------------------            
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/services")
            {
                Content = new StringContent("", Encoding.UTF8)
            };
            var context = new WebServerContext(request, new NameValueCollection());

            //------------Execute Test---------------------------
            context.Dispose();

            //------------Assert Results-------------------------
            Assert.IsFalse(context.Request.InputStream.CanRead, "WebServerContext Request input stream not null after dispose.");
        }
    }
}
