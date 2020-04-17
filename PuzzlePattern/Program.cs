using System;

namespace FactoryPuzzle
{
    public interface IPuzzle
    {
        public void Match(int[] myNum, int snumber);
    }

    public class Logic1 : IPuzzle
    {
        public void Match(int[] myNum, int snumber)
        {
            for (int i = 0; i < myNum.Length; i++)
            {
                for (int j = i + 1; j < myNum.Length; j++)
                {
                    if (myNum[i] + myNum[j] == snumber)
                    {
                        Console.WriteLine("Match found at Index:" + i + " and " + j + "(" + myNum[i] + "+" + myNum[j] + ")\n");
                    }
                }
            }
        }
    }

    public class Logic2 : IPuzzle
    {
        public void Match(int[] myNum, int snumber)
        {
            Array.Sort(myNum);

            int low = 0;
            int high = myNum.Length - 1;

            while (low < high)
            {
                if (myNum[low] + myNum[high] == snumber)
                {
                    Console.WriteLine("Match found at Index: " + low + " and " + high + "(" + myNum[low] + "+" + myNum[high] + ")\n");
                    low++;

                }
                else if (myNum[low] + myNum[high] < snumber)
                {
                    low = low + 1;
                }
                else
                {
                    high = high - 1;
                }
            }
        }
    }
    public abstract class PuzzleFactory
    {
        public abstract IPuzzle GetMatch(string Logic);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcretePuzzleFactory : PuzzleFactory
    {
        public override IPuzzle GetMatch(string Logic)
        {
            switch (Logic)
            {
                case "Logic1":
                    return new Logic1();
                case "Logic2":
                    return new Logic2();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Logic));


            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the Method you want to use:\n1.Method 1\n2.Method 2");
            int method= Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the no of elements in the array");
            int num = Convert.ToInt16(Console.ReadLine());
            int[] myNum = new int[num];
            Console.WriteLine("Enter the elements");
            for (int i = 0; i < num; i++)
            {
                myNum[i] = Convert.ToInt16(Console.ReadLine());
            }
            Console.WriteLine("Enter the sum of the number to be found");
            int snumber = Convert.ToInt16(Console.ReadLine());
            PuzzleFactory factory = new ConcretePuzzleFactory();
            switch (method)
            {
                case 1: 
                    IPuzzle logic1 = factory.GetMatch("Logic1");
                    logic1.Match(myNum, snumber);
                    break;
                case 2: 
                    IPuzzle logic2 = factory.GetMatch("Logic2");
                    logic2.Match(myNum, snumber);
                    break;
                default: break;
            }
            
            
            //Console.ReadKey();

        }
    }

}

