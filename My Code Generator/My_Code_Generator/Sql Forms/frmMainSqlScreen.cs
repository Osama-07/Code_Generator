using My_Code_Generator.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static My_Code_Generator.frmMainMenue;

namespace My_Code_Generator.Sql_Forms
{
    public partial class frmMainSqlScreen : Form
    {
        private frmMainMenue _frmMainMenue;
        
        public frmMainSqlScreen(frmMainMenue frmMainMenue)
        {
            InitializeComponent();

            _frmMainMenue = frmMainMenue;
        }

        private void btnGeneratorSqlCode_Click(object sender, EventArgs e)
        {
            _frmMainMenue.OpenChildSubForm(new frmSQLServer(this), enThameMode.SqlServer);

            this.Hide();
        }

        private void btnGeneratorSql_Click(object sender, EventArgs e)
        {
            _frmMainMenue.OpenChildSubForm(new frmSQLServer(this), enThameMode.SqlServer);

            this.Hide();
        }
    }
}
