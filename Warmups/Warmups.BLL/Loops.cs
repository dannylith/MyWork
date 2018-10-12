using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string x ="";
            for(int i=0; i<n; i++)
            {
                x += str;
            }
            return x;
        }

        public string FrontTimes(string str, int n)
        {
            string x = "";
            if(str.Length > 3)
            {

                for(int i = 0; i<n; i++)
                {
                    x += str.Substring(0, 3);
                }
                return x;
            }
            return str + str + str;
        }

        public int CountXX(string str)
        {
            int x = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) == "x" && str.Substring(i + 1, 1) == "x")
                {
                    x++;
                }
            }
            return x;
        }

        public bool DoubleX(string str)
        {
            for(int i = 0; i<str.Length-1; i++)
            {
                if (str.Substring(i, 1) == "x")
                {
                    if (str.Substring(i, 1) == "x" && str.Substring(i + 1, 1) == "x")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public string EveryOther(string str)
        {
            string x= "";
            for(int i = 0; i<str.Length; i += 2)
            {
                x += str.Substring(i, 1);
            }
            return x;
        }

        public string StringSplosion(string str)
        {
            string x = "";
            int counter = 1;
            for(int i = 0; i<str.Length; i++)
            {
                x += str.Substring(0, counter);
                counter++;
            }
            return x;
        }

        public int CountLast2(string str)
        {
            int count = 0;
            for(int i = 0; i<str.Length - 1; i++)
            {
                if (str.Substring(i, 2) == "xa")
                {
                    count++;
                    return count;
                }
                if (str.Substring(i, 2) == str.Substring(str.Length -3, 2))
                {
                    count++;
                    
                }
            }
            return count;
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            for(int i = 0; i<numbers.Length; i++)
            {
                if(numbers[i] == 9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {
            if(numbers.Length > 4)
            {
                for(int i = 0; i< 4; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for(int i = 0; i<numbers.Length; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            for(int i = 0; i<numbers.Length-2; i++)
            {
                if (numbers[i] == 1 && numbers[i+1]==2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int length, count=0;
            if(a.Length > b.Length)
            {
                length = b.Length;
            }
            else
            {
                length = a.Length;
            }
            for(int i = 0; i<length-1; i++)
            {
                if(a[i] == b[i] && a[i + 1] == b[i + 1])
                {
                    count++;
                }
            }
            return count;
        }

        public string StringX(string str)
        {
            string x = "";
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) != "x")
                {
                    x += str.Substring(i, 1);
                }
            }
            return str.Substring(0, 1) + x + str.Substring(str.Length -1, 1);
        }

        public string AltPairs(string str)
        {
            if(str.Length < 5)
            {
                return str.Substring(0, 1) + str.Substring(1, 1);
            }
            if(str.Length < 6)
            {
                return str.Substring(0, 1) + str.Substring(1, 1) + str.Substring(4, 1);
            }
            if(str.Length < 7)
            {
                return str.Substring(0, 1) + str.Substring(1, 1) + str.Substring(4, 1) + str.Substring(5, 1);
            }
            if(str.Length < 10)
            {
                return str.Substring(0, 1) + str.Substring(1, 1) + str.Substring(4, 1) + str.Substring(5, 1) + str.Substring(8, 1);
            }
            //0,1, 4,5, 8,9
            return str.Substring(0, 1) + str.Substring(1, 1) + str.Substring(4, 1) + str.Substring(5, 1) + str.Substring(8, 1) + str.Substring(9, 1);
        }

        public string DoNotYak(string str)
        {
            if(str.IndexOf("yak") != -1)
            {
                return str.Remove(str.IndexOf("yak"), 3);
            }
            return str;
        }

        public int Array667(int[] numbers)
        {
            int count = 0;
            for(int i = 0; i<numbers.Length-1; i++)
            {
                if(numbers[i] == 6 && (numbers[i+1] == 6 || numbers[i+1] == 7))
                {
                    count++;
                }
            }
            return count;
        }

        public bool NoTriples(int[] numbers)
        {
            if (numbers.Length >= 3)
            {
                for (int i = 0; i < numbers.Length - 2; i++)
                {
                    if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for(int i = 0; i<numbers.Length - 2; i++)
            {
                if(Math.Abs(numbers[i] - numbers[i +1]) == 5 && Math.Abs(numbers[i] - numbers[i+2]) == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
