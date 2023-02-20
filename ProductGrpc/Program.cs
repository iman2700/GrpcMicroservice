using ProductGrpc.Data;
using ProductGrpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();
SeedDataBase(app);

void SeedDataBase(IHost host)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    //var productContext = services.GetRequiredService<ProductsContext>();
    //ProductsContextSeed.SeedAsync(productContext);
}

// Configure the HTTP request pipeline.
 app.MapGrpcService<ProductService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
