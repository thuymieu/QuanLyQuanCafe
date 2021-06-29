using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manager
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != "" && txtPasswordConfrim.Text != "" && txtUserName.Text != "")
            {
                if (txtPassword.Text == txtPasswordConfrim.Text)
                {
                    if (SysAccount.CreateAccount(txtUserName.Text, txtPassword.Text))
                    {
                        MessageBox.Show("Tạo tài khoản thành công", "Thành công!");
                        this.Hide();
                        this.Close();
       

                    }

                    else
                        MessageBox.Show("Tên tài khoản đã đăng ký", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else 
                {
                    MessageBox.Show("Mật khẩu xác nhận chưa trùng với mật khẩu", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
            else
            {
                MessageBox.Show("Phải điền đầy đủ thông tin các ô", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
              
        }

        private void txtPasswordConfrim_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text == txtPasswordConfrim.Text)
            {
                labelcheck.ForeColor = System.Drawing.Color.Green;
                labelcheck.Text = "Ok";
                
            }
            else
            {
                labelcheck.ForeColor = System.Drawing.Color.Red;
                labelcheck.Text = "!";
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
