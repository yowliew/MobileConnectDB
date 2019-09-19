using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileConnectDB
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Company";
            button.Clicked += Button_clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Get All Companies";
            button.Clicked += Button_Get_clicked;
            stackLayout.Children.Add(button);


            button = new Button();
            button.Text = "Edit Companies";
            button.Clicked += Button_Edit_clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete Companies";
            button.Clicked += Button_Delete_clicked;
            stackLayout.Children.Add(button);


            Content = stackLayout;

        }

        private async void Button_Delete_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompanyPage());

        }


        private async void Button_Edit_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPage());

        }


        private async void Button_Get_clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new GetAllCompanyPage());
            
        }

        private async void Button_clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new AddCompanyPage());
        }
    }
}