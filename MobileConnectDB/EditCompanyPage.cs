using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using Xamarin.Forms;

namespace MobileConnectDB
{
    public class EditCompanyPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Button _buttonEdit;

        Company _company = new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");


        public EditCompanyPage()
        {
            this.Title = "Edit Company";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderByDescending(x => x.Name).ToList();
            _listView.ItemSelected += _listviewItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Placeholder = "Name";
//            _nameEntry.Keyboard = Keyboard.Text;
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Placeholder = "Address";
            _addressEntry.Keyboard = Keyboard.Text;
            stackLayout.Children.Add(_addressEntry);

            _buttonEdit = new Button();
            _buttonEdit.Text = "Update";
            _buttonEdit.Clicked += _buttonClick;
            stackLayout.Children.Add(_buttonEdit);

            Content = stackLayout;

        }

        private async void _buttonClick(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            Company company = new Company()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Address = _addressEntry.Text
            };

            db.Update(company);
            await Navigation.PopAsync();
        }

        private void _listviewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;
            _idEntry.Text = _company.Id.ToString();
            _nameEntry.Text = _company.Name;
            _addressEntry.Text = _company.Address;


        }
    }
}