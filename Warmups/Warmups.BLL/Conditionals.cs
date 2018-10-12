using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if(aSmile && bSmile)
            {
                return true;
            }
            if(aSmile || bSmile)
            {
                return false;
            }
            if (!aSmile && !bSmile)
            {
                return true;
            }
            return false;

        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if(isWeekday == false && isVacation == false)
            {
                return true;
            }
            if (isWeekday == true && isVacation == false)
            {
                return false;
            }
            if (isWeekday == false && isVacation == true)
            {
                return true;
            }
            return false;
        }

        public int SumDouble(int a, int b)
        {
            if(a == b)
            {
                return (a + b) * 2;
            }
            return a + b;
        }
        
        public int Diff21(int n)
        {

            if(21-n < 0)
            {
                return (21 - n) * -2;
            }
            return 21-n;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true && (hour < 7 || hour >= 20))
            {
                return true;
            }
            return false;
        }
        
        public bool Makes10(int a, int b)
        {
            if(a == 10 || b == 10)
            {
                return true;
            }
            if(a + b == 10)
            {
                return true;
            }
            return false;
        }
        
        public bool NearHundred(int n)
        {
            if ((n >= 90 && n<=110) || (n>=190 && n<+210))
            {
                return true;
            }
            return false;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            if ((a>0 && b<0) || (a<0 && b>0) )
            {
                return true;
            }
            if(a<0 && b<0 && negative == true)
            {
                return true;
            }
            return false;
        }
        
        public string NotString(string s)
        {
            if(!s.Contains("not"))
            {
                return "not " + s;
            }
            return s;
        }
        
        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }
        
        public string FrontBack(string str)
        {
            string x, y;
            if (str.Length == 1)
            {
                return str;
            }
            return str.Substring(str.Length -1, 1) + str.Substring(1, str.Length - 2) + str.Substring(0, 1);
        }
        
        public string Front3(string str)
        {
            if(str.Length >= 3)
            {
                return str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);
            }
            return str + str + str;
        }
        
        public string BackAround(string str)
        {
            string x = str.Substring(str.Length - 1, 1);
            return x + str + x;
        }
        
        public bool Multiple3or5(int number)
        {
            if(number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool StartHi(string str)
        {
            if(str.Length == 1)
            {
                return false;
            }
            if ((str.Contains("hi ")|| str.Contains("hi,") || str.Contains("hi")) && !str.Contains("hig") && !str.Contains("hip"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if((temp1 < 0 && temp2 >100) || (temp1 > 100 || temp2 < 0))
            {
                return true;
            }
            return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            if((a >= 10 && a<= 20) || (b >= 10 && b <= 20))
            {
                return true;
            }
            return false;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19)|| (c >= 13 && c <= 19))
            {
                return true;
            }
            return false;
        }
        
        public bool SoAlone(int a, int b)
        {
            if (((a >= 13 && a <= 19) && !(b >= 13 && b <= 19)) || (!(a >= 13 && a <= 19) && (b >= 13 && b <= 19)))
            {
                return true;
            }
            return false;
        }
        
        public string RemoveDel(string str)
        {
            if(str.Substring(1, 3) == "del")
            {
                return str.Remove(1, 3);
            }
            return str;
        }
        
        public bool IxStart(string str)
        {
            if (str.Contains("ix"))
            {
                return true;
            }
            return false;
        }
        
        public string StartOz(string str)
        {
            if(str == "w")
            {
                return "";
            }
            if(str.Substring(0,1) == "o" && str.Substring(1,1) == "z")
            {
                return "oz";
            }else if(str.Substring(1,1) == "z" && !(str.Substring(0, 1) == "o"))
            {
                return "z";
            }
            else if (str.Substring(0, 1) == "o")
            {
                return "o";
            }
            return str.Substring(0,2);
        }
        
        public int Max(int a, int b, int c)
        {
            if(a > b && a > c)
            {
                return a;
            }
            if(b > a && b > c)
            {
                return b;
            }
            return c;
        }
        
        public int Closer(int a, int b)
        {
            int x, y;

            x = Math.Abs(10 - a);
            y = Math.Abs(10 - b);
            if (x == y)
            {
                return 0;
            }
            else if (x < y)
            {
                return a;
            }
            else
            {
                return b;
            }

        }
        
        public bool GotE(string str)
        {
            int counter = 0;
            for(int i = 0; i<str.Length; i++)
            {
                if(str.Substring(i, 1) == "e")
                {
                    counter++;
                }
            }
            if(counter >=1 && counter <= 3)
            {
                return true;
            }
            return false;
        }
        
        public string EndUp(string str)
        {
            if(str.Length >= 3)
            {
                return str.Substring(0, str.Length - 3) + str.Substring(str.Length - 3).ToUpper();
            }
            return str.ToUpper();
        }
        
        public string EveryNth(string str, int n)
        {
            string sum = "";
            for(int i = 0; i<str.Length; i = i+n)
            {
                sum += str.Substring(i, 1);
            }
            return sum;
        }
    }
}
