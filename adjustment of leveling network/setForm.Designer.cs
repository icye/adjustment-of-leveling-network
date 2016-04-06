namespace adjustment_of_leveling_network
{
    partial class setForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxWay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonNO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(44, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "高程网等级：";
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.BackColor = System.Drawing.Color.SteelBlue;
            this.comboBoxLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxLevel.ForeColor = System.Drawing.Color.White;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.ItemHeight = 14;
            this.comboBoxLevel.Items.AddRange(new object[] {
            "四等",
            "",
            "三等",
            "",
            "二等",
            "",
            "等外"});
            this.comboBoxLevel.Location = new System.Drawing.Point(157, 36);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(128, 22);
            this.comboBoxLevel.TabIndex = 3;
            // 
            // comboBoxType
            // 
            this.comboBoxType.BackColor = System.Drawing.Color.SteelBlue;
            this.comboBoxType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxType.ForeColor = System.Drawing.Color.White;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "水准",
            "",
            "高程"});
            this.comboBoxType.Location = new System.Drawing.Point(157, 69);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(128, 22);
            this.comboBoxType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(44, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "高程网类型：";
            // 
            // comboBoxWay
            // 
            this.comboBoxWay.BackColor = System.Drawing.Color.SteelBlue;
            this.comboBoxWay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxWay.ForeColor = System.Drawing.Color.White;
            this.comboBoxWay.FormattingEnabled = true;
            this.comboBoxWay.Items.AddRange(new object[] {
            "距离",
            "",
            "测站"});
            this.comboBoxWay.Location = new System.Drawing.Point(157, 102);
            this.comboBoxWay.Name = "comboBoxWay";
            this.comboBoxWay.Size = new System.Drawing.Size(128, 22);
            this.comboBoxWay.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(44, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "定权方式  ：";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(47, 161);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(98, 37);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonNO
            // 
            this.buttonNO.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNO.Location = new System.Drawing.Point(187, 161);
            this.buttonNO.Name = "buttonNO";
            this.buttonNO.Size = new System.Drawing.Size(98, 37);
            this.buttonNO.TabIndex = 9;
            this.buttonNO.Text = "取消";
            this.buttonNO.UseVisualStyleBackColor = false;
            this.buttonNO.Click += new System.EventHandler(this.buttonNO_Click);
            // 
            // setForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(331, 227);
            this.Controls.Add(this.buttonNO);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxWay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水准网间接平差";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxWay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonNO;
    }
}