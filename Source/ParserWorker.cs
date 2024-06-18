using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ZakupkiParser.Models;
using ZakupkiParser.Source;

namespace ZakupkiParser.Source;

public class ParserWorker
{
    IParser parser;
    HtmlLoader htmlLoader;
    HttpRequestBuilder requestBuilder;

    public ParserWorker(IParser parser)
    {
        this.parser = parser;
        htmlLoader = new HtmlLoader(new HttpClient(
            new HttpClientHandler() {
                AutomaticDecompression = System.Net.DecompressionMethods.All
            }
        ));
        requestBuilder = new HttpRequestBuilder(
            "https://zakupki.gov.ru/epz/order/extendedsearch/results.html" +
            "?searchString={regnum}" +
            "&morphology=on" +
            "&search-filter=Дате+размещения" +
            "&pageNumber=1&sortDirection=false" +
            "&recordsPerPage=_10" +
            "&showLotsInfoHidden=false" +
            "&sortBy=UPDATE_DATE" +
            "&fz44=on&fz223=on&af=on&ca=on&pc=on&pa=on" +
            "&currencyIdGeneral=-1");
    }
    public async Task<List<Purchase>> GetPurchasesAsync(string regNum)
    {
        string? pageSource = await htmlLoader.GetPageAsync(requestBuilder.Create(HttpMethod.Get, regNum));
        
        HtmlParser htmlParser = new();

        IHtmlDocument document = await htmlParser.ParseDocumentAsync(pageSource);

        var res = parser.Parse(document);

        return res;
    }
}