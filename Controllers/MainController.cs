using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZakupkiParser.Source;
using ZakupkiParser.Models;

namespace ZakupkiParser.Controllers;

[ApiController]
[Route("/api")]
public class MainController : ControllerBase
{
    ParserWorker worker = new ParserWorker(new PurchaseParser());
    [Route("/api/get")]
    [HttpPost]
    public async Task<IActionResult> GetPurchas([FromBody] RequestBody body)
    {
        var res = await worker.GetPurchasesAsync(body.purchaseId);
        return Ok(JsonConvert.SerializeObject(res));
    }
}