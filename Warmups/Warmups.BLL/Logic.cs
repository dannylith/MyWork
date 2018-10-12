using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (isWeekend)
            {
                return true;
            }
            if (cigars >= 40 && cigars <= 60)
            {
                return true;
            }
            return false;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if(yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }else if(yourStyle >= 8 || dateStyle >= 8)
            {
                return 2;
            }
            return 1;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if(temp >= 60 && temp<=90 && isSummer == false)
            {
                return true;
            }else if (temp >=60&&temp<=100 && isSummer == true)
            {
                return true;
            }
            return false;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int first = 60, second = 61, third = 80, forth = 81;
            if (isBirthday)
            {
                first += 5;
                second += 5;
                third += 5;
                forth += 5;
            }
            if(speed <= first)
            {
                return 0;
            }else if (speed >=second && speed <= third)
            {
                return 1;
            }else if (speed >= forth)
            {
                return 2;
            }
            return 0;
        }
        
        public int SkipSum(int a, int b)
        {
            if(a+b >= 10&& a+b <= 19)
            {
                return 20;
            }
            return a + b;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            if (day >= 1 && day <= 5 && vacation == false)
            {
                return "7:00";
            } else if ((day == 0 && vacation == false) || (day == 6 && vacation == false))
            {
                return "10:00";
            }else if(day >= 1 && day <= 5 && vacation == true)
            {
                return "10:00";
            }else if((day == 0 && vacation == true) || (day == 6 && vacation == true))
            {
                return "off";
            }
            return "off";
        }
        
        public bool LoveSix(int a, int b)
        {
            if(Math.Abs(a-b) == 6 || a == 6 || b == 6 || a+b == 6)
            {
                return true;
            }
            return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if(n >=1 &&n<=10 && outsideMode == false)
            {
                return true;
            }else if ((n <= 1 || n >= 10) && outsideMode)
            {
                return true;
            }
            return false;
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0)
            {
                return true;
            }else if((n-1)%11 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool Mod20(int n)
        {
            if ((n-1) % 20 == 0)
            {
                return true;
            }
            else if ((n -2) % 20 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 != 0)
            {
                return true;
            }else if (n % 3 != 0 && n % 5 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isMorning == true && isMom == true && isAsleep == true)
            {
                return true;
            } else if (isMorning == false && isMom == false && isAsleep == false)
            {
                return true;
            }
            return false;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if(a+b == c||Math.Abs(a-b)==c)
            {
                return true;
            }
            return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if(b>a && c>b && bOk == false)
            {
                return true;
            }else if(c>b && bOk)
            {
                return true;
            }
            return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if(a<b && b<c && equalOk == false)
            {
                return true;
            }else if(a<=b && b<=c && equalOk)
            {
                return true;
            }
            return false;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            if(a.ToString().Substring(a.ToString().Length - 1) == c.ToString().Substring(c.ToString().Length-1))
            {
                return true;

            }else if(b.ToString().Substring(b.ToString().Length - 1) == c.ToString().Substring(c.ToString().Length - 1))
            {
                return true;
            }
            else if (a.ToString().Substring(a.ToString().Length - 1) == b.ToString().Substring(b.ToString().Length - 1))
            {
                return true;
            }
            return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if(die1 == die2 && noDoubles == false)
            {
                return die2 + die1;
            }
            else if(die1 == die2 && noDoubles)
            {
                if(die1 == 6)
                {
                    die1 = 1;
                    return die2 + die1;
                }
                else if(die2 == 6)
                {
                    die2 = 1;
                    return die2 + die1;
                }
                return die1 + die2 +1;
            }
            return die2 + die1;
        }

    }
}
