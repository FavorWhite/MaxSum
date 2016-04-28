using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSum
{
    class Program
    {
       static void GetSumOfTriangle(ref int sum, ref int caughtIndex, int[] digitLine)
        {
            if (digitLine.Length == 1)
            {
                caughtIndex = 0;
                sum += digitLine[0];
            }
            else
            {
                if (caughtIndex == 0)
                {
                    if (digitLine[0] >= digitLine[1])
                    {
                        sum += digitLine[0];
                        caughtIndex = 0;
                    }
                    else
                    {
                        sum += digitLine[1];
                        caughtIndex = 1;
                    }
                }
                else
                {
                    int maxIndex = caughtIndex - 1;
                    for (int i = caughtIndex; i <= caughtIndex + 1; i++)
                    {
                        if (digitLine[i] > digitLine[maxIndex])
                        {
                            maxIndex = i;
                        }
                    }
                    sum += digitLine[maxIndex];
                    caughtIndex = maxIndex;
                }   
            }
        }
        static void ConvertArrStrToInt(string[] dataLine, ref int[] digitLine, int counter)
        {
            string[] split = dataLine[counter].Split(new Char[] { ' ' });
            digitLine = new int[split.Length];

            for (int l = 0; l < split.Length; l++)
            {
                digitLine[l] = int.Parse(split[l]);
            }
        }
        static string GetDataFromFile()
        {
            string dataFromFile;
            StreamReader digitalTriangle = File.OpenText("Redirecting1.txt"); // or Redirecting2.txt
            dataFromFile =digitalTriangle.ReadToEnd();
            digitalTriangle.Close();
            return dataFromFile;
        }
        static void Main(string[] args)
        {
            int sum = 0;
            int caughtIndex = 0;
            string digitMass=null;
            string[] dataLine;
            int[] digitLine=new int[0];

            digitMass=GetDataFromFile();

            dataLine = digitMass.Split(new Char[] { '\n' });
            for (int i = 0; i < dataLine.Length; i++)
            {
                ConvertArrStrToInt(dataLine, ref digitLine,i);
                GetSumOfTriangle(ref sum, ref caughtIndex, digitLine);
            }
            Console.WriteLine("Sum of adjacent numbers of the triangle is {0}",sum);
            Console.ReadKey();
        }
    }
}
