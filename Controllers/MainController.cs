using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZakupkiParser.GosZakupkiParser;
using ZakupkiParser.Models;
using ZakupkiParser.Source;

namespace ZakupkiParser.Controllers;

[ApiController]
[Route("/api")]
public class MainController : ControllerBase
{
    private readonly PurchaseParser parser;
    private readonly ILogger<MainController> logger;
    private readonly IHttpClientFactory httpClientFactory;
    public MainController(ILogger<MainController> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;
        this.httpClientFactory = httpClientFactory;
        parser = new(
            "https://zakupki.gov.ru/epz/order/extendedsearch/results.html?searchString={regnum}&morphology=on&search-filter=Дате+размещения&pageNumber=1&sortDirection=false&recordsPerPage=_10&showLotsInfoHidden=false&sortBy=UPDATE_DATE&fz44=on&fz223=on&af=on&ca=on&pc=on&pa=on&currencyIdGeneral=-1",
            new PurchaseParserFromHtml(),
            new HtmlLoader(httpClientFactory));
    }
    [Route("/api/getpurchases")]
    [HttpPost]
    public async Task<IActionResult> GetPurchasesAsync([FromBody] RequestBody body)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var res = await parser.GetPurchasesAsync(body.purchaseId);
        logger.LogInformation(DateTime.Now + " | downloaded " + res.Count + " elements");

        return Ok(JsonConvert.SerializeObject(res));
    }
}