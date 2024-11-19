using SOAP_TraduzioneJSONSoap.WSSoap;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddSoapCore();
builder.Services.AddScoped<IServizioStoricoBologna, ServizioStoricoBologna>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<IServizioStoricoBologna>("/service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});
app.Run();
