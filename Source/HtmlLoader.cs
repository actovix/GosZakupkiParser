using Microsoft.Extensions.Http;
using Serilog;

namespace ZakupkiParser.Source;

public class HtmlLoader : IHtmlLoader
{
    private readonly IHttpClientFactory httpClientFactory;
    public HtmlLoader(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public static async Task<string> GetPageByLinkAsync(HttpClient httpClient, string link)
    {
        return await httpClient.GetStringAsync(link);
    }

    public async Task<string?> GetPageAsync(string link)
    {
        string res = "";
        var req = HttpRequestBuilder.Create(HttpMethod.Get, link, "");

        using (var httpClient = httpClientFactory.CreateClient())
        {
            var respMessage = await httpClient.SendAsync(req);
            res = await respMessage.Content.ReadAsStringAsync();
            if (res is null)
            {
                return res;
            }
            if (respMessage.IsSuccessStatusCode)
            {
                res = await respMessage.Content.ReadAsStringAsync();
            }
        }

        return res;
    }

    public async Task<string?> GetPageByIdAsync(string url, string id)
    {
        string res = "";
        var req = HttpRequestBuilder.Create(HttpMethod.Get, url, id);

        using (var httpClient = httpClientFactory.CreateClient())
        {
            var respMessage = await httpClient.SendAsync(req);
            res = await respMessage.Content.ReadAsStringAsync();
            if (res is null)
            {
                return res;
            }
            if (respMessage.IsSuccessStatusCode)
            {
                res = await respMessage.Content.ReadAsStringAsync();
            }
        }

        return res;
    }
}