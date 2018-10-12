using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
                {
                    return true;
                }
               
            }
            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if(numbers.Length == 1)
            {
                return true;
            }
            for (int i = 0; i<numbers.Length; i++)
            {
                if(numbers[0] ==  numbers[numbers.Length - 1])
                {
                    return true;
                }
            }
            return false;
        }
        public int[] MakePi(int n)
        {
            int[] x = null;
            if(n == 1)
            {
                x = new int[1]{ 3 } ;
            }else if (n == 3)
            {
                x = new int[3] { 3, 1, 4 };
            }
            else if (n == 5)
            {
                x = new int[5] { 3, 1, 4, 1 , 5};
            }
            return x;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if(a[0] == b[0] || a[a.Length-1] == b[b.Length - 1])
            {
                return true;
            }
            return false;
        }
        
        public int Sum(int[] numbers)
        {
            int intSum = 0;
            for(int i = 0; i<numbers.Length; i++)
            {
                intSum += numbers[i];
            }
            return intSum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
  
            int temp;
            for(int i = 0; i<numbers.Length - 1; i++)
            {
                temp = numbers[i];
                numbers[i] = numbers[i + 1];
                numbers[i + 1] = temp;
            }
            return numbers;
        }
        
        public int[] Reverse(int[] numbers)
        {
            int[] x = new int[numbers.Length];
            int y = 0;
            for(int i = numbers.Length -1; i>= 0; i--)
            {
                x[y] = numbers[i];
                y++;
            }
            return x;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int x = 0;
            int[] y = new int[numbers.Length];
            for(int i = 0; i<numbers.Length; i++)
            {
                if (numbers[0] > numbers[numbers.Length - 1])
                {
                    x = numbers[0];
                }
                else
                {
                    x = numbers[numbers.Length - 1];
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                y[i] = x;
            }
            return y;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] x = new int[2];
            x[0] = a[1];
            x[1] = b[1];

            return x;

        }
        
        public bool HasEven(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] x = new int[numbers.Length * 2];
            int y = numbers[numbers.Length - 1];

            for(int i = 0; i<x.Length; i++)
            {
                x[i] = 0;
            }
            x[x.Length - 1] = y;
            return x;
        }
        
        public bool Double23(int[] numbers)
        {
            int three=0, two=0;
            for(int i = 0; i<numbers.Length; i++)
            {
                if(numbers[i] == 2)
                {
                    two++;
                }
                if (numbers[i] == 3)
                {
                    three++;
                }
            }
            if(two == 2)
            {
                return true;
            }
            if(three == 2)
            {
                return true;
            }
            return false;
        }
        
        public int[] Fix23(int[] numbers)
        {
            for(int i = 0; i<numbers.Length-1; i++)
            {
                if (numbers[i] == 2 && numbers[i+1] == 3)
                {
                    numbers[i + 1] = 0;
                }
            }
            return numbers;
        }

        public bool Unlucky1(int[] numbers)
        {
            if (numbers[0] == 1 && numbers[1] == 3)
            {
                return true;
            }
            if (numbers[1] == 1 && numbers[2] == 3)
            {
                return true;
            }
            if (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length-1] == 3)
            {
                return true;
            }
            return false;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] x = new int[2];
            int counter = 0;

            for(int i = 0; i<a.Length; i++)
            {

                x[counter] = a[i];
                counter++;
                if(counter == 2)
                {
                    break;
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                if (counter == 2)
                {
                    break;
                }
                x[counter] = b[i];
                counter++;
                
            }

            return x;
        }

    }
}
