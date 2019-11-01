using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerAndModuleRead
{
    class Module
    {
        private readonly Random generator = new Random();

        public int UpperBoundary { get; private set; }
        public int LowerBoundary { get; private set; }
        public string ModuleName { get; }

        public Module(string moduleName)
        {
            //assign name
            ModuleName = moduleName;

            //set boundaries
            Console.WriteLine($"\n{ModuleName} Boundaries");

            Console.Write("Enter Upper Boundary: ");
            Int32.TryParse(Console.ReadLine().ToString(), out int a);
            UpperBoundary = a;

            Console.Write("Enter Lower Boundary: ");
            Int32.TryParse(Console.ReadLine().ToString(), out int b);
            LowerBoundary = b;
        }

        public Alert CheckPatientData()
        {
            //generate data
            int reading = GenerateReading();
            //compare to boundaries
            if (CompareToUpperBoundary(reading))
            {
                return new Alert($"Above {ModuleName} upper boundary", true);
            }
            if (CompareToLowerBoundary(reading))
            {
                return new Alert($"Below {ModuleName} lower boundary", true);
            }
            return new Alert(false);
            
        }

        private int GenerateReading()
        {
            //create a reading
            int reading = generator.Next(LowerBoundary - 10, UpperBoundary + 21);
            Console.WriteLine($"Current {ModuleName} Reading: {reading}");
            return reading;
        }

        private bool CompareToUpperBoundary(int reading)
        {
            if (reading >= UpperBoundary)
            {
                return true;
            }
            return false;
        }
        private bool CompareToLowerBoundary(int reading)
        {
            if (reading <= LowerBoundary)
            {
                return true;
            }
            return false;
        }
    }
}
