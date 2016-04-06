using System;
using System.Windows.Forms;

namespace adjustment_of_leveling_network
{
    public partial class askForm : Form
    {
        public askForm()
        {
            InitializeComponent();
            labelAsk.Text = commonData.askStr;
        }

        //*///////
        //禁用当前窗体的关闭按钮
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        //*///////

        private void buttonOK_Click(object sender, EventArgs e)
        {
            commonData.Flag = true;
            this.Close();
        }

        private void buttonNO_Click(object sender, EventArgs e)
        {
            commonData.Flag = false;
            this.Close();
        }
    }
}
