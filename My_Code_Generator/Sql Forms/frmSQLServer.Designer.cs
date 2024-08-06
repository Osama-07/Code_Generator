namespace My_Code_Generator.Forms
{
    partial class frmSQLServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbColumns = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTables = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbDatabases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGeneratorCode = new System.Windows.Forms.TextBox();
            this.btnAddNew = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnGet = new Guna.UI2.WinForms.Guna2Button();
            this.btnGenerateAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnIsExists = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // cmbColumns
            // 
            this.cmbColumns.Animated = true;
            this.cmbColumns.AutoRoundedCorners = true;
            this.cmbColumns.BackColor = System.Drawing.Color.Transparent;
            this.cmbColumns.BorderRadius = 17;
            this.cmbColumns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumns.FillColor = System.Drawing.Color.Ivory;
            this.cmbColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbColumns.FocusedColor = System.Drawing.Color.Empty;
            this.cmbColumns.FocusedState.Parent = this.cmbColumns;
            this.cmbColumns.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColumns.ForeColor = System.Drawing.Color.Black;
            this.cmbColumns.HoverState.BorderColor = System.Drawing.Color.Gray;
            this.cmbColumns.HoverState.Parent = this.cmbColumns;
            this.cmbColumns.ItemHeight = 30;
            this.cmbColumns.ItemsAppearance.Parent = this.cmbColumns;
            this.cmbColumns.Location = new System.Drawing.Point(1187, 110);
            this.cmbColumns.Margin = new System.Windows.Forms.Padding(4);
            this.cmbColumns.MaxDropDownItems = 6;
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.ShadowDecoration.Parent = this.cmbColumns;
            this.cmbColumns.Size = new System.Drawing.Size(254, 36);
            this.cmbColumns.TabIndex = 34;
            // 
            // cmbTables
            // 
            this.cmbTables.Animated = true;
            this.cmbTables.AutoRoundedCorners = true;
            this.cmbTables.BackColor = System.Drawing.Color.Transparent;
            this.cmbTables.BorderRadius = 17;
            this.cmbTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTables.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FillColor = System.Drawing.Color.Ivory;
            this.cmbTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTables.FocusedColor = System.Drawing.Color.Empty;
            this.cmbTables.FocusedState.Parent = this.cmbTables;
            this.cmbTables.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables.ForeColor = System.Drawing.Color.Black;
            this.cmbTables.HoverState.BorderColor = System.Drawing.Color.Gray;
            this.cmbTables.HoverState.Parent = this.cmbTables;
            this.cmbTables.ItemHeight = 30;
            this.cmbTables.ItemsAppearance.Parent = this.cmbTables;
            this.cmbTables.Location = new System.Drawing.Point(707, 110);
            this.cmbTables.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTables.MaxDropDownItems = 6;
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.ShadowDecoration.Parent = this.cmbTables;
            this.cmbTables.Size = new System.Drawing.Size(254, 36);
            this.cmbTables.TabIndex = 33;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.Animated = true;
            this.cmbDatabases.AutoRoundedCorners = true;
            this.cmbDatabases.BackColor = System.Drawing.Color.Transparent;
            this.cmbDatabases.BorderRadius = 17;
            this.cmbDatabases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDatabases.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabases.FillColor = System.Drawing.Color.Ivory;
            this.cmbDatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDatabases.FocusedColor = System.Drawing.Color.Empty;
            this.cmbDatabases.FocusedState.Parent = this.cmbDatabases;
            this.cmbDatabases.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabases.ForeColor = System.Drawing.Color.Black;
            this.cmbDatabases.HoverState.BorderColor = System.Drawing.Color.Gray;
            this.cmbDatabases.HoverState.Parent = this.cmbDatabases;
            this.cmbDatabases.ItemHeight = 30;
            this.cmbDatabases.ItemsAppearance.Parent = this.cmbDatabases;
            this.cmbDatabases.Location = new System.Drawing.Point(222, 110);
            this.cmbDatabases.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDatabases.MaxDropDownItems = 6;
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.ShadowDecoration.Parent = this.cmbDatabases;
            this.cmbDatabases.Size = new System.Drawing.Size(254, 36);
            this.cmbDatabases.TabIndex = 32;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1096, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 32);
            this.label5.TabIndex = 31;
            this.label5.Text = "Columns";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 32);
            this.label4.TabIndex = 30;
            this.label4.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(590, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 32);
            this.label2.TabIndex = 29;
            this.label2.Text = "Table Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(612, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 63);
            this.label1.TabIndex = 36;
            this.label1.Text = "Generator SQL Code";
            // 
            // txtGeneratorCode
            // 
            this.txtGeneratorCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGeneratorCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtGeneratorCode.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneratorCode.Location = new System.Drawing.Point(0, 267);
            this.txtGeneratorCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtGeneratorCode.MaxLength = 32768;
            this.txtGeneratorCode.Multiline = true;
            this.txtGeneratorCode.Name = "txtGeneratorCode";
            this.txtGeneratorCode.ReadOnly = true;
            this.txtGeneratorCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGeneratorCode.Size = new System.Drawing.Size(1562, 698);
            this.txtGeneratorCode.TabIndex = 35;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Animated = true;
            this.btnAddNew.AutoRoundedCorners = true;
            this.btnAddNew.BorderColor = System.Drawing.Color.White;
            this.btnAddNew.BorderRadius = 27;
            this.btnAddNew.BorderThickness = 1;
            this.btnAddNew.CheckedState.Parent = this.btnAddNew;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.CustomImages.Parent = this.btnAddNew;
            this.btnAddNew.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.HoverState.Parent = this.btnAddNew;
            this.btnAddNew.Location = new System.Drawing.Point(111, 210);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.ShadowDecoration.Parent = this.btnAddNew;
            this.btnAddNew.Size = new System.Drawing.Size(214, 57);
            this.btnAddNew.TabIndex = 46;
            this.btnAddNew.Text = "ADD NEW";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Animated = true;
            this.btnUpdate.AutoRoundedCorners = true;
            this.btnUpdate.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.BorderRadius = 27;
            this.btnUpdate.BorderThickness = 1;
            this.btnUpdate.CheckedState.Parent = this.btnUpdate;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.CustomImages.Parent = this.btnUpdate;
            this.btnUpdate.FillColor = System.Drawing.Color.ForestGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.Parent = this.btnUpdate;
            this.btnUpdate.Location = new System.Drawing.Point(344, 210);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.Size = new System.Drawing.Size(214, 57);
            this.btnUpdate.TabIndex = 48;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Animated = true;
            this.btnDelete.AutoRoundedCorners = true;
            this.btnDelete.BorderColor = System.Drawing.Color.White;
            this.btnDelete.BorderRadius = 27;
            this.btnDelete.BorderThickness = 1;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Location = new System.Drawing.Point(575, 210);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(214, 57);
            this.btnDelete.TabIndex = 49;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGet
            // 
            this.btnGet.Animated = true;
            this.btnGet.AutoRoundedCorners = true;
            this.btnGet.BorderColor = System.Drawing.Color.White;
            this.btnGet.BorderRadius = 27;
            this.btnGet.BorderThickness = 1;
            this.btnGet.CheckedState.Parent = this.btnGet;
            this.btnGet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGet.CustomImages.Parent = this.btnGet;
            this.btnGet.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnGet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGet.ForeColor = System.Drawing.Color.White;
            this.btnGet.HoverState.Parent = this.btnGet;
            this.btnGet.Location = new System.Drawing.Point(797, 210);
            this.btnGet.Margin = new System.Windows.Forms.Padding(4);
            this.btnGet.Name = "btnGet";
            this.btnGet.ShadowDecoration.Parent = this.btnGet;
            this.btnGet.Size = new System.Drawing.Size(214, 57);
            this.btnGet.TabIndex = 50;
            this.btnGet.Text = "GET";
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Animated = true;
            this.btnGenerateAll.AutoRoundedCorners = true;
            this.btnGenerateAll.BorderColor = System.Drawing.Color.White;
            this.btnGenerateAll.BorderRadius = 27;
            this.btnGenerateAll.BorderThickness = 1;
            this.btnGenerateAll.CheckedState.Parent = this.btnGenerateAll;
            this.btnGenerateAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateAll.CustomImages.Parent = this.btnGenerateAll;
            this.btnGenerateAll.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnGenerateAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateAll.ForeColor = System.Drawing.Color.White;
            this.btnGenerateAll.HoverState.Parent = this.btnGenerateAll;
            this.btnGenerateAll.Location = new System.Drawing.Point(1241, 210);
            this.btnGenerateAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.ShadowDecoration.Parent = this.btnGenerateAll;
            this.btnGenerateAll.Size = new System.Drawing.Size(214, 57);
            this.btnGenerateAll.TabIndex = 51;
            this.btnGenerateAll.Text = "ALL";
            this.btnGenerateAll.Click += new System.EventHandler(this.btnGenerateAll_Click);
            // 
            // btnIsExists
            // 
            this.btnIsExists.Animated = true;
            this.btnIsExists.AutoRoundedCorners = true;
            this.btnIsExists.BorderColor = System.Drawing.Color.White;
            this.btnIsExists.BorderRadius = 27;
            this.btnIsExists.BorderThickness = 1;
            this.btnIsExists.CheckedState.Parent = this.btnIsExists;
            this.btnIsExists.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIsExists.CustomImages.Parent = this.btnIsExists;
            this.btnIsExists.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnIsExists.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIsExists.ForeColor = System.Drawing.Color.White;
            this.btnIsExists.HoverState.Parent = this.btnIsExists;
            this.btnIsExists.Location = new System.Drawing.Point(1019, 210);
            this.btnIsExists.Margin = new System.Windows.Forms.Padding(4);
            this.btnIsExists.Name = "btnIsExists";
            this.btnIsExists.ShadowDecoration.Parent = this.btnIsExists;
            this.btnIsExists.Size = new System.Drawing.Size(214, 57);
            this.btnIsExists.TabIndex = 52;
            this.btnIsExists.Text = "IsExists";
            this.btnIsExists.Click += new System.EventHandler(this.btnIsExists_Click);
            // 
            // frmSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1583, 928);
            this.Controls.Add(this.btnIsExists);
            this.Controls.Add(this.btnGenerateAll);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGeneratorCode);
            this.Controls.Add(this.cmbColumns);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSQLServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server";
            this.Shown += new System.EventHandler(this.frmSQLServer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbColumns;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTables;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDatabases;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGeneratorCode;
        private Guna.UI2.WinForms.Guna2Button btnAddNew;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnGet;
        private Guna.UI2.WinForms.Guna2Button btnGenerateAll;
        private Guna.UI2.WinForms.Guna2Button btnIsExists;
    }
}