using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MasterManager
    {
        private static MasterManager _existingMasterManager = null;
        public UsersVM User { get; set; }
        public IKennelManager KennelManager { get; set; }
        public IUsersManager UsersManager { get; set; }
        public IDeathManager DeathManager { get; set; }
        
        public IAnimalManager AnimalManager { get; set; }
        public IAnimalUpdatesManager AnimalUpdatesManager { get; set; }
        public IScheduleManager scheduleManager { get; set; }
        public ITestManager TestManager { get; set; }
        public IImagesManager ImagesManager { get; set; }

        private MasterManager()
        {
            KennelManager = new KennelManager();
            UsersManager = new UsersManager();
            DeathManager = new DeathManager();
            AnimalManager = new AnimalManager();
            AnimalUpdatesManager = new AnimalUpdatesManager();
            scheduleManager = new ScheduleManager();
            TestManager = new TestManager();
            ImagesManager = new ImagesManager();
        }
    
        public static MasterManager GetMasterManager()
        {
            if (_existingMasterManager == null)
            {
                _existingMasterManager = new MasterManager();
            }
            return _existingMasterManager;
        }
    }
}
