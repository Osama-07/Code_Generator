namespace My_Code_Generator.Forms
{
    partial class frmBusinessAccessLayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGeneratorCode = new System.Windows.Forms.TextBox();
            this.cmbColumns = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTables = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbDatabases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerateBusiness = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(550, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 63);
            this.label1.TabIndex = 44;
            this.label1.Text = "Generator Business Code";
            // 
            // txtGeneratorCode
            // 
            this.txtGeneratorCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGeneratorCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtGeneratorCode.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneratorCode.Location = new System.Drawing.Point(0, 302);
            this.txtGeneratorCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGeneratorCode.MaxLength = 32768;
            this.txtGeneratorCode.Multiline = true;
            this.txtGeneratorCode.Name = "txtGeneratorCode";
            this.txtGeneratorCode.ReadOnly = true;
            this.txtGeneratorCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGeneratorCode.Size = new System.Drawing.Size(1551, 631);
            this.txtGeneratorCode.TabIndex = 43;
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
            this.cmbColumns.Location = new System.Drawing.Point(1174, 134);
            this.cmbColumns.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbColumns.MaxDropDownItems = 6;
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.ShadowDecoration.Parent = this.cmbColumns;
            this.cmbColumns.Size = new System.Drawing.Size(254, 36);
            this.cmbColumns.TabIndex = 42;
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
            this.cmbTables.Location = new System.Drawing.Point(672, 134);
            this.cmbTables.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTables.MaxDropDownItems = 6;
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.ShadowDecoration.Parent = this.cmbTables;
            this.cmbTables.Size = new System.Drawing.Size(254, 36);
            this.cmbTables.TabIndex = 41;
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
            this.cmbDatabases.Location = new System.Drawing.Point(132, 134);
            this.cmbDatabases.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDatabases.MaxDropDownItems = 6;
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.ShadowDecoration.Parent = this.cmbDatabases;
            this.cmbDatabases.Size = new System.Drawing.Size(254, 36);
            this.cmbDatabases.TabIndex = 40;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1078, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 32);
            this.label5.TabIndex = 39;
            this.label5.Text = "Columns";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(36, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 32);
            this.label4.TabIndex = 38;
            this.label4.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(555, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 32);
            this.label2.TabIndex = 37;
            this.label2.Text = "Table Name";
            // 
            // btnGenerateBusiness
            // 
            this.btnGenerateBusiness.Animated = true;
            this.btnGenerateBusiness.AutoRoundedCorners = true;
            this.btnGenerateBusiness.BorderColor = System.Drawing.Color.White;
            this.btnGenerateBusiness.BorderRadius = 27;
            this.btnGenerateBusiness.BorderThickness = 1;
            this.btnGenerateBusiness.CheckedState.Parent = this.btnGenerateBusiness;
            this.btnGenerateBusiness.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateBusiness.CustomImages.Parent = this.btnGenerateBusiness;
            this.btnGenerateBusiness.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnGenerateBusiness.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateBusiness.ForeColor = System.Drawing.Color.White;
            this.btnGenerateBusiness.HoverState.Parent = this.btnGenerateBusiness;
            this.btnGenerateBusiness.Location = new System.Drawing.Point(672, 237);
            this.btnGenerateBusiness.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerateBusiness.Name = "btnGenerateBusiness";
            this.btnGenerateBusiness.ShadowDecoration.Parent = this.btnGenerateBusiness;
            this.btnGenerateBusiness.Size = new System.Drawing.Size(214, 57);
            this.btnGenerateBusiness.TabIndex = 45;
            this.btnGenerateBusiness.Text = "Generate Business Access";
            this.btnGenerateBusiness.Click += new System.EventHandler(this.btnGenerateBusiness_Click);
            // 
            // frmBusinessAccessLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1551, 933);
            this.Controls.Add(this.btnGenerateBusiness);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGeneratorCode);
            this.Controls.Add(this.cmbColumns);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBusinessAccessLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Business Access Layer";
            this.Shown += new System.EventHandler(this.frmBusinessAccessLayer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGeneratorCode;
        private Guna.UI2.WinForms.Guna2ComboBox cmbColumns;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTables;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDatabases;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnGenerateBusiness;
    }
}