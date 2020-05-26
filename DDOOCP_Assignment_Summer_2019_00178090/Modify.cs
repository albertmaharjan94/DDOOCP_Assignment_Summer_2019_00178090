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
    public partial class Modify : Form
    {
        usercontrol uc;
        DataTable dt;
        string[] l1;
        string[] l2;
        public Modify()
        {
            InitializeComponent();
        }

        private void Modify_Load(object sender, EventArgs e)
        {            
            cmbWs.ValueMember = "1";
            bool l=loadComboBox();          
        }
        public bool loadComboBox()
        {
            usercontrol uc = new usercontrol();
            dt = uc.sWordset();            
            cmbWs.DataSource = dt;
            cmbWs.DisplayMember = "ws_Name";
            cmbWs.ValueMember = "ws_Id";
            if(cmbWs.DataSource==null)
            {
                return false;
            }
            else { return true; }
        }

        private void cmbWs_SelectedIndexChanged(object sender, EventArgs e)
        {
            uc = new usercontrol();
            dt = uc.selectAllLan(Convert.ToInt16(cmbWs.SelectedValue));
            //DataTable dt = uc.selectAllLan(1);
            txtL1.Text = dt.Rows[0][1].ToString(); txtL1W1.Text = dt.Rows[0]["word1"].ToString(); txtL1W2.Text = dt.Rows[0]["word2"].ToString(); txtL1W3.Text = dt.Rows[0]["word3"].ToString(); txtL1W4.Text = dt.Rows[0]["word4"].ToString(); txtL1W5.Text = dt.Rows[0]["word5"].ToString(); txtL1W6.Text = dt.Rows[0]["word6"].ToString(); txtL1W7.Text = dt.Rows[0]["word7"].ToString(); txtL1W8.Text = dt.Rows[0]["word8"].ToString(); txtL1W9.Text = dt.Rows[0]["word9"].ToString(); txtL1W10.Text = dt.Rows[0]["word10"].ToString(); txtL1W11.Text = dt.Rows[0]["word11"].ToString(); txtL1W12.Text = dt.Rows[0]["word12"].ToString(); txtL1W13.Text = dt.Rows[0]["word13"].ToString(); txtL1W14.Text = dt.Rows[0]["word14"].ToString(); txtL1W15.Text = dt.Rows[0]["word15"].ToString(); txtL1W16.Text = dt.Rows[0]["word16"].ToString(); txtL1W17.Text = dt.Rows[0]["word17"].ToString(); txtL1W18.Text = dt.Rows[0]["word18"].ToString(); txtL1W19.Text = dt.Rows[0]["word19"].ToString(); txtL1W20.Text = dt.Rows[0]["word20"].ToString(); txtL1W21.Text = dt.Rows[0]["word21"].ToString(); txtL1W22.Text = dt.Rows[0]["word22"].ToString(); txtL1W23.Text = dt.Rows[0]["word23"].ToString(); txtL1W24.Text = dt.Rows[0]["word24"].ToString(); txtL1W25.Text = dt.Rows[0]["word25"].ToString(); txtL1W26.Text = dt.Rows[0]["word26"].ToString();
            txtL2.Text = dt.Rows[1][1].ToString(); txtL2W1.Text = dt.Rows[1]["word1"].ToString(); txtL2W2.Text = dt.Rows[1]["word2"].ToString(); txtL2W3.Text = dt.Rows[1]["word3"].ToString(); txtL2W4.Text = dt.Rows[1]["word4"].ToString(); txtL2W5.Text = dt.Rows[1]["word5"].ToString(); txtL2W6.Text = dt.Rows[1]["word6"].ToString(); txtL2W7.Text = dt.Rows[1]["word7"].ToString(); txtL2W8.Text = dt.Rows[1]["word8"].ToString(); txtL2W9.Text = dt.Rows[1]["word9"].ToString(); txtL2W10.Text = dt.Rows[1]["word10"].ToString(); txtL2W11.Text = dt.Rows[1]["word11"].ToString(); txtL2W12.Text = dt.Rows[1]["word12"].ToString(); txtL2W13.Text = dt.Rows[1]["word13"].ToString(); txtL2W14.Text = dt.Rows[1]["word14"].ToString(); txtL2W15.Text = dt.Rows[1]["word15"].ToString(); txtL2W16.Text = dt.Rows[1]["word16"].ToString(); txtL2W17.Text = dt.Rows[1]["word17"].ToString(); txtL2W18.Text = dt.Rows[1]["word18"].ToString(); txtL2W19.Text = dt.Rows[1]["word19"].ToString(); txtL2W20.Text = dt.Rows[1]["word20"].ToString(); txtL2W21.Text = dt.Rows[1]["word21"].ToString(); txtL2W22.Text = dt.Rows[1]["word22"].ToString(); txtL2W23.Text = dt.Rows[1]["word23"].ToString(); txtL2W24.Text = dt.Rows[1]["word24"].ToString(); txtL2W25.Text = dt.Rows[1]["word25"].ToString(); txtL2W26.Text = dt.Rows[1]["word26"].ToString();     
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to update the data?", "Albert's Mind Game", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                uc = new usercontrol();
                l1 = new string[27] { txtL1.Text, txtL1W1.Text, txtL1W2.Text, txtL1W3.Text, txtL1W4.Text, txtL1W5.Text, txtL1W6.Text, txtL1W7.Text, txtL1W8.Text, txtL1W9.Text, txtL1W10.Text, txtL1W11.Text, txtL1W12.Text, txtL1W13.Text, txtL1W14.Text, txtL1W15.Text, txtL1W16.Text, txtL1W17.Text, txtL1W18.Text, txtL1W19.Text, txtL1W20.Text, txtL1W21.Text, txtL1W22.Text, txtL1W23.Text, txtL1W24.Text, txtL1W25.Text, txtL1W26.Text };
                l2 = new string[27] { txtL2.Text, txtL2W1.Text, txtL2W2.Text, txtL2W3.Text, txtL2W4.Text, txtL2W5.Text, txtL2W6.Text, txtL2W7.Text, txtL2W8.Text, txtL2W9.Text, txtL2W10.Text, txtL2W11.Text, txtL2W12.Text, txtL2W13.Text, txtL2W14.Text, txtL2W15.Text, txtL2W16.Text, txtL2W17.Text, txtL2W18.Text, txtL2W19.Text, txtL2W20.Text, txtL2W21.Text, txtL2W22.Text, txtL2W23.Text, txtL2W24.Text, txtL2W25.Text, txtL2W26.Text };
                //uc.updateWords(l1, l2, Convert.ToInt16(cmbWs.SelectedValue));
                int counter = 0;
                while (counter < 27)
                {
                    if (l1[counter].Equals("") || l2[counter].Equals(""))
                    {
                        MessageBox.Show("Please Fill all the fields");
                        return;
                    }
                }
                int ret = uc.updateWords(l1, l2, Convert.ToInt16(cmbWs.SelectedValue));
                if (ret > 0)
                {
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainMenu().ShowDialog();
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("All the data will be lost, do you wish to continue?", "Albert's Mind Game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int ret = uc.deleteWs(Convert.ToInt16(cmbWs.SelectedValue));
                if (ret > 0)
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else { return; }
            this.Hide();
            new MainMenu().ShowDialog();
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            new viewAll().ShowDialog();
            this.Close();
        }
    }
}
