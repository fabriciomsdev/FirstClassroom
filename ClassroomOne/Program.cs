using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassroomOne
{
    #region Class declaration
    class People
    {
        public string name;
        public int age;

        public override string ToString()
        {
            return name;
        }
    }

    #endregion

    #region Struct Declaration
    
    struct CartesianPoint 
    {
        public int X;
        public int Y;
        public event Action<int> PointChanged;

        public CartesianPoint(int x, int y, Action<int> PointChanged)
        {
            X = x;
            Y = y;
            this.PointChanged = PointChanged;
        }
    }

    #endregion

    #region Enum Declaration
    enum OrderStatus {
        Started = 0,
        PaymentPending = 1,
        Confirmed = 2,
        Rejected = 3,
        Expired = 4
    }
    #endregion

    #region My program
    class Program
    {
        static void Main(string[] args)
        {
            #region HelloWorld
            Console.WriteLine("Hello World");
            #endregion


            #region Conditional Structure
            bool thisIsTheMainContext = true;

            if (thisIsTheMainContext)
            {
                Console.WriteLine("Main Context");
            }

            #endregion


            #region Loops and Arrays
            int[] fundamentalNumbers = {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            for (int i = 0; i < fundamentalNumbers.Length; i++)
            {
                Console.WriteLine(fundamentalNumbers[i]);
            }

            foreach (int number in fundamentalNumbers)
            {
                Console.WriteLine(number);
            }
            #endregion


            #region Operation with 2 numbers using Delegate

            MathOperationWith2Numbers sum, mult, myCustomMathOperation;
            sum = Sum;
            mult = Mult;

            myCustomMathOperation = sum + mult;

            Console.WriteLine(myCustomMathOperation(2, 3));

            #endregion


            #region List Declaration and Delegate Filter

            SimpleFilter callbackFilter = IsGreaterThanOrEqualsTo22Years;

            List<People> youngPeoples = new List<People> { 
                new People { 
                    name = "Fabricio",
                    age = 22
                },
                new People {
                    name = "Kelvin",
                    age = 22
                },
                new People {
                    name = "Caique",
                    age = 21
                },
                new People {
                    name = "Larissa",
                    age = 18
                },
                new People {
                    name = "Victor",
                    age = 18
                },
            };

            List<People> newPeoplesFilteredByAge = ApplyFilterInPeople(youngPeoples, callbackFilter);

            foreach (People peopleFilteredByAge in newPeoplesFilteredByAge)
            {
                Console.WriteLine(peopleFilteredByAge);
            }

            #endregion


            #region using LINQ

            List<People> resultUsingLinq = (
                from APeople in youngPeoples 
                where APeople.name[0] == 'F' 
                select APeople
            ).ToList();

            Console.Write(resultUsingLinq[0]);

            #endregion
        }

        #region Delegate Declaration
        public delegate int MathOperationWith2Numbers(int n1, int n2);
        public delegate bool SimpleFilter(People people);
        #endregion


        #region Methods Declarations
        public static int Sum(int n1, int n2) => n1 + n2;

        public static int Mult(int n1, int n2) => n1 * n2;

        public static List<People> ApplyFilterInPeople(List<People> peoples, SimpleFilter customFilter)
        {
            List<People> newPeoples = new List<People> { };

            foreach (People people in peoples) {
                if (customFilter(people)) {
                    newPeoples.Add(people);
                }
            }

            return newPeoples;
        }

        public static bool IsGreaterThanOrEqualsTo22Years(People people)
        {
            return people.age >= 22;
        }
        #endregion
    }

    #endregion
}
