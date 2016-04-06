namespace adjustment_of_leveling_network
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxStar = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxEnd = new System.Windows.Forms.RichTextBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonGetDate = new System.Windows.Forms.Button();
            this.buttonAdjustment = new System.Windows.Forms.Button();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxStar);
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(10, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 245);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "起算数据及中间过程（双击文本框清空数据）";
            // 
            // textBoxStar
            // 
            this.textBoxStar.BackColor = System.Drawing.Color.White;
            this.textBoxStar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxStar.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStar.Location = new System.Drawing.Point(8, 20);
            this.textBoxStar.Name = "textBoxStar";
            this.textBoxStar.ReadOnly = true;
            this.textBoxStar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textBoxStar.Size = new System.Drawing.Size(430, 219);
            this.textBoxStar.TabIndex = 1;
            this.textBoxStar.Text = "";
            this.textBoxStar.WordWrap = false;
            this.textBoxStar.TextChanged += new System.EventHandler(this.textBoxStar_TextChanged);
            this.textBoxStar.DoubleClick += new System.EventHandler(this.textBoxStar_DoubleClick_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxEnd);
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(10, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 302);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "平差结果";
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.BackColor = System.Drawing.Color.White;
            this.textBoxEnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxEnd.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxEnd.Location = new System.Drawing.Point(8, 20);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.ReadOnly = true;
            this.textBoxEnd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textBoxEnd.Size = new System.Drawing.Size(430, 273);
            this.textBoxEnd.TabIndex = 2;
            this.textBoxEnd.Text = "";
            this.textBoxEnd.WordWrap = false;
            // 
            // buttonSet
            // 
            this.buttonSet.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSet.ForeColor = System.Drawing.Color.White;
            this.buttonSet.Location = new System.Drawing.Point(10, 606);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(91, 35);
            this.buttonSet.TabIndex = 2;
            this.buttonSet.Text = "设置参数";
            this.buttonSet.UseVisualStyleBackColor = false;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonGetDate
            // 
            this.buttonGetDate.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGetDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetDate.ForeColor = System.Drawing.Color.White;
            this.buttonGetDate.Location = new System.Drawing.Point(98, 606);
            this.buttonGetDate.Name = "buttonGetDate";
            this.buttonGetDate.Size = new System.Drawing.Size(91, 35);
            this.buttonGetDate.TabIndex = 3;
            this.buttonGetDate.Text = "导入数据";
            this.buttonGetDate.UseVisualStyleBackColor = false;
            this.buttonGetDate.Click += new System.EventHandler(this.buttonGetDate_Click);
            // 
            // buttonAdjustment
            // 
            this.buttonAdjustment.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdjustment.ForeColor = System.Drawing.Color.White;
            this.buttonAdjustment.Location = new System.Drawing.Point(186, 606);
            this.buttonAdjustment.Name = "buttonAdjustment";
            this.buttonAdjustment.Size = new System.Drawing.Size(91, 35);
            this.buttonAdjustment.TabIndex = 4;
            this.buttonAdjustment.Text = "平差计算";
            this.buttonAdjustment.UseVisualStyleBackColor = false;
            this.buttonAdjustment.Click += new System.EventHandler(this.buttonAdjustment_Click);
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveData.ForeColor = System.Drawing.Color.White;
            this.buttonSaveData.Location = new System.Drawing.Point(274, 606);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(91, 35);
            this.buttonSaveData.TabIndex = 5;
            this.buttonSaveData.Text = "保存数据";
            this.buttonSaveData.UseVisualStyleBackColor = false;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(363, 606);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(91, 35);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(464, 659);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.buttonAdjustment);
            this.Controls.Add(this.buttonGetDate);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水准网间接平差";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonGetDate;
        private System.Windows.Forms.Button buttonAdjustment;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.RichTextBox textBoxStar;
        private System.Windows.Forms.RichTextBox textBoxEnd;
        private System.Windows.Forms.Button buttonExit;
    }
}

