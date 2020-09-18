namespace EF_Project
{
    partial class TransferringProducts
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
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_from = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_to = new System.Windows.Forms.ComboBox();
            this.cmb_prodName = new System.Windows.Forms.ComboBox();
            this.txt_Qnty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ValidPeriod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.prodDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_supplier = new System.Windows.Forms.ComboBox();
            this.btn_transfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(45, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 65;
            this.label7.Text = "From Store";
            // 
            // cmb_from
            // 
            this.cmb_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_from.FormattingEnabled = true;
            this.cmb_from.Location = new System.Drawing.Point(125, 24);
            this.cmb_from.Name = "cmb_from";
            this.cmb_from.Size = new System.Drawing.Size(191, 24);
            this.cmb_from.TabIndex = 66;
            this.cmb_from.SelectedIndexChanged += new System.EventHandler(this.cmb_from_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(384, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "To Store";
            // 
            // cmb_to
            // 
            this.cmb_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_to.FormattingEnabled = true;
            this.cmb_to.Location = new System.Drawing.Point(448, 19);
            this.cmb_to.Name = "cmb_to";
            this.cmb_to.Size = new System.Drawing.Size(191, 24);
            this.cmb_to.TabIndex = 68;
            // 
            // cmb_prodName
            // 
            this.cmb_prodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_prodName.FormattingEnabled = true;
            this.cmb_prodName.Location = new System.Drawing.Point(125, 65);
            this.cmb_prodName.Name = "cmb_prodName";
            this.cmb_prodName.Size = new System.Drawing.Size(191, 24);
            this.cmb_prodName.TabIndex = 81;
            this.cmb_prodName.SelectedIndexChanged += new System.EventHandler(this.cmb_prodName_SelectedIndexChanged);
            // 
            // txt_Qnty
            // 
            this.txt_Qnty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Qnty.Location = new System.Drawing.Point(451, 65);
            this.txt_Qnty.Name = "txt_Qnty";
            this.txt_Qnty.Size = new System.Drawing.Size(191, 22);
            this.txt_Qnty.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(380, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 79;
            this.label6.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(58, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 78;
            this.label4.Text = "Products";
            // 
            // txt_ValidPeriod
            // 
            this.txt_ValidPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValidPeriod.Location = new System.Drawing.Point(451, 107);
            this.txt_ValidPeriod.Name = "txt_ValidPeriod";
            this.txt_ValidPeriod.Size = new System.Drawing.Size(191, 22);
            this.txt_ValidPeriod.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(341, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 84;
            this.label8.Text = "Validity Period";
            // 
            // prodDate
            // 
            this.prodDate.Location = new System.Drawing.Point(125, 106);
            this.prodDate.Name = "prodDate";
            this.prodDate.Size = new System.Drawing.Size(191, 20);
            this.prodDate.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(15, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 82;
            this.label5.Text = "Production Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(61, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 86;
            this.label2.Text = "Supplier";
            // 
            // cmb_supplier
            // 
            this.cmb_supplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_supplier.FormattingEnabled = true;
            this.cmb_supplier.Location = new System.Drawing.Point(125, 142);
            this.cmb_supplier.Name = "cmb_supplier";
            this.cmb_supplier.Size = new System.Drawing.Size(191, 24);
            this.cmb_supplier.TabIndex = 87;
            // 
            // btn_transfer
            // 
            this.btn_transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_transfer.Location = new System.Drawing.Point(286, 187);
            this.btn_transfer.Name = "btn_transfer";
            this.btn_transfer.Size = new System.Drawing.Size(158, 37);
            this.btn_transfer.TabIndex = 88;
            this.btn_transfer.Text = "Transfer";
            this.btn_transfer.UseVisualStyleBackColor = true;
            this.btn_transfer.Click += new System.EventHandler(this.btn_transfer_Click);
            // 
            // TransferringProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(690, 249);
            this.Controls.Add(this.btn_transfer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_supplier);
            this.Controls.Add(this.txt_ValidPeriod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.prodDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_prodName);
            this.Controls.Add(this.txt_Qnty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_from);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_to);
            this.Name = "TransferringProducts";
            this.Text = "TransferringProducts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_to;
        private System.Windows.Forms.ComboBox cmb_prodName;
        private System.Windows.Forms.TextBox txt_Qnty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ValidPeriod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker prodDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_supplier;
        private System.Windows.Forms.Button btn_transfer;
    }
}