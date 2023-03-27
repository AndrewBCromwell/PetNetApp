﻿/// <summary>
/// Ethan Kline
/// Created: 2023/03/3
/// 
/// Interaction logic for Medical_Notes.xaml
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
    /// Interaction logic for Medical_Notes.xaml
    /// </summary>
    public partial class Medical_Notes : Page
    {
        private List<MedicalRecordVM> _MedicalRecords;
        private Animal _medicalnoteAnimal;
        private MasterManager _manager;

        /// <summary>
        /// Ethan Kline
        /// Created: 2023/03/3
        /// 
        /// Constructor that is used when a new medicalnote is being added
        /// </summary>
        public Medical_Notes(Animal animal, MasterManager manager)
        {
            InitializeComponent();
            _medicalnoteAnimal = animal;
            _manager = manager;
        }
        /// <summary>
        /// Ethan Kline
        /// Created: 2023/03/3
        /// 
        /// Puts the columns of the medical notes datagrid  in the correct order by animalid
        /// for the animal, displays "No Notes Available" if there are no medicalnotes for 
        /// the animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datMedicalRecordGrid.ItemsSource = null;

            try
            {
                _MedicalRecords = _manager.MedicalRecordManager.SelectMedicalRecordByAnimal(_medicalnoteAnimal.AnimalId);
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
            }

            if (_MedicalRecords.Count != 0)
            {
                datMedicalRecordGrid.ItemsSource = _MedicalRecords;

                try
                {
                    datMedicalRecordGrid.Columns.RemoveAt(0);
                    datMedicalRecordGrid.Columns.RemoveAt(0);
                    datMedicalRecordGrid.Columns.RemoveAt(0);
                    datMedicalRecordGrid.Columns.RemoveAt(0);
                    datMedicalRecordGrid.Columns.RemoveAt(0);
                    datMedicalRecordGrid.Columns.RemoveAt(0);
                    datMedicalRecordGrid.Columns.RemoveAt(0);
                    datMedicalRecordGrid.Columns.RemoveAt(2);
                    datMedicalRecordGrid.Columns.RemoveAt(2);
                    datMedicalRecordGrid.Columns.RemoveAt(2);
                    datMedicalRecordGrid.Columns.RemoveAt(2);
                    datMedicalRecordGrid.Columns.RemoveAt(2);
                    datMedicalRecordGrid.Columns.RemoveAt(2);
                    datMedicalRecordGrid.Columns.RemoveAt(2);
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                }
            }
            else
            {
                List<string> noRecordMessage = new List<string>();
                datMedicalRecordGrid.ItemsSource = noRecordMessage;
                datMedicalRecordGrid.Columns[0].Header = "No Notes Available";
            }
        }

        private void datMedicalRecordGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var MedicalRecordVM = (MedicalRecordVM)datMedicalRecordGrid.SelectedItem;
            NavigationService.Navigate(new Edit_Medical_Notes(MedicalRecordVM, _manager));
        }

        private void btn_upload_file_Click(object sender, RoutedEventArgs e)
        {
            //var Edit_Medical_Notes = new Edit_Medical_Notes();
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (datMedicalRecordGrid.SelectedItems.Count == 0)
            {
                return;
            }
            var MedicalRecordVM = (MedicalRecordVM)datMedicalRecordGrid.SelectedItem;
            NavigationService.Navigate(new Edit_Medical_Notes(MedicalRecordVM, _manager));
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Edit_Medical_Notes(_medicalnoteAnimal, _manager));
        }
    }
}