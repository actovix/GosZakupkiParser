namespace ZakupkiParser.Models;

public class Purchase
{
    public string RegNum { get; set; } = "";
    public decimal Price { get; set; }
    public string PurchaseDetails { get; set; } = "";
    public string Customer { get; set; } = "";
    public string TargetСustomer { get; set; } = "";
    public string Status { get; set; } = "";
    public DateOnly PublicationDate { get; set; }
    public DateOnly UpdateDate { get; set; }
    public DateOnly DeadLine { get; set; }
    public string PurchaseCardLink { get; set; } = "";
}