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
    public partial class viewAll : Form
    {
        usercontrol uc;
        DataTable dt;
        public viewAll()
        {
            InitializeComponent();
        }
        private void viewAll_Load(object sender, EventArgs e)
        {
            bool l = loadGrid();
        }
        public bool loadGrid()
        {
            uc = new usercontrol();
            dt = uc.viewAll();
            dataGridView1.DataSource = dt;
            if(dataGridView1.DataSource!=null)
            {
                return true;
            }
            else { return false; }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Modify().ShowDialog();
            this.Close();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainMenu().ShowDialog();
            this.Close();
        }
    }
}
