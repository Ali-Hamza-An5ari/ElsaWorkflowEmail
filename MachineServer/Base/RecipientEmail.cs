namespace MachineServer.Base;

public class RecipientEmail
{
    public string Name { get; set; }
    public string EmailAddress { get; set; }

    public RecipientEmail(string Name, string EmailAddress)
    {
        this.Name = Name;
        this.EmailAddress = EmailAddress;
    }
}