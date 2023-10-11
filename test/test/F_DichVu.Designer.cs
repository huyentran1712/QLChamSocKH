
namespace test
{
    partial class F_DichVu
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
            this.dvg_dichvu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Makh = new System.Windows.Forms.TextBox();
            this.txt_Madv = new System.Windows.Forms.TextBox();
            this.txt_Tendv = new System.Windows.Forms.TextBox();
            this.txt_Giadv = new System.Windows.Forms.TextBox();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.Madv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tendv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_dichvu)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_dichvu
            // 
            this.dvg_dichvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_dichvu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Madv,
            this.Tendv,
            this.Gia});
            this.dvg_dichvu.Location = new System.Drawing.Point(27, 22);
            this.dvg_dichvu.Name = "dvg_dichvu";
            this.dvg_dichvu.Size = new System.Drawing.Size(368, 398);
            this.dvg_dichvu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ DỊCH VỤ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã dịch vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(422, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên dịch vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(428, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giá dịch vụ";
            // 
            // txt_Makh
            // 
            this.txt_Makh.Location = new System.Drawing.Point(566, 101);
            this.txt_Makh.Name = "txt_Makh";
            this.txt_Makh.Size = new System.Drawing.Size(203, 20);
            this.txt_Makh.TabIndex = 6;
            // 
            // txt_Madv
            // 
            this.txt_Madv.Location = new System.Drawing.Point(566, 151);
            this.txt_Madv.Name = "txt_Madv";
            this.txt_Madv.Size = new System.Drawing.Size(203, 20);
            this.txt_Madv.TabIndex = 7;
            // 
            // txt_Tendv
            // 
            this.txt_Tendv.Location = new System.Drawing.Point(566, 197);
            this.txt_Tendv.Name = "txt_Tendv";
            this.txt_Tendv.Size = new System.Drawing.Size(203, 20);
            this.txt_Tendv.TabIndex = 8;
            // 
            // txt_Giadv
            // 
            this.txt_Giadv.Location = new System.Drawing.Point(566, 247);
            this.txt_Giadv.Name = "txt_Giadv";
            this.txt_Giadv.Size = new System.Drawing.Size(203, 20);
            this.txt_Giadv.TabIndex = 9;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(471, 309);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 49);
            this.btn_Them.TabIndex = 10;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(578, 309);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 49);
            this.btn_Xoa.TabIndex = 11;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(683, 307);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(75, 49);
            this.btn_Sua.TabIndex = 12;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // Madv
            // 
            this.Madv.HeaderText = "Mã dịch vụ";
            this.Madv.Name = "Madv";
            // 
            // Tendv
            // 
            this.Tendv.HeaderText = "Tên dịch vụ";
            this.Tendv.Name = "Tendv";
            // 
            // Gia
            // 
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            // 
            // F_DichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.txt_Giadv);
            this.Controls.Add(this.txt_Tendv);
            this.Controls.Add(this.txt_Madv);
            this.Controls.Add(this.txt_Makh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dvg_dichvu);
            this.Name = "F_DichVu";
            this.Text = "F_DichVu";
            this.Load += new System.EventHandler(this.F_DichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_dichvu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_dichvu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Makh;
        private System.Windows.Forms.TextBox txt_Madv;
        private System.Windows.Forms.TextBox txt_Tendv;
        private System.Windows.Forms.TextBox txt_Giadv;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Madv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tendv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
    }
}