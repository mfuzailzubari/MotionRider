namespace MotionRider
{
    partial class frmViewClosings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvViewClosings = new System.Windows.Forms.DataGridView();
            this.lblViewMotionRIde = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewClosings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViewClosings
            // 
            this.dgvViewClosings.AllowUserToDeleteRows = false;
            this.dgvViewClosings.AllowUserToOrderColumns = true;
            this.dgvViewClosings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvViewClosings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewClosings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewClosings.ColumnHeadersHeight = 30;
            this.dgvViewClosings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewClosings.Location = new System.Drawing.Point(14, 38);
            this.dgvViewClosings.MultiSelect = false;
            this.dgvViewClosings.Name = "dgvViewClosings";
            this.dgvViewClosings.ReadOnly = true;
            this.dgvViewClosings.RowHeadersWidth = 25;
            this.dgvViewClosings.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvViewClosings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViewClosings.ShowEditingIcon = false;
            this.dgvViewClosings.Size = new System.Drawing.Size(887, 422);
            this.dgvViewClosings.TabIndex = 0;
            this.dgvViewClosings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewClosings_CellDoubleClick);
            // 
            // lblViewMotionRIde
            // 
            this.lblViewMotionRIde.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblViewMotionRIde.AutoSize = true;
            this.lblViewMotionRIde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblViewMotionRIde.Location = new System.Drawing.Point(388, 10);
            this.lblViewMotionRIde.Name = "lblViewMotionRIde";
            this.lblViewMotionRIde.Size = new System.Drawing.Size(116, 21);
            this.lblViewMotionRIde.TabIndex = 28;
            this.lblViewMotionRIde.Text = "View Closings";
            // 
            // frmViewClosings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 474);
            this.Controls.Add(this.lblViewMotionRIde);
            this.Controls.Add(this.dgvViewClosings);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewClosings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Closings";
            this.Load += new System.EventHandler(this.On_frmView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On_frmViewClosings_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewClosings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvViewClosings;
        private System.Windows.Forms.Label lblViewMotionRIde;
    }
}