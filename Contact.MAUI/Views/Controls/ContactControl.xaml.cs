using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.MAUI.Views.Controls;

public partial class ContactControl : ContentView
{
    public string Name
    {
        get
        {
            return EntryName.Text;
        }
        set
        {
            EntryName.Text = value;
        }
    }
    public string Email
    {
        get
        {
            return EntryEmail.Text;
        }
        set
        {
            EntryEmail.Text = value;
        }
    }
    public string Address
    {
        get
        {
            return EntryAddress.Text;
        }
        set
        {
            EntryAddress.Text = value;
        }
    }
    public string Phone
    {
        get
        {
            return EntryPhone.Text;
        }
        set
        {
            EntryPhone.Text = value;
        }
    }

    public event EventHandler<string> OnError;
    public event EventHandler<string> OnSuccess; 
    public event EventHandler<string> OnCancel;
    public ContactControl()
    {
        InitializeComponent();
    }

    private void BtnUpdate_OnClicked(object? sender, EventArgs e)
    {
        if (NameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required");
            return;
        }

        if (EmailValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Email is required");
            return;
        }
        
        OnSuccess?.Invoke(sender, "Success");
    }

    private void BtnCancel_OnClicked(object? sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, "Cancel");
    }
}