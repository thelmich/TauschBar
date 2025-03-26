using TauschbarAPI.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Offer> Offers { get; set; } = new List<Offer>();
}