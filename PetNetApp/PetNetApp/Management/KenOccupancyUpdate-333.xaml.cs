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

namespace WpfPresentation.Management
{
    /// <summary>
    /// Interaction logic for KenOccupancyUpdate_333.xaml
    /// </summary>
    public partial class KenOccupancyUpdate_333 : Page
    {
        private KennelVM _kennel = new KennelVM();
        private MasterManager _masterManager = MasterManager.GetMasterManager();

        public KenOccupancyUpdate_333(KennelVM kennel)
        {
            _kennel = kennel;

            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            lbl_KennelName.Content = _kennel.KennelName;
            lbl_AnimalNameTitle.Content = "This is " + _kennel.Animal.AnimalName + "'s kennel!";
            lbl_Species.Content = _kennel.AnimalTypeId;
            lbl_Name.Content = _kennel.Animal.AnimalName;
            lbl_Intake.Content = _kennel.Animal.BroughtIn.ToShortDateString();
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;

            try
            {
                if (PromptSelection.Yes == PromptWindow.ShowPrompt("Remove", "Remove animal from kennel?", ButtonMode.YesNo))
                {
                    result = _masterManager.KennelManager.RemoveAnimalKennelingByKennelIdAndAnimalId(_kennel.KennelId, _kennel.Animal.AnimalId);
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);
            }

            if (result)
            {
                PromptWindow.ShowPrompt("Congrats", "Animal Kenneling removed.", ButtonMode.Ok);
                NavigationService.Navigate(new WpfPresentation.Management.ViewKennelPage());
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WpfPresentation.Management.ViewKennelPage());
        }
    }
}
