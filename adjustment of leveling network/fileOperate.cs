using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace adjustment_of_leveling_network
{
    /// 进行文件流操作
    class fileOperate
    {
        //获取数据
        public static void getFileData()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "@:\\";
                openFileDialog.Filter = "(*.txt)|*.txt|(*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //StreamReader streamReader = new StreamReader(openFileDialog.FileName, true);// 打开文件可能乱码 修改如下
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.Default);

                    //确定已导入数据，不能放在该判断语句外，防止出现调用getFileData方法但不导入数据的情况
                    commonData.Flag_getFileData = true;

                    string strData = String.Empty;
                    string[] strTemp;
                    int dataIdx = 0;

                    while (streamReader.Peek() != -1)
                    {
                        //增加索引值已区别导入数据前四行
                        dataIdx++;

                        //"strData"存储剔除空格逐行读取文档的当前行所有字符，
                        // "strTemp"以数组形式存储当前行，以逗号分隔
                        strData = streamReader.ReadLine().Trim();
                        strTemp = strData.Trim().Split(',');

                        //存储第一行参数设置
                        if (dataIdx == 1)
                        {
                            commonData.Level = strTemp[0];
                            commonData.Type = strTemp[1];
                            commonData.Way = strTemp[2];
                        }
                        //存储第二行点数
                        else if (dataIdx == 2)
                        {
                            commonData.Kn = Convert.ToInt16(strTemp[0]);
                            commonData.Un = Convert.ToInt16(strTemp[1]);
                            commonData.Hn = Convert.ToInt16(strTemp[2]);

                            commonData.My_observation = new commonData.observation[commonData.Hn];

                            commonData.My_result = new commonData.result[commonData.Un];

                            ////*//根据读取到的点的个数创建存储数组

                            commonData.Pname = new string[commonData.Kn + commonData.Un];

                            commonData.Hknown = new double[commonData.Kn];

                            //未知点近似高程
                            commonData.Hcirca = new double[commonData.Un];

                            //误差方程“V = B(x) + L"中的矩阵B
                            commonData.MatrixB = new double[commonData.Hn, commonData.Un];

                            //误差方程“V = B(x) + L"中的矩阵L
                            commonData.MatrixL = new double[1, commonData.Hn];

                            //误差方程“V = B(x) + L"中的矩阵P
                            commonData.MatrixP = new double[commonData.Hn, commonData.Hn];

                            //法方程系数矩阵
                            commonData.MatrixN = new double[commonData.Un, commonData.Un];

                            //法方程系数矩阵的逆矩
                            commonData.MatrixNN = new double[commonData.Un, commonData.Un];

                            //各点高程改正数
                            commonData.MatrixX = new double[commonData.Un, 1];

                            //高差观测值改正数
                            commonData.MatrixV = new double[commonData.Hn, 1];

                            //平差高差观测值
                            commonData.MatrixH = new double[commonData.Hn];
                        }

                        //存储第三行点名
                        else if (dataIdx == 3)
                        {
                            strTemp.CopyTo(commonData.Pname, 0);
                        }

                        //存储第四行已知高程
                        else if (dataIdx == 4)
                        {
                            for (int i = 0; i < commonData.Kn; i++)
                            {
                                commonData.Hknown[i] = Convert.ToDouble(strTemp[i]);
                            }
                        }

                        //存储自第五行起高程观测值
                        else
                        {
                            commonData.My_observation[dataIdx - 5].Be = strTemp[0];
                            commonData.My_observation[dataIdx - 5].En = strTemp[1];
                            commonData.My_observation[dataIdx - 5].H = Convert.ToDouble(strTemp[2]);
                            commonData.My_observation[dataIdx - 5].S = Convert.ToDouble(strTemp[3]);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("读取的文件不符合数据排列规范，请参考示例数据！！！");
                commonData.clearData();
            }   
        }

        //保存数据
        public static void saveFileData()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            saveFileDialog.FileName = "平差结果-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm") + ".txt";     //将日期时间作为文件名
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);
                streamWriter.Write("\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write(DateTime.Now.ToString("yyyy年MM月dd日  HH:mm"));
                streamWriter.Write("\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write("起算数据及中间过程---------------------------------------------------------------------");
                streamWriter.Write("\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write(commonData.textBoxStarData);    //txt文档中换行符为\r\n,需进行替换

                streamWriter.Write("\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write("平差结果-------------------------------------------------------------------------------");
                streamWriter.Write("\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write(commonData.textBoxEndData);
                streamWriter.Close();
            }
        }
    }
}
