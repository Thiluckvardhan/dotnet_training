namespace MultipleInHeritanceExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            IVegEater vegEater = new Visitor();
            string vTaste = vegEater.GetTaste();

            INonVegEater nonVegEater = new Visitor();
            string nvTaste = nonVegEater.GetTaste();
        }
    }

    public interface IVegEater
    {
        void EatVeggies();
        string GetTaste();
    }

    public interface INonVegEater
    {
        void EatNonVeggies();
        string GetTaste();

    }

    public class  Visitor : INonVegEater, IVegEater
    {
        public void EatNonVeggies()
        {
            Console.WriteLine("Eating Non Veggies");
        }
        public void EatVeggies()
        {
            Console.WriteLine("Eating Veggies");
        }

   

        string INonVegEater.GetTaste()
        {
           return "Non Veg Taste is Rank 2";
        }

        string IVegEater.GetTaste()
        {
            return "Veg Taste is Rank 1";

        }
    }
  
}
