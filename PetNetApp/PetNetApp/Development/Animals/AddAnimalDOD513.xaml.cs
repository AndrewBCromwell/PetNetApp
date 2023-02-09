// Created by Asa Armstrong
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

namespace WpfPresentation.Development.Animals
{
    public partial class AddAnimalDOD513 : Page
    {
        private DeathVM _death = new DeathVM();
        private MasterManager _masterManager = new MasterManager();
        private Animal _animal = new Animal();

        public AddAnimalDOD513(Animal animal)
        {
            _animal = animal;
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _death.DeathDate = date_DOD.SelectedDate;
                _death.DeathCause = txt_Cause.Text;
                _death.DeathNotes = txt_Notes.Text;
                _death.AnimalId = _animal.AnimalId;

                // need currently signed in user
                _death.UsersId = 100000;
                //_death.UsersId = MasterManager.User.UsersId;

                //No field for these in UI?
                _death.DeathDisposal = "UNKNOWN";
                _death.DeathDisposalDate = DateTime.Now;


                if (_death.DeathDate.Equals(null))
                {
                    throw new ApplicationException("Death Date cannot be null.");
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

                _masterManager.DeathManager.AddAnimalDOD(_death);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // needs PromptWindow.ShowPrompt(name,desc,buttonmode)
            }
        }
    }
}
