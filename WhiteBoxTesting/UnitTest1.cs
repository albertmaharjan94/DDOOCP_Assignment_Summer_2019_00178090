using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDOOCP_Assignment_Summer_2019_00178090;
using System.Windows;
using System.Data;

namespace WhiteBoxTesting
{
    [TestClass]
    public class UnitTest1
    {        
        [TestMethod]
        public void TestPlayerName()
        {
            usercontrol uc = new usercontrol();
            string[] actual;
            string[] expected = new string[2] { "albert", "aal" };

            actual = new string[2];
            
            actual=uc.PlayerName(2);
            Assert.AreEqual(expected[1], actual[1]);             
        }
        [TestMethod]
        public void TestLanguageName()
        {
            usercontrol uc = new usercontrol();
            string[] actual = new string[2];
            string[] expected = new string[2] { "English", "Nepali"};

            actual = uc.showLan(1);

            Assert.AreEqual(expected[1], actual[1]);

        }
        [TestMethod]
        public void TestUpdateWordSet()
        {
            usercontrol uc = new usercontrol();
            int actual;
            int expected = 1;
            actual = uc.updateWS("English and Nepali", 1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestTimeMinute()
        {
            Game g = new Game();            
            int[] actual;
            int[] expected = new int[2] {1,40};

            actual = g.conTime(100);

            Assert.AreEqual(expected[0], actual[0]);
        }
        [TestMethod]
        public void TestTimeSecond()
        {
            Game g = new Game();
            int[] actual;
            int[] expected = new int[2] {1, 40};

            actual = g.conTime(100);

            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void TestMainMenuComboBox()
        {
            MainMenu m = new MainMenu();
            bool actual;
            bool expected = true;

            actual=m.loadCombo();

            Assert.AreEqual(expected, actual);           
        }

        [TestMethod]
        public void TestHighscorePlayerNameOfWordsetEnglishNepali()
        {
            usercontrol uc = new usercontrol();
            DataSet ds = uc.highScore1();
            string actual;
            string expected = "Kimi";

            actual = ds.Tables[3].Rows[0][1].ToString();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestRetrievingGameID()
        {
            usercontrol uc = new usercontrol();
            int actual;
            int expected=1134;

            actual = uc.retrieveGameID();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRng()
        {
            Game g = new Game();
            int[] actual;        
            int[] expected = new int[1] { 1 };

            actual = g.rng();

            Assert.AreNotEqual(expected[0], actual[0]); 
        }
        [TestMethod]
        public void TestingModifyFormComboBox()
        {
            Modify m = new Modify();

            bool actual;
            bool expected = true;

            actual = m.loadComboBox();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestingViewAllFormForTableLoad()
        {
            viewAll va= new viewAll();
            bool actual;
            bool expected = true;

            actual = va.loadGrid();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestInsertWordSetNameAndRetrivingId()
        {
            usercontrol uc = new usercontrol();
            int actual;
            int expected = 23;

            actual = uc.insertWS("New");

            Assert.AreEqual(expected, actual);
        }

    }
}
