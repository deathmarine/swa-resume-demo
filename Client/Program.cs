using JMSWAResume;
using JMSWAResume.Logging;
using JMSWAResume.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices(config => {
	config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
	config.SnackbarConfiguration.PreventDuplicates = true;
	config.SnackbarConfiguration.NewestOnTop = true;
	config.SnackbarConfiguration.ShowCloseIcon = true;
	config.SnackbarConfiguration.VisibleStateDuration = 10000;
	config.SnackbarConfiguration.HideTransitionDuration = 500;
	config.SnackbarConfiguration.ShowTransitionDuration = 500;
	config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

//Default HttpClient
builder.Services.AddSingleton(c => new HttpClient {
	BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});

//Allows connections to local resources.
builder.Services.AddSingleton<IResumeService, ResumeService>();

//Allows connections to the API. 
if(builder.HostEnvironment.Environment == "Development") {
    //Named client for local development and connects the Frontend SWA to the Backend FA in Visual Studio.
    builder.Services.AddHttpClient("dev_api", c => {
        c.BaseAddress = new Uri("http://localhost:7254/");
    });
    builder.Services.AddSingleton<IAPIService, APITestService>(); //Local Development
} else {
    builder.Services.AddSingleton<IAPIService, APIService>(); //Production
}

//Default Logging
//builder.Services.AddLogging();

//Custom Logging
//The below Logger Provider will send logs to the API.
string log_uri = builder.HostEnvironment.BaseAddress;
if (builder.HostEnvironment.Environment == "Development") {
    log_uri = "http://localhost:7254/";
    builder.Logging.AddAPILogger(configuration => {
        configuration.BaseAddress = log_uri;
        configuration.Filter.Add(LogLevel.Information);
        configuration.Filter.Add(LogLevel.Debug);
    });
} else {
    builder.Logging.AddAPILogger(configuration => {
        configuration.BaseAddress = log_uri;
        configuration.Filter.AddRange(LoggingModel.GetAllLogLevels()); //Block everything By Default
        //Used for debugging, be advised this will send a lot of data to the API.
        //The function app will trigger quite a few times per page load.
        //The function can be disabled with the app setting AzureWebJobs.Log.Disabled = true
    });
}

//builder.Logging.AddApplicationInsights();
//Blazor and SWAs do not support the Application Insights SDK yet.



var app = builder.Build();    
await app.RunAsync();
