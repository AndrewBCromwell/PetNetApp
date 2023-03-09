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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
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
                Zipcode = "78520",
                ContactType = "Contact",
                ShelterId = 100000
            });

            //makes 300 additional InstitutionalEntityFakes
            Random randomNum = new Random();
            //char ranChar;
            //string charList = "abcdefghijklmnopqrstuvwxyz";
            string[] gnList = { "Chris", "Asa", "Mohammed", "Elon", "Mads", "Tyler", "Will", "Keegan", "Chris", "Lemon", "Liam", "Noah", "Oliver", "Elijah", "Mateo", "Lucas", "Olivia", "Emma", "Amelia", "Ava", "Sophia", "Isabella", "Luna", "Mia", "Charlotte", "Evelyn", "Levi", "Asher", "James", "Leo", "Harper", "Scarlett", "Nova", "Aurora", "Ella", "Mila", "Aria", "Ellie", "Gianna", "Sofia", "Grayson", "Ezra", "Luca", "Ethan", "Aiden", "Wyatt", "Sebastian", "Benjamin", "Mason", "Henry" };
            string[] fnList = { "Forsberg", "Armstrong", "Musk", "Rhea", "Tousah", "Hand", "Smith", "Grimes", "Andrews", "Stephenson", "Deegan", "Glasgow", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzales", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts", "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards", "Collins", "Reyes", "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper", "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson", "Watson", "Brooks", "Chavez", "Wood", "James", "Bennet", "Gray", "Mendoza", "Ruiz", "Hughes", "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long", "Ross", "Foster", "Jimenez" };
            string[] cpyList = { "","Boeing", "SpaceX", "ULA", "Rocket Labs", "Amazon", "Alibaba", "Microsoft", "Apple", "Rockwell", "Nordstrom", "Asus", "Ford", "BMW", "Rivian", "Tesla", "Walmart", "Amazon", "Apple", "CVS Health", "United Health", "Exxon Mobil", "Berkshire Hathaway", "Alphabet", "McKesson", "Amerisource Bergen", "Costco Wholesale", "Cigna", "ATT", "Microsoft", "Cardinal Health", "Chevron", "Home Depot", "Walgreens Boots", "Marathon Petroleum", "Elevance Health", "Kroger", "Ford Motor", "Verizon", "JPMorgan Chase", "General Motors", "Centene", "Meta Platforms", "Comcast", "Phillips 66", "Valero Energy", "Dell Technologies", "Target", "FannieMae", "United Parcel Service", "Lowes", "Bank of America", "Johnson Johnson", "Archer Daniels Midland", "Fed Ex", "Humana", "Wells Fargo", "State Farm", "Pfizer", "Citi", "Pepsi Co", "Intel", "Procter Gamble", "General Electric", "IBM", "Met Life", "Prudential", "Albertsons", "Walt Disney", "Energy Transfer", "Lockheed Martin", "Freddie Mac", "Goldman Sachs", "Raytheon Technologies", "HP", "Boeing", "Morgan Stanley", "HCA Healthcare", "Abb Vie", "Dow", "Tesla", "Allstate", "AIG", "BestBuy", "Charter Communications", "Sysco", "Merck", "New York Life", "Caterpillar", "Cisco Systems", "TJX", "Publix Super Markets", "Conoco Phillips", "Liberty Mutual", "Progressive", "Nationwide", "Tyson Foods", "Bristol Myers Squibb", "Nike", "Deere", "American Express", "Abbott Laboratories", "StoneX", "Plains GP Holdings", "Enterprise Products", "TIAA", "Oracle", "Thermo Fisher Scientific", "Coca Cola", "Genera Dynamics", "CHS", "USAA", "Northwestern Mutual", "Nucor", "Exelon", "Mass Mutual" };
            string[] contactTypes = { "Host", "Sponsor", "Contact" };
            string[] zipcodeList = { "52404", "10013", "29384", "29555", "38001", "00601"};
            for (int i = 0; i < 300; i++)
            {
                string phoneNumber = "";
                for (int j = 0; j < 10; j++)
                {
                    phoneNumber += randomNum.Next(0, 9).ToString();
                }
                randomNum.Next(0, 9);

                //ranChar = charList[randomNum.Next(0, charList.Length)];
                string givenName = gnList[randomNum.Next(0, gnList.Length)];
                string familyName = fnList[randomNum.Next(0, fnList.Length)];
                string cpyName = cpyList[randomNum.Next(0, cpyList.Length)];
                string ct = contactTypes[randomNum.Next(0, contactTypes.Length)];
                string zc = zipcodeList[randomNum.Next(0, zipcodeList.Length)]; 

                _institutionalEntities.Add(new InstitutionalEntity()
                {
                    InstitutionalEntityId = 1011 + i,
                    CompanyName = cpyName,
                    GivenName = givenName,
                    FamilyName = familyName,
                    Email = (givenName + "." + familyName).ToLower() + i + "@" + cpyName.ToLower().Replace(" ", "") + ".com",
                    Phone = phoneNumber,
                    Address = "123 Boca Chica Blvd",
                    AddressTwo = null,
                    Zipcode = zc,
                    ContactType = ct,
                    ShelterId = 100000
                });
            }

        }

        /// <summary>
        /// Updated by Barry Mikulas
        /// 2023/03/05
        /// 
        /// 
        /// </summary>
        /// <param name="shelterId"></param>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public List<InstitutionalEntity> SelectAllInstitutionalEntitiesByShelterIdAndEntityType(int shelterId, string entityType)
        {
            List<InstitutionalEntity> fakes = new List<InstitutionalEntity>();

            fakes = _institutionalEntities.Where(i => i.ContactType == entityType).Where(i => i.ShelterId == shelterId).ToList();

            //fakes = _institutionalEntities.FindAll(i => i.ContactType == contactType && i.ShelterId == shelterId);

            return fakes;

        }

        public InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId)
        {
            throw new NotImplementedException();
        }
    }
}
