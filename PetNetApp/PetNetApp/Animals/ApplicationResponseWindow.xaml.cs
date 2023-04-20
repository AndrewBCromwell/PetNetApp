/// <summary>
/// Molly Meister
/// Created: 04/14/2023
/// 
/// ApplicationResponseWindow class
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
using System.Windows.Shapes;
using DataObjects;

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for ApplicationResponseWindow.xaml
    /// </summary>
    public partial class ApplicationResponseWindow : Window
    {
        private AdoptionApplicationVM _application = null;

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Custom constructor for the ApplicationResponseWindow that requires an AdoptionApplicationVM object.
        /// Initalizes the _application.
        /// </summary>
        ///
        /// <param name="application"></param>
        public ApplicationResponseWindow(AdoptionApplicationVM application)
        {
            _application = application;
            InitializeComponent();
        }

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Close button click that closes the ApplicationResponseWindow.
        /// </summary>
        ///
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseWindowX_Click(object sender, RoutedEventArgs e)
        {
            PromptSelection result = PromptWindow.ShowPrompt("Confirm", "Are you sure you want to cancel? \n\n Your response will not be saved.", ButtonMode.YesNo);
            if (result == PromptSelection.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Logic for ApplicationResponseWindow load.
        /// Fills the frmApplicationResponse content to a new AdoptionApplicationResposne page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frmApplicationResponse.Content = new AdoptionApplicationResponse(_application);
        }
    }
}
