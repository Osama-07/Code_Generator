using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Code_Generator_Business;
using System.Threading.Tasks;

namespace My_Code_Generator.Forms
{
    public partial class frmBusinessAccessLayer : Form
    {
        private frmMainMenue _frmMainMenue;

        public frmBusinessAccessLayer(frmMainMenue frmMainMenue)
        {
            InitializeComponent();

            _frmMainMenue = frmMainMenue;
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

        private void frmBusinessAccessLayer_Shown(object sender, EventArgs e)
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

        private void btnGenerateBusiness_Click(object sender, EventArgs e)
        {
            string[,] Columns = clsGetDatabasesInformation.GetColumns(cmbDatabases.Text, cmbTables.Text);

            txtGeneratorCode.Text = clsGeneratorBusiness.GeneratorBusinessCode(cmbTables.Text, Columns);
        }
    }
}
