namespace LogisticsProShipmentSystem
{
    public class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode(string shipmentCode)
        {
            if (shipmentCode.Length != 7)
            {
                return false;
            }
            if ("GC#" != shipmentCode.Substring(0, 3)) return false;
            foreach (char letter in shipmentCode.Substring(3, 5))
            {
                if (!char.IsDigit(letter)) return false;
            }
            return true;
        }
        public double CalculateTotalCost()
        {
            double TotalCost=0;
            if (TransportMode == "Sea")
            {
                TotalCost=Weight*15.0 + Math.Sqrt(StorageDays);
            }
            else if (TransportMode == "Air")
            {
                TotalCost=Weight*50.0 + Math.Sqrt(StorageDays);
            }
            else if (TransportMode == "Land")
            {
                TotalCost=Weight*25.0 + Math.Sqrt(StorageDays);
            }
            return Math.Round(TotalCost,2);
        }
    }
}