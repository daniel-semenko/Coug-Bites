using CougBites.Models;
using CougBites.ViewModels;
using CougBites.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CougBites.Views
{
    public partial class SearchPage : ContentPage
    {
        SearchViewModel _viewModel;

        public SearchPage()
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new SearchViewModel();

            /*void OnTextChanged(object sender, EventArgs e)
            {

                SearchBar searchBar = (SearchBar)sender;
                searchBar.ItemsSource = DataService.GetSearchResults(searchBar.Text);


            }*/


        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}