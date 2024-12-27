using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.MAUI.Model;

namespace Contact.MAUI.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var contacts = new ObservableCollection<Model.Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private async void ListContacts_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            Console.WriteLine(nameof(EditContactPage));
            try
            {
                await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Model.Contact)listContacts.SelectedItem).ContactId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Navigation failed: {ex.Message}");
            }
        }
    }

    private void ListContacts_OnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void BtnAdd_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void MenuItem_OnClicked(object? sender, EventArgs e)
    {
        var menuItem = (MenuItem)sender;
        var contact = (Model.Contact)menuItem.BindingContext;
        // Handle deletion logic here
        DisplayAlert("Delete", $"{contact.Name} Is Deleted", "OK");
        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Model.Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
      var contacts =   new ObservableCollection<Model.Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
      listContacts.ItemsSource = contacts;
    }
}