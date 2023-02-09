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

namespace WpfPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for AnimalListUserControl.xaml
    /// </summary>
    public partial class AnimalListUserControl : UserControl
    {
        public AnimalListUserControl()
        {
            InitializeComponent();
        }

        private void btnViewAnimalProfile_Click(object sender, RoutedEventArgs e)
        {
            // placeholder click for View Animal Profile, delete when ready
            
            PromptWindow.ShowPrompt("Animal Profile", "Animal Profile Goes Here");
            
        }
    }
}
