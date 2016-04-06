using System;

namespace errors_equation
{
    ///*/此类中的方法通过调用shortest_path中的方法，
    ///求得未知点与已知点中的最短路径
    ///通过最短路径求得未知点的高程近似值
    ///最后求得误差方程
    public class errors_equation
    {
        //定义点结构体，包含点编号，点名，近似高程与精确高程
        private struct point
        {
            public int index;
            public string name;
            public double Hexact;
            public double Hcirca;
        }

        private struct observation
        {
            public string starName;
            public string stopName;
            public double Height;
            public double length;
        }
            
        private point[] my_point;
        private observation[] my_observation;

        private int pathNum;                //测段数
        private int pointNum;               //点数
        private int pointNum_K;             //已知点数

        private string[] pointName;         //点名
        private double[] ponintHknown;      //已知点高程

        private string[] singlePath;        //定义最短路径的单项值
        private string[,] mixPath;          //定义最短路径

        private double[] singleDistance;    //定义通过最短路径的距离的单项值
        private double[,] mixDistance;      //定义通过所有最短路径的距离

        private int[] indexMix;              //存储最短路编号
        private string[] pathMix;            //存储最短路径

        private short[,] singlePolynomial;      //误差方程未知项系数
        private double[] constantPolynomial;     //误差方程常数项

        private double[,] MatrixB;
        private double[,] MatrixL;
        private double[,] MatrixP;

        public errors_equation(int my_pathNum, int my_pointNum, int my_pointNum_K, string[] my_pointName, double[] my_ponintHknown)
        {
            pathNum = my_pathNum;
            pointNum = my_pointNum;
            pointNum_K = my_pointNum_K;

            my_point = new point[pointNum];
            my_observation = new observation[pathNum];

            singlePath = new string[pointNum];
            //Array.Clear(singlePath, 0, my_pointNum);
            mixPath = new string[pointNum - pointNum_K, pointNum_K];

            singleDistance = new double[pointNum];
            //Array.Clear(singleDistance, 0, my_pointNum);
            mixDistance = new double[pointNum - pointNum_K, pointNum_K];

            indexMix = new int[(pointNum - my_pointNum_K)];
            //Array.Clear(indexMix, 0, pointNum - pointNum_K);
            pathMix = new string[(pointNum - pointNum_K)];
            //Array.Clear(pathMix, 0, pointNum - pointNum_K);

            pointName = new string[pointNum];
            //Array.Copy(my_pointName, pointName, 0);
            ponintHknown = new double[pointNum];
            //Array.Copy(my_ponintHknown, ponintHknown, 0);

            singlePolynomial = new short[pathNum, pointNum - pointNum_K];
            constantPolynomial = new double[pathNum];
            //Array.Clear(constantPolynomial, 0, pathNum);

            MatrixB = new double[pathNum, pointNum - pointNum_K];
            MatrixL = new double[1,pathNum];
            MatrixP = new double[pathNum, pathNum];

            for (int i = 0; i < pointNum; i++)
            {
                my_point[i].index = i;
                my_point[i].name = my_pointName[i];

                pointName[i] = my_pointName[i];

                for (int j = 0; j < pointNum - pointNum_K; j++)
                {
                    singlePolynomial[i, j] = 0;
                }

                if (i < pointNum_K)
                {
                    ponintHknown[i] = my_ponintHknown[i];
                    my_point[i].Hexact = ponintHknown[i];
                    my_point[i].Hcirca = ponintHknown[i];
                }
                else
                {
                    my_point[i].Hexact = 0;
                    my_point[i].Hcirca = 0;
                }
            }
        }

        public void createObservation(int i, string starName, string stopName, double Height, double length)
        {
            //获取观测值
            my_observation[i].starName = starName;
            my_observation[i].stopName = stopName;
            my_observation[i].Height = Height;
            my_observation[i].length = length;
        }

        public void crateErrorsEquation()
        {
            //实例化shortest_path对象
            shortest_path.shortest_path my_shortest_path = new shortest_path.shortest_path(pathNum, pointNum, pointName);

            //为shortest_path中的观测值赋值
            for (int i = 0; i < pathNum; i++)
            {
                my_shortest_path.createObservation(i, my_observation[i].starName, my_observation[i].stopName, my_observation[i].length);
            }

            //建立路径无向图
            my_shortest_path.createGraph();

            //********//
            //调用Dijkstra方法
            //找出所有未知点与其他点两两间的最短距离与最短路径
            for (int i = 0; i < pointNum - pointNum_K; i++)
            {
                my_shortest_path.Dijkstra(i + pointNum_K);

                singlePath = my_shortest_path.getmixPath();
                singleDistance = my_shortest_path.getmixDistance();

                for (int j = 0; j < pointNum_K; j++)
                {
                    mixPath[i,j] = singlePath[j];
                    mixDistance[i,j] = singleDistance[j];
                }

                Array.Clear(singlePath, 0, pointNum);
                Array.Clear(singleDistance, 0, pointNum);
            }

            //********//
            //找出每个未知点到每个已知点中最近距离的编号
            for (int i = 0; i < pointNum - pointNum_K; i++)
            {
                double tempMix = mixDistance[i, 0];
                indexMix[i] = 0;
                if (pointNum_K != 1)
                {
                    for (int j = 0; j < pointNum_K - 1; j++)
                    {
                        if (mixDistance[i, j + 1] < tempMix)
                        {
                            indexMix[i] = j + 1;
                            tempMix = mixDistance[i, j + 1];
                        }
                    }
                }
            }

            //********//
            //根据编号找出每个未知点到每个已知点中最近距离的路径
            for (int i = 0; i < pointNum - pointNum_K; i++)
            {
                for (int j = 0; j < pointNum_K; j++)
                {
                    if (j == indexMix[i])
                        pathMix[i] = mixPath[i,j];
                }
            }

            //********//
            //根据最近距离的路径得到所有未知点近似高程
            for (int i = 0; i < pointNum - pointNum_K; i++)
            {
                //根据点名路径获取点编号路径
                int[] digitPath = getDigitPath(pathMix[i]);

                double Height = 0.0;

                //初始该未知点的近似高程为离该点最近已知点高程
                my_point[i + pointNum_K].Hcirca = my_point[digitPath[digitPath.Length - 1]].Hexact;

                for (int j = digitPath.Length - 1; j > 0; j--)
                {
                    double singleHeight = 0.0;
                    for (int k = 0; k < pathNum; k++)
                    {
                        //如果路径等于观测路径，返回观测高差
                        if (my_point[digitPath[j]].name == my_observation[k].starName && my_point[digitPath[j - 1]].name == my_observation[k].stopName)
                        {
                            singleHeight = my_observation[k].Height;
                            k = pathNum;
                        }
                        //如果路径等于观测路径的反项，返回观测高差的负数
                        else if (my_point[digitPath[j]].name == my_observation[k].stopName && my_point[digitPath[j - 1]].name == my_observation[k].starName)
                        {
                            singleHeight = -(my_observation[k].Height);
                            k = pathNum;
                        }
                    }
                    Height += singleHeight;
                }

                my_point[i + pointNum_K].Hcirca += Height;
            }

            ////********//
            //根据公式“（起点近似高程 + 起点近似高程误差）+ （观测高差 + 观测高差误差） = （终点近似高程 + 终点近似高程误差）”
            //即 “观测高差误差 = （终点近似高程误差 - 起点近似高程误差）+ （终点近似高程 - 起点近似高程 - 观测高差） ”
            //先找到观测值起点与终点的编号
            //对所有未知点进行遍历，如果第 j 个点是第 i 个观测高差中的起点 
            //则误差方程未知项系数第 i 行 第 j 列 的值 为 -1 
            //如果第 j（j < 未知点数） 是第 i（i < 观测高差个数） 个观测高差中的终点
            //则误差方程 第 i 行 第 j 列 的值 为 1
            //误差方程 第 i 项常数项就根据上面的公式算出
            for (int i = 0; i < pathNum; i++)
            {
                //获取 观测值起点与终点的点编号
                int starIndex = Array.IndexOf(pointName, my_observation[i].starName);
                int stopIndex = Array.IndexOf(pointName, my_observation[i].stopName);

                for (int j = 0; j < pointNum - pointNum_K; j++)
                {
                    if (j + pointNum_K == starIndex || j + pointNum_K == stopIndex)
                    {
                        //为未知项系数赋值
                        if (j + pointNum_K == starIndex)
                        {
                            singlePolynomial[i, j] = -1;
                        }
                        else
                        {
                            singlePolynomial[i, j] = 1;
                        }
                    }
                }
                //为常数项赋值
                constantPolynomial[i] = -1000*(my_point[stopIndex].Hcirca - my_point[starIndex].Hcirca - my_observation[i].Height);
            }

            //将误差方程未知项系数赋值到B矩阵
            for (int i = 0; i < pathNum; i++)
                for (int j = 0; j < pointNum - pointNum_K; j++)
                    MatrixB[i,j] = singlePolynomial[i, j];

            //将误差方程常数项赋值到L矩阵
            for (int i = 0; i < pointNum; i++)
            {
                MatrixL[0, i] = constantPolynomial[i];
            }

            //赋值权矩阵
            for (int i = 0; i < pathNum; i++)
                for (int j = 0; j < pathNum; j++)
                {
                    if (j == i)
                    {
                        MatrixP[i,j] = 1.0/my_observation[i].length;
                    }
                    else
                        MatrixP[i,j] = 0.0;
                }

        }

        //根据点名路径返回点编号路径
        private int[] getDigitPath(string stringPath)
        {
            string[] strTemp = stringPath.Trim().Split(',');
            int l = strTemp.Length;
            int[] intPath = new int[l];
            for (int i = 0; i < l; i++)
            {
                intPath[i] = Array.IndexOf(pointName, strTemp[i]);
            }
            return intPath;
        }

        //返回点高程近似值
        public double[] getHcirca()
        {
            double[] Hcirca = new double[pointNum-pointNum_K];

            for (int i = pointNum_K; i < pointNum; i++)
            {
                Hcirca[i - pointNum_K] = my_point[i].Hcirca;
            }
            return Hcirca;
        }

        //返回。。。
        public double[,] getMatrixB()
        {
            return MatrixB;
        }

        public double[,] getMatrixL()
        {
            return MatrixL;
        }

        public double[,] getMatrixP()
        {
            return MatrixP;
        }
    }
}
