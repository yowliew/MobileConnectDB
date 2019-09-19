using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;

using Xamarin.Forms;

namespace MobileConnectDB
{
    public class AddCompanyPage : ContentPage
    {

        private readonly Entry _nameEntry ;
        private readonly Entry _addressEntry;
        private readonly Button _saveButton;

        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");

        public AddCompanyPage()
        {
            this.Title = "Add Company";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Company Name";
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(_addressEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;

        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Company>();

            var maxPK = db.Table<Company>().OrderByDescending(c => c.Id).FirstOrDefault();

            Company company = new Company()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Name = _nameEntry.Text,
                Address = _addressEntry.Text

            };
            db.Insert(company);
            await DisplayAlert(null, company.Name + " Saved","OK");
            await Navigation.PopAsync();

        }
    }
}