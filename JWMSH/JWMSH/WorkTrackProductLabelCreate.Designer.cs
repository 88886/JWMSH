namespace JWMSH
{
    partial class WorkTrackProductLabelCreate
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
            this.lblRemainQuantity = new System.Windows.Forms.Label();
            this.uteiQuantity = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblcInvName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblcInvCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbldDate = new System.Windows.Forms.Label();
            this.lblcOrder = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uneSerial = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.uteiQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneSerial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemainQuantity
            // 
            this.lblRemainQuantity.AutoSize = true;
            this.lblRemainQuantity.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemainQuantity.Location = new System.Drawing.Point(84, 185);
            this.lblRemainQuantity.Name = "lblRemainQuantity";
            this.lblRemainQuantity.Size = new System.Drawing.Size(159, 35);
            this.lblRemainQuantity.TabIndex = 84;
            this.lblRemainQuantity.Text = "生产日期";
            // 
            // uteiQuantity
            // 
            this.uteiQuantity.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uteiQuantity.Location = new System.Drawing.Point(264, 231);
            this.uteiQuantity.MaskInput = "nnnnnn";
            this.uteiQuantity.MaxValue = 10000;
            this.uteiQuantity.MinValue = 0;
            this.uteiQuantity.Name = "uteiQuantity";
            this.uteiQuantity.Nullable = true;
            this.uteiQuantity.Size = new System.Drawing.Size(121, 43);
            this.uteiQuantity.TabIndex = 82;
            // 
            // lblcInvName
            // 
            this.lblcInvName.AutoSize = true;
            this.lblcInvName.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcInvName.Location = new System.Drawing.Point(264, 85);
            this.lblcInvName.Name = "lblcInvName";
            this.lblcInvName.Size = new System.Drawing.Size(0, 35);
            this.lblcInvName.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(156, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 35);
            this.label6.TabIndex = 75;
            this.label6.Text = "名称";
            // 
            // lblcInvCode
            // 
            this.lblcInvCode.AutoSize = true;
            this.lblcInvCode.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcInvCode.Location = new System.Drawing.Point(264, 35);
            this.lblcInvCode.Name = "lblcInvCode";
            this.lblcInvCode.Size = new System.Drawing.Size(0, 35);
            this.lblcInvCode.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(156, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 35);
            this.label4.TabIndex = 78;
            this.label4.Text = "编码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 35);
            this.label2.TabIndex = 79;
            this.label2.Text = "客户订单号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(84, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 35);
            this.label1.TabIndex = 80;
            this.label1.Text = "包装数量";
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.BackColor = System.Drawing.Color.White;
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSubmit.Location = new System.Drawing.Point(571, 354);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(95, 45);
            this.btnSubmit.TabIndex = 77;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbldDate
            // 
            this.lbldDate.AutoSize = true;
            this.lbldDate.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldDate.Location = new System.Drawing.Point(264, 185);
            this.lbldDate.Name = "lbldDate";
            this.lbldDate.Size = new System.Drawing.Size(0, 35);
            this.lbldDate.TabIndex = 85;
            // 
            // lblcOrder
            // 
            this.lblcOrder.AutoSize = true;
            this.lblcOrder.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcOrder.Location = new System.Drawing.Point(264, 135);
            this.lblcOrder.Name = "lblcOrder";
            this.lblcOrder.Size = new System.Drawing.Size(0, 35);
            this.lblcOrder.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(156, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 35);
            this.label3.TabIndex = 88;
            this.label3.Text = "备注";
            // 
            // txtcMemo
            // 
            this.txtcMemo.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcMemo.Location = new System.Drawing.Point(264, 279);
            this.txtcMemo.Name = "txtcMemo";
            this.txtcMemo.Size = new System.Drawing.Size(402, 47);
            this.txtcMemo.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(419, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 35);
            this.label5.TabIndex = 89;
            this.label5.Text = "序列数";
            // 
            // uneSerial
            // 
            this.uneSerial.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uneSerial.Location = new System.Drawing.Point(545, 231);
            this.uneSerial.MaskInput = "nnnnnn";
            this.uneSerial.MaxValue = 10000;
            this.uneSerial.MinValue = 0;
            this.uneSerial.Name = "uneSerial";
            this.uneSerial.Nullable = true;
            this.uneSerial.Size = new System.Drawing.Size(121, 43);
            this.uneSerial.TabIndex = 90;
            // 
            // WorkTrackProductLabelCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 451);
            this.Controls.Add(this.uneSerial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcMemo);
            this.Controls.Add(this.lbldDate);
            this.Controls.Add(this.lblcOrder);
            this.Controls.Add(this.lblRemainQuantity);
            this.Controls.Add(this.uteiQuantity);
            this.Controls.Add(this.lblcInvName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblcInvCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Icon = global::JWMSH.Properties.Resources.scanicon;
            this.Name = "WorkTrackProductLabelCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成产成品标签序列";
            this.Load += new System.EventHandler(this.WorkTrackProductLabelCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uteiQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneSerial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemainQuantity;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uteiQuantity;
        private System.Windows.Forms.Label lblcInvName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblcInvCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lbldDate;
        private System.Windows.Forms.Label lblcOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcMemo;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneSerial;
    }
}