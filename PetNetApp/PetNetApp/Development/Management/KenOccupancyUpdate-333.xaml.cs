using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataObjects;
using LogicLayer;

namespace WpfPresentation.Development.Management
{
    /// <summary>
    /// Interaction logic for KenOccupancyUpdate_333.xaml
    /// </summary>
    public partial class KenOccupancyUpdate_333 : Page
    {
        private Animal _animal = new Animal();
        private Kennel _kennel = new Kennel();
        private MasterManager _masterManager = MasterManager.GetMasterManager();

        public KenOccupancyUpdate_333(Kennel kennel, Animal animal)
        {
            _animal = animal;
            _kennel = kennel;

            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            lbl_KennelName.Content = _kennel.KennelName;
            lbl_AnimalNameTitle.Content = "This is " + _animal.AnimalName + "'s kennel!";
            lbl_Species.Content = _kennel.AnimalTypeId;
            lbl_Name.Content = _animal.AnimalName;
            lbl_Intake.Content = _animal.BroughtIn.ToShortDateString();
            lbl_Occupancy.Content = _kennel.KennelSpace;
            txt_Notes.Text = "I don't know what notes go here";
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;

            try
            {
                _masterManager.KennelManager.AddAnimalIntoKennelByAnimalId(100001, 100001);
                result = _masterManager.KennelManager.RemoveAnimalKennelingByKennelIdAndAnimalId(100001, 100001);
                // result = _masterManager.KennelManager.RemoveAnimalKennelingByKennelIdAndAnimalId(_kennel.KennelId, _animal.AnimalId);
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);
            }

            if (result)
            {
                PromptWindow.ShowPrompt("Congrats", "Animal Kenneling removed.", ButtonMode.Ok);
            }
        }
    }
}
