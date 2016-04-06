using System;
using System.Windows.Forms;

namespace adjustment_of_leveling_network
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            //程序运行默认“保存数据”与“平差计算”按钮不可用
            buttonSaveData.Enabled = false;  
            buttonAdjustment.Enabled = false;
        }

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

        //设定“平差计算”按钮功能
        private void buttonAdjustment_Click(object sender, EventArgs e)
        {
            textBoxEnd.Text = "";
            textBoxEnd.Update();

            //调用匿名方法adjustmentData对数据进行平差
            adjustment.adjustmentData();

            //调用成功
            if (commonData.Flag_adjustmentData == true)
            {
                //打印到结果文本框
                outputEndData();
            }
            //否则
            else
                MessageBox.Show("平差失败！！！");
        }

        //参数“设置”功能
        private void buttonSet_Click(object sender, EventArgs e)
        {
            //新建临时变量暂存修改设置前参数，以判断用户是否对参数进行修改
            string tempLevel = commonData.Level;
            string tempType = commonData.Type;
            string tempWay = commonData.Way;

            //打开设置窗口
            setForm setForm = new setForm();
            setForm.ShowDialog();

            //判断设置窗口用户选择结果
            if (commonData.Flag == true)
            {
                commonData.Flag = false;

                //若用户没有对参数进行修改，则不打印
                if (commonData.Level == tempLevel && commonData.Type == tempType && commonData.Way == tempWay)
                {
                    MessageBox.Show("未对当前参数进行修改");
                }
                else
                {
                    textBoxStar.AppendText("当前参数已设置为：");
                    textBoxStar.AppendText("\n");
                    textBoxStar.AppendText("\n");
                    textBoxStar.AppendText("     " + "高程网等级：" + commonData.Level);
                    textBoxStar.AppendText("\n");
                    textBoxStar.AppendText("     " + "高程网类型：" + commonData.Type);
                    textBoxStar.AppendText("\n");
                    textBoxStar.AppendText("     " + "定权方式  ：" + commonData.Way);
                    textBoxStar.AppendText("\n");
                    textBoxStar.AppendText("\n");
                }
            }
            else return;
        }

        //设定“保存数据”按钮功能
        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            //判断是否进行过平差
            if (!(commonData.Flag_adjustmentData == true))
            {
                commonData.askStr = "未进行平差，仍然保存吗？";

                askForm askForm = new askForm();
                askForm.ShowDialog();

                if (commonData.Flag == true)
                {
                    commonData.Flag = false;

                    //txt文件不支持"\n"换行，全部替换为"\r\n"后保存文件
                    commonData.textBoxStarData = textBoxStar.Text.Replace("\n", "\r\n");
                    commonData.textBoxEndData = textBoxEnd.Text.Replace("\n", "\r\n");
                    fileOperate.saveFileData();
                }
                else return;
            }
            else
            {
                commonData.textBoxStarData = textBoxStar.Text.Replace("\n", "\r\n");
                commonData.textBoxEndData = textBoxEnd.Text.Replace("\n", "\r\n");
                fileOperate.saveFileData();
            }
        }

        //设定“导入数据”按钮功能
        private void buttonGetDate_Click(object sender, EventArgs e)
        {
            //判断是否导入过数据
            if (commonData.Flag_getFileData == true)
            {
                commonData.askStr = "需清空当前数据，继续吗？";

                //弹出询问窗口
                askForm askForm = new askForm();
                askForm.ShowDialog();

                //判断用户选择
                if (commonData.Flag == true)
                {
                    commonData.Flag = false;
                    //清空所有数据后再次导入数据
                    commonData.clearData();
                    textBoxStar.Text = "";
                    textBoxEnd.Text = "";
                    fileOperate.getFileData();
                    outputStarData();
                }
                else return;
            }
            else
            {
                fileOperate.getFileData();
                outputStarData();
            }
        }

        //增加“双击初始文本框清除所有数据”功能
        private void textBoxStar_DoubleClick_1(object sender, EventArgs e)
        {
            //判断初始文本框是否为空
            if (textBoxStar.Text.Length != 0)
            {
                commonData.askStr = "  确定清空所有数据吗？";
                askForm askForm = new askForm();
                askForm.ShowDialog();
                if (commonData.Flag == true)
                {
                    commonData.Flag = false;
                    //调用数据清除方法
                    commonData.clearData();
                    textBoxStar.Text = "";
                    textBoxEnd.Text = "";
                }
                else return;
            }
            else return;
        }

        //设定“退出”按钮功能
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (commonData.Flag_adjustmentData == true)
            {
                commonData.askStr = "确定已保存数据，退出吗？";

                askForm askForm = new askForm();
                askForm.ShowDialog();

                if (commonData.Flag == true)
                {
                    commonData.Flag = false;
                    Application.Exit();
                }
                else return;
            }
            else
            {
                Application.Exit();
            }
        }

        //依据“是否已导入数据”设定“保存数据”与“平差计算”按钮可用状态
        private void textBoxStar_TextChanged(object sender, EventArgs e)
        {
            //判断是否导入数据
            if (commonData.Flag_getFileData == true)
            {
                //设定“保存数据”与“平差计算”按钮可用
                buttonSaveData.Enabled = true;
                buttonAdjustment.Enabled = true;
            }
            else
            {
                buttonSaveData.Enabled = false;
                buttonAdjustment.Enabled = false;
            }
        }

        //打印数据到初始文本框
        private void outputStarData()
        {
            //判断是否导入过数据
            if (commonData.Flag_getFileData == true)
            {
                //将对应字符串追加到文本框
                textBoxStar.AppendText("当前参数设置为：");
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("    " + "高程网等级：" + commonData.Level);
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("    " + "高程网类型：" + commonData.Type);
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("    " + "定权方式  ：" + commonData.Way);
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("\n");

                textBoxStar.AppendText("读入的水准网数据：");
                textBoxStar.AppendText("已知点 " + commonData.Kn + " 个" + ", " + "未知点 " + commonData.Un + " 个" + ", " + "观测值 " + commonData.Hn + " 个");
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("\n");

                textBoxStar.AppendText("计算涉及点名：");
                for (int i = 0; i < commonData.Kn + commonData.Un; i++)
                {
                    textBoxStar.AppendText(commonData.Pname[i]);
                    if (i < commonData.Kn + commonData.Un - 1)
                    {
                        textBoxStar.AppendText(", ");
                    }
                }
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("\n");

                textBoxStar.AppendText("已知点的高程为：");
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("\n");
                for (int i = 0; i < commonData.Kn; i++)
                {
                    textBoxStar.AppendText("    点" + commonData.Pname[i] + "：" + commonData.Hknown[i].ToString("0.0000"));
                    textBoxStar.AppendText("\n");
                }
                textBoxStar.AppendText("\n");

                textBoxStar.AppendText("各观测值分别为：");
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("    起点   终点   高差观测值   距离观测值");
                textBoxStar.AppendText("\n");
                for (int i = 0; i < commonData.Hn; i++)
                {
                    textBoxStar.AppendText("    " + commonData.My_observation[i].Be);

                    //为了保持数据对齐打印，根据commonData.My_observation[i].Be字符长度决定空格个数，
                    //其中‘7’指“起点”的4个字符长度加3个空格长度 
                    for (int j = 0; j < 7 - commonData.My_observation[i].Be.Length; j++)
                    {
                        textBoxStar.AppendText(" ");
                    }

                    textBoxStar.AppendText(commonData.My_observation[i].En);

                    for (int j = 0; j < 7 - commonData.My_observation[i].En.Length; j++)
                    {
                        textBoxStar.AppendText(" ");
                    }

                    textBoxStar.AppendText(commonData.My_observation[i].H.ToString("0.000"));

                    for (int j = 0; j < 13 - commonData.My_observation[i].H.ToString("0.000").Length; j++)
                    {
                        textBoxStar.AppendText(" ");
                    }

                    textBoxStar.AppendText(commonData.My_observation[i].S.ToString("0.00"));

                    textBoxStar.AppendText("\n");
                }
                textBoxStar.AppendText("\n");
                textBoxStar.AppendText("\n");
            }
            else return;

            textBoxStar.Update();
        }

        //打印数据到结果文本框
        private void outputEndData()             
        {
            //判断是否已进行平差
            //if (commonData.Flag_adjustmentData == true){}
            //else return;
            //将对应字符串追加到文本框
            textBoxEnd.AppendText("    点号   " + "初始高程值(m)   " + "高程改正数(mm)   " + "平差后高程(m)");
            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("\n");

            for (int i = 0; i < commonData.Un; i++)
            {
                textBoxEnd.AppendText("    " + commonData.My_result[i].Pname);

                //为了保持数据对齐打印，根据commonData.My_observation[i].Be字符长度决定空格个数，
                //其中‘7’指“点号”的4个字符长度加3个空格长度 
                for (int j = 0; j < 7 - commonData.My_result[i].Pname.Length; j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText(commonData.My_result[i].Hstar.ToString("0.0000"));

                for (int j = 0; j < 15 - commonData.My_result[i].Hstar.ToString("0.000").Length; j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText(commonData.My_result[i].Hv.ToString("0.00"));

                for (int j = 0; j < 17 - commonData.My_result[i].Hv.ToString("0.00").Length; j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText(commonData.My_result[i].Hend.ToString("0.0000"));

                for (int j = 0; j < 15 - commonData.My_result[i].Hend.ToString("0.000").Length; j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText("\n");
            }
            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    单位权误差(mm)：" + commonData.UWMSE.ToString("0.0000"));

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("\n");


            textBoxEnd.AppendText("    ///////////////////////////////////////////////");

            textBoxEnd.AppendText("\n");

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    测段编号   " + "初始高差观测值(m)   " + "高差改正数(mm)   " + "平差后高差(m)");
            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("\n");

            for (int i = 0; i < commonData.Hn; i++)
            {
                textBoxEnd.AppendText("    ");
                textBoxEnd.AppendText(i.ToString("0"));

                for (int j = 0; j < 11 - i.ToString("0").Length; j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText(commonData.My_observation[i].H.ToString("0.000"));

                for (int j = 0; j < 20 - commonData.My_observation[i].H.ToString("0.000").Length; j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText(commonData.MatrixV[i, 0].ToString("0.000"));

                for (int j = 0; j < 17 - commonData.MatrixV[i, 0].ToString("0.000").Length; j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText(commonData.MatrixH[i].ToString("0.000"));

                textBoxEnd.AppendText("\n");
            }

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    ///////////////////////////////////////////////");
            textBoxEnd.AppendText("\n");

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    误差方程 V(x) = B(x) + L：");
            textBoxEnd.AppendText("\n");

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    矩阵 B：                                矩阵 L：");
            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("\n");

            for (int i = 0; i < commonData.Hn; i++)
            {
                int tempL = 0;
                textBoxEnd.AppendText("    ");
                for (int j = 0; j < commonData.Un; j++)
                {
                    textBoxEnd.AppendText(commonData.MatrixB[i,j].ToString("0"));
                    textBoxEnd.AppendText("   ");
                    tempL += commonData.MatrixB[i, j].ToString("0").Length;
                }

                for (int j = 0; j < 40 -  (tempL + 3* commonData.Un); j++)
                {
                    textBoxEnd.AppendText(" ");
                }

                textBoxEnd.AppendText(commonData.MatrixL[0, i].ToString("0.00"));

                textBoxEnd.AppendText("\n");
            }

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    ///////////////////////////////////////////////");
            textBoxEnd.AppendText("\n");

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    法方程系数矩阵 N：");
            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("\n");

            for (int i = 0; i < commonData.Un; i++)
            {
                textBoxEnd.AppendText("    ");
                for (int j = 0; j < commonData.Un; j++)
                {
                    textBoxEnd.AppendText(commonData.MatrixN[i, j].ToString("0.000"));
                    textBoxEnd.AppendText("   ");
                }
                textBoxEnd.AppendText("\n");
                textBoxEnd.AppendText("\n");
            }

            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("    法方程系数矩阵的逆矩阵 NN：");
            textBoxEnd.AppendText("\n");
            textBoxEnd.AppendText("\n");

            for (int i = 0; i < commonData.Un; i++)
            {
                textBoxEnd.AppendText("    ");
                for (int j = 0; j < commonData.Un; j++)
                {
                    textBoxEnd.AppendText(commonData.MatrixNN[i, j].ToString("0.000"));
                    textBoxEnd.AppendText("   ");
                }
                textBoxEnd.AppendText("\n");
                textBoxEnd.AppendText("\n");
            }

            textBoxEnd.Update();
        }
    }
}