namespace MotionRider
{
    partial class frmSalesDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSlushGridHeading = new System.Windows.Forms.Label();
            this.dgvMainSlush = new System.Windows.Forms.DataGridView();
            this.strahlenstudios = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtInvoiceTotalAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvMainTicket = new System.Windows.Forms.DataGridView();
            this.lblTicketGridHeading = new System.Windows.Forms.Label();
            this.lblMainTime = new System.Windows.Forms.Label();
            this.lblMainDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSalesCounter = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainSlush)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSlushGridHeading
            // 
            this.lblSlushGridHeading.AutoSize = true;
            this.lblSlushGridHeading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlushGridHeading.Location = new System.Drawing.Point(459, 283);
            this.lblSlushGridHeading.Name = "lblSlushGridHeading";
            this.lblSlushGridHeading.Size = new System.Drawing.Size(43, 19);
            this.lblSlushGridHeading.TabIndex = 104;
            this.lblSlushGridHeading.Text = "Slush";
            // 
            // dgvMainSlush
            // 
            this.dgvMainSlush.AllowUserToDeleteRows = false;
            this.dgvMainSlush.AllowUserToOrderColumns = true;
            this.dgvMainSlush.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMainSlush.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMainSlush.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMainSlush.ColumnHeadersHeight = 30;
            this.dgvMainSlush.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMainSlush.Location = new System.Drawing.Point(14, 308);
            this.dgvMainSlush.MultiSelect = false;
            this.dgvMainSlush.Name = "dgvMainSlush";
            this.dgvMainSlush.ReadOnly = true;
            this.dgvMainSlush.RowHeadersWidth = 25;
            this.dgvMainSlush.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMainSlush.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMainSlush.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainSlush.Size = new System.Drawing.Size(933, 179);
            this.dgvMainSlush.TabIndex = 1;
            // 
            // strahlenstudios
            // 
            this.strahlenstudios.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.strahlenstudios.AutoSize = true;
            this.strahlenstudios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strahlenstudios.Location = new System.Drawing.Point(503, 554);
            this.strahlenstudios.Name = "strahlenstudios";
            this.strahlenstudios.Size = new System.Drawing.Size(179, 15);
            this.strahlenstudios.TabIndex = 101;
            this.strahlenstudios.TabStop = true;
            this.strahlenstudios.Text = "http://www.strahlenstudios.com";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(252, 554);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(246, 15);
            this.label14.TabIndex = 99;
            this.label14.Text = "Designed and Maintained By Strahlen Studios";
            // 
            // txtInvoiceTotalAmount
            // 
            this.txtInvoiceTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceTotalAmount.Location = new System.Drawing.Point(772, 494);
            this.txtInvoiceTotalAmount.Name = "txtInvoiceTotalAmount";
            this.txtInvoiceTotalAmount.ReadOnly = true;
            this.txtInvoiceTotalAmount.Size = new System.Drawing.Size(174, 23);
            this.txtInvoiceTotalAmount.TabIndex = 96;
            this.txtInvoiceTotalAmount.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(678, 497);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 94;
            this.label7.Text = "Total Amount :";
            // 
            // dgvMainTicket
            // 
            this.dgvMainTicket.AllowUserToDeleteRows = false;
            this.dgvMainTicket.AllowUserToOrderColumns = true;
            this.dgvMainTicket.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMainTicket.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMainTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMainTicket.ColumnHeadersHeight = 30;
            this.dgvMainTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMainTicket.Location = new System.Drawing.Point(14, 95);
            this.dgvMainTicket.MultiSelect = false;
            this.dgvMainTicket.Name = "dgvMainTicket";
            this.dgvMainTicket.ReadOnly = true;
            this.dgvMainTicket.RowHeadersWidth = 25;
            this.dgvMainTicket.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMainTicket.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMainTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMainTicket.Size = new System.Drawing.Size(933, 179);
            this.dgvMainTicket.TabIndex = 0;
            // 
            // lblTicketGridHeading
            // 
            this.lblTicketGridHeading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTicketGridHeading.AutoSize = true;
            this.lblTicketGridHeading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketGridHeading.Location = new System.Drawing.Point(425, 69);
            this.lblTicketGridHeading.Name = "lblTicketGridHeading";
            this.lblTicketGridHeading.Size = new System.Drawing.Size(103, 19);
            this.lblTicketGridHeading.TabIndex = 111;
            this.lblTicketGridHeading.Text = "Motion Riders";
            // 
            // lblMainTime
            // 
            this.lblMainTime.AutoSize = true;
            this.lblMainTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTime.Location = new System.Drawing.Point(64, 67);
            this.lblMainTime.Name = "lblMainTime";
            this.lblMainTime.Size = new System.Drawing.Size(44, 15);
            this.lblMainTime.TabIndex = 109;
            this.lblMainTime.Text = "label13";
            // 
            // lblMainDate
            // 
            this.lblMainDate.AutoSize = true;
            this.lblMainDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainDate.Location = new System.Drawing.Point(64, 44);
            this.lblMainDate.Name = "lblMainDate";
            this.lblMainDate.Size = new System.Drawing.Size(44, 15);
            this.lblMainDate.TabIndex = 106;
            this.lblMainDate.Text = "label11";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 108;
            this.label6.Text = "Time :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 107;
            this.label5.Text = "Date :";
            // 
            // lblSalesCounter
            // 
            this.lblSalesCounter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSalesCounter.AutoSize = true;
            this.lblSalesCounter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesCounter.Location = new System.Drawing.Point(418, 10);
            this.lblSalesCounter.Name = "lblSalesCounter";
            this.lblSalesCounter.Size = new System.Drawing.Size(120, 25);
            this.lblSalesCounter.TabIndex = 105;
            this.lblSalesCounter.Text = "Sales Details";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(772, 524);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(175, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.On_btnClose_Click);
            // 
            // frmSalesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(961, 578);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTicketGridHeading);
            this.Controls.Add(this.lblMainTime);
            this.Controls.Add(this.lblMainDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSalesCounter);
            this.Controls.Add(this.lblSlushGridHeading);
            this.Controls.Add(this.dgvMainSlush);
            this.Controls.Add(this.strahlenstudios);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtInvoiceTotalAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvMainTicket);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Details";
            this.Load += new System.EventHandler(this.On_frmSalesDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainSlush)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSlushGridHeading;
        private System.Windows.Forms.DataGridView dgvMainSlush;
        private System.Windows.Forms.LinkLabel strahlenstudios;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtInvoiceTotalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvMainTicket;
        private System.Windows.Forms.Label lblTicketGridHeading;
        private System.Windows.Forms.Label lblMainTime;
        private System.Windows.Forms.Label lblMainDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSalesCounter;
        private System.Windows.Forms.Button btnClose;
    }
}