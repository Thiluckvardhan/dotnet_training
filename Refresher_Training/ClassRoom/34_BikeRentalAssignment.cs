namespace BikeRental
{
    public class Bike
    {
        public string Model { get; set; }
        public int PricePerDay { get; set; }
        public string Brand { get; set; }

    }

    public class BikeUtility
    {
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            Bike bike = new();
            bike.Model = model;
            bike.Brand = brand;
            bike.PricePerDay = pricePerDay;

            int key = Program.bikeDetails.Count + 1;
            Program.bikeDetails.Add(key, bike);
        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> result = new();
            foreach (var item in Program.bikeDetails)
            {
                Bike bike = item.Value;
                if (!result.ContainsKey(bike.Brand))
                {
                    result.Add(bike.Brand, new List<Bike>());
                }
                result[bike.Brand].Add(bike);
            }
            return result;
        }
    }

    public class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails =
            new SortedDictionary<int, Bike>();

        public static void Main(string[] args)
        {
            BikeUtility utility = new BikeUtility();

            while (true)
            {
                Console.WriteLine("1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                if(!int.TryParse(Console.ReadLine(),out int choice))
                {
                    Console.WriteLine("Enter only Numbers");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the model: ");
                        string model = Console.ReadLine();

                        Console.Write("Enter the brand: ");
                        string brand = Console.ReadLine();

                        Console.Write("Enter the price per day: ");
                        if(!int.TryParse(Console.ReadLine(),out int price))
                        {
                            Console.WriteLine("Invalid Input. Enter only Integers");
                            continue;
                        }

                        utility.AddBikeDetails(model, brand, price);

                        Console.WriteLine("Bike details added successfully");
                        break;

                    case 2:
                        SortedDictionary<string, List<Bike>> grouped =utility.GroupBikesByBrand();

                        foreach (KeyValuePair<string, List<Bike>> item in grouped)
                        {
                            foreach (Bike bike in item.Value)
                            {
                                Console.WriteLine(item.Key + " " + bike.Model);
                            }
                        }
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}