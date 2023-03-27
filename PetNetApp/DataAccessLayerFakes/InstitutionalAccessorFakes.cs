/// <summary>
/// Barry Mikulas
/// Created: 2023/03/01
/// 
/// Data Accessor Fakes class for fake accessor data and test classes.
/// </summary>
///
/// <remarks>
/// Updater
/// Updated: 
/// Comments:
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;


namespace DataAccessLayerFakes
{
    public class InstitutionalEntityAccessorFakes : IInstitutionalEntityAccessor
    {
        public List<InstitutionalEntity> _institutionalEntities = new List<InstitutionalEntity>();
        private InstitutionalEntity _institutionalEntity = new InstitutionalEntity();

        public InstitutionalEntityAccessorFakes()
        {
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1000,
                CompanyName = "SpaceX",
                GivenName = "Elon",
                FamilyName = "Musk",
                Email = "elon@spacex.com",
                Phone = "4539876541",
                Address = "123 Boca Chica Blvd",
                AddressTwo = "",
                Zipcode = "01111",
                ContactType = "Host",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1001,
                CompanyName = "SpaceX",
                GivenName = "Elona",
                FamilyName = "Musk",
                Email = "elona@spacex.com",
                Phone = "2539876541",
                Address = "223 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Host",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1002,
                CompanyName = "SpaceX",
                GivenName = "Elono",
                FamilyName = "Musko",
                Email = "elono@spacex.com",
                Phone = "3539876541",
                Address = "323 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Host",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1003,
                CompanyName = "SpaceX",
                GivenName = "Melon",
                FamilyName = "Husk",
                Email = "melon@spacex.com",
                Phone = "6539876541",
                Address = "623 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Sponsor",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1004,
                CompanyName = "SpaceX",
                GivenName = "Lemon",
                FamilyName = "Dusk",
                Email = "lemon@spacex.com",
                Phone = "7539876541",
                Address = "723 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Host",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1005,
                CompanyName = "SpaceX",
                GivenName = "Grape",
                FamilyName = "Mush",
                Email = "Grape@spacex.com",
                Phone = "8539876541",
                Address = "823 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Host",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1006,
                CompanyName = "SpaceX",
                GivenName = "Dragon",
                FamilyName = "Musk",
                Email = "Dragon@spacex.com",
                Phone = "9539876541",
                Address = "923 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Host",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1007,
                CompanyName = "SpaceX",
                GivenName = "Falcon",
                FamilyName = "Musk",
                Email = "Falcon@spacex.com",
                Phone = "1139876541",
                Address = "113 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Sponsor",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1008,
                CompanyName = "SpaceX",
                GivenName = "Glen",
                FamilyName = "Musk",
                Email = "glen@spacex.com",
                Phone = "1239876541",
                Address = "1233 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Sponsor",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1009,
                CompanyName = "SpaceX",
                GivenName = "Nole",
                FamilyName = "Musk",
                Email = "nole@spacex.com",
                Phone = "1339876541",
                Address = "1323 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Contact",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1010,
                CompanyName = "SpaceX",
                GivenName = "Grimes",
                FamilyName = "Musk",
                Email = "grimes@spacex.com",
                Phone = "1439876541",
                Address = "1423 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Contact",
                ShelterId = 100000
            });
            _institutionalEntities.Add(new InstitutionalEntity()
            {
                InstitutionalEntityId = 1011,
                CompanyName = "SpaceX",
                GivenName = "X Æ A-12",
                FamilyName = "Musk",
                Email = "xasha12@spacex.com",
                Phone = "4539876541",
                Address = "123 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "01111",
                ContactType = "Contact",
                ShelterId = 100000
            });


            //makes 300 additional InstitutionalEntityFakes
            Random randomNum = new Random();
            char ranChar;
            string charList = "abcdefghijklmnopqrstuvwxyz";
            string contactType;
            string startName;
            for (int i = 0; i < 300; i++)
            {
                randomNum.Next(100000000, 999999999);

                if (i < 100)
                {
                    contactType = "Host";
                    startName = "Chris";
                }
                else if (i < 200)
                {
                    contactType = "Sponsor";
                    startName = "Andrew";
                }
                else
                {
                    contactType = "Contact";
                    startName = "Asa";
                }
                ranChar = charList[randomNum.Next(0, charList.Length)];

                _institutionalEntities.Add(new InstitutionalEntity()
                {
                    InstitutionalEntityId = 1011 + i,
                    CompanyName = ranChar.ToString().ToUpper() + ("SpaceX" + ranChar).ToLower(),
                    GivenName = ranChar.ToString().ToUpper() + (startName + ranChar).ToLower(),
                    FamilyName = "Musk" + ranChar,
                    Email = ranChar + startName.ToLower() + ranChar + "@spacex.com",
                    Phone = randomNum.ToString() + "9",
                    Address = "123 Boca Chica Blvd",
                    AddressTwo = null,
                    Zipcode = "01111",
                    ContactType = contactType,
                    ShelterId = 100000
                });
            }
        }

        public List<InstitutionalEntity> SelectAllInstitutionalEntitiesByShelterIdAndContactType(int shelterId, string contactType)
        {
            List<InstitutionalEntity> fakes = new List<InstitutionalEntity>();

            fakes = _institutionalEntities.FindAll(i => i.ContactType == contactType && i.ShelterId == shelterId);

            return fakes;

        }

        public InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId)
        {
            throw new NotImplementedException();
        }
    }
}
