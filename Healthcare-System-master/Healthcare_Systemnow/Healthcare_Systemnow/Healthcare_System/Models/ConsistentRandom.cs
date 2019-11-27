using System;

namespace Healthcare_System.Models
{
    public class ConsistentRandom
    {
        private static Random Random = new Random();
        private static int tendToUpperLower = 0; //using int as three states needed
        private static ConsistentRandom instance;

        public int UpperBoundary { get; set; }
        public int LowerBoundary { get; set; }

        //singleton design pattern
        public static ConsistentRandom Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsistentRandom();
                }
                return instance;
            }
        }

        public int GenerateValue(int currentValue)
        {
            int previousValue = currentValue; //generating a new value, so the current value on the module ui becomes the previous value

            int randomResult;
            if (previousValue == 0) //create a start value
            {
                randomResult = Random.Next(LowerBoundary, UpperBoundary + 1);
            }

            //if the previous is equal or greater than the upper boundary then the next reading should be lower
            else if (previousValue >= UpperBoundary)
            {
                int minValue = (int)(UpperBoundary * 0.8);
                randomResult = Random.Next(minValue, UpperBoundary);
            }

            //if the previous is equal or less than the lower boundary then the next reading should be lower
            else if (previousValue <= LowerBoundary)
            {
                int maxValue = (int)(LowerBoundary * 1.2);
                randomResult = Random.Next(LowerBoundary + 1, maxValue + 1);
            }

            else
            {
                //decide if patient values should be generally increasing or decreasing
                int chance = Random.Next(0, 10);
                switch (chance)
                {
                    case 0:
                        //values above previous to be generated only
                        tendToUpperLower = 1;
                        break;
                    case 1:
                        //values below previous to be generated only
                        tendToUpperLower = 2;
                        break;
                    default:
                        //other wise generate within range of the previous value
                        tendToUpperLower = 0;
                        break;
                }

                if (tendToUpperLower == 1)
                {
                    //generates a value between the previous value and 20% higher than the previous value
                    Console.Write("Upper: ");
                    int maxValue = (int)(previousValue * 1.2);
                    randomResult = Random.Next(previousValue, maxValue + 1);
                }
                else if (tendToUpperLower == 2)
                {
                    //generates a value between 80% of previous value and the previous value
                    Console.Write("Lower: ");
                    int minValue = (int)(previousValue * 0.8);
                    randomResult = Random.Next(minValue, previousValue + 1);
                }
                else
                {
                    //generates within range of +-10% of previous value
                    Console.Write("previous' boundary: ");
                    int maxValue = (int)(previousValue * 1.1);
                    int minValue = (int)(previousValue * 0.9);
                    randomResult = Random.Next(minValue, maxValue + 1);
                }
            }

            previousValue = randomResult;
            return previousValue;
        }
    }
}
