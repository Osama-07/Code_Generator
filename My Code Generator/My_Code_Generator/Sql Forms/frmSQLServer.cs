using Code_Generator_Business;
using Generator_Code_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace My_Code_Generator.Forms
{
    public partial class frmSQLServer : Form
    {
        private frmMainMenue _frmMainMenue;

        public frmSQLServer(frmMainMenue frmMain)
        {
            InitializeComponent();

            _frmMainMenue = frmMain;
        }

        public List<DatabaseSchema> databaseSchemas { get; set; }

        private void _GetDatabases()
        {
            foreach (var database in databaseSchemas.OrderBy(d => d.DatabaseName))
            {
                cmbDatabases.Items.Add(database.DatabaseName);
            }

            if (cmbDatabases.Items.Count > 0)
                cmbDatabases.SelectedIndex = 0;
        }

        private void _GetTables(string SelectedDatabase)
        {
            var database = databaseSchemas.Find(d => d.DatabaseName == SelectedDatabase);

            if (database != null)
            {
                foreach (var table in database.Tables.OrderBy(t => t.TableName))
                {
                    cmbTables.Items.Add(table.TableName);
                }
            }

            cmbTables.SelectedIndex = 0;
        }

        private void _GetColumns(string selectedDatabase, string tableName)
        {
            var database = databaseSchemas.Find(d => d.DatabaseName == selectedDatabase);

            if (database != null)
            {
                var tables = database.Tables.Find(t => t.TableName == tableName);

                if (tables != null)
                {
                    foreach (var column in tables.Columns)
                    {
                        cmbColumns.Items.Add(column.ColumnName);
                    }
                }
            }

            cmbColumns.SelectedIndex = 0;
        }

        private void frmSQLServer_Shown(object sender, EventArgs e)
        {
            databaseSchemas = clsDatabaseInfoData.GetAllDatabaseSchemas();

            _GetDatabases();
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var database = databaseSchemas.FirstOrDefault(s => s.DatabaseName == cmbDatabases.Text);
            var table = database.Tables.FirstOrDefault(s => s.TableName == cmbTables.Text);

            txtGeneratorCode.Text = clsGetSQLCode.SP_AddNew(table);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var database = databaseSchemas.FirstOrDefault(s => s.DatabaseName == cmbDatabases.Text);
            var table = database.Tables.FirstOrDefault(s => s.TableName == cmbTables.Text);

            txtGeneratorCode.Text = clsGetSQLCode.SP_Update(table);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var database = databaseSchemas.FirstOrDefault(s => s.DatabaseName == cmbDatabases.Text);
            var table = database.Tables.FirstOrDefault(s => s.TableName == cmbTables.Text);

            txtGeneratorCode.Text = clsGetSQLCode.SP_Delete(table);
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            var database = databaseSchemas.FirstOrDefault(s => s.DatabaseName == cmbDatabases.Text);
            var table = database.Tables.FirstOrDefault(s => s.TableName == cmbTables.Text);

            txtGeneratorCode.Text = clsGetSQLCode.SP_Get(table);
        }

        private void btnIsExists_Click(object sender, EventArgs e)
        {
            var database = databaseSchemas.FirstOrDefault(s => s.DatabaseName == cmbDatabases.Text);
            var table = database.Tables.FirstOrDefault(s => s.TableName == cmbTables.Text);

            txtGeneratorCode.Text = clsGetSQLCode.SP_IsExists(table);
        }

        private void btnGenerateAll_Click(object sender, EventArgs e)
        {
            var database = databaseSchemas.FirstOrDefault(s => s.DatabaseName == cmbDatabases.Text);
            var table = database.Tables.FirstOrDefault(s => s.TableName == cmbTables.Text);

            txtGeneratorCode.Text = clsGetSQLCode.All(table);
        }


    }
}
