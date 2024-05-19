namespace My_Code_Generator
{
    partial class frmDataAccessLayer
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGeneratorCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDatabases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTables = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbColumns = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnGenerateData = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Table Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 49);
            this.label1.TabIndex = 14;
            this.label1.Text = "Generator Code";
            // 
            // txtGeneratorCode
            // 
            this.txtGeneratorCode.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneratorCode.Location = new System.Drawing.Point(121, 215);
            this.txtGeneratorCode.MaxLength = 32768;
            this.txtGeneratorCode.Multiline = true;
            this.txtGeneratorCode.Name = "txtGeneratorCode";
            this.txtGeneratorCode.ReadOnly = true;
            this.txtGeneratorCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGeneratorCode.Size = new System.Drawing.Size(956, 708);
            this.txtGeneratorCode.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(792, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Columns";
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
            this.cmbDatabases.Location = new System.Drawing.Point(121, 19);
            this.cmbDatabases.MaxDropDownItems = 6;
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.ShadowDecoration.Parent = this.cmbDatabases;
            this.cmbDatabases.Size = new System.Drawing.Size(218, 36);
            this.cmbDatabases.TabIndex = 26;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
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
            this.cmbTables.Location = new System.Drawing.Point(502, 19);
            this.cmbTables.MaxDropDownItems = 6;
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.ShadowDecoration.Parent = this.cmbTables;
            this.cmbTables.Size = new System.Drawing.Size(218, 36);
            this.cmbTables.TabIndex = 27;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
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
            this.cmbColumns.Location = new System.Drawing.Point(873, 19);
            this.cmbColumns.MaxDropDownItems = 6;
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.ShadowDecoration.Parent = this.cmbColumns;
            this.cmbColumns.Size = new System.Drawing.Size(218, 36);
            this.cmbColumns.TabIndex = 28;
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.Animated = true;
            this.btnGenerateData.AutoRoundedCorners = true;
            this.btnGenerateData.BorderRadius = 30;
            this.btnGenerateData.CheckedState.Parent = this.btnGenerateData;
            this.btnGenerateData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateData.CustomImages.Parent = this.btnGenerateData;
            this.btnGenerateData.FillColor = System.Drawing.Color.DarkRed;
            this.btnGenerateData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateData.ForeColor = System.Drawing.Color.White;
            this.btnGenerateData.HoverState.Parent = this.btnGenerateData;
            this.btnGenerateData.Location = new System.Drawing.Point(511, 98);
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.ShadowDecoration.Parent = this.btnGenerateData;
            this.btnGenerateData.Size = new System.Drawing.Size(174, 62);
            this.btnGenerateData.TabIndex = 29;
            this.btnGenerateData.Text = "Generate Data Access";
            this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
            // 
            // frmDataAccessLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1208, 703);
            this.Controls.Add(this.btnGenerateData);
            this.Controls.Add(this.cmbColumns);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGeneratorCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataAccessLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Access Layer";
            this.Shown += new System.EventHandler(this.frmDataAccessLayer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGeneratorCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDatabases;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTables;
        private Guna.UI2.WinForms.Guna2ComboBox cmbColumns;
        private Guna.UI2.WinForms.Guna2Button btnGenerateData;
    }
}

