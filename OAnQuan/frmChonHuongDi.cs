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
    public partial class frmChonHuongDi : Form
    {
        public string SelectedDirection { get; private set; } // Lưu hướng đi người chơi chọn
        public frmChonHuongDi()
        {
            InitializeComponent();
        }
        
        private void btnLeft_Click(object sender, EventArgs e)
        {
            SelectedDirection = "Left";  // Đặt giá trị cho hướng đi
            this.DialogResult = DialogResult.OK;  // Đóng Form với kết quả OK
            this.Close();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            SelectedDirection = "Right";  // Đặt giá trị cho hướng đi
            this.DialogResult = DialogResult.OK;  // Đóng Form với kết quả OK
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
