using System.ComponentModel.DataAnnotations;

namespace ZakupkiParser.Models;

public class RequestBody
{
    [Required(ErrorMessage = "PurchaseID is required")]
    [RegularExpression(@"[0-9]{1,20}")]
    [MinLength(1, ErrorMessage = "PurchaseID length must be more then 0")]
    [MaxLength(30, ErrorMessage = "PurchaseID length must be less then 30")]
    public string purchaseId { get; set;}
}