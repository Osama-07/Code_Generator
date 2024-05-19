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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQLServer));
            this.cmbColumns = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTables = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbDatabases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGeneratorCode = new System.Windows.Forms.TextBox();
            this.btnGenerateSQLCode = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteCode = new Guna.UI2.WinForms.Guna2Button();
            this.btnFindCode = new Guna.UI2.WinForms.Guna2Button();
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
            this.cmbColumns.Location = new System.Drawing.Point(118, 161);
            this.cmbColumns.MaxDropDownItems = 6;
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.ShadowDecoration.Parent = this.cmbColumns;
            this.cmbColumns.Size = new System.Drawing.Size(218, 36);
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
            this.cmbTables.Location = new System.Drawing.Point(118, 110);
            this.cmbTables.MaxDropDownItems = 6;
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.ShadowDecoration.Parent = this.cmbTables;
            this.cmbTables.Size = new System.Drawing.Size(218, 36);
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
            this.cmbDatabases.Location = new System.Drawing.Point(118, 62);
            this.cmbDatabases.MaxDropDownItems = 6;
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.ShadowDecoration.Parent = this.cmbDatabases;
            this.cmbDatabases.Size = new System.Drawing.Size(218, 36);
            this.cmbDatabases.TabIndex = 32;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "Columns";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 29;
            this.label2.Text = "Table Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(609, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 49);
            this.label1.TabIndex = 36;
            this.label1.Text = "Generator SQL Code";
            // 
            // txtGeneratorCode
            // 
            this.txtGeneratorCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGeneratorCode.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneratorCode.Location = new System.Drawing.Point(385, 62);
            this.txtGeneratorCode.MaxLength = 32768;
            this.txtGeneratorCode.Multiline = true;
            this.txtGeneratorCode.Name = "txtGeneratorCode";
            this.txtGeneratorCode.ReadOnly = true;
            this.txtGeneratorCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGeneratorCode.Size = new System.Drawing.Size(702, 619);
            this.txtGeneratorCode.TabIndex = 35;
            // 
            // btnGenerateSQLCode
            // 
            this.btnGenerateSQLCode.Animated = true;
            this.btnGenerateSQLCode.AutoRoundedCorners = true;
            this.btnGenerateSQLCode.BorderColor = System.Drawing.Color.White;
            this.btnGenerateSQLCode.BorderRadius = 22;
            this.btnGenerateSQLCode.BorderThickness = 1;
            this.btnGenerateSQLCode.CheckedState.Parent = this.btnGenerateSQLCode;
            this.btnGenerateSQLCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateSQLCode.CustomImages.Parent = this.btnGenerateSQLCode;
            this.btnGenerateSQLCode.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.btnGenerateSQLCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateSQLCode.ForeColor = System.Drawing.Color.White;
            this.btnGenerateSQLCode.HoverState.Parent = this.btnGenerateSQLCode;
            this.btnGenerateSQLCode.Location = new System.Drawing.Point(12, 274);
            this.btnGenerateSQLCode.Name = "btnGenerateSQLCode";
            this.btnGenerateSQLCode.ShadowDecoration.Parent = this.btnGenerateSQLCode;
            this.btnGenerateSQLCode.Size = new System.Drawing.Size(183, 46);
            this.btnGenerateSQLCode.TabIndex = 46;
            this.btnGenerateSQLCode.Text = "Generate ADD NEW";
            this.btnGenerateSQLCode.Click += new System.EventHandler(this.btnGenerateSQLCode_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.CheckedState.Parent = this.btnBack;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.HoverState.ImageSize = new System.Drawing.Size(29, 29);
            this.btnBack.HoverState.Parent = this.btnBack;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageSize = new System.Drawing.Size(30, 30);
            this.btnBack.Location = new System.Drawing.Point(12, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.PressedState.Parent = this.btnBack;
            this.btnBack.Size = new System.Drawing.Size(26, 24);
            this.btnBack.TabIndex = 47;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Animated = true;
            this.btnUpdate.AutoRoundedCorners = true;
            this.btnUpdate.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.BorderRadius = 22;
            this.btnUpdate.BorderThickness = 1;
            this.btnUpdate.CheckedState.Parent = this.btnUpdate;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.CustomImages.Parent = this.btnUpdate;
            this.btnUpdate.FillColor = System.Drawing.Color.ForestGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.Parent = this.btnUpdate;
            this.btnUpdate.Location = new System.Drawing.Point(196, 274);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.Size = new System.Drawing.Size(183, 46);
            this.btnUpdate.TabIndex = 48;
            this.btnUpdate.Text = "Generate UPDATE";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDeleteCode
            // 
            this.btnDeleteCode.Animated = true;
            this.btnDeleteCode.AutoRoundedCorners = true;
            this.btnDeleteCode.BorderColor = System.Drawing.Color.White;
            this.btnDeleteCode.BorderRadius = 22;
            this.btnDeleteCode.BorderThickness = 1;
            this.btnDeleteCode.CheckedState.Parent = this.btnDeleteCode;
            this.btnDeleteCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCode.CustomImages.Parent = this.btnDeleteCode;
            this.btnDeleteCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteCode.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCode.HoverState.Parent = this.btnDeleteCode;
            this.btnDeleteCode.Location = new System.Drawing.Point(12, 339);
            this.btnDeleteCode.Name = "btnDeleteCode";
            this.btnDeleteCode.ShadowDecoration.Parent = this.btnDeleteCode;
            this.btnDeleteCode.Size = new System.Drawing.Size(183, 46);
            this.btnDeleteCode.TabIndex = 49;
            this.btnDeleteCode.Text = "Generate DELETE";
            this.btnDeleteCode.Click += new System.EventHandler(this.btnDeleteCode_Click);
            // 
            // btnFindCode
            // 
            this.btnFindCode.Animated = true;
            this.btnFindCode.AutoRoundedCorners = true;
            this.btnFindCode.BorderColor = System.Drawing.Color.White;
            this.btnFindCode.BorderRadius = 22;
            this.btnFindCode.BorderThickness = 1;
            this.btnFindCode.CheckedState.Parent = this.btnFindCode;
            this.btnFindCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindCode.CustomImages.Parent = this.btnFindCode;
            this.btnFindCode.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnFindCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFindCode.ForeColor = System.Drawing.Color.White;
            this.btnFindCode.HoverState.Parent = this.btnFindCode;
            this.btnFindCode.Location = new System.Drawing.Point(196, 339);
            this.btnFindCode.Name = "btnFindCode";
            this.btnFindCode.ShadowDecoration.Parent = this.btnFindCode;
            this.btnFindCode.Size = new System.Drawing.Size(183, 46);
            this.btnFindCode.TabIndex = 50;
            this.btnFindCode.Text = "Generate FIND";
            this.btnFindCode.Click += new System.EventHandler(this.btnFindCode_Click);
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Animated = true;
            this.btnGenerateAll.AutoRoundedCorners = true;
            this.btnGenerateAll.BorderColor = System.Drawing.Color.White;
            this.btnGenerateAll.BorderRadius = 22;
            this.btnGenerateAll.BorderThickness = 1;
            this.btnGenerateAll.CheckedState.Parent = this.btnGenerateAll;
            this.btnGenerateAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateAll.CustomImages.Parent = this.btnGenerateAll;
            this.btnGenerateAll.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnGenerateAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateAll.ForeColor = System.Drawing.Color.White;
            this.btnGenerateAll.HoverState.Parent = this.btnGenerateAll;
            this.btnGenerateAll.Location = new System.Drawing.Point(93, 470);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.ShadowDecoration.Parent = this.btnGenerateAll;
            this.btnGenerateAll.Size = new System.Drawing.Size(183, 46);
            this.btnGenerateAll.TabIndex = 51;
            this.btnGenerateAll.Text = "Generate ALL";
            this.btnGenerateAll.Click += new System.EventHandler(this.btnGenerateAll_Click);
            // 
            // btnIsExists
            // 
            this.btnIsExists.Animated = true;
            this.btnIsExists.AutoRoundedCorners = true;
            this.btnIsExists.BorderColor = System.Drawing.Color.White;
            this.btnIsExists.BorderRadius = 22;
            this.btnIsExists.BorderThickness = 1;
            this.btnIsExists.CheckedState.Parent = this.btnIsExists;
            this.btnIsExists.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIsExists.CustomImages.Parent = this.btnIsExists;
            this.btnIsExists.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnIsExists.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIsExists.ForeColor = System.Drawing.Color.White;
            this.btnIsExists.HoverState.Parent = this.btnIsExists;
            this.btnIsExists.Location = new System.Drawing.Point(12, 399);
            this.btnIsExists.Name = "btnIsExists";
            this.btnIsExists.ShadowDecoration.Parent = this.btnIsExists;
            this.btnIsExists.Size = new System.Drawing.Size(183, 46);
            this.btnIsExists.TabIndex = 52;
            this.btnIsExists.Text = "Generate IsExists";
            this.btnIsExists.Click += new System.EventHandler(this.btnIsExists_Click);
            // 
            // frmSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1122, 531);
            this.Controls.Add(this.btnIsExists);
            this.Controls.Add(this.btnGenerateAll);
            this.Controls.Add(this.btnFindCode);
            this.Controls.Add(this.btnDeleteCode);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGenerateSQLCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGeneratorCode);
            this.Controls.Add(this.cmbColumns);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
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
        private Guna.UI2.WinForms.Guna2Button btnGenerateSQLCode;
        private Guna.UI2.WinForms.Guna2ImageButton btnBack;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnDeleteCode;
        private Guna.UI2.WinForms.Guna2Button btnFindCode;
        private Guna.UI2.WinForms.Guna2Button btnGenerateAll;
        private Guna.UI2.WinForms.Guna2Button btnIsExists;
    }
}