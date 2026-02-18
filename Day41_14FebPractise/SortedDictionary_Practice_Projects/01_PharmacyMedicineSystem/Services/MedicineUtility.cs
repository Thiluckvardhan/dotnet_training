using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class MedicineUtility
    {
        private SortedDictionary<int,List<Medicine>> _data = new();
        private Dictionary<string,Medicine> _seen=new();
        public void AddMedicine(Medicine medicine)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if (medicine.Price < 0)
            {
                throw new InvalidPriceException("Price should not be Negative, cannot add");
            }
            if (medicine.ExpiryYear < DateTime.Now.Year)
            {
                throw new InvalidExpiryYearException("Medicine already Expired, cannot add");
            }
            if (_seen.ContainsKey(medicine.MedicineId))
            {
                throw new DuplicateMedicineException("Medicine already Present,cannot add");
            }
            _data.TryAdd(medicine.ExpiryYear,new());
            _data[medicine.ExpiryYear].Add(medicine);
            _seen.Add(medicine.MedicineId,medicine);
        }

        public void UpdateMedicinePrice(string id,double price)
        {
            // TODO: Update entity logic
            if (!_seen.ContainsKey(id))
            {
                throw new MedicineNotFoundException("Medicine not present to update");
            }
            Medicine medicine=_seen[id];
            foreach(var med in _data[medicine.ExpiryYear])
            {
                if (med.MedicineId == id)
                {
                    med.Price=price;
                }
            }
            medicine.Price=price;
        }

        public void RemoveEntity(string id)
        {
            // TODO: Remove entity logic
            if (!_seen.ContainsKey(id))
            {
                throw new MedicineNotFoundException("Medicine not present to Delete");
            }
            Medicine medicine=_seen[id];
            foreach(var med in _data[medicine.ExpiryYear])
            {
                if (med.MedicineId == id)
                {
                    _data[medicine.ExpiryYear].Remove(med);
                }
            }
            _seen.Remove(id);
        }

        public SortedDictionary<int,List<Medicine>> GetAll()
        {
            // TODO: Return sorted entities
            return new SortedDictionary<int,List<Medicine>>(_data);
        }
    }
}
