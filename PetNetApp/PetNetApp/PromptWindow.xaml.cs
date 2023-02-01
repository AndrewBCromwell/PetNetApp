
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

namespace WpfPresentation
{
    /// <summary>
    /// Stephen Jaurigue
    /// Created: 2023/01/31
    /// 
    /// Internal class for the Prompt Class
    /// </summary>
    public partial class PromptWindow : Window
    {
        public string PromptText { get; set; } = "";
        public ButtonMode ButtonMode { get; set; }
        public PromptSelection PromptSelection { get; private set; }

        public PromptWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch(ButtonMode)
            {
                case ButtonMode.YesNo:
                    btn1.Content = "Yes";
                    btn1.Style = (Style)Application.Current.Resources["rsrcDefaultButton"];
                    btn2.Content = "No";
                    btn2.Style = (Style)Application.Current.Resources["rsrcSafeButton"];
                    PromptSelection = PromptSelection.No;
                    break;
                case ButtonMode.DeleteCancel:
                    btn1.Content = "Delete";
                    btn1.Style = (Style)Application.Current.Resources["rsrcWarningButton"];
                    btn2.Content = "Cancel";
                    btn2.Style = (Style)Application.Current.Resources["rsrcSafeButton"];
                    PromptSelection = PromptSelection.Cancel;
                    break;
                case ButtonMode.SaveCancel:
                    btn1.Content = "Save";
                    btn1.Style = (Style)Application.Current.Resources["rsrcDefaultButton"];
                    btn2.Content = "Cancel";
                    btn2.Style = (Style)Application.Current.Resources["rsrcSafeButton"];
                    PromptSelection = PromptSelection.Cancel;
                    break;
                case ButtonMode.Ok:
                    btn1.Content = "Ok";
                    btn1.Style = (Style)Application.Current.Resources["rsrcDefaultButton"];
                    Grid.SetColumnSpan(btn1, 2);
                    btn2.Visibility = Visibility.Hidden;
                    PromptSelection = PromptSelection.Ok;
                    break;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            switch (ButtonMode)
            {
                case ButtonMode.YesNo:
                    PromptSelection = PromptSelection.Yes;
                    break;
                case ButtonMode.SaveCancel:
                    PromptSelection = PromptSelection.Save;
                    break;
                case ButtonMode.Ok:
                    PromptSelection = PromptSelection.Ok;
                    break;
                case ButtonMode.DeleteCancel:
                    PromptSelection = PromptSelection.Delete;
                    break;
            }
            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            switch (ButtonMode)
            {
                case ButtonMode.YesNo:
                    PromptSelection = PromptSelection.No;
                    break;
                case ButtonMode.SaveCancel:
                case ButtonMode.DeleteCancel:
                    PromptSelection = PromptSelection.Cancel;
                    break;
                default:
                    PromptSelection = PromptSelection.Cancel;
                    break;
            }
            this.Close();
        }
    }
    /// <summary>
    /// Stephen Jaurigue
    /// Created: 2023/01/31
    /// 
    /// This is a custom messagebox class styled for our application
    /// </summary>
    public class Prompt
    {
        private PromptWindow _promptWindow = null;
        public PromptSelection PromptSelection
        {
            get
            {
                return _promptWindow.PromptSelection;
            }
        }

        public Prompt(string title, string prompt, ButtonMode buttonMode = ButtonMode.Ok)
        {
            _promptWindow = new PromptWindow()
            {
                PromptText = prompt,
                Title = title,
                ButtonMode = buttonMode
            };
        }
        
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/01/31
        /// 
        /// Displays the Prompt and returns a PromptSelection
        /// </summary>
        public PromptSelection Show()
        {
            _promptWindow.ShowDialog();
            return _promptWindow.PromptSelection;
        }
    }

    public enum ButtonMode
    {
        YesNo,
        DeleteCancel,
        SaveCancel,
        Ok
    }
    public enum PromptSelection
    {
        Yes,
        No,
        Delete,
        Save,
        Cancel,
        Ok
    }
}
