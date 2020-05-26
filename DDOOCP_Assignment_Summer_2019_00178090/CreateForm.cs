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
    public partial class CreateForm : Form
    {
        usercontrol uc;
        int ret;
        int ret2;
        string[] l1;
        string[] l2;
        public CreateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            l1 = new string[27] { txtL1.Text, txtL1W1.Text, txtL1W2.Text, txtL1W3.Text, txtL1W4.Text, txtL1W5.Text, txtL1W6.Text, txtL1W7.Text, txtL1W8.Text, txtL1W9.Text, txtL1W10.Text, txtL1W11.Text, txtL1W12.Text, txtL1W13.Text, txtL1W14.Text, txtL1W15.Text, txtL1W16.Text, txtL1W17.Text, txtL1W18.Text, txtL1W19.Text, txtL1W20.Text, txtL1W21.Text, txtL1W22.Text, txtL1W23.Text, txtL1W24.Text, txtL1W25.Text, txtL1W26.Text };
            l2 = new string[27] { txtL2.Text, txtL2W1.Text, txtL2W2.Text, txtL2W3.Text, txtL2W4.Text, txtL2W5.Text, txtL2W6.Text, txtL2W7.Text, txtL2W8.Text, txtL2W9.Text, txtL2W10.Text, txtL2W11.Text, txtL2W12.Text, txtL2W13.Text, txtL2W14.Text, txtL2W15.Text, txtL2W16.Text, txtL2W17.Text, txtL2W18.Text, txtL2W19.Text, txtL2W20.Text, txtL2W21.Text, txtL2W22.Text, txtL2W23.Text, txtL2W24.Text, txtL2W25.Text, txtL2W26.Text };
            int counter = 0;
            if (txtWS.Text.Equals(""))
            {
                MessageBox.Show("Please Insert wordset name");
                return;
            }
            while (counter < 27)
            {
                if (l1[counter].Equals("") || l2[counter].Equals(""))
                {
                    MessageBox.Show("Please Fill all the fields");
                    return;
                }
                counter = counter+1;
            }            
            ret =uc.insertWS(txtWS.Text);
            ret2=uc.insertWords(l1, l2, ret);
            if (ret2 > 0)
            {
                MessageBox.Show("Succesfully Added");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainMenu().ShowDialog();
            this.Close();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            uc = new usercontrol();
        }
    }
}
