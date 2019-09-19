using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;

using Xamarin.Forms;

namespace MobileConnectDB
{
    public class DeleteCompanyPage : ContentPage
    {

        private ListView _listView;
        private Button _button;

        Company _company = new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");

        public DeleteCompanyPage()
        {
            this.Title = "Delete Company";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderByDescending(x => x.Name).ToList();
            _listView.ItemSelected += _listviewItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete Record";
            _button.Clicked += _button_Click;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void _button_Click(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            db.Table<Company>().Delete(x => x.Id == _company.Id);

            await DisplayAlert(null, _company.Name + " Deleted", "OK");

            await Navigation.PopAsync();
        }

        private void _listviewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;

        }
    }
}