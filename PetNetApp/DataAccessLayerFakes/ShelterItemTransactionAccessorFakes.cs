using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class ShelterItemTransactionAccessorFakes : IShelterItemTransactionAccessor
    {
        List<ShelterItemTransactionVM> shelterItemTransactions;

        public ShelterItemTransactionAccessorFakes()
        {
            shelterItemTransactions = new List<ShelterItemTransactionVM>();
            shelterItemTransactions.Add(new ShelterItemTransactionVM()
            {
                ShelterItemTransactionId = 1,
                ShelterId = 55,
                ItemId = "Dog Food",
                ChangedByUsersId = 1,
                InventoryChangeReasonId = "Check-out",
                QuantityIncrement = 5,
                DateChanged = DateTime.Now,
                ShelterName = "Cedar Shelter",
                GivenName = "Phil",
                FamilyName = "Peter",
                ReasonDescription = "I needed to feed the dogs"
            });
            shelterItemTransactions.Add(new ShelterItemTransactionVM()
            {
                ShelterItemTransactionId = 2,
                ShelterId = 66,
                ItemId = "Absorbant Pad",
                ChangedByUsersId = 3,
                InventoryChangeReasonId = "Check-out",
                QuantityIncrement = 2,
                DateChanged = DateTime.Now,
                ShelterName = "Pine Shelter",
                GivenName = "Bil",
                FamilyName = "Peter",
                ReasonDescription = "Fido made a mess"
            });
            shelterItemTransactions.Add(new ShelterItemTransactionVM()
            {
                ShelterItemTransactionId = 3,
                ShelterId = 55,
                ItemId = "Cat Food",
                ChangedByUsersId = 2,
                InventoryChangeReasonId = "Check-in",
                QuantityIncrement = 6,
                DateChanged = DateTime.Now,
                ShelterName = "Cedar Shelter",
                GivenName = "Simon",
                FamilyName = "Peter",
                ReasonDescription = "We received some from the Pine Shelter"
            });
        }


        public List<ShelterItemTransactionVM> SelcetShelterItemTransactionByShelterId(int shelterId)
        {
            return shelterItemTransactions.Where(m => m.ShelterId == shelterId).ToList();
        }
    }
}
