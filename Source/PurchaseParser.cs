using AngleSharp.Browser;
using AngleSharp.Dom;
using AngleSharp.Dom.Events;
using AngleSharp.Html.Dom;
using AngleSharp.Text;
using ZakupkiParser.Models;
using ZakupkiParser.Source;

namespace ZakupkiParser.Source;

public class PurchaseParser : IParser
{
    public List<Purchase> Parse(IHtmlDocument htmlDocument)
    {
        List<Purchase> purchaseList = [];
        var items = htmlDocument.QuerySelectorAll(".row.no-gutters.registry-entry__form.mr-0");

        Purchase purchase;
        foreach (var item in items)
        {
            purchase = new()
            {
                RegNum = GetTextField(item, ".highlightColor"),
                Price = GetPrice(item),
                PurchaseDetails = GetTextField(item, ".registry-entry__body-value"),
                Customer = GetTextField(item, ".registry-entry__body-href a"),
                TargetСustomer = GetTextField(item, ".col-9.p-0.registry-entry__header-top__title.text-truncate"),
                Status = GetTextField(item, ".registry-entry__header-mid__title.text-normal"),
                PurchaseCardLink = "https://zakupki.gov.ru" 
                    + item.QuerySelector(".registry-entry__header-mid__number a")?.GetAttribute("href").Trim('\n', ' ')
            };
            var dateElem = item.QuerySelectorAll(".data-block__value");

            purchase.PublicationDate = DateOnly.Parse(dateElem[0].Text());
            purchase.UpdateDate = DateOnly.Parse(dateElem[1].Text());
            if (dateElem.Count() > 2)
                purchase.DeadLine = DateOnly.Parse(dateElem[2].Text());
            purchaseList.Add(purchase);
        }

        return purchaseList;
    }
    decimal GetPrice(IElement element)
    {
        string? s = string.Join("", GetTextField(element, ".price-block__value")
            .Replace("&nbsp;", "")
            .Where(x => (x >= '0' && x <= '9') || x == ','));
        if (!decimal.TryParse(s, out decimal price))
            return 0;
        return price;
    }
    string GetTextField(IElement element, string selector)
    {
        return element
            .QuerySelector(selector)?
            .Text()?
            .Trim('\n', ' ')
            .Replace("\n", "")
            .Collapse();
    }
}