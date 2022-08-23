namespace ApplicationCore.Models;

public class PurchaseModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PurchaseId { get; set; }
    public decimal TotalPrice { get; set; }
    public int MovieId { get; set; }
}
