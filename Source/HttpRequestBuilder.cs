namespace ZakupkiParser.Source;

public class HttpRequestBuilder
{
    public static HttpRequestMessage Create(HttpMethod method, string src, string regNum)
    {
        HttpRequestMessage httpRequestMessage = new(method, src.Replace("{regnum}", regNum));
        httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        httpRequestMessage.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        httpRequestMessage.Headers.Add("Accept-Language", "en-US,en;q=0.9");
        httpRequestMessage.Headers.Add("Cache-Control", "max-age=0");
        httpRequestMessage.Headers.Add("Connection", "keep-alive");
        httpRequestMessage.Headers.Add("Cookie", "doNotAdviseToChangeLocationWhenIosReject=true; _ym_uid=1718701318210113977; _ym_d=1718701318; _ym_isad=2; _ym_visorc=b");
        httpRequestMessage.Headers.Add("Dnt", "1");
        httpRequestMessage.Headers.Add("Host", "zakupki.gov.ru");
        httpRequestMessage.Headers.Add("Referer", "https://zakupki.gov.ru/epz/order/extendedsearch/results.html?searchString=3241371495&morphology=on&search-filter=%D0%94%D0%B0%D1%82%D0%B5+%D1%80%D0%B0%D0%B7%D0%BC%D0%B5%D1%89%D0%B5%D0%BD%D0%B8%D1%8F&pageNumber=1&sortDirection=false&recordsPerPage=_10&showLotsInfoHidden=false&sortBy=UPDATE_DATE&fz44=on&fz223=on&af=on&ca=on&pc=on&pa=on&currencyIdGeneral=-1");
        httpRequestMessage.Headers.Add("Sec-Ch-Ua", "\"Chromium\";v=\"118\", \"Opera\";v=\"104\", \"Not=A?Brand\";v=\"99\"");
        httpRequestMessage.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
        httpRequestMessage.Headers.Add("Sec-Ch-Ua-Platform", "\"Linux\"");
        httpRequestMessage.Headers.Add("Sec-Fetch-Dest", "document");
        httpRequestMessage.Headers.Add("Sec-Fetch-Mode", "navigate");
        httpRequestMessage.Headers.Add("Sec-Fetch-Site", "same-origin");
        httpRequestMessage.Headers.Add("Sec-Fetch-User", "?1");
        httpRequestMessage.Headers.Add("Upgrade-Insecure-Requests", "1");
        httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.5993.118 Safari/537.36");
        return httpRequestMessage;
    }
}
