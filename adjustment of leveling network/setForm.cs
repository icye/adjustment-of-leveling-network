using System;
using System.Windows.Forms;

namespace adjustment_of_leveling_network
{
    public partial class setForm : Form
    {
        public setForm()
        {
            InitializeComponent();
            if (commonData.Level.Length != 0)       //判断是否对参数进行设置
            {
                comboBoxLevel.Text = commonData.Level;
                comboBoxType.Text = commonData.Type;
                comboBoxWay.Text = commonData.Way;
            }
        }

        //*//////
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
        //*//////

        private void buttonOK_Click(object sender, EventArgs e)
        {
            commonData.Flag = true;
            //如果用户没有选择选项
            if (comboBoxType.Text == "" || comboBoxLevel.Text == "" || comboBoxWay.Text == "")
            {
                MessageBox.Show("设置不能为空！！！");
            }
            //否则
            else
            {
                commonData.Level = comboBoxLevel.Text;
                commonData.Type = comboBoxType.Text;
                commonData.Way = comboBoxWay.Text;
                this.Close();
            }
        }

        private void buttonNO_Click(object sender, EventArgs e)
        {
            commonData.Flag = false;
            this.Close();
        }
    }
}
