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
            // for (int i = 0; i < 5; i++)
            {
                HttpResponseMessage respMessage = await httpClient.SendAsync(reqMessage);
                await File.AppendAllTextAsync("log.txt", DateTime.Now + " | " + respMessage.StatusCode + " | " + reqMessage.RequestUri + "\n");
                if (respMessage.IsSuccessStatusCode)
                {
                    res = await respMessage.Content.ReadAsStringAsync();
                    // Thread.Sleep(5000);
                    // break;
                }
            }
        }
        return res;
    }
}