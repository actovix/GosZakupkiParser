using ZakupkiParser.Source;
using System.Net;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient()
                .ConfigureHttpClientDefaults(cb =>
                    cb.ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler()
                    {
                        AutomaticDecompression =
                            DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
                    }));
builder.Services.AddScoped<IHtmlLoader, HtmlLoader>();


builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();   

app.Run();
