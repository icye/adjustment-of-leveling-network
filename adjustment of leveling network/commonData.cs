using System;

namespace adjustment_of_leveling_network
{
    ///定义所有数据
    class commonData
    {
        //-------------------------------------------------------------------
        public static string Level = "";         //高程网等级
        public static string Type = "";          //高程网类型
        public static string Way = "";           //定权方式

        public static int Kn = 0;                //已知点数
        public static int Un = 0;                //未知点数
        public static int Hn = 0;                //观测点数

        public static double UWMSE = 0;          //单位权中误差

        public static string[] Pname;            //点名
        public static double[] Hknown;           //已知点高程
        public static double[] Hcirca;           //未知点近似高程

        public struct observation                //高程观测值
        {
            public string Be;                    //观测起点点号
            public string En;                    //观测终点点号
            public double H;                     //高差观测值
            public double S;                     //距离观测值
        }

        public struct result                     //平差结果
        {
            public string Pname;                 //点名
            public double Hstar;                 //各点初始高程
            public double Hv;                    //各点高程改正数
            public double Hend;                  //平差后高程
        }

        public static observation[] My_observation;

        public static result[] My_result;

        //误差方程V=B(x) + L,矩阵B
        public static double[,] MatrixB;

        //误差方程V=B(x) + L,矩阵L
        public static double[,] MatrixL;

        //距离定权矩阵
        public static double[,] MatrixP;

        //法方程系数矩阵
        public static double[,] MatrixN;

        //法方程系数矩阵的逆矩阵
        public static double[,] MatrixNN;

        //各点高程改正数
        public static double[,] MatrixX;

        //高差观测值改正数
        public static double[,] MatrixV;

        //平差高差观测值
        public static double[] MatrixH;

        public static string askStr = "";        //“询问对话框”内容
        public static bool Flag = false;         //“询问对话框”用户判断结果
        public static bool Flag_getFileData = false;     //是否导入数据
        public static bool Flag_adjustmentData = false;  //是否进行平差

        public static string textBoxStarData;    //初始文本框数据副本
        public static string textBoxEndData;     //结果文本框数据副本
        //-------------------------------------------------------------------

        public static void clearData()
        {
            //判断是否导入过数据，将所有数据清零
            if (Flag_getFileData == true)
            {
                //Array.Clear(Pname, 0, Kn + Un);
                //Array.Clear(Hknown, 0, Kn);
                //Array.Clear(My_observation, 0, Hn);
                Pname = null;
                Hknown = null;
                My_observation = null;

                if (Flag_adjustmentData == true)
                {
                    MatrixB = null;
                    MatrixL = null;
                    MatrixP = null;
                    MatrixN = null;
                    MatrixNN = null;
                    MatrixX = null;
                    MatrixV = null;
                    My_result = null;
                    //Array.Clear(My_result, 0, Un);
                    UWMSE = 0;

                }
            }
            Level = "";
            Type = "";
            Way = "";
            Kn = 0;
            Un = 0;
            Hn = 0;
            askStr = "";
            Flag = false;
            Flag_getFileData = false;
            Flag_adjustmentData = false;
            textBoxStarData = "";
            textBoxEndData = "";
        }
    }
}
