using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Library_Manager
{
    public partial class StudentForm : DevExpress.XtraEditors.XtraForm
    {
        string imgLogcation = "";
        DataTable table;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void timeSystem_Tick(object sender, EventArgs e)
        {
            lblTimeSys.Text = " | " + DateTime.Now.ToLongTimeString();
        }

        private void setAutoComplete()
        {
            txtName.AutoCompleteMode = txtEmail.AutoCompleteMode = txtId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtId.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var txtNameAutoCompleteCustomsource = new AutoCompleteStringCollection();
            txtNameAutoCompleteCustomsource.AddRange(Student.getStudentName());
            txtName.AutoCompleteCustomSource = txtNameAutoCompleteCustomsource;
            //Id
            txtName.AutoCompleteMode = txtEmail.AutoCompleteMode = txtId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtId.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var txtIdAutoCompleteCustomsource = new AutoCompleteStringCollection();
            txtIdAutoCompleteCustomsource.AddRange(Student.getStudentId());
            txtId.AutoCompleteCustomSource = txtIdAutoCompleteCustomsource;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            lblAccount.Text = Utility.ACCOUNT;
            setLabel("chưa chọn");
            setButton("", false);
            rbtnFindbyId.Visible = rbtnFindbyName.Visible = false;
            //set txt source
            //name
            setAutoComplete();
        }

        private void setButton(string btn, bool status)
        {
            switch (btn)
            {
                case "find":
                    #region FIND
                    //set button
                    btnMode.Enabled = btnReset.Enabled = tsbtnFindMode.Enabled = status; 
                    //set menu strip
                    tsbtnAddMode.Enabled = tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = !status;
                    //set tool trip menu
                    thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = btnAddImage.Enabled = !status;
                    //set txt no need
                    txtEmail.Enabled = txtPhone.Enabled = !status;
                    //Set rbtn find
                    rbtnFindbyId.Select();
                    rbtnFindbyName.Visible = rbtnFindbyId.Visible = false;
                    txtName.Enabled = false;
                    break;
                    #endregion FIND
                case "add":
                    #region ADD
                
                    btnAddImage.Enabled = btnMode.Enabled = btnReset.Enabled = tsbtnAddMode.Enabled = status;

                    tsbtnFindMode.Enabled = tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = !status;

                    tìmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = !status;

                    //set txt need
                    txtEmail.Enabled = txtPhone.Enabled = txtName.Enabled = status;
                    //Set rbtn find
                    //rbtnFindbyId.Select();
                    rbtnFindbyName.Visible = rbtnFindbyId.Visible = false;
                    break;
                    #endregion ADD
                case "del":
                    #region DELETE
                    btnAddImage.Enabled = !status;
                    btnMode.Enabled = btnReset.Enabled = tsbtnDelMode.Enabled = status;
                    txtId.Enabled =  txtEmail.Enabled = txtPhone.Enabled =  txtName.Enabled = !status;
                    tsbtnAddMode.Enabled = tsbtnFindMode.Enabled = tsbtnUpdateMode.Enabled = !status;
                    thêmToolStripMenuItem.Enabled = tìmToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = !status;
                    break;
                    #endregion DELETE

                case "update":
                    txtId.Enabled = false;
                    txtEmail.Enabled = txtPhone.Enabled = txtName.Enabled = status;
                    btnAddImage.Enabled = btnMode.Enabled = btnReset.Enabled = tsbtnUpdateMode.Enabled = status;
                    tsbtnAddMode.Enabled = tsbtnDelMode.Enabled = tsbtnFindMode.Enabled = !status;
                    thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = tìmToolStripMenuItem.Enabled = !status;
                    break;
                case "":
                    btnAddImage.Enabled = btnMode.Enabled = btnReset.Enabled = status;
                    tsbtnAddMode.Enabled = tsbtnFindMode.Enabled = !status;
                    //must found before del or update
                    tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = status;
                    tìmToolStripMenuItem.Enabled = thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = 
                    txtName.Enabled = txtEmail.Enabled = txtId.Enabled = txtPhone.Enabled = !status;
                    //rbtnFindbyId.Select();
                    rbtnFindbyName.Visible = rbtnFindbyId.Visible = false;
                    break;
            }

        }

        private void setLabel(string mode)
        {
            btnMode.Text = mode;
            lblMode.Text = "Chế độ " + mode;
        }

        private void clear()
        {
            txtEmail.Text = txtName.Text = txtPhone.Text = txtId.Text = "";
            ptbImg.ImageLocation = null;
            ptbImg.Image = ptbImg.InitialImage;
        }

        #region ToolStrip

        private void tsbtnFindMode_Click(object sender, EventArgs e)
        {
            setLabel("Tìm");
            setButton("find", true);
        }

        private void tsbtnAddMode_Click(object sender, EventArgs e)
        {
            setLabel("Thêm");
            setButton("add", true);
        }

        private void tsbtnDelMode_Click(object sender, EventArgs e)
        {
            setLabel("Xóa");
            setButton("del", true);
        }

        private void tsbtnUpdateMode_Click(object sender, EventArgs e)
        {
            setLabel("Sửa");
            setButton("update", true);
        }

        private void tìmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnFindMode_Click(sender, e);
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnAddMode_Click(sender, e);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnDelMode_Click(sender, e);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnUpdateMode_Click(sender, e);
        }
        #endregion ToolStrip

        private void ptbImg_Click(object sender, EventArgs e)
        {
            if (btnAddImage.Enabled)
                btnAddImage_Click(sender, e);
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn ảnh";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imgLogcation = openFileDialog.FileName.ToString();
                    ptbImg.ImageLocation = imgLogcation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            switch (btnMode.Text)
            {
                case "Tìm":
                    #region TÌM 
                    if (rbtnFindbyId.Checked)
                    {
                        try
                        {
                            table = Student.findStudentById(txtId.Text);
                            txtId.Text = table.Rows[0][0].ToString();
                            txtName.Text = table.Rows[0][1].ToString();                            
                            txtPhone.Text = table.Rows[0][2].ToString();
                            txtEmail.Text = table.Rows[0][3].ToString();
                            //img
                            if (table.Rows[0][4] == DBNull.Value)
                            {
                                ptbImg.Image = ptbImg.InitialImage;
                            }
                            else
                            {
                                byte[] img = (byte[])table.Rows[0][4];
                                MemoryStream ms = new MemoryStream(img);
                                ptbImg.Image = Image.FromStream(ms);
                            }
                            //
                            tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = true;
                            xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = true;
                        }
                        catch(Exception ex)
                        {
                            clear();
                            MessageBox.Show("Không tìm thấy sinh viên", "Thất bại!");
                        }
                    }
                   
                    setAutoComplete();
                    break;
                #endregion TÌM
                case "Thêm":
                    #region THÊM
                    if (!IsValidEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Email bạn đã nhập chưa hợp lệ!", "Thông báo ");
                        break;
                    }

                    else
                        Student.insertStudent(txtId.Text, txtName.Text, txtPhone.Text, txtEmail.Text);
                        MessageBox.Show("Thêm sinh viên thành công!", "Thành công");

                    setAutoComplete();
                    clear();
                    break;
                #endregion THÊM
                case "Xóa":
                    #region Xóa
                    if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (Student.deleteStudent(txtId.Text))
                        {
                            MessageBox.Show("Xóa sinh viên thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Không xóa được sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    setAutoComplete();
                    break;
                #endregion Xóa
                case "Sửa":
                    #region SỬA
                    if(!IsValidEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Email bạn đã nhập chưa hợp lệ!", "Thông báo ");
                        break;
                    }
                    if (MessageBox.Show("Bạn có chắc muốn sửa thông tin của sinh viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                            Student.updateStudent(txtId.Text, txtName.Text, txtPhone.Text, txtEmail.Text);
                            MessageBox.Show("Sửa sinh viên thành công!", "Thành công");

                        }  
                    setAutoComplete();
                    break;
                    #endregion SỬA
                default:
                    break;
            }
        }
        

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            setLabel("chưa chọn");
            setButton("", false);
            imgLogcation = "";
            clear();
            setAutoComplete();
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((txtEmail.TextLength + txtName.TextLength + txtPhone.TextLength + txtId.TextLength) > 0)
            {
                if (MessageBox.Show("Có vẻ như bạn chưa hoàn thành công việc... \n\n Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
            }
        }


        #region RADIOBUTTON
        private void rbtnFindbyId_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFindbyId.Checked)
            {
                txtId.Enabled = true;
                txtId.Select();
                txtName.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                txtName.Enabled = true;
                txtName.Select();
            }
        }
        #endregion RADIOBUTTON

        private void VerifyInput_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            for (int i = 0; i < textBox.TextLength; i++)
            {
                if (!char.IsLetterOrDigit(textBox.Text[i]) && textBox.Text[i] != ' ' && textBox.Text[i] != '@' && textBox.Text[i] != '.')
                {
                    textBox.Text = textBox.Text.Remove(i, 1);
                    textBox.SelectionStart = i;
                    textBox.SelectionLength = 0;
                }
            }
        }
        private void VerifyInputPhone_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            for (int i = 0; i < textBox.TextLength; i++)
            {
                if (!char.IsDigit(textBox.Text[i]))
                {
                    textBox.Text = textBox.Text.Remove(i, 1);
                    textBox.SelectionStart = i;
                    textBox.SelectionLength = 0;
                }
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
                if (form.Name == "RouterForm")
                {
                    form.Close();
                    break;
                }
        }
    }
}