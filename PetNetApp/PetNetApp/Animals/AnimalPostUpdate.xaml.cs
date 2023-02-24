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
    /// Interaction logic for AnimalPostUpdate.xaml
    /// </summary>
    public partial class AnimalPostUpdate : Page
    {
        private int _animalId = 0;
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        public AnimalPostUpdate(int animalId)
        {
            InitializeComponent();
            _animalId = animalId;
        }

        private void btnPostComment_Click(object sender, RoutedEventArgs e)
        {
            SaveAnimalUpdateToDataBase();
        }

        private void SaveAnimalUpdateToDataBase()
        {
            string animalRecordNotes = "";
            if (tbxAnimalPostUpdate.Text == "" || tbxAnimalPostUpdate.Text == null)
            {
                PromptWindow.ShowPrompt("Error", "Please enter your note first.");
            }
            else
            {
                animalRecordNotes = tbxAnimalPostUpdate.Text;
                PromptSelection dialogResult = PromptWindow.ShowPrompt("Animal Update Note", "Do you want to record this note?", ButtonMode.YesNo);
                if (dialogResult == PromptSelection.Yes)
                {
                    try
                    {
                        if (_masterManager.AnimalUpdatesManager.AddAnimalUpdatesByAnimalId(_animalId, animalRecordNotes))
                        {
                            tbxAnimalPostUpdate.Text = "";
                            LoadAnimalNote();
                        }
                    }
                    catch (Exception ex)
                    {
                        PromptWindow.ShowPrompt("Error", ex.Message);
                    }
                }
                else
                {
                    tbxAnimalPostUpdate.Text = "";
                }
            }
        }

        private string LoadAnimalNote()
        {
            string result = "";

            try
            {
                result =_masterManager.AnimalUpdatesManager.RetrieveAnimalUpdatesByAnimal(_animalId);
                if (result != "")
                {
                    tbkAnimalNote.Text = result;
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
            }

            return result;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAnimalNote();
        }

        private void tbxAnimalPostUpdate_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SaveAnimalUpdateToDataBase();
            }
        }
    }
}
