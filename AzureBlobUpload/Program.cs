using Azure.Identity;
using Azure.Storage.Blobs;
using AzureBlobUpload.Repository;
using AzureBlobUpload.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IStorage, FolderStorage>();
if (builder.Environment.IsDevelopment())
{

    //Set the connection string for your Azure storage Account in appsettings.development.json. Copy the connection string from "Access keys" section of the Azure storage account
    builder.Services.AddSingleton<BlobServiceClient>(x => new BlobServiceClient(builder.Configuration.GetConnectionString("Azurestorage")));


}
else
{
    //For Production Release on Azure App service, add "ASPNETCORE_ENVIRONMENT" value = "Production" for Environment Variables. Copy the Endpoint URL from Primary Endpoimt under "Endpoints" section of Azure storage Account
    builder.Services.AddSingleton<BlobServiceClient>(x =>
   new BlobServiceClient(
       new Uri("Your Azure Storage Account Endpoint URL"),
        new DefaultAzureCredential()));
}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
