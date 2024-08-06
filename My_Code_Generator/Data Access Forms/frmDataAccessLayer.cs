using System;
using System.Windows.Forms;
using Code_Generator_Business;
using Generator_Code_Data;
using System.Collections.Generic;
using System.Linq;

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

        private void frmDataAccessLayer_Shown(object sender, EventArgs e)
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

        private void btnGenerateData_Click(object sender, EventArgs e)
        {
            var database = databaseSchemas.Find(d => d.DatabaseName == cmbDatabases.Text); // get database name.
            var table = database.Tables.Find(t => t.TableName == cmbTables.Text);

            txtGeneratorCode.Clear();
            txtGeneratorCode.Text = clsGeneratorDataAccess.GetAllCode(table);
        }

    }
}
