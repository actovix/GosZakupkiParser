namespace ZakupkiParser.Source;

public class HtmlLoader(HttpClient httpClient)
{
    private readonly HttpClient httpClient = httpClient;

    public static async Task<string> GetPageByLinkAsync(HttpClient httpClient, string link)
    {
        return await httpClient.GetStringAsync(link);
    }

    public async Task<string?> GetPageAsync(HttpRequestMessage requestMessage)
    {
        string res = "";
        using (HttpRequestMessage reqMessage = requestMessage)
        {
            HttpResponseMessage respMessage = await httpClient.SendAsync(reqMessage);
            res = await respMessage.Content.ReadAsStringAsync();
            await File.WriteAllTextAsync("log.txt", DateTime.Now + " | " + respMessage.StatusCode + " | " + reqMessage.RequestUri + "\n");
        }
        return res;
    }
}