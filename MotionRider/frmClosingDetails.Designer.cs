namespace MotionRider
{
    partial class frmClosingDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabClosingDetails = new System.Windows.Forms.TabControl();
            this.tabAllSales = new System.Windows.Forms.TabPage();
            this.dgvAllSales = new System.Windows.Forms.DataGridView();
            this.tabTicketSales = new System.Windows.Forms.TabPage();
            this.dgvTicketSales = new System.Windows.Forms.DataGridView();
            this.tabIceGolaSales = new System.Windows.Forms.TabPage();
            this.dgvIceGolaSales = new System.Windows.Forms.DataGridView();
            this.lblSalesTotal = new System.Windows.Forms.Label();
            this.lblTicketTotal = new System.Windows.Forms.Label();
            this.lblSlustTotal = new System.Windows.Forms.Label();
            this.tabClosingDetails.SuspendLayout();
            this.tabAllSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSales)).BeginInit();
            this.tabTicketSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketSales)).BeginInit();
            this.tabIceGolaSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIceGolaSales)).BeginInit();
            this.SuspendLayout();
            // 
            // tabClosingDetails
            // 
            this.tabClosingDetails.Controls.Add(this.tabAllSales);
            this.tabClosingDetails.Controls.Add(this.tabTicketSales);
            this.tabClosingDetails.Controls.Add(this.tabIceGolaSales);
            this.tabClosingDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClosingDetails.Location = new System.Drawing.Point(0, 0);
            this.tabClosingDetails.Name = "tabClosingDetails";
            this.tabClosingDetails.SelectedIndex = 0;
            this.tabClosingDetails.Size = new System.Drawing.Size(729, 441);
            this.tabClosingDetails.TabIndex = 0;
            // 
            // tabAllSales
            // 
            this.tabAllSales.Controls.Add(this.lblSalesTotal);
            this.tabAllSales.Controls.Add(this.dgvAllSales);
            this.tabAllSales.Location = new System.Drawing.Point(4, 24);
            this.tabAllSales.Name = "tabAllSales";
            this.tabAllSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllSales.Size = new System.Drawing.Size(721, 413);
            this.tabAllSales.TabIndex = 0;
            this.tabAllSales.Text = "All Sales";
            this.tabAllSales.UseVisualStyleBackColor = true;
            // 
            // dgvAllSales
            // 
            this.dgvAllSales.ColumnHeadersHeight = 30;
            this.dgvAllSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAllSales.Location = new System.Drawing.Point(3, 3);
            this.dgvAllSales.Name = "dgvAllSales";
            this.dgvAllSales.RowHeadersWidth = 20;
            this.dgvAllSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAllSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllSales.Size = new System.Drawing.Size(715, 372);
            this.dgvAllSales.TabIndex = 1;
            // 
            // tabTicketSales
            // 
            this.tabTicketSales.Controls.Add(this.lblTicketTotal);
            this.tabTicketSales.Controls.Add(this.dgvTicketSales);
            this.tabTicketSales.Location = new System.Drawing.Point(4, 24);
            this.tabTicketSales.Name = "tabTicketSales";
            this.tabTicketSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabTicketSales.Size = new System.Drawing.Size(721, 413);
            this.tabTicketSales.TabIndex = 1;
            this.tabTicketSales.Text = "Ticket Sales";
            this.tabTicketSales.UseVisualStyleBackColor = true;
            // 
            // dgvTicketSales
            // 
            this.dgvTicketSales.ColumnHeadersHeight = 30;
            this.dgvTicketSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTicketSales.Location = new System.Drawing.Point(3, 3);
            this.dgvTicketSales.Name = "dgvTicketSales";
            this.dgvTicketSales.RowHeadersWidth = 20;
            this.dgvTicketSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTicketSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTicketSales.Size = new System.Drawing.Size(715, 372);
            this.dgvTicketSales.TabIndex = 3;
            // 
            // tabIceGolaSales
            // 
            this.tabIceGolaSales.Controls.Add(this.lblSlustTotal);
            this.tabIceGolaSales.Controls.Add(this.dgvIceGolaSales);
            this.tabIceGolaSales.Location = new System.Drawing.Point(4, 24);
            this.tabIceGolaSales.Name = "tabIceGolaSales";
            this.tabIceGolaSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabIceGolaSales.Size = new System.Drawing.Size(721, 413);
            this.tabIceGolaSales.TabIndex = 2;
            this.tabIceGolaSales.Text = "Ice Gola Sales";
            this.tabIceGolaSales.UseVisualStyleBackColor = true;
            // 
            // dgvIceGolaSales
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvIceGolaSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIceGolaSales.ColumnHeadersHeight = 30;
            this.dgvIceGolaSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIceGolaSales.Location = new System.Drawing.Point(3, 3);
            this.dgvIceGolaSales.Name = "dgvIceGolaSales";
            this.dgvIceGolaSales.RowHeadersWidth = 20;
            this.dgvIceGolaSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvIceGolaSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIceGolaSales.Size = new System.Drawing.Size(715, 372);
            this.dgvIceGolaSales.TabIndex = 2;
            // 
            // lblSalesTotal
            // 
            this.lblSalesTotal.AutoSize = true;
            this.lblSalesTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesTotal.Location = new System.Drawing.Point(563, 386);
            this.lblSalesTotal.Name = "lblSalesTotal";
            this.lblSalesTotal.Size = new System.Drawing.Size(142, 15);
            this.lblSalesTotal.TabIndex = 1;
            this.lblSalesTotal.Text = "Total Amount: Rs. 20000";
            // 
            // lblTicketTotal
            // 
            this.lblTicketTotal.AutoSize = true;
            this.lblTicketTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketTotal.Location = new System.Drawing.Point(563, 386);
            this.lblTicketTotal.Name = "lblTicketTotal";
            this.lblTicketTotal.Size = new System.Drawing.Size(142, 15);
            this.lblTicketTotal.TabIndex = 4;
            this.lblTicketTotal.Text = "Total Amount: Rs. 20000";
            // 
            // lblSlustTotal
            // 
            this.lblSlustTotal.AutoSize = true;
            this.lblSlustTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlustTotal.Location = new System.Drawing.Point(563, 386);
            this.lblSlustTotal.Name = "lblSlustTotal";
            this.lblSlustTotal.Size = new System.Drawing.Size(142, 15);
            this.lblSlustTotal.TabIndex = 3;
            this.lblSlustTotal.Text = "Total Amount: Rs. 20000";
            // 
            // frmClosingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 441);
            this.Controls.Add(this.tabClosingDetails);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClosingDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Closing Details";
            this.Load += new System.EventHandler(this.On_frmClosingDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On_frmClosingDetails_KeyDown);
            this.tabClosingDetails.ResumeLayout(false);
            this.tabAllSales.ResumeLayout(false);
            this.tabAllSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSales)).EndInit();
            this.tabTicketSales.ResumeLayout(false);
            this.tabTicketSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketSales)).EndInit();
            this.tabIceGolaSales.ResumeLayout(false);
            this.tabIceGolaSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIceGolaSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabClosingDetails;
        private System.Windows.Forms.TabPage tabAllSales;
        private System.Windows.Forms.TabPage tabTicketSales;
        private System.Windows.Forms.TabPage tabIceGolaSales;
        private System.Windows.Forms.DataGridView dgvAllSales;
        private System.Windows.Forms.DataGridView dgvIceGolaSales;
        private System.Windows.Forms.DataGridView dgvTicketSales;
        private System.Windows.Forms.Label lblSalesTotal;
        private System.Windows.Forms.Label lblTicketTotal;
        private System.Windows.Forms.Label lblSlustTotal;
    }
}