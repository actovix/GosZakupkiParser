using AngleSharp.Html.Dom;
using ZakupkiParser.Models;

namespace ZakupkiParser.Source;

public interface IParser
{
    public List<Purchase> Parse(IHtmlDocument htmlDocument);
}