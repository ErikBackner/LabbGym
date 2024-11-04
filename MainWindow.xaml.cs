using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LabbGym
{
    public partial class MainWindow : Window
    {
        private Booking booking;  
        private User currentUser;

        public MainWindow()
        {
            InitializeComponent();
            booking = new Booking();
            booking.AddPass(new Pass("Strength", new DateTime(2024, 10, 18, 10, 0, 0), 10));
            booking.AddPass(new Pass("Intensity", new DateTime(2024, 10, 18, 12, 0, 0), 15));
            booking.AddPass(new Pass("Yoga", new DateTime(2024, 10, 19, 9, 0, 0), 20));
            currentUser = new User("randomUser");
            PassListView.ItemsSource = booking.PassLista;
        }

        private void BookPass_Click(object sender, RoutedEventArgs e)
        {
            Pass selectedPass = (Pass)PassListView.SelectedItem;
            if (selectedPass != null)
            {
                bool success = currentUser.BookPass(booking, selectedPass); 
                MessageTextBlock.Text = success ? "Bokning lyckades!" : "Bokning misslyckades! Passet är redan bokat eller fullt.";
                PassListView.Items.Refresh();
            }
            else
            {
                MessageTextBlock.Text = "Välj ett pass att boka.";
            }
        }

        private void UnbookPass_Click(object sender, RoutedEventArgs e)
        {
            Pass selectedPass = (Pass)PassListView.SelectedItem;
            if (selectedPass != null)
            {
                bool success = currentUser.UnbookPass(booking, selectedPass); 
                MessageTextBlock.Text = success ? "Avbokning lyckades!" : "Avbokning misslyckades! Passet var inte bokat.";
                PassListView.Items.Refresh();
            }
            else
            {
                MessageTextBlock.Text = "Välj ett pass att avboka.";
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredPass = booking.PassLista.Where(p =>
                p.Workout.ToLower().Contains(searchText) ||
                p.Time.ToString("HH:mm").Contains(searchText)).ToList();
            PassListView.ItemsSource = filteredPass;
        }
    }
}