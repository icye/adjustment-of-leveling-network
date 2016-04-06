using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adjustment_of_leveling_network
{
    public class adjustment
    {
        ///*//此函数通过调用errors_equation项目，求得误差方
        ///调用InverseMatrix项目，求得平差结果
        public static void adjustmentData()
        {
            try
            {
                //实例化errors_equation对象
                errors_equation.errors_equation my_errors_equation = new errors_equation.errors_equation(commonData.Hn, commonData.Kn + commonData.Un, commonData.Kn, commonData.Pname, commonData.Hknown);

                //传递观测值
                for (int i = 0; i < commonData.Hn; i++)
                {
                    my_errors_equation.createObservation(i, commonData.My_observation[i].Be, commonData.My_observation[i].En, commonData.My_observation[i].H, commonData.My_observation[i].S);
                }

                //调用crateErrorsEquation方法得到误差方程与点高程近似值
                my_errors_equation.crateErrorsEquation();

                //得到点高程近似值
                commonData.Hcirca = my_errors_equation.getHcirca();

                //得到误差方程“V = B(x) + L"中的矩阵B
                commonData.MatrixB = my_errors_equation.getMatrixB();

                //得到误差方程“V = B(x)  L"中的矩阵L
                commonData.MatrixL = my_errors_equation.getMatrixL();

                //得到权矩阵
                commonData.MatrixP = my_errors_equation.getMatrixP();

                //为存储一系列矩阵运算过程中间值定义临时矩阵
                double[,] tempA = new double[commonData.Un, commonData.Hn];
                double[,] tempB = new double[commonData.Hn, 1];
                double[,] tempC = new double[commonData.Un, 1];
                double[,] tempD = new double[commonData.Hn, 1];
                double[,] tempE = new double[1, commonData.Hn];
                double[,] tempF = new double[1, 1];

                //*///以下语句通过调用InverseMatrix矩阵运算项目中的相关方法
                //进行平差过程中的相关矩阵运算
                ///////////////////////////////////////////////////////////

                //还原算式："N = 000000B(转置)*P*B " 求得法方程系数矩阵 N
                tempA = InverseMatrix.InverseMatrix.TransposeMatrix(commonData.MatrixB);
                tempA = InverseMatrix.InverseMatrix.MatrixMultiplication(tempA, commonData.MatrixP);
                commonData.MatrixN = InverseMatrix.InverseMatrix.MatrixMultiplication(tempA, commonData.MatrixB);

                //对法方程系数矩阵 N 进行矩阵求逆
                commonData.MatrixNN = InverseMatrix.InverseMatrix.GetInverseMatrix(commonData.MatrixN);

                //还原算式："X = N(求逆)*(B(转置)*P*L(转置))" 求得各点高程改正数X
                tempB = InverseMatrix.InverseMatrix.TransposeMatrix(commonData.MatrixL);
                tempC = InverseMatrix.InverseMatrix.MatrixMultiplication(tempA, tempB);
                commonData.MatrixX = InverseMatrix.InverseMatrix.MatrixMultiplication(commonData.MatrixNN, tempC);

                //还原算式："V = B*X - L(转置)" 求得各观测高差改正数V
                tempD = InverseMatrix.InverseMatrix.MatrixMultiplication(commonData.MatrixB, commonData.MatrixX);
                for (int i = 0; i < commonData.Hn; i++)
                {
                    commonData.MatrixV[i, 0] = tempD[i, 0] - tempB[i, 0];
                }

                //还原算式："UWMSE = sqrt((V(转置)*P*V)/3)" 求得单位权中误差UWMSE
                tempE = InverseMatrix.InverseMatrix.TransposeMatrix(commonData.MatrixV);
                tempE = InverseMatrix.InverseMatrix.MatrixMultiplication(tempE, commonData.MatrixP);
                tempF = InverseMatrix.InverseMatrix.MatrixMultiplication(tempE, commonData.MatrixV);
                commonData.UWMSE = Math.Sqrt(tempF[0, 0]) / 3.0;

                //将各矩阵赋值到平差结果结构体里
                for (int i = 0; i < commonData.Un; i++)
                {
                    commonData.My_result[i].Pname = commonData.Pname[i + commonData.Kn];
                    commonData.My_result[i].Hstar = commonData.Hcirca[i];
                    commonData.My_result[i].Hv = commonData.MatrixX[i, 0];
                    commonData.My_result[i].Hend = commonData.MatrixX[i, 0] * 0.001 + commonData.Hcirca[i];
                }

                for (int i = 0; i < commonData.Hn; i++)
                {
                    commonData.MatrixH[i] = commonData.My_observation[i].H + commonData.MatrixV[i, 0]*0.001;
                }

                //是否成功平差标志为真
                commonData.Flag_adjustmentData = true;
            }

            catch
            {
                //是否成功平差标志为假
                commonData.Flag_adjustmentData = false;
            }
        }
    }
}
