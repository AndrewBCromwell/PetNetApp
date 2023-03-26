using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTest
{
    [TestClass]
    public class ReplyManagerTests
    {
        ReplyManager replyManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            replyManager = new ReplyManager(new DataAccessLayerFakes.ReplyAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveAllReplies()
        {
            int expectedResult = 2;
            int actualResult = 0;
            int postId = 1;

            actualResult = replyManager.RetrieveAllRepliesByPostId(postId).Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetrieveActiveReplies()
        {
            int expectedResult = 1;
            int actualResult = 0;
            int postId = 2;

            actualResult = replyManager.RetrieveActiveRepliesByPostId(postId).Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCountActiveReplies()
        {
            int expectedResult = 2;
            int actualResult = 0;
            int postId = 1;

            actualResult = replyManager.RetrieveCountActiveRepliesByPostId(postId);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestCountReplies()
        {
            int expectedResult = 1;
            int actualResult = 0;
            int postId = 2;

            actualResult = replyManager.RetrieveCountRepliesByPostId(postId);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
