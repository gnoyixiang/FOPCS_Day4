using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Workshop
    {
        static void Main()
        {
            G3();
        }

        static bool EqualsIgnoreCase(string a, string b)
        {
            if (a.ToUpper() == b.ToUpper())
                return true;
            return false;
        }

        static void Swap<T>(T[] arr, int index1, int index2)
        {
            T swap = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = swap;
        }

        static void F3()
        {
            Console.WriteLine("Section F: Qn 3"); //using substring method   
            Console.Write("Enter string to test: ");
            string input = Console.ReadLine();
            char[] c = { ' ', ',', '.', '?', '!' };
            string s = input;
            int index = s.IndexOfAny(c);
            while (index != -1)
            {
                s = s.Remove(index, 1);
                index = s.IndexOfAny(c);
            }
            bool isPalindrome = true;
            for (int i = 0; i <= s.Length / 2; i++)
                //if(input.Substring(i,1)!=input.Substring(input.Length-i-1,1))
                if (!EqualsIgnoreCase(s.Substring(i, 1), s.Substring(s.Length - i - 1, 1)))
                    isPalindrome = false;
            Console.Write("{0} is ", input);
            Console.WriteLine(isPalindrome ? "palindrome" : "not palindrome");
        }




        static void F4()
        {
            Console.WriteLine("Section F: Qn 4");
            Console.Write("Enter a title: ");
            string title = Console.ReadLine();
            string[] words = title.Split(' ');
            string result = "";
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
                result += word + " ";
            }
            Console.WriteLine(result.Trim());
        }


        static void F5()
        {
            Console.WriteLine("Section F: Qn 5");
            string[] names = { "John", "Venkat", "Mary", "Victor", "Betty" };
            int[] marks = { 63, 29, 75, 82, 55 };
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = i + 1; j < marks.Length; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        //int mark = marks[i];
                        //marks[i] = marks[j];
                        //marks[j] = mark;
                        //string name = names[i];
                        //names[i] = names[j];
                        //names[j] = name;
                        Swap<int>(marks, i, j);
                        Swap<string>(names, i, j);
                    }
                }
            }
            Console.WriteLine("Sorting by marks: ...");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("{0,-10}: {1}", names[i], marks[i]);
            }
            for (int i = 0; i < names.Length; i++)
            {
                for (int j = i + 1; j < names.Length; j++)
                {
                    if (names[i][0] > names[j][0])
                    {
                        //int mark = marks[i];
                        //marks[i] = marks[j];
                        //marks[j] = mark;
                        //string name = names[i];
                        //names[i] = names[j];
                        //names[j] = name;
                        Swap<int>(marks, i, j);
                        Swap<string>(names, i, j);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sorting by names: ...");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("{0,-10}: {1}", names[i], marks[i]);
            }
        }


        static void F6()
        {
            Console.WriteLine("Section F: Qn 6");
            bool valid = false;
            do
            {
                Console.Write("Enter a matriculation number: ");
                string mn = Console.ReadLine();
                char[] checkSum = { 'O', 'P', 'Q', 'R', 'S' };
                string output = "Invalid";
                if ((mn.Substring(0, 1)).ToUpper() == "A" && mn.Length == 7)
                {
                    int num;
                    if (int.TryParse(mn.Substring(1, 5), out num))
                    {
                        int result = (num / 10000 * 6 + num % 10000 / 1000 * 5 +
                            num % 1000 / 100 * 4 + num % 100 / 10 * 3 + num % 10 * 2) % 5;
                        if (checkSum[result] == mn[mn.Length - 1])
                        {
                            valid = true; output = "Valid";
                        }
                    }
                }
                Console.WriteLine(output);
            } while (!valid);
        }


        static void G1()
        {
            Console.WriteLine("Section G: Qn 1");

            double[] sales = new double[12];
            string[] strMin = new string[12];
            string[] strMax = new string[12];
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            for (int i = 0; i < 12; i++)
            {
                do
                {
                    Console.Write("Enter sales for {0}: ", months[i]);
                } while (!(Double.TryParse(Console.ReadLine(), out sales[i])));
            }
            double min = sales.Min();
            double max = sales.Max();
            for (int i = 0; i < 12; i++)
            {
                if (sales[i] == max) strMax[Array.IndexOf<string>(strMax, null)] = months[i];
                if (sales[i] == min) strMin[Array.IndexOf<string>(strMin, null)] = months[i];
            }
            int n = 0;
            Console.Write("Max sales: ");
            while (strMax[n] != null)
            {
                if (n != 0) Console.Write(", ");
                Console.Write(strMax[n]);
                n++;
            }
            n = 0;
            Console.WriteLine();
            Console.Write("Min sales: ");
            while (strMin[n] != null)
            {
                if (n != 0) Console.Write(", ");
                Console.Write(strMin[n]);
                n++;
            }
            Console.WriteLine();
            //Console.WriteLine("Max sales: " + months[Array.IndexOf(sales, sales.Max())]);
            //Console.WriteLine("Min sales: " + months[Array.IndexOf(sales, sales.Min())]);
            Console.WriteLine("Avg sales: {0:c}", sales.Sum() / 12);
        }


        static void G2()
        {
            Console.WriteLine("Section G: Qn 2");
            string s; int num;
            do
            {
                Console.Write("Enter a string of numbers: ");
            } while (!int.TryParse(Console.ReadLine(), out num));
            s = num.ToString();
            char[] c = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
                for (int j = i + 1; j < s.Length; j++)
                    if (c[i] < c[j])
                    {
                        Swap<char>(c, i, j);
                        Console.WriteLine(c);
                    }
        }


        static void G3()
        {
            Console.WriteLine("Section G: Qn 3");

            int subsLength;
            do
            {
                Console.Write("How many Subjects? ");
            } while (!int.TryParse(Console.ReadLine(), out subsLength));

            string[] subs = new string[subsLength];
            Console.Write("List subjects with ',' separator: ");
            string subsInput = Console.ReadLine();
            subs = subsInput.Split(',');
            for (int i = 0; i < subs.Length; i++)
                subs[i] = subs[i].Trim();

            int sLength;
            do
            {
                Console.Write("How many students? ");
            } while (!int.TryParse(Console.ReadLine(), out sLength));


            //double[,] marks = new double[sLength, subsLength];

            double[,] marks = { {56, 84, 68, 29 },
                { 94, 73, 31, 96 },
                { 41, 63, 36, 90 },
                { 99, 9, 18, 17 },
                { 62,3,65,75},
                { 40,96,53,23},
                { 81,15,27,30},
                { 21,70,100,22},
                { 88,50,13,12},
                { 48,54,52,78},
                { 64,71,67,25},
                { 16,93,46,72}};

            double[] subTot = new double[marks.GetLength(0)];

            /*
            for (int i = 0; i < marks.GetLength(0); i++)
            {
                Console.WriteLine("Student {0}", i + 1);
                for (int j = 0; j < marks.GetLength(1); j++)
                {
                    int err = 0;
                    do
                    {
                        if (err > 0) Console.WriteLine("Invalid entry. Please enter again.");
                        Console.Write(subs[j] + ": ");
                        err++;
                    } while (!double.TryParse(Console.ReadLine(), out marks[i, j]));
                }
            }
            */

            
            Console.WriteLine();
            for (int j = 0; j < marks.GetLength(1); j++)
                Console.Write("{0,-20}", subs[j]);
            Console.Write("{0,-20}{1,-20}", "Total", "Average");
            Console.WriteLine();
            for (int i = 0; i < marks.GetLength(0); i++)
            {
                double total = 0;
                for (int j = 0; j < marks.GetLength(1); j++)
                {
                    total += marks[i, j];
                    subTot[j] += marks[i, j];
                    Console.Write("{0,-20}", marks[i, j]);
                }
                Console.Write("{0,-20}{1,-20}", total, total / marks.GetLength(1));
                Console.WriteLine();
            }
            Console.WriteLine("Average per Subject:");
            for (int i = 0; i < marks.GetLength(1); i++)
                Console.Write("{0,-20:#.00}", subTot[i] / marks.GetLength(0));
            Console.WriteLine();
            Console.WriteLine();

            double[] varSum = new double[marks.GetLength(1)];
            double[] stDev = new double[marks.GetLength(1)];
            double avg;
            for (int i = 0; i < marks.GetLength(1); i++)
            {
                avg = subTot[i] / marks.GetLength(0);
                for (int j = 0; j < marks.GetLength(0); j++)
                {
                    
                    varSum[i] += Math.Pow(marks[j, i] - avg, 2);
                }
                stDev[i] = Math.Sqrt(varSum[i] / marks.GetLength(0));
            }
            for (int i = 0; i < stDev.Length; i++)
            {
                Console.WriteLine("Variance of {0}: {1:0.00}", subs[i], varSum[i]);
                Console.WriteLine("Standard Deviation of {0}: {1:0.00}", subs[i], stDev[i]);
            }
            Console.WriteLine();
        }

       
    }
}
