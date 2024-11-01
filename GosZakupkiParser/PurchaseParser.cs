using AngleSharp.Html.Parser;
using ZakupkiParser.Models;
using ZakupkiParser.Source;

namespace ZakupkiParser.GosZakupkiParser;

public class PurchaseParser
{

    
    private readonly PurchaseParserFromHtml purchaseParserFromHtml;
    private readonly IHtmlLoader htmlLoader;
    private readonly string url;
    public PurchaseParser(string url, PurchaseParserFromHtml purchaseParserFromHtml, IHtmlLoader htmlLoader)
    {
        this.url = url;
        this.htmlLoader = htmlLoader;
        this.purchaseParserFromHtml = purchaseParserFromHtml;
    }
    public async Task<List<Purchase>> GetPurchasesAsync(string id)
    {
        List<Purchase> purchaseList = [];
        var source = await htmlLoader.GetPageByIdAsync(url, id);

        var zhopa = "";

        if (string.IsNullOrEmpty(source))
                return purchaseList;

        HtmlParser htmlParser = new();
        var res = await htmlParser.ParseDocumentAsync(source); 

        if(res is null)
            return purchaseList;

        purchaseList = purchaseParserFromHtml.Parse(res);

        return purchaseList;
    }
}