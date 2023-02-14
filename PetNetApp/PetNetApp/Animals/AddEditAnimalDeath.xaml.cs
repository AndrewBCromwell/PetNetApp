﻿// Created by Asa Armstrong
// Created on 2023/02/02

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
    public partial class AddAnimalDOD513 : Page
    {
        private DeathVM _death = new DeathVM();
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private Animal _animal = new Animal();  // the currently selected animal
        private bool isEditMode = false;
        private DeathVM _oldDeathVM = new DeathVM();

        public AddAnimalDOD513(Animal animal)
        {
            _animal = animal;

            InitializeComponent();

            populateControls();


            retrieveOldDeath();
            if (!_oldDeathVM.DeathId.Equals(0))
            {
                setEditMode();
            }
        }

        private void retrieveOldDeath()
        {
            try
            {
                _oldDeathVM = _masterManager.DeathManager.RetrieveAnimalDeath(_animal);
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);
            }
        }

        private void populateControls()
        {
            txt_Name.Text = (_oldDeathVM.AnimalName == null || _oldDeathVM.AnimalName.Length == 0) ?
                                ((_animal.AnimalName == null || _animal.AnimalName.Length == 0) ? "UNKNOWN" : _animal.AnimalName) :
                                _oldDeathVM.AnimalName;
            txt_AnimalID.Text = _animal.AnimalId.Equals(0) ? (_oldDeathVM.AnimalId.Equals(0) ? "UNKNOWN" : _oldDeathVM.AnimalId.ToString()) :
                                _animal.AnimalId.ToString();
        }

        private void setEditMode()
        {
            // _death = _oldDeathVM; // just creates a pointer instead of a new DeathVM
            _death.DeathDate = _oldDeathVM.DeathDate;
            _death.AnimalBreed = _oldDeathVM.AnimalBreed;
            _death.AnimalGender = _oldDeathVM.AnimalGender;
            _death.AnimalId = _oldDeathVM.AnimalId;
            _death.AnimalName = _oldDeathVM.AnimalName;
            _death.AnimalType = _oldDeathVM.AnimalType;
            _death.DeathCause = _oldDeathVM.DeathCause;
            _death.DeathDisposal = _oldDeathVM.DeathDisposal;
            _death.DeathDisposalDate = _oldDeathVM.DeathDisposalDate;
            _death.DeathId = _oldDeathVM.DeathId;
            _death.DeathNotes = _oldDeathVM.DeathNotes;

            populateControls();
            isEditMode = true;
            lbl_Title.Content = "Edit Animal Death Record";
            txt_Cause.Text = _oldDeathVM.DeathCause;
            date_DOD.SelectedDate = _oldDeathVM.DeathDate;
            txt_Notes.Text = _oldDeathVM.DeathNotes;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _death.DeathDate = date_DOD.SelectedDate.Value;
                _death.DeathCause = txt_Cause.Text;
                _death.DeathNotes = txt_Notes.Text;
                _death.AnimalId = _animal.AnimalId;

                _death.UsersId = _masterManager.User.UsersId;

                if (_death.DeathDate.Equals(null))
                {
                    throw new ApplicationException("Death Date cannot be empty.");
                }

                if (_death.DeathCause.Equals(null) || _death.DeathCause.Length < 1 || _death.DeathCause.Length > 100)
                {
                    throw new ApplicationException("Death Cause must be between 1 and 100 characters.");
                }

                if (_death.DeathNotes.Length > 500)
                {
                    throw new ApplicationException("Death Notes cannot be greater than 500 characters.");
                }

                if (_death.DeathDate > DateTime.Now)
                {
                    throw new ApplicationException("Death Date cannot be in the future.");
                }

                bool success = false;
                if (!isEditMode) // if not in edit mode, create new death record
                {
                    //No field for these in UI?
                    _death.DeathDisposal = "UNKNOWN";
                    _death.DeathDisposalDate = DateTime.Now;
                    success = _masterManager.DeathManager.AddAnimalDeath(_death);
                }
                else if (isEditMode) // if in edit mode, update existing death record
                {

                    success = _masterManager.DeathManager.EditAnimalDeath(_death, _oldDeathVM);
                }

                if (success)
                {
                    PromptWindow.ShowPrompt("Congratulations", isEditMode ? "Death Record Edited" : "Death Record Created", ButtonMode.Ok);
                }
                else
                {
                    PromptWindow.ShowPrompt("Error", isEditMode ? "Death Record Not Edited" : "Death Record Not Created", ButtonMode.Ok);
                }

                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    retrieveOldDeath();
                    setEditMode();
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (PromptWindow.ShowPrompt("Confirm Cancel", "Cancel and return?", ButtonMode.YesNo).Equals(PromptSelection.Yes))
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    // return to a base page
                }
            }
        }
    }
}
