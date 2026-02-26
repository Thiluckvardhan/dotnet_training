using DALReverseProj;
namespace businessLogicProj
{
    public class BusinessLogic
    {
        public static string BlReverseName()
        {
            string name = DalReverse.GetAllData();
            string reverseName = new string(name.Reverse().ToArray());
            return $"Reverse of the Name: {reverseName}";
        }
    }
}
