using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 10000;

        for (int i = 0; i < salaries.Length; i++)
        {
            try
            {
                Console.WriteLine(bonus / salaries[i]);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero salary.");
            }
        }
    }
}
