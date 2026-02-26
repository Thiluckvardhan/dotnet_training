using businessLogicProj;
namespace ClientSideProj
{
    public class ClientSideClass
    {
        public static void Main()
        {
            string name=BusinessLogic.BlReverseName();
            Console.WriteLine(name);
        }
    }
}