using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace caves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] Homework_heighMap = System.IO.File.ReadAllLines("numbersText.txt"); // input heightMap given in the homework
            string[] HeighMapTest = System.IO.File.ReadAllLines("example_heightmap.txt"); // Example heightmap 

            Console.WriteLine("Welcome to lava tubes Game");
            Console.WriteLine("To Run the ExampleMap Game Press on Number 1");
            Console.WriteLine("To Run the Input Game Press on Number 2");
            
            int ChooseNumber = Convert.ToInt32(Console.ReadLine());
            if(ChooseNumber == 1)
            {
                int[,] inputArray = resultArray(HeighMapTest);
                solveTheQuestions(inputArray);
                Console.WriteLine();
            }
            else
            {
                int[,] inputArray1 = resultArray(Homework_heighMap);
                Console.WriteLine();
                solveTheQuestions(inputArray1);
            }
        }

        /// <summary>
        /// Find the low points - the locations that are lower than any of its adjacent locations.
        /// Most locations have four adjacent locations (up, down, left, and right)
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns>List of Low points</returns>
        private static List<int> getLowerPoints(int [,]Arr)
        {
            List<int> ListResult = new List<int>();
            
            
            for (int i = 0; i <= Arr.GetLength(0)-1; i++)
            {
                for (int j = 0; j <= Arr.GetLength(1)-1; j++)
                {                   
                    if (i == 0 && j == 0)
                    {
                        if (Arr[i, j] < Arr[i + 1, j] && Arr[i, j] < Arr[i, j + 1])
                        {
                            ListResult.Add(Arr[i, j]);

                            //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                        }
                    }

                    else if(i == Arr.GetLength(0)-1 && j==0)
                    {
                        if (Arr[i, j] < Arr[i - 1, j])
                        {
                            if (Arr[i, j] < Arr[i, j + 1])
                            {
                                ListResult.Add(Arr[i, j]);
                                //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                            }
                        }
                    }

                    else if (i == 0 && j== Arr.GetLength(1)-1)
                    {
                        if (Arr[i, j] < Arr[i + 1, j])
                        {
                            if (Arr[i, j] < Arr[i , j- 1])
                            {
                                ListResult.Add(Arr[i, j]);
                                //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                            }
                        }
                    }

                    else if(i==Arr.GetLength(0)-1 && j==Arr.GetLength(1)-1)
                    {
                        if(Arr[i,j] < Arr[i-1,j] && Arr[i,j] < Arr[i,j-1])
                        {
                            ListResult.Add(Arr[i, j]);
                            //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                        }
                    }
                   
                    else if(i == 0 && j > 0 && j < Arr.GetLength(1)-1)
                    {
                        if(Arr[i,j] < Arr[i,j-1] && Arr[i,j] < Arr[i,j+1] && Arr[i,j] < Arr[i+1,j])
                        {
                            ListResult.Add(Arr[i, j]);
                            //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                        }
                    }

                    else if(i==Arr.GetLength(0)-1 && j != 0 && j !=Arr.GetLength(1)-1)
                    {
                        if(Arr[i,j] < Arr[i-1,j] && Arr[i,j] < Arr[i,j+1] && Arr[i,j] < Arr[i,j-1])
                        {
                            ListResult.Add(Arr[i, j]);
                            //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                        }
                    }

                    else if(j==0 && i!=0 && i < Arr.GetLength(0)-1)
                    {
                        if(Arr[i,j]<Arr[i-1,j] && Arr[i,j]<Arr[i+1,j] && Arr[i,j]<Arr[i+1,j+1])
                        {
                            ListResult.Add(Arr[i, j]);
                            Console.WriteLine("the index of low point is : {0},{1}", i, j);
                        }
                    }

                    else if(j==Arr.GetLength(1)-1 && i>0 && i<Arr.GetLength(0)-1)
                    {
                        if(Arr[i,j]<Arr[i+1,j] && Arr[i,j]<Arr[i-1,j] && Arr[i,j]<Arr[i,j-1])
                        {
                            ListResult.Add(Arr[i, j]);
                            //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                        }
                    }

                    else
                    {
                        if(Arr[i,j] < Arr[i-1,j] && Arr[i,j] < Arr[i+1,j] && Arr[i,j] < Arr[i,j-1] && Arr[i,j] < Arr[i,j+1])
                        {
                            ListResult.Add(Arr[i, j]);
                            //Console.WriteLine("the index of low point is : {0},{1}", i, j);
                        }
                    }
                }
            }

            return ListResult;
        }

        /// <summary>
        /// Find The risk level of a low point by 1 plus its height
        /// </summary>
        /// <param name="lowPoints"></param>
        /// <returns>List of risk level points</returns>
        private static List<int> riskLevelOfHeightMap(List<int> lowPoints)
        {
            List<int> riskLevelArray = new List<int>();
            foreach(int item in lowPoints)
            {
                riskLevelArray.Add(item + 1);
            }
            return riskLevelArray;
        }

        /// <summary>
        /// Sum of the risk levels of all low points on your heightmap
        /// </summary>
        /// <param name="riskLevelOfHeightMap"></param>
        /// <returns>integer value Sum of all risk levels of low points</returns>
        private static double SumOfTheRiskLevelsOfAllPoints(List<int> riskLevelOfHeightMap)
        {
            double sumOfRiskLevel=1;
            foreach(int item in riskLevelOfHeightMap)
            {
                sumOfRiskLevel += item;
            }
            return sumOfRiskLevel;
        }
    
        /// <summary>
        /// Print Two Dinensional array
        /// </summary>
        /// <param name="array"></param>
        private static void printArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Find Rows Length of Array
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Return integer column numbers array</returns>
        private static int getArrayRowLength(string[] array)
        {
            return array.Length;
        }

        /// <summary>
        /// Find Columns Length of Length
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Return integer row numbers array</returns>
        private static int getArrayColumnsLength(string[] array)
        {
            var list = Enumerable
            .Range(0, array[0].Length / 1)
            .Select(j => array[0].Substring(j * 1, 1));

            return list.Count();
        }
        
        /// <summary>
        /// Organize the array with two dimensional
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns>2D array</returns>
        private static int[,] resultArray(string[] inputArray)
        {
            int arrayRows = getArrayRowLength(inputArray);
            int arrayColumns = getArrayColumnsLength(inputArray);
            int[,] resultArray = new int[arrayRows, arrayColumns];

            for (int i = 0; i < arrayRows; i++)
            {
                for (int j = 0; j < arrayColumns; j++)
                {
                    var list = Enumerable
                    .Range(0, inputArray[i].Length / 1)
                    .Select(k => inputArray[i].Substring(k * 1, 1));

                    resultArray[i, j] = Convert.ToInt32(list.ToList()[j]);
                }
            }

            return resultArray;
        }

        /// <summary>
        /// Mothod do the following Task:
        /// 1- find low points - the locations that are lower than any of its adjacent locations.
        /// 2- find risk level of a low point is 1 plus its height
        /// 3- Sum of the risk levels of all low points on your heightmap
        /// </summary>
        /// <param name="inputArray"></param>
        private static void solveTheQuestions(int[,] inputArray)
        {
            Console.WriteLine("heightmap given in the Question:");
            Console.WriteLine();
            printArray(inputArray);
            Console.WriteLine();

            List<int> LowPointsList = getLowerPoints(inputArray);
            Console.WriteLine("The Low Points of the heightmap are: ");
            foreach (var item in LowPointsList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------- The Risk Level Of Height Map ---------");
            List<int> riskLevelsList = riskLevelOfHeightMap(LowPointsList);
            foreach (var item in riskLevelsList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------- The sum of the risk levels of all low points  ---------");
            Console.WriteLine(SumOfTheRiskLevelsOfAllPoints(riskLevelsList));

            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
