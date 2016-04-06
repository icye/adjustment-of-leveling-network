namespace adjustment_of_leveling_network
{
    partial class askForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(askForm));
            this.labelAsk = new System.Windows.Forms.Label();
            this.buttonNO = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAsk
            // 
            this.labelAsk.AutoSize = true;
            this.labelAsk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAsk.ForeColor = System.Drawing.Color.Gray;
            this.labelAsk.Location = new System.Drawing.Point(36, 34);
            this.labelAsk.Name = "labelAsk";
            this.labelAsk.Size = new System.Drawing.Size(200, 16);
            this.labelAsk.TabIndex = 0;
            this.labelAsk.Text = "待定文本待定文本待定文本";
            this.labelAsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNO
            // 
            this.buttonNO.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNO.ForeColor = System.Drawing.Color.White;
            this.buttonNO.Location = new System.Drawing.Point(140, 75);
            this.buttonNO.Name = "buttonNO";
            this.buttonNO.Size = new System.Drawing.Size(98, 37);
            this.buttonNO.TabIndex = 11;
            this.buttonNO.Text = "取消";
            this.buttonNO.UseVisualStyleBackColor = false;
            this.buttonNO.Click += new System.EventHandler(this.buttonNO_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.ForeColor = System.Drawing.Color.White;
            this.buttonOK.Location = new System.Drawing.Point(27, 75);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(98, 37);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // askForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(265, 134);
            this.Controls.Add(this.buttonNO);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAsk);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "askForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水准网间接平差";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAsk;
        private System.Windows.Forms.Button buttonNO;
        private System.Windows.Forms.Button buttonOK;
    }
}