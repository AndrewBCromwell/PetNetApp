﻿using DataObjects;
using LogicLayer;
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

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for MedicalTreatmentPage.xaml
    /// </summary>
    public partial class MedicalTreatmentPage : Page
    {
        private MedicalRecordManager _medicalRecordManager = null;
        private List<MedicalRecordVM> _medicalRecords = null;
        private Animal _animal = null;
        public MedicalTreatmentPage(Animal animal)
        {
            InitializeComponent();
            _medicalRecordManager = new MedicalRecordManager();
            _animal = animal;
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblTreatmentAnimalName.Content = _animal.AnimalName + ": Diagnosis and Treatment";
            lblTreatmentAnimalId.Content = "Animal ID: " + _animal.AnimalId;
            refreshPage();
        }

        private void refreshPage()
        {
            stckMedicalTreatment.Children.Clear();
            try
            {
                _medicalRecords = _medicalRecordManager.RetrieveMedicalRecordDiagnosisByAnimalId(_animal.AnimalId);
                if (_medicalRecords.Count == 0)
                {
                    Grid grid = new Grid();
                    grid.Width = 350;
                    grid.Height = 500;

                    Label label = new Label();
                    label.Content = "No Diagnosis and Treatment information";
                    label.HorizontalAlignment = HorizontalAlignment.Center;

                    grid.Children.Add(label);

                    stckMedicalTreatment.Children.Add(grid);
                }
                else
                {
                    foreach (MedicalRecord medicalRecord in _medicalRecords)
                    {
                        createDiagnosisBox(medicalRecord);
                    }
                }

            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message + "\n" + ex.InnerException.Message, ButtonMode.Ok);
            }
        }

        private void createDiagnosisBox(MedicalRecord medicalRecord)
        {
            Grid grid = new Grid();
            grid.Width = 350;
            grid.Height = 530;
            grid.Margin = new Thickness(25, 0, 0, 0);

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            RowDefinition rowDef5 = new RowDefinition();
            RowDefinition rowDef6 = new RowDefinition();
            RowDefinition rowDef7 = new RowDefinition();

            grid.RowDefinitions.Add(rowDef1);
            rowDef1.Height = new GridLength(60, GridUnitType.Pixel);
            grid.RowDefinitions.Add(rowDef2);
            rowDef2.Height = new GridLength(50, GridUnitType.Pixel);
            grid.RowDefinitions.Add(rowDef3);
            rowDef3.Height = new GridLength(50, GridUnitType.Pixel);
            grid.RowDefinitions.Add(rowDef4);
            rowDef4.Height = new GridLength(35, GridUnitType.Pixel);
            grid.RowDefinitions.Add(rowDef5);
            rowDef5.Height = new GridLength(285, GridUnitType.Pixel);
            grid.RowDefinitions.Add(rowDef6);

            Border border = new Border();
            border.CornerRadius = new CornerRadius(5);
            border.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFE2E0C5");
            Grid.SetRow(border, 0);
            Grid.SetRowSpan(border, 6);

            Label lblDate = new Label();
            lblDate.HorizontalAlignment = HorizontalAlignment.Center;
            lblDate.VerticalAlignment = VerticalAlignment.Bottom;
            lblDate.Content = "Date of Diagnosis: " + medicalRecord.Date;
            lblDate.FontSize = 15;
            lblDate.Margin = new Thickness(0, 20, 0, 0);
            Grid.SetRow(lblDate, 0);

            Label lblDiagnosis = new Label();
            lblDiagnosis.HorizontalAlignment = HorizontalAlignment.Center;
            lblDiagnosis.VerticalAlignment = VerticalAlignment.Top;
            lblDiagnosis.FontSize = 20;
            lblDiagnosis.Content = medicalRecord.Diagnosis;
            Grid.SetRow(lblDiagnosis, 0);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/WpfPresentation;component/Images/PlusIcon_light.png", UriKind.Relative));

            Button btnQuarantineStatus = new Button();
            btnQuarantineStatus.Margin = new Thickness(25, 15, 15, 15);
            btnQuarantineStatus.HorizontalAlignment = HorizontalAlignment.Left;
            btnQuarantineStatus.Content = image;
            Grid.SetRow(btnQuarantineStatus, 1);

            Label lblQuarantineStatus = new Label();
            lblQuarantineStatus.Margin = new Thickness(45, 0, 0, 0);
            lblQuarantineStatus.VerticalAlignment = VerticalAlignment.Center;
            lblQuarantineStatus.Content = "Quarantine Required: " + (medicalRecord.QuarantineStatus ? "Yes" : "No");
            Grid.SetRow(lblQuarantineStatus, 1);

            Image image2 = new Image();
            image2.Source = new BitmapImage(new Uri("/WpfPresentation;component/Images/PlusIcon_light.png", UriKind.Relative));

            Button btnPrescriptions = new Button();
            btnPrescriptions.Margin = new Thickness(25, 15, 15, 15);
            btnPrescriptions.HorizontalAlignment = HorizontalAlignment.Left;
            btnPrescriptions.Content = image2;
            Grid.SetRow(btnPrescriptions, 2);

            Label lblPrescriptions = new Label();
            lblPrescriptions.Margin = new Thickness(45, 0, 0, 0);
            lblPrescriptions.VerticalAlignment = VerticalAlignment.Center;
            lblPrescriptions.Content = "Prescription(s) Required: " + (medicalRecord.PrescriptionStatus ? "Yes" : "No");
            Grid.SetRow(lblPrescriptions, 2);

            Label lblNotes = new Label();
            lblNotes.Content = "Notes:";
            lblNotes.Margin = new Thickness(21, 0, 0, 0);
            Grid.SetRow(lblNotes, 3);

            TextBlock txtBlockNotes = new TextBlock();
            txtBlockNotes.Text = medicalRecord.MedicalNotes;
            txtBlockNotes.Margin = new Thickness(21, 5, 15, 5);
            txtBlockNotes.Background = new SolidColorBrush(Colors.White);
            Grid.SetRow(txtBlockNotes, 4);

            Button btnEdit = new Button();
            btnEdit.Margin = new Thickness(75, 10, 75, 15);
            btnEdit.Content = "Edit";
            Grid.SetRow(btnEdit, 7);

            grid.Children.Add(border);
            grid.Children.Add(lblDate);
            grid.Children.Add(lblDiagnosis);
            grid.Children.Add(btnQuarantineStatus);
            grid.Children.Add(lblQuarantineStatus);
            grid.Children.Add(btnPrescriptions);
            grid.Children.Add(lblPrescriptions);
            grid.Children.Add(lblNotes);
            grid.Children.Add(txtBlockNotes);
            grid.Children.Add(btnEdit);

            btnQuarantineStatus.Click += (s, e) =>
            {

                // add Quarantine window to be opened here and remove PromptWindow

                PromptWindow.ShowPrompt("Quarantine", "TODO", ButtonMode.Ok);
            };

            btnPrescriptions.Click += (s, e) =>
            {

                // add Prescription window to be opened here and remove PromptWindow

                PromptWindow.ShowPrompt("Prescriptions", "TODO", ButtonMode.Ok);
            };

            btnEdit.Click += (s, e) =>
            {

                // add Edit window to be opened here and remove PromptWindow

                PromptWindow.ShowPrompt("Edit", "TODO", ButtonMode.Ok);
            };

            stckMedicalTreatment.Children.Add(grid);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scrollviewer.LineLeft();
                scrollviewer.LineLeft();
            }
            else
            {
                scrollviewer.LineRight();
                scrollviewer.LineRight();
            }
            e.Handled = true;
        }
    }
}
