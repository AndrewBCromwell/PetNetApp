using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    public class KennelAccessorFake : IKennelAccessor
    {
        List<KennelVM> fakeKennelVMs = new List<KennelVM>();

        public KennelAccessorFake()
        {
            fakeKennelVMs.Add(new KennelVM
            {
                KennelId = 1,
                ShelterId = 1,
                KennelName = "Kennel1",
                KennelActive = true,
                AnimalTypeId = "Dog",
                ShelterName = "Shelter1",
                Animal = new Animal()
            });
            fakeKennelVMs.Add(new KennelVM
            {
                KennelId = 2,
                ShelterId = 1,
                KennelName = "Kennel2",
                KennelActive = true,
                AnimalTypeId = "Dog",
                ShelterName = "Shelter2",
                Animal = new Animal()
            });
            fakeKennelVMs.Add(new KennelVM
            {
                KennelId = 3,
                ShelterId = 1,
                KennelName = "Kennel3",
                KennelActive = true,
                AnimalTypeId = "Dog",
                ShelterName = "Shelter3",
                //Animal = new Animal()
            });
        }

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods retrieves fake kennels from the kennel accessor fakes with the associated shelter id
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="shelterid">A description of the parameter that this method takes</param>
        /// <returns>List<KennelVM></returns>
        public List<KennelVM> SelectKennels(int shelterid)
        {
            return fakeKennelVMs.Where(ken => ken.ShelterId == shelterid).ToList();
        }
    }
}
