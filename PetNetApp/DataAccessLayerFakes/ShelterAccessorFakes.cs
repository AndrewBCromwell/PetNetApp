using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    /// <summary>
    /// Brian Collum
    /// Created: 2023/02/23
    /// ShelterAccessorFakes contains fake data for ShelterManager unit tests
    /// </summary>
    public class ShelterAccessorFakes : IShelterAccessor
    {
        List<Shelter> shelterList = new List<Shelter>();

        public ShelterAccessorFakes()
        {
            shelterList.Add(new Shelter
            {
                ShelterId = 0,
                ShelterName = "Test Shelter 00",
                Address = "Fake area 00",
                AddressTwo = "Fake address 00",
                ZipCode = "50001",
                Phone = "000-000-0000",
                Email = "zero@zero.zerp",
                AreasOfNeed = "There is no shelter here",
                ShelterActive = false
            });
            shelterList.Add(new Shelter
            {
                ShelterId = 1,
                ShelterName = "Test Shelter 01",
                Address = "Fake area 01",
                AddressTwo = "Fake address 01",
                ZipCode = "50001",
                Phone = "555-666-7777",
                Email = "fake@fake.fake",
                AreasOfNeed = "Need fake things",
                ShelterActive = true
            });
            shelterList.Add(new Shelter
            {
                ShelterId = 2,
                ShelterName = "Test Shelter 02",
                Address = "Fake area 02",
                AddressTwo = null,
                ZipCode = "50002",
                Phone = null,
                Email = null,
                AreasOfNeed = null,
                ShelterActive = false
            });
        }
        public int DeactivateShelterByShelterID(int shelterID)
        {
            shelterList[shelterID].ShelterActive = false;
            return 1;
        }
        public bool InsertShelter(string shelterName, string address, string addressTwo, string zipCode, string phone, string email, string areasOfNeed, bool shelterActive)
        {
            Shelter newShelter = new Shelter();
            newShelter.ShelterId = 000003;  // Arbitrary value must be added
            newShelter.ShelterName = shelterName;
            newShelter.Address = address;
            newShelter.AddressTwo = addressTwo;
            newShelter.ZipCode = zipCode;
            newShelter.Phone = phone;
            newShelter.Email = email;
            newShelter.AreasOfNeed = areasOfNeed;
            newShelter.ShelterActive = shelterActive;
            shelterList.Add(newShelter);
            return true;
        }
        public List<Shelter> RetrieveShelterList()
        {
            return shelterList;
        }
        public ShelterVM SelectShelterVMByShelterID(int shelterID)
        {
            ShelterVM returnShelter = new ShelterVM();
            returnShelter.ShelterId = shelterList[shelterID].ShelterId;
            returnShelter.ShelterName = shelterList[shelterID].ShelterName;
            returnShelter.Address = shelterList[shelterID].Address;
            returnShelter.AddressTwo = shelterList[shelterID].AddressTwo;
            returnShelter.ZipCode = shelterList[shelterID].ZipCode;
            returnShelter.Phone = shelterList[shelterID].Phone;
            returnShelter.Email = shelterList[shelterID].Email;
            returnShelter.AreasOfNeed = shelterList[shelterID].AreasOfNeed;
            returnShelter.ShelterActive = shelterList[shelterID].ShelterActive;
            return returnShelter;
        }
        public int UpdateActiveStatusByShelterID(int shelterID, bool oldActiveStatus, bool newActiveStatus)
        {
            if (oldActiveStatus != newActiveStatus)
            {
                shelterList[shelterID].ShelterActive = newActiveStatus;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int UpdateAddressByShelterID(int shelterID, string oldAddress, string newAddress)
        {
            if (oldAddress != newAddress)
            {
                shelterList[shelterID].Address = newAddress;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int UpdateAddressTwoByShelterID(int shelterID, string newAddressTwo)
        {
            shelterList[shelterID].AddressTwo = newAddressTwo;
            return 1;
        }
        public int UpdateAreasOfNeedByShelterID(int shelterID, string newAreasOfNeed)
        {
            shelterList[shelterID].AreasOfNeed = newAreasOfNeed;
            return 1;
        }
        public int UpdateEmailByShelterID(int shelterID, string newEmail)
        {
            shelterList[shelterID].Email = newEmail;
            return 1;
        }
        public int UpdatePhoneByShelterID(int shelterID, string newPhone)
        {
            shelterList[shelterID].Phone = newPhone;
            return 1;
        }
        public int UpdateShelterNameByShelterID(int shelterID, string oldShelterName, string newShelterName)
        {
            if (oldShelterName != newShelterName)
            {
                shelterList[shelterID].ShelterName = newShelterName;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int UpdateZipCodeByShelterID(int shelterID, string oldZipCode, string newZipCode)
        {
            if (oldZipCode != newZipCode)
            {
                shelterList[shelterID].ZipCode = newZipCode;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
