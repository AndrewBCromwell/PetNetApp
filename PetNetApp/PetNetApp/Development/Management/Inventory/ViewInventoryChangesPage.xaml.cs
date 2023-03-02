﻿using System;
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
using LogicLayer;
using DataObjects;

namespace WpfPresentation.Development.Management.Inventory
{
    /// <summary>
    /// Interaction logic for ViewInventoryChangesPage.xaml
    /// </summary>
    public partial class ViewInventoryChangesPage : Page
    {
        MasterManager _manager;
        List<ShelterItemTransactionVM> _shelterItemTransactions;
        private string _genericTransactionTag = "[user] checked[in/out] [quantity] units of [item] on [date]";

        public ViewInventoryChangesPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            stpInventroyItemTransactionList.Children.Clear();
            _shelterItemTransactions = _manager.ShelterItemTransactionManager.RetrieveInventoryTransactionByShelterId(55);
            int index = 0;
            if(_shelterItemTransactions.Count != 0)
            {
                foreach(ShelterItemTransactionVM transaction in _shelterItemTransactions)
                {
                    DisplayInventoryChangeRecord(transaction, index);
                    index++;
                }
            }
            else
            {
                Label lblNoTransactions = new Label();
                lblNoTransactions.VerticalContentAlignment = VerticalAlignment.Center;
                lblNoTransactions.HorizontalContentAlignment = HorizontalAlignment.Center;
                lblNoTransactions.FontSize = 20;
                lblNoTransactions.Content = "no changes have been made in the past month";
                stpInventroyItemTransactionList.Children.Add(lblNoTransactions);                
            }
            
        }

        private void DisplayInventoryChangeRecord(ShelterItemTransactionVM transaction, int index)
        {
            Label lblTransaction = new Label();

            string transactionTag;
            transactionTag = transaction.GivenName + " " + transaction.FamilyName + " ";
            if(transaction.InventoryChangeReasonId.ToLower() == "check-in")
            {
                transactionTag = transactionTag + "checked-in ";
            }
            else
            {
                transactionTag = transactionTag + "checked-out ";
            }
            if (Math.Abs(transaction.QuantityIncrement) == 1)
            {
                transactionTag = transactionTag + Math.Abs(transaction.QuantityIncrement) + " unit ";
            }
            else
            {
                transactionTag = transactionTag + Math.Abs(transaction.QuantityIncrement) + " units ";
            }
            transactionTag = transactionTag + "of " + transaction.ItemId + " on " + transaction.DateChanged.Date + ".";
            lblTransaction.Content = transactionTag;

            var bc = new BrushConverter();
            if (index % 2 == 0)
            {                
                lblTransaction.Background = (Brush)bc.ConvertFrom("#3D8361");
            }
            else
            {
                lblTransaction.Background = (Brush)bc.ConvertFrom("#D6CDA4");
            }

            lblTransaction.VerticalContentAlignment = VerticalAlignment.Center;
            lblTransaction.FontSize = 20;
            lblTransaction.Foreground = (Brush)bc.ConvertFrom("#000000");
            lblTransaction.Padding = new Thickness(50, 0, 0, 0);
            lblTransaction.Height = 50;

            stpInventroyItemTransactionList.Children.Add(lblTransaction);
        }
    }
}
