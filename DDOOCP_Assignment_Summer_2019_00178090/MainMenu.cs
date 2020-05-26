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
    public partial class MainMenu : Form
    {
        public static int wid;
        usercontrol uc;
        DataTable dt;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            bool l=loadCombo();           
        }
        public bool loadCombo()
        {
            uc = new usercontrol();
            dt = uc.sWordset();
            cbmWs.DataSource = dt;
            cbmWs.DisplayMember = "ws_Name";
            cbmWs.ValueMember = "ws_Id";
            if (cbmWs.DataSource != null)
            {
                return true;
            }
            else { return false; }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            wid = Convert.ToInt16(cbmWs.SelectedValue);
            this.Hide();
            new InsertPlayer().ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit this game?", "Albert's Mind Game", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else { return; }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateForm().ShowDialog();
            this.Close();

        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Modify().ShowDialog();
            this.Close();
        }

        private void cbmWs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HighScore().ShowDialog();
            this.Close();
        }
    }
}
