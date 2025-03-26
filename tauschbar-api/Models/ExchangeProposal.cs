public class ExchangeProposal
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OfferedById { get; set; }
    public Guid TargetOfferId { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Accepted { get; set; } = false;
}