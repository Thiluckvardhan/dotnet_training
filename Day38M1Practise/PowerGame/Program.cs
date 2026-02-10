using System;

public class Test
{
    public static int powerGame(int N, int[] A)
    {
        long current = 0;

        for (int i = 0; i < N; i++)
        {
            if (current == 0)
            {
                current = A[i];
            }
            else if (A[i] > current)
            {
                current = 0;          // both eliminated
            }
            else
            {
                current += A[i];      // absorb
            }
        }

        if (current == 0)
        {
            Console.WriteLine("NO");
            return 0;
        }
        else
        {
            Console.WriteLine($"YES {current}");
            return (int)current;
        }
    }

    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] A = new int[N];
        string[] tokens = Console.ReadLine().Split();

        for (int i = 0; i < N; i++)
            A[i] = int.Parse(tokens[i]);

        powerGame(N, A);
    }
}
