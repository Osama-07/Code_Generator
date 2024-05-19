namespace My_Code_Generator.Sql_Forms
{
    partial class frmMainSqlScreen
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
            this.btnGeneratorSqlCode = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btnGeneratorSql = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.SuspendLayout();
            // 
            // btnGeneratorSqlCode
            // 
            this.btnGeneratorSqlCode.Animated = true;
            this.btnGeneratorSqlCode.BorderRadius = 50;
            this.btnGeneratorSqlCode.CheckedState.Parent = this.btnGeneratorSqlCode;
            this.btnGeneratorSqlCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneratorSqlCode.CustomImages.Parent = this.btnGeneratorSqlCode;
            this.btnGeneratorSqlCode.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.btnGeneratorSqlCode.FillColor2 = System.Drawing.Color.Gainsboro;
            this.btnGeneratorSqlCode.Font = new System.Drawing.Font("Rockwell Extra Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratorSqlCode.ForeColor = System.Drawing.Color.Black;
            this.btnGeneratorSqlCode.HoverState.Parent = this.btnGeneratorSqlCode;
            this.btnGeneratorSqlCode.ImageSize = new System.Drawing.Size(60, 60);
            this.btnGeneratorSqlCode.Location = new System.Drawing.Point(553, 24);
            this.btnGeneratorSqlCode.Name = "btnGeneratorSqlCode";
            this.btnGeneratorSqlCode.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnGeneratorSqlCode.ShadowDecoration.Parent = this.btnGeneratorSqlCode;
            this.btnGeneratorSqlCode.Size = new System.Drawing.Size(284, 250);
            this.btnGeneratorSqlCode.TabIndex = 1;
            this.btnGeneratorSqlCode.Text = "Generator Sql Code";
            this.btnGeneratorSqlCode.Click += new System.EventHandler(this.btnGeneratorSqlCode_Click);
            // 
            // btnGeneratorSql
            // 
            this.btnGeneratorSql.Animated = true;
            this.btnGeneratorSql.BorderRadius = 35;
            this.btnGeneratorSql.CheckedState.Parent = this.btnGeneratorSql;
            this.btnGeneratorSql.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneratorSql.CustomImages.Parent = this.btnGeneratorSql;
            this.btnGeneratorSql.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.btnGeneratorSql.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGeneratorSql.Font = new System.Drawing.Font("Rockwell Extra Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratorSql.ForeColor = System.Drawing.Color.White;
            this.btnGeneratorSql.HoverState.Parent = this.btnGeneratorSql;
            this.btnGeneratorSql.Location = new System.Drawing.Point(79, 52);
            this.btnGeneratorSql.Name = "btnGeneratorSql";
            this.btnGeneratorSql.ShadowDecoration.Parent = this.btnGeneratorSql;
            this.btnGeneratorSql.Size = new System.Drawing.Size(341, 191);
            this.btnGeneratorSql.TabIndex = 2;
            this.btnGeneratorSql.Text = "Generator Sql Code";
            this.btnGeneratorSql.Click += new System.EventHandler(this.btnGeneratorSql_Click);
            // 
            // frmMainSqlScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(914, 479);
            this.Controls.Add(this.btnGeneratorSql);
            this.Controls.Add(this.btnGeneratorSqlCode);
            this.Name = "frmMainSqlScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Sql Screen";
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientCircleButton btnGeneratorSqlCode;
        private Guna.UI2.WinForms.Guna2GradientTileButton btnGeneratorSql;
    }
}