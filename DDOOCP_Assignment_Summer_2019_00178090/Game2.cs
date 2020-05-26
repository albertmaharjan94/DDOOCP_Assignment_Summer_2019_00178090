using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment_Summer_2019_00178090
{
    public partial class Game : Form
    {
        int[] numbers;
        int[] number2;
        int buttonC = 0;
        Button bc = new Button();
        string temp = null;
        bool btn1 = false;
        usercontrol uc;
        DataTable dt;
        bool a1 = false;
        bool a2 = false;
        string ch = null;
        string turn;   
        Player p1 = new Player();
        Player p2 = new Player();
        Language l = new Language();
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            uc = new usercontrol();            
            dt = uc.but1(MainMenu.wid);
            string[] langauge = uc.showLan(MainMenu.wid);
            l.Language1 = groupBox1.Text = langauge[0];
            l.Language2 = groupBox2.Text = langauge[1];
            string[] player = uc.PlayerName(Form1.id);
            p1.Name = lvlP1.Text = player[0];
            p2.Name = lblP2.Text = player[1];
            p1.Score = Convert.ToInt16(lblScoreP1.Text = "0");
            p2.Score = Convert.ToInt16(lblScoreP2.Text = "0");
            turn = "p1";
            bc = null;
            splitContainer1.Panel1.BackColor = Color.WhiteSmoke;
            splitContainer1.Panel2.BackColor = Color.Gray;
            //RNG1
            numbers = new int[26];
            var counter = 0;
            do
            {
                Random random = new Random();
                var randomNumber = random.Next(1, 27);
                if (Array.IndexOf(numbers, randomNumber) == -1)
                {
                    numbers[counter] = randomNumber;
                    counter++;
                }
            } while (counter < 26);
            //RNG2
            number2 = new int[26];
            var counter1 = 0;
            do
            {
                Random random2 = new Random();
                var randomNumber2 = random2.Next(1, 27);
                if (Array.IndexOf(number2, randomNumber2) == -1)
                {
                    number2[counter1] = randomNumber2;
                    counter1++;
                }
            } while (counter1 < 26);
        }
        private string check(string btntext, string temp, Button b1, Button b2)
        {
            int chk = MainMenu.wid;
            string dt2 = uc.chec(btntext, temp, 1);            
            if (dt2 == btntext)
            {
                MessageBox.Show("Matched");
                buttonC++;
                if(turn=="p1")
                {
                    lblScoreP1.Text = (p1.Score = p1.Score + 1).ToString();
                }
                if(turn=="p2")
                {
                    lblScoreP2.Text = (p2.Score = p2.Score + 1).ToString();
                }
                b1.Hide();
                b2.Hide();
                return null;
            }
            else
            {
                MessageBox.Show("Try Again");
                if (turn == "p1")
                {
                    turn = "p2";
                    splitContainer1.Panel2.BackColor = Color.WhiteSmoke;
                    splitContainer1.Panel1.BackColor = Color.Gray;
                    
                }
                else
                {
                    turn = "p1";
                    splitContainer1.Panel1.BackColor = Color.WhiteSmoke;
                    splitContainer1.Panel2.BackColor = Color.Gray;
                    
                }
                a2 = false;
                a1 = false;
                temp = null;
                btn1 = false;
                return "Show";
            }
        }
        
        private void a1True()
        {
            if (a1 == true)
            {
                btn1 = false;
                bc = null;
                temp = null;
                a1 = false;
            }

        }
        private bool grpAtrue(object bt)
        {
            Button bu = bt as Button;
            if (a1 == true)
            {
                btn1 = false;
                bc = null;
                temp = null;
                a1 = false;
                bu.Text = "Show";
                MessageBox.Show("Same not allowed");
                return true;    
            }
            else { return false; }

        }
        private void a2True()
        {
            if (a2 == true)
            {
                btn1 = false;
                bc = null;
                temp = null;
                a2 = false;

            }

        }
        private void btnAtrue()
        {
            btn1 = false;
            temp = null;
            a2 = false;
        }
        private void btnBtrue()
        {
            btn1 = false;
            temp = null;
            a1 = false;
        }
        private void gamestat()
        {
            if (p1.Score > p2.Score)
            {
                MessageBox.Show(p1.Name + " Wins!!");
            }
            else if (p2.Score > p1.Score)
            {
                MessageBox.Show(p2.Name + " Wins!!");
            }
            else if (p1.Score == p2.Score)
            {
                MessageBox.Show("TIE");
            }
            int upg = uc.updateScore(p1.Score, p2.Score, Form1.id);
        }
        private void btnAtrueElse(string bText, Button bu)
        {
            temp = bText;
            bc = bu;
            btn1 = true;
            a1 = true;
        }
        private void btnBtrueElse(string btext, Button bu)
        {
            btn1 = true;
            temp = btext;
            bc = bu;
            a2 = true;
        }
        public void grpA(object bu)
        {
            string ch = null;
            Button bt = bu as Button;
            if (btn1 == true)
            {
                ch = check(bt.Text, temp, bt, bc);
                btnAtrue();
            }
            else
            {
                btnAtrueElse(bt.Text, bt);                                
            }
            if (ch != null)
            {
                bc.Text = (ch);
                bt.Text = ch;
                a2 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }

        }
        private void btnA1_Click(object sender, EventArgs e)
        {

            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            ////}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;           
            //if (btn1 == true)
            //{
            //    ch = check(btnA1.Text, temp, btnA1, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA1.Text, btnA1);
            //    //temp = btnA1.Text;
            //    //bc = btnA1;                
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA1.Text = ch;
            //    a2 = false;
            //}
            //if(buttonC==26)
            //{
            //    gamestat();
            //}
            bool a = grpAtrue(bc);
            if (a == true) { return; }
            btnA1.Text = dt.Rows[0]["word" + numbers[0] + ""].ToString();
            grpA(btnA1);
        }
        private void btnA2_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA2.Text = dt.Rows[0]["word"+numbers[1]+""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA2.Text, temp, btnA2, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA2.Text, btnA2);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA2.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA2.Text = dt.Rows[0]["word" + numbers[1] + ""].ToString();
            grpA(btnA2);
        }
        private void btnA3_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA3.Text = dt.Rows[0]["word"+numbers[2]+""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA3.Text, temp, btnA3, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA3.Text, btnA3);
            //    //temp = btnA1.Text;
            //    //bc = btnA1;                
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA3.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA3.Text = dt.Rows[0]["word" + numbers[2] + ""].ToString();
            grpA(btnA3);

        }
        private void btnB1_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB1.Text = dt.Rows[1]["word"+number2[0]+""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB1.Text, temp, btnB1, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB1.Text, btnB1);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB1.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB2_Click(object sender, EventArgs e)
        {

            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB2.Text = dt.Rows[1]["word"+number2[1]+""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB2.Text, temp, btnB2, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB2.Text, btnB2);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB2.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
            //    if (a2 == true)
            //    {
            //        MessageBox.Show("Same Language is not allowed");
            //        bc.Text = "Click Me";
            //        btn1 = false;
            //        bc = null;
            //        temp = null;
            //        a2 = false;
            //        return;

            //    }
            //    uc = new usercontrol();
            //    dt = uc.but1(MainMenu.wid);
            //    string ch = null;
            //    btnB2.Text = dt.Rows[1]["word3"].ToString();
            //    if (btn1 == true)
            //    {
            //        ch = check(btnB2.Text, temp, btnB2, bc);
            //        btn1 = false;
            //        temp = null;
            //        a1 = false;
            //    }
            //    else
            //    {
            //        btn1 = true;
            //        temp = btnB2.Text;
            //        bc = btnB2;
            //        a2 = true;
            //    }
            //    if (ch != null)
            //    {
            //        bc.Text = (ch);
            //        btnB2.Text = ch;
            //        a1 = false;
            //    }
            //}
        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB3.Text = dt.Rows[1]["word" + number2[2] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB3.Text, temp, btnB3, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB3.Text, btnB3);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB3.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA4.Text = dt.Rows[0]["word" + numbers[3] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA4.Text, temp, btnA4, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA4.Text, btnA4);
            //    //temp = btnA1.Text;
            //    //bc = btnA1;                
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA4.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA4.Text = dt.Rows[0]["word" + numbers[3] + ""].ToString();
            grpA(btnA4);
        }

        private void btnA5_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA5.Text = dt.Rows[0]["word" + numbers[4] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA5.Text, temp, btnA5, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA5.Text, btnA5);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA5.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA5.Text = dt.Rows[0]["word" + numbers[4] + ""].ToString();
            grpA(btnA5);
        }

        private void btnA6_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA6.Text = dt.Rows[0]["word" + numbers[5] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA6.Text, temp, btnA6, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA6.Text, btnA6);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA6.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA6.Text = dt.Rows[0]["word" + numbers[5] + ""].ToString();
            grpA(btnA6);
        }

        private void btnA7_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA7.Text = dt.Rows[0]["word" + numbers[6] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA7.Text, temp, btnA7, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA7.Text, btnA7);           
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA7.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA7.Text = dt.Rows[0]["word" + numbers[6] + ""].ToString();
            grpA(btnA7);
        }

        private void btnA8_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA8.Text = dt.Rows[0]["word" + numbers[7] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA8.Text, temp, btnA8, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA8.Text, btnA8);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA8.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA8.Text = dt.Rows[0]["word" + numbers[7] + ""].ToString();
            grpA(btnA8);

        }

        private void btnA9_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA9.Text = dt.Rows[0]["word" + numbers[8] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA9.Text, temp, btnA9, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA9.Text, btnA9);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA9.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA9.Text = dt.Rows[0]["word" + numbers[8] + ""].ToString();
            grpA(btnA9);
        }

        private void btnA10_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA10.Text = dt.Rows[0]["word" + numbers[9] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA10.Text, temp, btnA10, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA10.Text, btnA10);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA10.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA10.Text = dt.Rows[0]["word" + numbers[9] + ""].ToString();
            grpA(btnA10);
        }

        private void btnA11_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null; 
            //btnA11.Text = dt.Rows[0]["word" + numbers[10] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA11.Text, temp, btnA11, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA11.Text, btnA11);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA11.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA11.Text = dt.Rows[0]["word" + numbers[10] + ""].ToString();
            grpA(btnA11);
        }

        private void btnA12_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA12.Text = dt.Rows[0]["word" + numbers[11] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA12.Text, temp, btnA12, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA12.Text, btnA12);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA12.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA12.Text = dt.Rows[0]["word" + numbers[11] + ""].ToString();
            grpA(btnA12);
        }

        private void btnA13_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA13.Text = dt.Rows[0]["word" + numbers[12] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA13.Text, temp, btnA13, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA13.Text, btnA13);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA13.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA13.Text = dt.Rows[0]["word" + numbers[12] + ""].ToString();
            grpA(btnA13);
        }

        private void btnA14_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA14.Text = dt.Rows[0]["word" + numbers[13] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA14.Text, temp, btnA14, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA14.Text, btnA14);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA14.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA14.Text = dt.Rows[0]["word" + numbers[13] + ""].ToString();
            grpA(btnA14);
        }
        private void btn15_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();

            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA15.Text = dt.Rows[0]["word" + numbers[14] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA15.Text, temp, btnA15, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA15.Text, btnA15);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA15.Text = ch;
            //    a2 = false;
            //}
            if (grpAtrue(bc)) { return; }
            btnA15.Text = dt.Rows[0]["word" + numbers[14] + ""].ToString();
            grpA(btnA15);

        }
        private void btnA16_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA16.Text = dt.Rows[0]["word" + numbers[15] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA16.Text, temp, btnA16, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA16.Text, btnA16);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA16.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA16.Text = dt.Rows[0]["word" + numbers[15] + ""].ToString();
            grpA(btnA16);
        }

        private void btnA17_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA17.Text = dt.Rows[0]["word" + numbers[16] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA17.Text, temp, btnA17, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA17.Text, btnA17);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA17.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA17.Text = dt.Rows[0]["word" + numbers[16] + ""].ToString();
            grpA(btnA17);
        }

        private void btnA18_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA18.Text = dt.Rows[0]["word" + numbers[17] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA18.Text, temp, btnA18, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA18.Text, btnA18);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA18.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA18.Text = dt.Rows[0]["word" + numbers[17] + ""].ToString();
            grpA(btnA18);
        }

        private void btnA19_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA19.Text = dt.Rows[0]["word" + numbers[18] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA19.Text, temp, btnA19, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA19.Text, btnA19);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA19.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA19.Text = dt.Rows[0]["word" + numbers[18] + ""].ToString();
            grpA(btnA19);
        }

        private void btnA20_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA20.Text = dt.Rows[0]["word" + numbers[19] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA20.Text, temp, btnA20, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA20.Text, btnA20);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA20.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA20.Text = dt.Rows[0]["word" + numbers[19] + ""].ToString();
            grpA(btnA20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA21.Text = dt.Rows[0]["word" + numbers[20] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA21.Text, temp, btnA21, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA21.Text, btnA21);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA21.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA21.Text = dt.Rows[0]["word" + numbers[20] + ""].ToString();
            grpA(btnA21);
        }

        private void btnA22_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA22.Text = dt.Rows[0]["word" + numbers[21] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA22.Text, temp, btnA22, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA22.Text, btnA22);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA22.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA22.Text = dt.Rows[0]["word" + numbers[21] + ""].ToString();
            grpA(btnA22);
        }

        private void btnA23_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA23.Text = dt.Rows[0]["word" + numbers[22] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA23.Text, temp, btnA23, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA23.Text, btnA23);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA23.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA23.Text = dt.Rows[0]["word" + numbers[22] + ""].ToString();
            grpA(btnA23);
        }

        private void btnA24_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA24.Text = dt.Rows[0]["word" + numbers[23] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA24.Text, temp, btnA24, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA24.Text, btnA24);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA24.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA24.Text = dt.Rows[0]["word" + numbers[23] + ""].ToString();
            grpA(btnA24);
        }

        private void btnA25_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA25.Text = dt.Rows[0]["word" + numbers[24] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA25.Text, temp, btnA25, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA25.Text, btnA25);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA25.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA25.Text = dt.Rows[0]["word" + numbers[24] + ""].ToString();
            grpA(btnA25);
        }

        private void btnA26_Click(object sender, EventArgs e)
        {
            //if (a1 == true)
            //{
            //    MessageBox.Show("Same Language is not allowed");
            //    bc.Text = "Show";
            //    a1True();
            //    return;
            //}
            //uc = new usercontrol();
            //dt = uc.but1(MainMenu.wid);
            //string ch = null;
            //btnA26.Text = dt.Rows[0]["word" + numbers[25] + ""].ToString();
            //if (btn1 == true)
            //{
            //    ch = check(btnA26.Text, temp, btnA26, bc);
            //    btnAtrue();
            //}
            //else
            //{
            //    btnAtrueElse(btnA26.Text, btnA26);
            //}
            //if (ch != null)
            //{
            //    bc.Text = (ch);
            //    btnA26.Text = ch;
            //    a2 = false;
            //}
            //if (buttonC == 26)
            //{
            //    gamestat();
            //}
            if (grpAtrue(bc)) { return; }
            btnA26.Text = dt.Rows[0]["word" + numbers[25] + ""].ToString();
            grpA(btnA26);
        }

        private void btnB4_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB4.Text = dt.Rows[1]["word" + number2[3] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB4.Text, temp, btnB4, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB4.Text, btnB4);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB4.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB5_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB5.Text = dt.Rows[1]["word" + number2[4] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB5.Text, temp, btnB5, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB5.Text, btnB5);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB5.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB6_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB6.Text = dt.Rows[1]["word" + number2[5] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB6.Text, temp, btnB6, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB6.Text, btnB6);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB6.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB7_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB7.Text = dt.Rows[1]["word" + number2[6] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB7.Text, temp, btnB7, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB7.Text, btnB7);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB7.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB8_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB8.Text = dt.Rows[1]["word" + number2[7] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB8.Text, temp, btnB8, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB8.Text, btnB8);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB8.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB9_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB9.Text = dt.Rows[1]["word" + number2[8] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB9.Text, temp, btnB9, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB9.Text, btnB9);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB9.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB10_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB10.Text = dt.Rows[1]["word" + number2[9] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB10.Text, temp, btnB10, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB10.Text, btnB10);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB10.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB11_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB11.Text = dt.Rows[1]["word" + number2[10] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB11.Text, temp, btnB11, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB11.Text, btnB11);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB11.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB12_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB12.Text = dt.Rows[1]["word" + number2[11] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB12.Text, temp, btnB12, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB12.Text, btnB12);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB12.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB13_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB13.Text = dt.Rows[1]["word" + number2[12] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB13.Text, temp, btnB13, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB13.Text, btnB13);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB13.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB14_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB14.Text = dt.Rows[1]["word" + number2[13] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB14.Text, temp, btnB14, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB14.Text, btnB14);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB14.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB15_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB15.Text = dt.Rows[1]["word" + number2[14] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB15.Text, temp, btnB15, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB15.Text, btnB15);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB15.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB16_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB16.Text = dt.Rows[1]["word" + number2[15] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB16.Text, temp, btnB16, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB16.Text, btnB16);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB16.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB17_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB17.Text = dt.Rows[1]["word" + number2[16] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB17.Text, temp, btnB17, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB17.Text, btnB17);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB17.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB18_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB18.Text = dt.Rows[1]["word" + number2[17] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB18.Text, temp, btnB18, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB18.Text, btnB18);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB18.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB19_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB19.Text = dt.Rows[1]["word" + number2[18] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB19.Text, temp, btnB19, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB19.Text, btnB19);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB19.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB20_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB20.Text = dt.Rows[1]["word" + number2[19] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB20.Text, temp, btnB20, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB20.Text, btnB20);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB20.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB21_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB21.Text = dt.Rows[1]["word" + number2[20] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB21.Text, temp, btnB21, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB21.Text, btnB21);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB21.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB22_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB22.Text = dt.Rows[1]["word" + number2[21] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB22.Text, temp, btnB22, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB22.Text, btnB22);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB22.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB23_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB23.Text = dt.Rows[1]["word" + number2[22] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB23.Text, temp, btnB23, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB23.Text, btnB23);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB23.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB24_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB24.Text = dt.Rows[1]["word" + number2[23] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB24.Text, temp, btnB24, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB24.Text, btnB24);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB24.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB25_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB25.Text = dt.Rows[1]["word" + number2[24] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB25.Text, temp, btnB25, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB25.Text, btnB25);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB25.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void btnB26_Click(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                MessageBox.Show("Same Language is not allowed");
                bc.Text = "Show";
                a2True();
                return;
            }
            uc = new usercontrol();
            dt = uc.but1(MainMenu.wid);
            string ch = null;
            btnB26.Text = dt.Rows[1]["word" + number2[25] + ""].ToString();
            if (btn1 == true)
            {
                ch = check(btnB26.Text, temp, btnB26, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(btnB26.Text, btnB26);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                btnB26.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new MainMenu().ShowDialog();
            this.Close();
        }
    }
}
