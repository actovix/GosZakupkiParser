namespace ZakupkiParser.Source;

public interface IHtmlLoader
{
    public Task<string?> GetPageAsync(string url);
    public Task<string?> GetPageByIdAsync(string url, string id);
}