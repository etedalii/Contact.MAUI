namespace Contact.MAUI.Model;

public static class ContactRepository
{
    private static List<Contact> _contacts =
    [
        new Contact() { ContactId = 1, Name = "John Doe", Email = "john.doe@gmail.com" },
        new Contact() { ContactId = 2, Name = "John Smith", Email = "john.smith@gmail.com" },
        new Contact() { ContactId = 3, Name = "Michael Johnson", Email = "michael.johnson@gmail.com" },
        new Contact() { ContactId = 4, Name = "Emily Davis", Email = "emily.davis@gmail.com" },
        new Contact() { ContactId = 5, Name = "David Wilson", Email = "david.wilson@gmail.com" },
        new Contact() { ContactId = 6, Name = "Sophia Brown", Email = "sophia.brown@gmail.com" },
        new Contact() { ContactId = 7, Name = "James Taylor", Email = "james.taylor@gmail.com" }
    ];
    
    public static IEnumerable<Contact> GetContacts() => _contacts;
    
    public static Contact GetContactById(int id) => _contacts.FirstOrDefault(x => x.ContactId == id);

    public static void UpdateContact(int id , Contact contact)
    {
        if (id != contact.ContactId)
        {
            return;
        }
        var contactToUpdate = GetContactById(id);
        if (contactToUpdate != null)
        {
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Address = contact.Address;
        }
    }
    
    public static void AddContact( Contact contact)
    {
        var maxId = _contacts.Max(x => x.ContactId);
        contact.ContactId = maxId + 1;
        _contacts.Add(contact);
    }
    
    public static void DeleteContact(int contactId)
    {
        _contacts.RemoveAll(x => x.ContactId == contactId);
    }

    public static List<Contact> SearchContacts(string query)
    {
        var contacts = _contacts.Where(x =>
                (x.Name?.Contains(query) ?? false) ||
                (x.Email?.Contains(query) ?? false) ||
                (x.Phone?.Contains(query) ?? false) ||
                (x.Address?.Contains(query) ?? false))
            .ToList();
        
        return contacts;
    }
}