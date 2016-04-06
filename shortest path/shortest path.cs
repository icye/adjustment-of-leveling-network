using System;

namespace shortest_path
{
    public class shortest_path
    {
        private const double INFINITY = 999999.00;               //定义无限远

        private string[] mixPath;     //最短路径数组，存储源点到所有点的最短路径

        private string singlePath = "";   //源点到单个点的最短路径

        private double[] mixDistance;     //最短距离数组，存储源点到所有点的最短距离

        private bool[] tagPoint;      //定义Tag数组标记数组中的某点是否已经找到最短路径

        //定义无向图，记录所有顶点间边的关系
        private struct graph
        {
            public int pathNum;           //边数
            public int pointNum;          //点数
            public string[] pointName;    //点名
            public double[,] pathDisdance;  //点距
        }

        private struct observation
        {
            public string starName;
            public string stopName;
            public double length;
        }

        private graph my_graph;

        private observation[] my_observation;

        //构造函数
        public shortest_path(int pathNum, int pointNum, string[] Pname)
        {
            mixPath = new string[pointNum];
            Array.Clear(mixPath, 0, pointNum);

            mixDistance = new double[pointNum];
            Array.Clear(mixDistance, 0, pointNum);

            tagPoint = new bool[pointNum];
            Array.Clear(tagPoint, 0, pointNum);

            my_graph.pathNum = pathNum;
            my_graph.pointNum = pointNum;
            my_graph.pointName = new string[pointNum];
            my_graph.pathDisdance = new double[pointNum, pointNum];
            Array.Copy(Pname, my_graph.pointName, pointNum);

            my_observation = new observation[pathNum];
            Array.Clear(my_observation, 0, pathNum);

            for (int i = 0; i < pointNum; i++)
                for (int j = 0; j < pointNum; j++)
                    if (i == j)
                        my_graph.pathDisdance[i, j] = 0.0;
                    else
                        my_graph.pathDisdance[i, j] = INFINITY;
        }

        //得到观测值
        public void createObservation(int i, string starName, string stopName, double length)
        {
            my_observation[i].starName = starName;
            my_observation[i].stopName = stopName;
            my_observation[i].length = length;
        }

        //创建无向图
        public void createGraph()
        {
            int starIndex = 0;
            int stopIndex = 0;

            for (int i = 0; i < my_graph.pathNum; i++)
            {
                starIndex = Array.IndexOf(my_graph.pointName, my_observation[i].starName);
                stopIndex = Array.IndexOf(my_graph.pointName, my_observation[i].stopName);

                my_graph.pathDisdance[starIndex, stopIndex] = my_observation[i].length;
                my_graph.pathDisdance[stopIndex, starIndex] = my_observation[i].length;
            }
        }

        //传入点号，求得该点与其他点的最短距离与最短路径
        public void Dijkstra(int currentIndex)
        {
            //定义临时路径
            int[] tempPath = new int[my_graph.pointNum];
            Array.Clear(tempPath, 0, my_graph.pointNum);

            //临时最小距离
            double tempMix;
            //中转点
            int Transit;

            //初始化tempPath与mixDistance，不使用中转点求得两项各自的值
            for (int i = 0; i < my_graph.pointNum; i++)
            {
                mixDistance[i] = my_graph.pathDisdance[currentIndex,i];

                tagPoint[i] = false;

                if (my_graph.pathDisdance[currentIndex, i] < INFINITY)
                    tempPath[i] = currentIndex;
                else
                    tempPath[i] = -1;
            }

            //让源点标记为“已找到最短路径”，因为源点与自己没有最短路径
            tagPoint[currentIndex] = true;
            //源点是所有路径的起始点
            tempPath[currentIndex] = 0;

            for (int i = 0; i < my_graph.pointNum - 1; i++)
            {
                tempMix = INFINITY;
                Transit = -1;

                //遍历所有点，找到当前与源点最近的点，标记其为中转点
                for (int j = 0; j < my_graph.pointNum; j++)
                {
                    if (tagPoint[j] == false && mixDistance[j] < tempMix)
                    {
                        tempMix = mixDistance[j];
                        Transit = j;
                    }
                }

                //标记该中转点为“已找到最短路径”，
                //因为所有点距都是正数，
                //已经是最近点的该点不会因为其他点的中转距离变得更小
                tagPoint[Transit] = true;

                //遍历所有点，找到源点直到该点的距离比源点经过中转点到该点的距离更远的情况
                //交换更新两个数值，将中转点压进临时最短路径数组
                for (int j = 0; j < my_graph.pointNum; j++)
                {
                    if (tagPoint[j] == false)
                    {
                        if (my_graph.pathDisdance[Transit, j] < INFINITY && mixDistance[Transit] + my_graph.pathDisdance[Transit, j] < mixDistance[j])
                        {
                            mixDistance[j] = mixDistance[Transit] + my_graph.pathDisdance[Transit, j];
                            tempPath[j] = Transit;
                        }
                    }
                }
            }

            //整理临时中转点数组
            tidyPath(tempPath, currentIndex);
        }

        //整理最短路径
        private string[] tidyPath (int[] tempPath, int currentIndex)
        {
            for (int i = 0; i < my_graph.pointNum; i++)
            {
                if (i != currentIndex)
                {
                    //当该点已经被标记为找到最短路径 并且到源点的距离有数值
                    if (tagPoint[i] == true && mixDistance[i] < INFINITY)
                    {
                        //调用递归方法recursive
                        recursive(tempPath, i, currentIndex);
                        //将该最短路径加上头尾，逗号存入最短路径数组
                        mixPath[i] += my_graph.pointName[currentIndex];
                        mixPath[i] += ",";
                        mixPath[i] += singlePath;
                        mixPath[i] += my_graph.pointName[i];
                        //每找完一个点，将singlePath清空
                        singlePath = "";
                    }
                    else
                    {
                        mixPath[i] = "";
                    }
                }
            }

            Array.Clear(tempPath, 0, my_graph.pointNum);

            return mixPath;
        }

        //递归得到源点到当前点最短路径，存到singlePath中
        private void recursive(int[] tempPath, int i, int currentIndex)
        {
            if (tempPath[i] == currentIndex)
                return;
            recursive(tempPath, tempPath[i], currentIndex);
            singlePath += my_graph.pointName[tempPath[i]];
            singlePath += ",";
        }

        //返回最短路径
        public string[] getmixPath()
        {
            return mixPath;
        }

        public double[] getmixDistance()
        {
            return mixDistance;
        }
    }
}
