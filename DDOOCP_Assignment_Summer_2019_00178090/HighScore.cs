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
    public partial class HighScore : Form
    {
        usercontrol uc;
        DataSet ds;
        public HighScore()
        {
            InitializeComponent();
        }
        private void HighScore_Load(object sender, EventArgs e)
        {
            uc = new usercontrol();
            ds = new DataSet();
            loadTable1();
            loadTable2();
            loadTable3();            
        }
        private void loadTable1()
        {
            ds = uc.highScore1();
            dataGridView1.DataSource = ds.Tables[3];
        }
        private void loadTable2()
        {
            ds = uc.highScore2();
            dataGridView2.DataSource = ds.Tables[3];
        }
        private void loadTable3()
        {
            ds = uc.highScore3();
            dataGridView3.DataSource = ds.Tables[3];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainMenu().ShowDialog();
            this.Close();
        }
    }
}
