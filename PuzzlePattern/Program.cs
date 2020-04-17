using System;

namespace FactoryDesign
{
    /// The 'Product' Abstract Class  

    public abstract class ArrayValues
    {
        public abstract string logic { get; }
        public abstract int[] myNum { get; set; }
        public abstract int snumber { get; set; }
    }


    /// A 'ConcreteProduct' class  

    public class Method1 : ArrayValues
    {
        private  string _logic;
        private int[] _myNum;
        private int _snumber;
        public Method1(int[] myNum, int snumber)
        {
            _myNum = myNum;
            _snumber = snumber;
            Console.WriteLine("Puzzle Method 1");
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

        public override string logic => throw new NotImplementedException();

        public override int[] myNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int snumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }




    /// The 'Creator' Abstract Class  

    public abstract class ArrayFactory
    {
        public abstract ArrayValues GetArrayValues();
    }

    /// A 'ConcreteCreator' class  

    public class Method1Factory : ArrayFactory
    {
        private string _logic;
        private int[] _myNum;
        private int _snumber;
        public Method1Factory(int[] myNum, int snumber)
        {
            _myNum = myNum;
            _snumber = snumber;
        }

        public override ArrayValues GetArrayValues()
        {
            return new Method1(_myNum, _snumber);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ArrayFactory factory = null;
            Console.WriteLine("Enter the Method you want to ues\n1. Method1\n2. Method2\n");
            int method = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Size of Array:");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] myNum = new int[num];
            Console.WriteLine("Enter the Sum Number that is to be Matched:");
            int snumber = Convert.ToInt32(Console.ReadLine()); ;
            Console.WriteLine("Enter Elements into Array:");
            for (int a = 0; a < num; a++)
            {
                myNum[a] = Convert.ToInt32(Console.ReadLine());
            }

            switch (method)
            {
                case 1:
                    factory = new Method1Factory(myNum, snumber);
                    break;
                /*case "method2":
                    factory = new TitaniumFactory(100000, 500);
                    break;*/
                default:
                    break;
            }

            /*arrayvalues arrayvalues = factory.Getarrayvalues();
            Console.WriteLine("\nYour method details are below : \n");
            Console.WriteLine("method Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",
                arrayvalues.logic, arrayvalues.[] myNum, arrayvalues.snumber);*/
        }
    }
}
