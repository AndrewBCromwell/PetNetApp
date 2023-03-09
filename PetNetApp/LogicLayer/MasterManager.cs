using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerFakes;

namespace LogicLayer
{
    public class MasterManager
    {
        private static MasterManager _existingMasterManager = null;
        private UsersVM _user;
        public UsersVM User
        {
            get => _user;
            set
            {
                _user = value;
                if (value == null)
                {
                    OnUserLogout();
                }
                else
                {
                    OnUserLogin();
                }
            }
        }
        public delegate void UserChangedAction();
        public event UserChangedAction UserLogout;
        public event UserChangedAction UserLogin;
        public IKennelManager KennelManager { get; set; }
        public IUsersManager UsersManager { get; set; }
        public IDeathManager DeathManager { get; set; }
        public IAnimalManager AnimalManager { get; set; }
        public IAnimalUpdatesManager AnimalUpdatesManager { get; set; }
        public IScheduleManager ScheduleManager { get; set; }
        public ITestManager TestManager { get; set; }
        public IRoleManager RoleManager { get; set; }
        public ITicketManager TicketManager { get; set; }
        public IProcedureManager ProcedureManager { get; set; }
        public IMedicalRecordManager MedicalRecordManager { get; set; }
        public IFundraisingCampaignManager FundraisingCampaignManager { get; set; }
        public IShelterItemTransactionManager ShelterItemTransactionManager { get; set; }
        public IDonationManager DonationManager { get; set; }
        public IImagesManager ImagesManager { get; set; }


        private MasterManager()
        {
            KennelManager = new KennelManager();
            UsersManager = new UsersManager();
            DeathManager = new DeathManager();
            AnimalManager = new AnimalManager();
            AnimalUpdatesManager = new AnimalUpdatesManager();
            ScheduleManager = new ScheduleManager();
            TestManager = new TestManager();
            RoleManager = new RoleManager();
            TicketManager = new TicketManager();
            ProcedureManager = new ProcedureManager();
            MedicalRecordManager = new MedicalRecordManager();
            FundraisingCampaignManager = new FundraisingCampaignManager();
            ImagesManager = new ImagesManager();
            ShelterItemTransactionManager = new ShelterItemTransactionManager();
            ImagesManager = new ImagesManager();
            DonationManager = new DonationManager();


            //for testing from dev page
            //User = new UsersVM()
            //{
            //    UsersId = 100004,
            //    ShelterId = 100000,
            //    GivenName = "Barry",
            //    FamilyName = "Mikulas",
            //    Email = "bmikulas@company.com",
            //    Address = "4150 riverview road",
            //    Zipcode = "52411",
            //    Phone = "319-123-1325",
            //    Active = true,
            //    Suspend = false,
            //    Roles = new List<string>() { "Admin" }
            //};


        }

        public static MasterManager GetMasterManager()
        {
            if (_existingMasterManager == null)
            {
                _existingMasterManager = new MasterManager();
            }
            return _existingMasterManager;
        }
        protected virtual void OnUserLogout()
        {
            UserChangedAction handler = UserLogout;
            handler?.Invoke();
        }
        protected virtual void OnUserLogin()
        {
            UserChangedAction handler = UserLogin;
            handler?.Invoke();
        }
    }
}
