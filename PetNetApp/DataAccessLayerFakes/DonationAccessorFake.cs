using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    public class DonationAccessorFake : IDonationAccessor
    {
        private List<DonationVM> fakeDonations = new List<DonationVM>();
        public DonationAccessorFake()
        {
            fakeDonations.Add(new DonationVM
            {
                DonationId = 1,
                UserId = 1,
                User = new Users() { GivenName = "Gwen", FamilyName = "Arman"},
                ShelterId = 1,
                Amount = 100.00M,
                Message = "I want to help",
                DateDonated = DateTime.Today,
                HasInKindDonation = true,
                Anonymous = false,
                Target = "To help",
                PaymentMethod = "Cash",
                ShelterName = "Doggy Care",
                InKindList = new List<InKind>()
                {
                    new InKind()
                    {
                        InKindId = 1, DonationId = 1, Description = "Dog Toys",
                        Quanity = 10, Target = "To Help", Recieved = true
                    },
                    new InKind()
                    {
                        InKindId = 2, DonationId = 1, Description = "Cat Toys",
                        Quanity = 10, Target = "To Help", Recieved = true
                    },
                    new InKind()
                    {
                        InKindId = 3, DonationId = 1, Description = "Rabbit Food",
                        Quanity = 15, Target = "To Help", Recieved = true
                    }
                }
            });
            ;
            fakeDonations.Add(new DonationVM
            {
                DonationId = 2,
                ShelterId = 1,
                Amount = 150.00M,
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + 
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                DateDonated = DateTime.Today,
                GivenName = "John",
                FamilyName = "Smith",
                HasInKindDonation = false,
                Anonymous = false,
                Target = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PaymentMethod = "Cash",
                ShelterName = "Kitty Care",
            });
            fakeDonations.Add(new DonationVM
            {
                DonationId = 3,
                ShelterId = 1,
                Amount = 110.00M,
                Message = "In honor of Buddy Senior",
                DateDonated = DateTime.Today,
                GivenName = "John",
                FamilyName = "Smith",
                HasInKindDonation = false,
                Anonymous = false,
                Target = "To help",
                PaymentMethod = "Cash",
                ShelterName = "Snakey Care",
            });
            fakeDonations.Add(new DonationVM
            {
                DonationId = 4,
                UserId = 2,
                User = new Users() { GivenName = "Hoang", FamilyName = "Chu" },
                ShelterId = 1,
                Amount = 9.99M,
                Message = "Một khoản đóng góp để giúp đỡ. Gia đình tôi rất thích nơi trú ẩn này.",
                DateDonated = DateTime.Today,
                HasInKindDonation = false,
                Anonymous = false,
                Target = "To help",
                PaymentMethod = "Cash",
                ShelterName = "Animal Care",
            });

        }

        public List<DonationVM> SelectAllDonations()
        {
            return fakeDonations;
        }

        public List<DonationVM> SelectDonationsByShelterId(int ShelterId)
        {
            return fakeDonations.Where(d => d.ShelterId == ShelterId).ToList();
        }

        public List<InKind> SelectInKindsByDonationId(int donationId)
        {
            return fakeDonations.First(don => don.DonationId == donationId).InKindList;
        }
    }
}
