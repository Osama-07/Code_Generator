using Code_Generator_Business;
using My_Code_Generator.Sql_Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Code_Generator.Forms
{
    public partial class frmSQLServer : Form
    {
        private frmMainSqlScreen _frmMainSqlScreen;

        public frmSQLServer(frmMainSqlScreen frmMainSqlScreen)
        {
            InitializeComponent();

            _frmMainSqlScreen = frmMainSqlScreen;
        }

        private void _GetDatabases()
        {
            string[] databasesName = clsGetDatabasesInformation.GetDatabases();

            for (int i = 0; i < databasesName.Length; i++)
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
            string[,] Columns = clsGetDatabasesInformation.GetColumns(selectedDatabase, tableName);

            for (int i = 0; i < Columns.GetLength(0); i++)
            {
                if (Columns[i, 1] == null)
                    break;

                cmbColumns.Items.Add(Columns[i, 1]);
            }

            cmbColumns.SelectedIndex = 0;
        }

        private void frmSQLServer_Shown(object sender, EventArgs e)
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

        private void btnGenerateSQLCode_Click(object sender, EventArgs e)
        {
            string SelectedDatabase = cmbDatabases.SelectedItem.ToString();
            string SelectedTable = cmbTables.SelectedItem.ToString();

            string[,] parameters = clsGetDatabasesInformation.GetColumnSQLInfo(SelectedDatabase, SelectedTable);

            txtGeneratorCode.Text = clsGetSQLCode.GenerateSP_AddNewCode(SelectedTable, parameters);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _frmMainSqlScreen.Show();

            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string tableName = cmbTables.SelectedItem.ToString();
            string[,] parameters = clsGetDatabasesInformation.GetColumnSQLInfo(cmbDatabases.SelectedItem.ToString(), tableName);

            txtGeneratorCode.Text = clsGetSQLCode.GenerateSP_UpdateCode(tableName, parameters);
        }

        private void btnDeleteCode_Click(object sender, EventArgs e)
        {
            string tableName = cmbTables.SelectedItem.ToString();
            string[,] parameters = clsGetDatabasesInformation.GetColumnSQLInfo(cmbDatabases.SelectedItem.ToString(), tableName);

            txtGeneratorCode.Text = clsGetSQLCode.GenerateSP_DeleteCode(tableName, parameters);
        }

        private void btnFindCode_Click(object sender, EventArgs e)
        {
            string tableName = cmbTables.SelectedItem.ToString();
            string[,] parameters = clsGetDatabasesInformation.GetColumnSQLInfo(cmbDatabases.SelectedItem.ToString(), tableName);

            txtGeneratorCode.Text = clsGetSQLCode.GenerateSP_FindCode(tableName, parameters);
        }

        private void btnGenerateAll_Click(object sender, EventArgs e)
        {
            string tableName = cmbTables.SelectedItem.ToString();
            string[,] parameters = clsGetDatabasesInformation.GetColumnSQLInfo(cmbDatabases.SelectedItem.ToString(), tableName);

            txtGeneratorCode.Text = clsGetSQLCode.GenerateAll(tableName, parameters);
        }

        private void btnIsExists_Click(object sender, EventArgs e)
        {
            string tableName = cmbTables.SelectedItem.ToString();
            string[,] parameters = clsGetDatabasesInformation.GetColumnSQLInfo(cmbDatabases.SelectedItem.ToString(), tableName);

            txtGeneratorCode.Text = clsGetSQLCode.GenerateSP_IsExistsCode(tableName, parameters);
        }

    }
}
