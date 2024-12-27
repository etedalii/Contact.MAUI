using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.MAUI.Model;

namespace Contact.MAUI.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
    {
        InitializeComponent();
    }
    
    private void ContactCtrl_OnOnSuccess(object? sender, string e)
    {
        ContactRepository.AddContact(new Model.Contact()
        {
            Name = ContactCtrl.Name,
            Phone = ContactCtrl.Phone,
            Address = ContactCtrl.Address
            ,Email = ContactCtrl.Email
        });
    }

    private void ContactCtrl_OnOnCancel(object? sender, string e)
    {
        Shell.Current.Navigation.PopAsync();
    }

    private void ContactCtrl_OnOnError(object? sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}