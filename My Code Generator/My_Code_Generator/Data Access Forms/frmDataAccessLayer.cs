using static Code_Generator_Business.clsGeneratorDataAccess;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using Code_Generator_Business;
using System.Text;

namespace My_Code_Generator
{
    public partial class frmDataAccessLayer : Form
    {
        private frmMainMenue _frmMainMenue;

        public string TitlePage
        {
            get
            {
                return _frmMainMenue.TitlePage;
            }
            set
            {
                _frmMainMenue.TitlePage = value;
            }
        }

        public frmDataAccessLayer(frmMainMenue frmMainMenue)
        {
            InitializeComponent();

            _frmMainMenue = frmMainMenue;
        }

        private void ShowDBInfo(object sender, DBQueryInfoEventArgs e)
        {
            StringBuilder properties = new StringBuilder();

            for (int i = 0; i < e.Properties.Length; i++)
            {
                if (i == e.Properties.Length - 1)
                {
                    properties.Append(e.Properties[i]);
                    break;
                }

                properties.Append(e.Properties[i] + ", ");
            }

            MessageBox.Show($"Database Name is \"{e.SelectedDatabase}\", Table Name is \"{e.SelectedTable}\"\n Properties : \n {properties}.",
                            "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _GetDatabases()
        {
            string[] databasesName = clsGetDatabasesInformation.GetDatabases();

            for(int i = 0; i < databasesName.Length; i++)
            {
                cmbDatabases.Items.Add(databasesName[i]);
            }

            cmbDatabases.SelectedIndex = 0;
        }

        private void _GetTables(string SelectedDatabase)
        {
            string[] tablesName = clsGetDatabasesInformation.GetTables(SelectedDatabase);

            for (int i = 0; i < tablesName.Length; i++)
            {
                cmbTables.Items.Add(tablesName[i]);
            }

            cmbTables.SelectedIndex = 0;
        }

        private void _GetColumns(string selectedDatabase, string tableName)
        {
            //clsGetDatabasesInformation.OnEndQuery += ShowDBInfo;

            string[,] Columns = clsGetDatabasesInformation.GetColumns(selectedDatabase, tableName);

            for (int i = 0; i < Columns.GetLength(0); i++)
            {
                if (Columns[i, 1] == null)
                    break;

                cmbColumns.Items.Add(Columns[i, 1]);
            }

            cmbColumns.SelectedIndex = 0;
        }

        private void frmDataAccessLayer_Shown(object sender, EventArgs e)
        {
            Parallel.Invoke(_GetDatabases);
        }

        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDatabases.Items.Count > 0)
            {
                cmbTables.Items.Clear();
                _GetTables(cmbDatabases.Text);
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTables.Items.Count > 0)
            {
                cmbColumns.Items.Clear();
                _GetColumns(cmbDatabases.Text, cmbTables.Text);
            }
        }

        private void btnGenerateData_Click(object sender, EventArgs e)
        {
            // Business Logic.
            /*string[,] Columns = clsGetDatabasesInformation.GetColumns(cmbDatabases.Text, cmbTables.Text);

            txtGeneratorCode.Clear();
            txtGeneratorCode.Text = clsGeneratorBusiness.GeneratorBusinessCode(cmbTables.Text, Columns);*/

            // Data Access.
            string[,] Columns = clsGetDatabasesInformation.GetColumns(cmbDatabases.Text, cmbTables.Text);

            txtGeneratorCode.Clear();
            txtGeneratorCode.Text = GetAllCode(cmbTables.Text, Columns);
        }

    }
}
