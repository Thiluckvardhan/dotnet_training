public class MultiplicationTable
{
    public static void Main()
    {
        Console.Write("Enter Number for which you need Table: ");
        if(!int.TryParse(Console.ReadLine(),out int num))
        {
            Console.WriteLine("Invalid Input. Only Integers are Allowed");
        }
        Console.Write("Enter Number upto: ");
        if(!int.TryParse(Console.ReadLine(),out int upto))
        {
            Console.WriteLine("Invalid Input. Only Integers are Allowed");
        }
        // Console.Write("[");
        // for(int i = 1; i <= upto; i++)
        // {
        //     Console.Write($"{num * i}");
        //     if(i!=upto)
        //     Console.Write(", ");
        // }
        // Console.Write("]");
		int[] arr=new int[upto];
		for(int i = 1; i <= upto; i++)
		{
			arr[i-1]=num*i;
		}
		Console.Write("[");
		foreach(int i in arr)
		{
			Console.Write($"{i}");
			if(i!=arr.Last())
			Console.Write(", ");
		}
		Console.Write("]");
    }
}
