using CougBites.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CougBites.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}