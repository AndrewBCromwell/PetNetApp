/// <summary>
/// Andrew Cromwell
/// Created: 2023/02/08
/// 
/// Interaction logic for EditProcedurePage.xaml
/// </summary>

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

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for EditProcedurePage.xaml
    /// </summary>
    public partial class EditProcedurePage : Page
    {
        private Animal _medProcedureAnimal;
        private MasterManager _manager;
        private bool _forAdd;
        private ProcedureVM _oldProcedure;

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/08
        /// 
        /// Constructor that is used when a new procedure is being added
        /// </summary>
        /// <param name="animal">the animal that recieved the procedure</param>
        /// <param name="manager">the MasterManager being used through out the program</param>
        public EditProcedurePage(Animal animal, MasterManager manager)
        {
            InitializeComponent();
            _forAdd = true;
            _medProcedureAnimal = animal;
            _manager = manager;            
            lblEditProcedure.Content = "Add Procedure";
            dateProcedurePerformed.DisplayDateEnd = DateTime.Today;

            _manager.User = new UsersVM() { UsersId = 100000 }; // for testing without login
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/16
        /// 
        /// Constructor that is used when a procedure is being edited
        /// </summary>
        /// <param name="oldProcedure">the procedure that will be overwriten</param>
        /// <param name="manager">the MasterManager being used through out the program</param>
        public EditProcedurePage(ProcedureVM oldProcedure, MasterManager manager)
        {
            InitializeComponent();
            _forAdd = false;
            _oldProcedure = oldProcedure;
            _manager = manager;
            dateProcedurePerformed.DisplayDateEnd = DateTime.Today;
            txtProcedureName.Text = _oldProcedure.ProcedureName;
            dateProcedurePerformed.SelectedDate = _oldProcedure.ProcedureDate;
            txtProcedureMedsAdministered.Text = _oldProcedure.MedicationsAdministered;
            txtProcedureNotes.Text = _oldProcedure.ProcedureNotes;

            _manager.User = new UsersVM() { UsersId = 100000 }; // for testing without login
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/08
        /// 
        /// When the save buttton is clicked, the input on the edit procedure page is cheked,
        /// and if it is acceptable it is saved. If it is a new a new procedure is being added,
        /// the medical record id of the animal's last medical record is used.
        /// </summary>
        /// 
        /// <remarks>
        /// Andrew Cromwell
        /// Updated: 2023/02/16 
        /// Added logic to handle editing an existing procedure record
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedProcedureEditSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtProcedureName.Text == null || txtProcedureName.Text == "")
            {
                PromptWindow.ShowPrompt("Missing Procedure Name", "You need to enter a procedure name.", ButtonMode.Ok);
                txtProcedureName.Focus();
                return;
            }

            if(dateProcedurePerformed.SelectedDate == null)
            {
                PromptWindow.ShowPrompt("Missing Procedure Date", "You need to select the date the procedure was performed.", ButtonMode.Ok);
                dateProcedurePerformed.Focus();
                return;
            }

            string prompt = "Verify that the information you entered is correct.";
            if (!_forAdd)
            {
                prompt += "\nThis will overwrite the existing procedure information";
            }
            PromptSelection selection = PromptWindow.ShowPrompt("Verify Input", prompt, ButtonMode.SaveCancel);
            if(selection == PromptSelection.Cancel)
            {
                return;
            }

            Procedure procedure = new Procedure();
            if (_forAdd)
            {
                try
                {
                    procedure.MedicalRecordId = _manager.MedicalRecordManager.RetrieveLastMedicalRecordIdByAnimalId(_medProcedureAnimal.AnimalId);
                } 
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                    return;
                }
            }
            else
            {
                procedure.ProcedureId = _oldProcedure.ProcedureId;
                procedure.MedicalRecordId = _oldProcedure.MedicalRecordId;
            }
            procedure.UserId = _manager.User.UsersId;
            procedure.ProcedureName = txtProcedureName.Text;
            procedure.ProcedureDate = (DateTime)dateProcedurePerformed.SelectedDate;
            procedure.MedicationsAdministered = txtProcedureMedsAdministered.Text;
            procedure.ProcedureNotes = txtProcedureNotes.Text;
            if (_forAdd)
            {
                try
                {
                    bool success = _manager.ProcedureManager.AddProcedureByMedicalRecordId(procedure, procedure.MedicalRecordId);
                    if (success)
                    {
                        PromptWindow.ShowPrompt("Success", "The procedure was saved.", ButtonMode.Ok);
                        NavigationService.GoBack();
                    }
                    else
                    {
                        PromptWindow.ShowPrompt("Failure", "The procedure was not saved.", ButtonMode.Ok);
                        return;
                    }
                } 
                catch(Exception ex)
                {
                    PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                    return;
                }                
            }
            else
            {
                try
                {
                    bool success = _manager.ProcedureManager.EditProcedureByProcedureId(procedure, _oldProcedure);
                    if (success)
                    {
                        PromptWindow.ShowPrompt("Success", "The procedure was saved.", ButtonMode.Ok);
                        NavigationService.GoBack();
                    }
                    else
                    {
                        PromptWindow.ShowPrompt("Failure", "The procedure was not saved.", ButtonMode.Ok);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                    return;
                }
            }
            
        }

        private void btnMedProcedureEditCancel_Click(object sender, RoutedEventArgs e)
        {
            PromptSelection selection = PromptWindow.ShowPrompt("Really Cancel?", "Do you really want to cancel? The data you entered will not be saved.", ButtonMode.YesNo);
            if(selection == PromptSelection.Yes)
            {
                NavigationService.GoBack();
            }
            
        }
    }
}
