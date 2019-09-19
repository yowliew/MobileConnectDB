using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using Xamarin.Forms;

namespace MobileConnectDB
{
    public class GetAllCompanyPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");

        public GetAllCompanyPage()
        {
            var db = new SQLiteConnection(_dbPath);
            this.Title = "Companies";

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderByDescending(x => x.Name).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;

        }
    }
}