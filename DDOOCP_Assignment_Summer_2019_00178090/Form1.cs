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
    public partial class InsertPlayer : Form
    {
        Player p1; Player p2;
        public static int id;
        public InsertPlayer()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            if (txtN1.Text.Equals("") || txtN2.Text.Equals(""))
            {
                MessageBox.Show("Please Fill the Name");
                return;
            }
            else
            {
                insertB();
                this.Hide();
                new Game().ShowDialog();
                this.Close();
            }
        }
        public void insertB()
        {
            usercontrol uc = new usercontrol();
            p1 = new Player(txtN1.Text);
            p2 = new Player(txtN2.Text);
            id = uc.insertPlayer(p1.Name, p2.Name);
        }
        private void btnB_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainMenu().ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p1 = new player1();
            p2 = new player2();
        }
    }
}
