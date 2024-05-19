using My_Code_Generator.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http;
using My_Code_Generator.Sql_Forms;

namespace My_Code_Generator
{
    public partial class frmMainMenue : Form
    {
        public enum enThameMode { DataAccess = 1, Business = 2, SqlServer = 3}

        private frmDataAccessLayer _frmDataAccessLayer;
        private frmBusinessAccessLayer _frmBusinessAccess;
        private frmMainSqlScreen _frmMainSql;

        private Form activeForm;
        public Form activeSubForm;

        public string TitlePage
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        public frmMainMenue()
        {
            InitializeComponent();

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);


        private void ChangeThameColor(enThameMode ThameColor)
        {
            switch (ThameColor)
            {
                case enThameMode.DataAccess:
                    panelMenue.FillColor = Color.Firebrick;
                    panelTitle.FillColor = Color.Firebrick;
                    break;
                case enThameMode.Business:
                    panelMenue.FillColor = Color.DarkSlateGray;
                    panelTitle.FillColor = Color.DarkSlateGray;
                    break;
                case enThameMode.SqlServer:
                    panelMenue.FillColor = Color.DarkOliveGreen;
                    panelTitle.FillColor = Color.DarkOliveGreen;
                    break;
            }
        }

        private void OpenChildForm(Form ChildForm, enThameMode ThameColor)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Hide();

                    if (activeSubForm != null)
                        activeSubForm.Close();
                }

                ChangeThameColor(ThameColor);
                activeForm = ChildForm;
                ChildForm.TopLevel = false;
                ChildForm.FormBorderStyle = FormBorderStyle.None;
                ChildForm.Dock = DockStyle.Fill;
                this.panelForms.Controls.Add(ChildForm);
                this.panelForms.Tag = ChildForm;
                ChildForm.BringToFront();
                ChildForm.Show();
                lblTitle.Text = ChildForm.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenChildSubForm(Form ChildSubForm, enThameMode ThameColor)
        {
            try
            {
                if (activeSubForm != null)
                {
                    activeSubForm.Close();
                }

                ChangeThameColor(ThameColor);
                activeSubForm = ChildSubForm;
                ChildSubForm.TopLevel = false;
                ChildSubForm.FormBorderStyle = FormBorderStyle.None;
                ChildSubForm.Dock = DockStyle.Fill;
                this.panelForms.Controls.Add(ChildSubForm);
                this.panelForms.Tag = ChildSubForm;
                ChildSubForm.BringToFront();
                ChildSubForm.Show();
                lblTitle.Text = ChildSubForm.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDataAccess_Click(object sender, EventArgs e)
        {
            if (_frmDataAccessLayer != null)
                OpenChildForm(_frmDataAccessLayer, enThameMode.DataAccess);
            else
            {
                _frmDataAccessLayer = new frmDataAccessLayer(this);

                OpenChildForm(_frmDataAccessLayer, enThameMode.DataAccess);
            }

        }

        private void btnBusinessAccess_Click(object sender, EventArgs e)
        {
            if (_frmBusinessAccess != null)
                OpenChildForm(_frmBusinessAccess, enThameMode.Business);
            else
            {
                _frmBusinessAccess = new frmBusinessAccessLayer(this);

                OpenChildForm(_frmBusinessAccess, enThameMode.Business);
            }
        }

        private void btnSqlServer_Click(object sender, EventArgs e)
        {
            if (_frmMainSql != null)
                OpenChildForm(_frmMainSql, enThameMode.SqlServer);
            else
            {
                _frmMainSql = new frmMainSqlScreen(this);
                
                OpenChildForm(_frmMainSql, enThameMode.SqlServer);
            }
        }

        private void frmMainMenue_Shown(object sender, EventArgs e)
        {
            btnDataAccess_Click(null, null);
        }

        private void frmMainMenue_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMainMenue_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            frmMainMenue_MouseDown(null, null);
        }

    }
}
