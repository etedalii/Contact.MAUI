
using Contact.MAUI.Model;

namespace Contact.MAUI.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Model.Contact contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            ContactCtrl.Name = contact.Name;
            ContactCtrl.Phone = contact.Phone;
            ContactCtrl.Email = contact.Email;
            ContactCtrl.Address = contact.Address;
        }
    }
    private void ContactCtrl_OnOnSuccess(object? sender, string e)
    {
        contact.Address = ContactCtrl.Address;
        contact.Name = ContactCtrl.Name;
        contact.Email = ContactCtrl.Email;
        contact.Phone = ContactCtrl.Phone;
        
        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
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