/// <summary>
/// Andrew Cromwell
/// Created: 2023/02/08
/// 
/// Interaction logic for MedProcedurePage.xaml
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for MedProcedurePage.xaml
    /// </summary>
    public partial class MedProcedurePage : Page
    {
        private Animal _procedureAnimal;
        private MasterManager _manager;
        private List<ProcedureVM> _procedures;
        
        public MedProcedurePage(Animal animal, MasterManager manager)
        {
            InitializeComponent();
            _procedureAnimal = animal;
            _manager = manager;
            displayProcedureAnimalId();
            
            
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/16
        /// 
        /// Puts the columns of the procedure datagrid in the correct order if there are procedures
        /// for the animal, displays "no procedure records available" if there are no procedures for 
        /// the animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datMedProcedure.ItemsSource = null;
            try
            {
                _procedures = _manager.ProcedureManager.GetProceduresByAnimalId(_procedureAnimal.AnimalId);
            } catch(Exception ex)
            {
                PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                _procedures = new List<ProcedureVM>();
            }

            if(_procedures.Count != 0){
                datMedProcedure.ItemsSource = _procedures;
                try
                {
                    datMedProcedure.Columns.RemoveAt(2);
                    datMedProcedure.Columns.RemoveAt(2);
                    datMedProcedure.Columns.RemoveAt(2);
                    datMedProcedure.Columns.RemoveAt(3);
                    datMedProcedure.Columns[0].DisplayIndex = 2;
                    datMedProcedure.Columns[1].DisplayIndex = 2;
                    datMedProcedure.Columns[4].DisplayIndex = 1;
                }
                catch (ArgumentOutOfRangeException) { }
            }
            else
            {
                List<string> noRecordMessage = new List<string>();
                datMedProcedure.ItemsSource = noRecordMessage;
                datMedProcedure.Columns[0].Header = "No procedure records available";
            }
            
            
        }

        private void displayProcedureAnimalId()
        {
            lblProcedureAnimalId.Content = "Animal ID #" + _procedureAnimal.AnimalId;
        }

        private void btnAddMedProcedure_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditProcedurePage(_procedureAnimal, _manager));
        }

        private void btnMedProcedureCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void datMedProcedure_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcedureVM selecteProcedure = (ProcedureVM)datMedProcedure.SelectedItem;
            NavigationService.Navigate(new EditProcedurePage(selecteProcedure, _manager));
        }
    }
}
