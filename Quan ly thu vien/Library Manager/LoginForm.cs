using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Library_Manager
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        //Thread thread;
        public LoginForm()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUserName.Select();
            Utility.DATABASECONNECTION = new DatabaseConnection();
            if (!Utility.DATABASECONNECTION.verifyConnection())
            {
                MessageBox.Show("Không thể kết nối database!", "Thông báo!");
                Application.Exit();
            }
                
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            RouterForm router = new RouterForm();
            router.ShowDialog();
        }

            private void VerifyInput_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            for (int i = 0; i < textBox.TextLength; i++)
            {
                if (char.IsLetterOrDigit(textBox.Text[i]) == false)
                {
                    textBox.Text = textBox.Text.Remove(i, 1);
                    textBox.SelectionStart = i;
                    textBox.SelectionLength = 0;
                }
            }
        }

 

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {                
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            RegisterForm router = new RegisterForm();
            router.ShowDialog();
         
        }
    }
}
