namespace TauschbarAPI.Models.DTOs;

public class OfferCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public OfferType Type { get; set; }
    public Guid UserId { get; set; }  // wird beim Auth später automatisch gesetzt
}