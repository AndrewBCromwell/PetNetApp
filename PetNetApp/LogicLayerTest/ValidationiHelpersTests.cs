using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;

namespace LogicLayerTest
{
    [TestClass]
    public class ValidationiHelpersTests
    {
        [TestMethod]
        public void TestBadEmails()
        {
            string badEmail1 = "@.";
            string badEmail2 = "a@a.a";
            string badEmail3 = "abc@ab$c.com";
            string badEmail4 = "abc#@td.td";
            string badEmail5 = "abc-@ab.ab";
            string badEmail6 = "abc..abc@abc.abc";
            string badEmail7 = "abc--abc@abc.abc";
            string badEmail8 = "abc-abc.abc.abc";
            string badEmail9 = "abc_abc@abc@abc";
            string badEmail10 = "abc.abc@abc";
            string badEmail11 = "abc.abc@abc..com";
            string badEmail12 = "abc.abc@abc-com";
            string badEmail13 = "abc.abc@abc!com";
            string badEmail14 = "abc.abc@.abccom";
            string badEmail15 = "abc@abc@asdf.abccom";
            string badEmail16 = "abcc.@asdf.abccom";
            string badEmail17 = "abc-.abc@abc.abc";
            string badEmail18 = "abc-_abc@abc.abc";
            string badEmail19 = "abc_.abc@abc.abc";
            string badEmail20 = "abc__abc@abc.abc";
            string badEmail21 = ".abc_abc@abc.abc";
            string badEmail22 = "abcdefghijkabcdefghijkabcdefghijkabcdefghijkabcdefghijkabcdefghijkabcdefghijk@abc.abc";
            string badEmail23 = "abcdefghijkabcdefghijkabcdefghijkabcdefghijcdefghijkabcdefghijk4@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz.abc";
            string badEmail24 = "abc_abc@--c.abc";


            Assert.IsFalse(badEmail1.IsValidEmail()); 
            Assert.IsFalse(badEmail2.IsValidEmail()); 
            Assert.IsFalse(badEmail3.IsValidEmail()); 
            Assert.IsFalse(badEmail4.IsValidEmail()); 
            Assert.IsFalse(badEmail5.IsValidEmail()); 
            Assert.IsFalse(badEmail6.IsValidEmail()); 
            Assert.IsFalse(badEmail7.IsValidEmail()); 
            Assert.IsFalse(badEmail8.IsValidEmail()); 
            Assert.IsFalse(badEmail9.IsValidEmail());
            Assert.IsFalse(badEmail10.IsValidEmail());
            Assert.IsFalse(badEmail11.IsValidEmail());
            Assert.IsFalse(badEmail12.IsValidEmail());
            Assert.IsFalse(badEmail13.IsValidEmail());
            Assert.IsFalse(badEmail14.IsValidEmail());
            Assert.IsFalse(badEmail15.IsValidEmail());
            Assert.IsFalse(badEmail16.IsValidEmail());
            Assert.IsFalse(badEmail17.IsValidEmail());
            Assert.IsFalse(badEmail18.IsValidEmail());
            Assert.IsFalse(badEmail19.IsValidEmail());
            Assert.IsFalse(badEmail20.IsValidEmail());
            Assert.IsFalse(badEmail21.IsValidEmail());
            Assert.IsFalse(badEmail22.IsValidEmail());
            Assert.IsFalse(badEmail23.IsValidEmail());
            Assert.IsFalse(badEmail24.IsValidEmail());
        }

        [TestMethod]
        public void TestGoodEmails()
        {
            string goodEmail1 = "abc.abc.abc@abc.abc-abc";
            string goodEmail2 = "abcdefghijkabcdefghijkabcdefghijkabcdefgdhijcdefgijkabcdefghijk4@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxywxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz.abc";
            string goodEmail3 = "b@a.ab";
            string goodEmail4 = "abc.abc_abc@abc.abc.abc";
            string goodEmail5 = "abc_abcabc@abc.abc.abc";
            string goodEmail6 = "abc@abc.abc";
            string goodEmail7 = "b@ac.ab";
            string goodEmail8 = "a0_12@abc.abc";
            string goodEmail9 = "01-a0@abc.abc";
            string goodEmail10 = "abc.abc@amazon.co.uk.international";
            string goodEmail11 = "k0123456@student.kirkwood.edu";
            string goodEmail12 = "stephen-jaurigue@student.kirkwood.edu";

            Assert.IsTrue(goodEmail1.IsValidEmail());
            Assert.IsTrue(goodEmail2.IsValidEmail());
            Assert.IsTrue(goodEmail3.IsValidEmail());
            Assert.IsTrue(goodEmail4.IsValidEmail());
            Assert.IsTrue(goodEmail5.IsValidEmail());
            Assert.IsTrue(goodEmail6.IsValidEmail());
            Assert.IsTrue(goodEmail7.IsValidEmail());
            Assert.IsTrue(goodEmail8.IsValidEmail());
            Assert.IsTrue(goodEmail9.IsValidEmail());
            Assert.IsTrue(goodEmail10.IsValidEmail());
            Assert.IsTrue(goodEmail11.IsValidEmail());
            Assert.IsTrue(goodEmail12.IsValidEmail());
        }
    
        [TestMethod]
        public void TestBadAmounts()
        {
            string badAmount1 = "00";
            string badAmount2 = "123456.12";
            string badAmount3 = "12345.";
            string badAmount4 = "123.123";
            string badAmount5 = ".12";
            string badAmount6 = "ab.ab";
            string badAmount7 = "80.a";
            string badAmount8 = "a.21";
            string badAmount9 = "123456";
            string badAmount10 = "001.12";

            Assert.IsFalse(badAmount1.IsValidAmount());
            Assert.IsFalse(badAmount2.IsValidAmount());
            Assert.IsFalse(badAmount3.IsValidAmount());
            Assert.IsFalse(badAmount4.IsValidAmount());
            Assert.IsFalse(badAmount5.IsValidAmount());
            Assert.IsFalse(badAmount6.IsValidAmount());
            Assert.IsFalse(badAmount7.IsValidAmount());
            Assert.IsFalse(badAmount8.IsValidAmount());
            Assert.IsFalse(badAmount9.IsValidAmount());
            Assert.IsFalse(badAmount10.IsValidAmount());
        }

        [TestMethod]
        public void TestGoodAmounts()
        {
            string goodAmount1 = "12.1";
            string goodAmount2 = "0.0";
            string goodAmount3 = "0.12";
            string goodAmount4 = "12345.12";
            string goodAmount5 = "12.00";
            string goodAmount6 = "9.99";
            string goodAmount7 = "0";
            string goodAmount8 = "9";
            string goodAmount9 = "12345";
            string goodAmount10 = "90000";

            Assert.IsTrue(goodAmount1.IsValidAmount());
            Assert.IsTrue(goodAmount2.IsValidAmount());
            Assert.IsTrue(goodAmount3.IsValidAmount());
            Assert.IsTrue(goodAmount4.IsValidAmount());
            Assert.IsTrue(goodAmount5.IsValidAmount());
            Assert.IsTrue(goodAmount6.IsValidAmount());
            Assert.IsTrue(goodAmount7.IsValidAmount());
            Assert.IsTrue(goodAmount8.IsValidAmount());
            Assert.IsTrue(goodAmount9.IsValidAmount());
            Assert.IsTrue(goodAmount10.IsValidAmount());
        }

        [TestMethod]
        public void TestBadShortDescription()
        {
            string badShortDesc1;
        }
    }
}
