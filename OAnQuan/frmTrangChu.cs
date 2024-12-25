using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAnQuan
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmOAnQuan frmOAnQuan = new frmOAnQuan();
            frmOAnQuan.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmOAnQuan2 frmOAnQuan2 = new frmOAnQuan2();
            frmOAnQuan2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmHuongDan frmHuongDan = new frmHuongDan();
            frmHuongDan.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmOAnQuan3 frmOAnQuan3 = new frmOAnQuan3();
            frmOAnQuan3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmOAnQuan4 frmOAnQuan4 = new frmOAnQuan4();
            frmOAnQuan4.Show();
            this.Hide();
        }
    }
}
