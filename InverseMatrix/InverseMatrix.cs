namespace InverseMatrix
{
    public class InverseMatrix
    {
        //矩阵求逆
        public static double[,] GetInverseMatrix(double[,] M_original)
        {
            int order = M_original.GetLength(0);

            double[,] M_inverse = new double[order, order];

            /* 定义扩展矩阵 */
            double[,] M_expand;
            M_expand = new double[order, 2 * order];

            /* 初始化扩展矩阵 */
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < 2 * order; j++)
                {
                    if (j < order)
                    {
                        M_expand[i, j] = M_original[i, j];
                    }
                    else
                    {
                        if (j - i == order)
                        {
                            M_expand[i, j] = 1;
                        }
                        else
                        {
                            M_expand[i, j] = 0;
                        }
                    }
                }
            }
            /* 调整扩展矩阵 */
            //bool flag1 = true;
            for (int i = 0; i < order; i++)
            {
                if (M_expand[i, i] == 0)//如果某行对角线数值为0  
                {
                    int j;
                    /*搜索该列其他不为0的行，如果都为0，则返回false*/
                    for (j = i + 1; j < order; j++)
                    {
                        if (M_expand[j, i] != 0)//如果有不为0的行，交换这两行 
                        {
                            double temp = 0;
                            for (int k = 0; k < 2 * order; k++)
                            {
                                temp = M_expand[i, k];
                                M_expand[i, k] = M_expand[j, k];
                                M_expand[j, k] = temp;
                            }
                            break;
                        }
                    }
                    /*
                    if (j >= order) //没有不为0的行  
                    {
                        flag1 = false;
                        break;
                    }
                    */
                }
                /*
                if (!flag1)
                {
                    break;
                }
                */
            }
            /*
            if (!flag1)
            {
                return false;
            }
            */
            /* 计算扩展矩阵 */
            //bool flag2 = true;
            for (int i = 0; i < order; i++)
            {
                double first_element = M_expand[i, i];
                if (first_element == 0)
                {
                    //flag2 = false;
                    break;
                }
                for (int j = 0; j < 2 * order; j++)
                {
                    M_expand[i, j] /= first_element;//将该行所有元素除以首元素  
                }
                /*把其他行再该列的数值都化为0*/
                for (int m = 0; m < order; m++)
                {
                    if (m == i)//遇到自己的行跳过  
                    {
                        continue;
                    }
                    double times = M_expand[m, i];
                    for (int n = 0; n < 2 * order; n++)
                    {
                        M_expand[m, n] -= M_expand[i, n] * times;
                    }
                }
            }
            /*
            if (!flag2)
            {
                return false;
            }
            */
            /* 获得逆矩阵 */
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    M_inverse[i, j] = M_expand[i, j + order];
                }
            }
            return M_inverse;
        }

        //矩阵相乘
        public static double[,] MatrixMultiplication(double[,] A, double[,] B)
        {
            int row_A = A.GetLength(0);
            int column_A = A.GetLength(1);
            int row_B = B.GetLength(0);
            int column_B = B.GetLength(1);

            double[,] C = new double[row_A, column_B];

            for (int i = 0; i < row_A; i++)
            {
                for (int j = 0; j < column_B; j++)
                {
                    for (int k = 0; k < column_A; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }

        //矩阵转置
        public static double[,] TransposeMatrix(double[,] M_original)
        {
            int row = M_original.GetLength(0);
            int column = M_original.GetLength(1);

            double[,] B = new double[column, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    B[j,i] = M_original[i,j]; 
                }
            }
            return B;
        }
    }
}
