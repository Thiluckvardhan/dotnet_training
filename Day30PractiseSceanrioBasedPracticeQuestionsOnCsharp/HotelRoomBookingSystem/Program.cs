namespace HotelRoomBookingSystem
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class HotelManager
    {
        public static Dictionary<int, Room> rooms = new();
        public void AddRoom(int roomNumber, string type, double price)
        {
            Room room = new()
            {
                RoomNumber = roomNumber,
                RoomType = type,
                PricePerNight = price,
                IsAvailable = true
            };
            rooms.TryAdd(roomNumber, room); // Adds only if room number is not present
        }

        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            Dictionary<string, List<Room>> result = new();

            foreach (var room in rooms.Values)
            {
                result.TryAdd(room.RoomType, new List<Room>());
                result[room.RoomType].Add(room);
            }

            return result;
        }


        public bool BookRoom(int roomNumber, int nights)
        {
            if (rooms.ContainsKey(roomNumber))
            {
                if (rooms[roomNumber].IsAvailable)
                {
                    rooms[roomNumber].IsAvailable = false;
                    System.Console.WriteLine($"Room Available and Price per night is {rooms[roomNumber].PricePerNight} and total stay cost will be {rooms[roomNumber].PricePerNight * nights}");
                    System.Console.WriteLine("Room booked successfully");
                    return true;
                }
            }
            return false;
        }

        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            List<Room> result = new();

            foreach (var room in rooms.Values)
            {
                if (room.IsAvailable &&
                    room.PricePerNight >= min &&
                    room.PricePerNight <= max)
                {
                    result.Add(room);
                }
            }

            return result;
        }

    }
    public class Program
    {
        public static Dictionary<int, List<Room>> AllRooms =
            new Dictionary<int, List<Room>>();

        static void Main(string[] args)
        {
            HotelManager manager = new HotelManager();

            while (true)
            {
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Group Rooms by Type");
                Console.WriteLine("3. Book a Room");
                Console.WriteLine("4. Show Available Rooms by Price Range");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Room Number: ");
                    int number = int.Parse(Console.ReadLine());

                    Console.Write("Enter Room Type: ");
                    string type = Console.ReadLine();

                    Console.Write("Enter Price Per Night: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.AddRoom(number, type, price);
                    Console.WriteLine("Room added successfully.\n");
                }
                else if (choice == 2)
                {
                    var groupedRooms = manager.GroupRoomsByType();

                    foreach (var item in groupedRooms)
                    {
                        Console.WriteLine($"Room Type: {item.Key}");
                        foreach (Room room in item.Value)
                        {
                            Console.WriteLine(
                                $"Room No: {room.RoomNumber}, Price: {room.PricePerNight}, Available: {room.IsAvailable}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Room Number to Book: ");
                    int roomNo = int.Parse(Console.ReadLine());

                    Console.Write("Enter Number of Nights: ");
                    int nights = int.Parse(Console.ReadLine());

                    bool success = manager.BookRoom(roomNo, nights);

                    if (!success)
                        Console.WriteLine("Room not available or invalid room number.\n");
                    else
                        Console.WriteLine();
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Minimum Price: ");
                    double min = double.Parse(Console.ReadLine());

                    Console.Write("Enter Maximum Price: ");
                    double max = double.Parse(Console.ReadLine());

                    var rooms = manager.GetAvailableRoomsByPriceRange(min, max);

                    if (rooms.Count == 0)
                    {
                        Console.WriteLine("No rooms available in this price range.\n");
                    }
                    else
                    {
                        foreach (Room room in rooms)
                        {
                            Console.WriteLine(
                                $"Room No: {room.RoomNumber}, Type: {room.RoomType}, Price: {room.PricePerNight}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Exiting application.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }
            }
        }
    }
}