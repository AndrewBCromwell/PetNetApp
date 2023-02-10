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

namespace WpfPresentation.Development.Animals
{
    /// <summary>
    /// Interaction logic for EditProcedurePage.xaml
    /// </summary>
    public partial class EditProcedurePage : Page
    {
        private Animal _medProcedureAnimal;
        private int _medicalRecordId;
        private MedicalRecordManager _medicalRecordManager;
        private ProcedureManager _procedureManager;
        private bool _forAdd;

        private int userId = 100000; // This should be related to the logedin user, but login is not available yet, so I am using this to test my code. -Andy 
        
        public EditProcedurePage(Animal animal)
        {
            InitializeComponent();
            _forAdd = true;
            _medProcedureAnimal = animal;
            _medicalRecordManager = new MedicalRecordManager();
            _procedureManager = new ProcedureManager();
            lblEditProcedure.Content = "Add Procedure";
            dateProcedurePerformed.DisplayDateEnd = DateTime.Today;
        }

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

            PromptSelection selection = PromptWindow.ShowPrompt("Verify Input", "Verify that the information you entered is correct.", ButtonMode.SaveCancel);
            if(selection == PromptSelection.Cancel)
            {
                return;
            }

            Procedure procedure = new Procedure();
            if (_forAdd)
            {
                try
                {
                    procedure.MedicalRecordId = _medicalRecordManager.getLastMedicalRecordIdByAnimalId(_medProcedureAnimal.AnimalId);
                } 
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                    return;
                }
            }
            procedure.UserId = userId;
            procedure.ProcedureName = txtProcedureName.Text;
            procedure.ProcedureDate = (DateTime)dateProcedurePerformed.SelectedDate;
            procedure.MedictationsAdministered = txtProcedureMedsAdministered.Text;
            procedure.ProcedureNotes = txtProcedureNotes.Text;
            if (_forAdd)
            {
                try
                {
                    bool success = _procedureManager.AddProcedureByMedicalRecordId(procedure, procedure.MedicalRecordId);
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
