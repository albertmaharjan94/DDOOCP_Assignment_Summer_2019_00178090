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
        int[] tTime;
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
        Player p1 = new player1();
        Player p2 = new player2();
        Language l = new Language();
        Timer gT; int timep1; int timep2;
        int c1=0;
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            gT = new Timer();
            tP1.Hide();tP2.Hide();
            timerG();
            uc = new usercontrol();            
            dt = uc.but1(MainMenu.wid);
            string[] langauge = uc.showLan(MainMenu.wid);
            l.Language1 = groupBox1.Text = langauge[0];
            l.Language2 = groupBox2.Text = langauge[1];
            string[] player = uc.PlayerName(InsertPlayer.id);
            p1.Name = lvlP1.Text = player[0];
            p2.Name = lblP2.Text = player[1];
            p1.Score = Convert.ToInt16(lblScoreP1.Text = "0");
            p2.Score = Convert.ToInt16(lblScoreP2.Text = "0");
            turn = "p1";
            bc = null;
            splitContainer1.Panel1.BackColor = Color.WhiteSmoke;
            splitContainer1.Panel2.BackColor = Color.Gray;
           
            numbers = rng();
            number2 = rng();
        }
        public int[] rng()
        {
            int[] number = new int[26];
            var counter = 0;
            do
            {
                Random random = new Random();
                var randomNumber = random.Next(1, 27);
                if (Array.IndexOf(number, randomNumber) == -1)
                {
                    number[counter] = randomNumber;
                    counter++;
                }
            } while (counter < 26);
            return number;
        }
        public int[] conTime(int num)
        {
            tTime = new int[2];
            int second = 0;
            int minutes = 0;
            int counter = 60;
            if (num <= counter)
            {
                second = num;
            }else
            {
                while (counter <= num)
                {
                    if (counter <= num)
                    {
                        minutes = minutes + 1;
                        second = num - counter;
                    }                    
                    counter = counter + 60;
                }
            }
            tTime[0] = minutes;tTime[1] = second;
            return tTime;
        }
        private void timerG()
        {
            gT.Start();
            gT.Interval = 1000;
            gT.Tick += (s, e) =>
            {
                c1 = c1 + 1;
                lblTime.Text = c1.ToString();
            };
        }
      
        private string check(string btntext, string temp, Button b1, Button b2)
        {
            int chk = MainMenu.wid;
            string dt2 = uc.chec(btntext, temp);            
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
                    timep1 = c1 - timep2;
                    tP1.Text = timep1.ToString();
                    turn = "p2";
                    splitContainer1.Panel2.BackColor = Color.WhiteSmoke;
                    splitContainer1.Panel1.BackColor = Color.Gray;                    
                }
                else
                {
                    timep2 = c1 - timep1;
                    tP2.Text = timep2.ToString();                 
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
        public bool grpAtrue(object bt)
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
        private bool grpBtrue(object bt)
        {
            Button bu = bt as Button;
            if (a2 == true)
            {
                btn1 = false;
                bc = null;
                temp = null;
                a2 = false;
                bu.Text = "Show";
                MessageBox.Show("Same not allowed");
                return true;
            }
            else { return false; }


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
            if(turn=="p1")
            {
                timep1 = c1 - timep2;
            }
            else
            {
                timep2 = c1 - timep1;
            }
            gT.Stop();
            if (p1.Score > p2.Score)
            {
                MessageBox.Show("CONGRATULATION!!"+"\n"+p1.Name + " Wins!!"+"\n"+p1.Name+" Score: "+p1.Score+" Time: " + timep1 +"\n"+p2.Name+" Score: "+p2.Score+" Time: "+timep2+"s","Albert's Mind Game");
            }
            else if (p2.Score > p1.Score)
            {
                MessageBox.Show("CONGRATULATION!!" + "\n"+p2.Name + " Wins!!" +"\n"+p1.Name+"  Score: "+p1.Score+" Time: " + timep1 +"\n"+p2.Name+" Score: "+p2.Score+" Time: "+timep2+"s", "Albert's Mind Game");
            }
            else if (p1.Score == p2.Score)
            {
                MessageBox.Show("TIE!!\nBetter Luck Next Time","Albert's Mind Game");
            }
            int[] tTg = conTime(c1);
            int[] tTp1 = conTime(timep1);
            int[] tTp2 = conTime(timep2);
            int gaid = uc.retrieveGameID();
            int upg = uc.updateScore(p1.Score, p2.Score, gaid, tTg, tTp1, tTp2);
            DialogResult dr = MessageBox.Show("Thanks For Playing.\nDo you want to see the Highscore Table?", "Albert's Mind Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                this.Hide();
                new HighScore().ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                new MainMenu().ShowDialog();
                this.Close();
            }
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
        private void grpB(object bu)
        {
            string ch = null;
            Button bt = bu as Button;
            if (btn1 == true)
            {
                ch = check(bt.Text, temp, bt, bc);
                btnBtrue();
            }
            else
            {
                btnBtrueElse(bt.Text, bt);
            }
            if (ch != null)
            {
                bc.Text = (ch);
                bt.Text = ch;
                a1 = false;
            }
            if (buttonC == 26)
            {
                gamestat();
            }
        }
        private void grpA(object bu)
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
            if (grpAtrue(bc)) { return; }
            btnA1.Text = dt.Rows[0]["word" + numbers[0] + ""].ToString();
            grpA(btnA1);
        }
        private void btnA2_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA2.Text = dt.Rows[0]["word" + numbers[1] + ""].ToString();
            grpA(btnA2);
        }
        private void btnA3_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA3.Text = dt.Rows[0]["word" + numbers[2] + ""].ToString();
            grpA(btnA3);
        }
        private void btnB1_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB1.Text = dt.Rows[1]["word" + number2[0] + ""].ToString();
            grpB(btnB1);
        }
        private void btnB2_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB2.Text = dt.Rows[1]["word" + number2[1] + ""].ToString();
            grpB(btnB2);
        }
        private void btnB3_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB3.Text = dt.Rows[1]["word" + number2[2] + ""].ToString();
            grpB(btnB3);
        }
        private void btnA4_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA4.Text = dt.Rows[0]["word" + numbers[3] + ""].ToString();
            grpA(btnA4);
        }
        private void btnA5_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA5.Text = dt.Rows[0]["word" + numbers[4] + ""].ToString();
            grpA(btnA5);
        }
        private void btnA6_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA6.Text = dt.Rows[0]["word" + numbers[5] + ""].ToString();
            grpA(btnA6);
        }
        private void btnA7_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA7.Text = dt.Rows[0]["word" + numbers[6] + ""].ToString();
            grpA(btnA7);
        }
        private void btnA8_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA8.Text = dt.Rows[0]["word" + numbers[7] + ""].ToString();
            grpA(btnA8);
        }
        private void btnA9_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA9.Text = dt.Rows[0]["word" + numbers[8] + ""].ToString();
            grpA(btnA9);
        }
        private void btnA10_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA10.Text = dt.Rows[0]["word" + numbers[9] + ""].ToString();
            grpA(btnA10);
        }
        private void btnA11_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA11.Text = dt.Rows[0]["word" + numbers[10] + ""].ToString();
            grpA(btnA11);
        }
        private void btnA12_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA12.Text = dt.Rows[0]["word" + numbers[11] + ""].ToString();
            grpA(btnA12);
        }
        private void btnA13_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA13.Text = dt.Rows[0]["word" + numbers[12] + ""].ToString();
            grpA(btnA13);
        }
        private void btnA14_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA14.Text = dt.Rows[0]["word" + numbers[13] + ""].ToString();
            grpA(btnA14);
        }
        private void btn15_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA15.Text = dt.Rows[0]["word" + numbers[14] + ""].ToString();
            grpA(btnA15);
        }
        private void btnA16_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA16.Text = dt.Rows[0]["word" + numbers[15] + ""].ToString();
            grpA(btnA16);
        }
        private void btnA17_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA17.Text = dt.Rows[0]["word" + numbers[16] + ""].ToString();
            grpA(btnA17);
        }
        private void btnA18_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA18.Text = dt.Rows[0]["word" + numbers[17] + ""].ToString();
            grpA(btnA18);
        }
        private void btnA19_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA19.Text = dt.Rows[0]["word" + numbers[18] + ""].ToString();
            grpA(btnA19);
        }
        private void btnA20_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA20.Text = dt.Rows[0]["word" + numbers[19] + ""].ToString();
            grpA(btnA20);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA21.Text = dt.Rows[0]["word" + numbers[20] + ""].ToString();
            grpA(btnA21);
        }
        private void btnA22_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA22.Text = dt.Rows[0]["word" + numbers[21] + ""].ToString();
            grpA(btnA22);
        }
        private void btnA23_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA23.Text = dt.Rows[0]["word" + numbers[22] + ""].ToString();
            grpA(btnA23);
        }
        private void btnA24_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA24.Text = dt.Rows[0]["word" + numbers[23] + ""].ToString();
            grpA(btnA24);
        }
        private void btnA25_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA25.Text = dt.Rows[0]["word" + numbers[24] + ""].ToString();
            grpA(btnA25);
        }
        private void btnA26_Click(object sender, EventArgs e)
        {
            if (grpAtrue(bc)) { return; }
            btnA26.Text = dt.Rows[0]["word" + numbers[25] + ""].ToString();
            grpA(btnA26);
        }
        private void btnB4_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB4.Text = dt.Rows[1]["word" + number2[3] + ""].ToString();
            grpB(btnB4);
        }
        private void btnB5_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB5.Text = dt.Rows[1]["word" + number2[4] + ""].ToString();
            grpB(btnB5);
        }
        private void btnB6_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB6.Text = dt.Rows[1]["word" + number2[5] + ""].ToString();
            grpB(btnB6);
        }
        private void btnB7_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB7.Text = dt.Rows[1]["word" + number2[6] + ""].ToString();
            grpB(btnB7);
        }
        private void btnB8_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB8.Text = dt.Rows[1]["word" + number2[7] + ""].ToString();
            grpB(btnB8);
        }
        private void btnB9_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB9.Text = dt.Rows[1]["word" + number2[8] + ""].ToString();
            grpB(btnB9);
        }
        private void btnB10_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB10.Text = dt.Rows[1]["word" + number2[9] + ""].ToString();
            grpB(btnB10);
        }
        private void btnB11_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB11.Text = dt.Rows[1]["word" + number2[10] + ""].ToString();
            grpB(btnB11);
        }
        private void btnB12_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB12.Text = dt.Rows[1]["word" + number2[11] + ""].ToString();
            grpB(btnB12);
        }
        private void btnB13_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB13.Text = dt.Rows[1]["word" + number2[12] + ""].ToString();
            grpB(btnB13);
        }
        private void btnB14_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB14.Text = dt.Rows[1]["word" + number2[13] + ""].ToString();
            grpB(btnB14);
        }
        private void btnB15_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB15.Text = dt.Rows[1]["word" + number2[14] + ""].ToString();
            grpB(btnB15);
        }
        private void btnB16_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB16.Text = dt.Rows[1]["word" + number2[15] + ""].ToString();
            grpB(btnB16);
        }
        private void btnB17_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB17.Text = dt.Rows[1]["word" + number2[16] + ""].ToString();
            grpB(btnB17);
        }
        private void btnB18_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB18.Text = dt.Rows[1]["word" + number2[17] + ""].ToString();
            grpB(btnB18);
        }
        private void btnB19_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB19.Text = dt.Rows[1]["word" + number2[18] + ""].ToString();
            grpB(btnB19);
        }
        private void btnB20_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB20.Text = dt.Rows[1]["word" + number2[19] + ""].ToString();
            grpB(btnB20);
        }
        private void btnB21_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB21.Text = dt.Rows[1]["word" + number2[20] + ""].ToString();
            grpB(btnB21);
        }
        private void btnB22_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB22.Text = dt.Rows[1]["word" + number2[21] + ""].ToString();
            grpB(btnB22);
        }
        private void btnB23_Click(object sender, EventArgs e)
        {            
            if (grpBtrue(bc)) { return; }
            btnB23.Text = dt.Rows[1]["word" + number2[22] + ""].ToString();
            grpB(btnB23);
        }
        private void btnB24_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB24.Text = dt.Rows[1]["word" + number2[23] + ""].ToString();
            grpB(btnB24);
        }
        private void btnB25_Click(object sender, EventArgs e)
        {
            if (grpBtrue(bc)) { return; }
            btnB25.Text = dt.Rows[1]["word" + number2[24] + ""].ToString();
            grpB(btnB25);
        }
        private void btnB26_Click(object sender, EventArgs e)
        {            
            if (grpBtrue(bc)) { return; }
            btnB26.Text = dt.Rows[1]["word" + number2[25] + ""].ToString();
            grpB(btnB26);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit to main menu?", "Albert's Mind Game", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                new MainMenu().ShowDialog();
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
