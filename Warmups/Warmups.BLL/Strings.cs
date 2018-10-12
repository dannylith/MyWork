using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a+b+b+a;
        }

        public string MakeTags(string tag, string content)
        {
            return $"<{tag}>{content}</{tag}>";
        }

        public string InsertWord(string container, string word) {
            return $"{container.Substring(0, 2)}{word}{container.Substring(2, 2)}";
        }

        public string MultipleEndings(string str)
        {
            int x = str.Length;
            string y;
            if (x == 2)
            {
                y = str;
            }
            else
            {
                y = str.Substring(x -2, 2);
            }
            return y+y+y;
        }

        public string FirstHalf(string str)
        {
            int x = str.Length / 2;
            return str.Substring(0, x);
            
        }

        public string TrimOne(string str)
        {
            return str.Substring(1, str.Length - 2);
        }

        public string LongInMiddle(string a, string b)
        {
            string x, y;
            if (a.Length < b.Length)
            {
                x = a;
                y = b;
            }
            else
            {
                x = b;
                y = a;
            }

            return $"{x}{y}{x}";
            
        }

        public string RotateLeft2(string str)
        {
            string x;
            if (str.Length > 2)
            {
                x = str.Substring(2, str.Length - 2) + str.Substring(0, 2);
            }
            else
            {
                x = str;
            }
            return x;
        }

        public string RotateRight2(string str)
        {
            string x;
            if (str.Length > 2)
            {
                x = str.Substring(str.Length - 2, 2) + str.Substring(0, str.Length - 2);
            }
            else
            {
                x = str;
            }
            return x;
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);
            }
            else
            {
                return str.Substring(str.Length - 1, 1);
            }
        }

        public string MiddleTwo(string str)
        {
            int x = (str.Length / 2) - 1;

            return str.Substring(x, 2);
        }

        public bool EndsWithLy(string str)
        {
            if (str.Contains("ly"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FrontAndBack(string str, int n)
        {
            return str.Substring(0, n) + str.Substring(str.Length - n, n);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (str.Length - 2 >= n)
            {
                return str.Substring(n, 2);
            }
            else
            {
                return str.Substring(0, 2);
            }
        }

        public bool HasBad(string str)
        {
            if (str.Contains("bad") && str.IndexOf("b") >= 0 && str.IndexOf("b") <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AtFirst(string str)
        {
            if(str.Length >= 2)
            {
                return str.Substring(0, 2);
            }
            else if (str.Length == 1)
            {
                return str.Substring(0) + "@";
            }
            else
            {
                return "@@";
            }
        }

        public string LastChars(string a, string b)
        {
            string x, y;

            if(a.Length > 1)
            {
                x = a.Substring(0,1);
            }
            else
            {
                x = "@";
            }
            if(b.Length >= 1)
            {
                y = b.Substring(b.Length-1, 1);
            }
            else
            {
                y = "@";
            }
            return x + y;
        }

        public string ConCat(string a, string b)
        {
            string first;
            if(a == "")
            {
                return b;
            }
            if (b == "")
            {
                return a;
            }
            if (a.Substring(a.Length - 1, 1) == b.Substring(0, 1))
            {
                first = a.Substring(0, a.Length - 1);
            }
            else
            {
                first = a;
            }

            return first + b;

        }

        public string SwapLast(string str)
        {
            string x = "";
            if (str.Length >= 2)
            {
                x = str.Substring(0, str.Length - 2) + str.Substring(str.Length - 1) + str.Substring(str.Length - 2, 1);
            }
            else
            {
                x = str;
            }
            return x;
        }

        public bool FrontAgain(string str)
        {
            if(str.Substring(0, 2) == str.Substring(str.Length-2, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string MinCat(string a, string b)
        {
            int lowestCount;
            if(a.Length < b.Length)
            {
                lowestCount = a.Length;
                b = b.Substring(b.Length - lowestCount);
            }
            else if(b.Length < a.Length)
            {
                lowestCount = b.Length;
                a = a.Substring(a.Length - lowestCount);
            }
            return a+b;
        }

        public string TweakFront(string str)
        {
            if(str == "")
            {
                return "";
            }
            if(str.Substring(0, 1) ==  "a" && str.Substring(1, 1) == "b")
            {
                return str;
            }
            if(str.Substring(0, 1) == "a")
            {
                return str.Substring(0,1) + str.Substring(2);
            }
            if (str.Substring(1, 1) == "b")
            {
                return str.Substring(1, 1) + str.Substring(2); 
            }
            return str.Substring(2);
        }

        public string StripX(string str)
        {
            if (str.Substring(0) == "" || str.Substring(0) == "x")
            {
                return "";
            }
            if(str.Substring(0, 1) == "x" && str.Substring(str.Length-1, 1) == "x")
            {
                return str.Substring(1, str.Length - 2);
            }else if(str.Substring(0, 1) == "x")
            {
                return str.Substring(1, str.Length - 1);
            }else if(str.Substring(str.Length -1, 1) == "x")
            {
                return str.Substring(0, str.Length - 1);
            }
            return "";
        }
    }
}
