namespace Draft
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public class Man : Person
    {
        public string Job { get; set; }
    }

    public class Woman : Person
    {
        public string TopJob { get; set; }
    }
}
