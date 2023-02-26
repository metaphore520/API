using API;
using API.Contracts;
using API.DbContextFile;
using API.Repository;
using API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<InvoiceDBContext>();

builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IInvoiceDetailsRepository, InvoiceDetailsRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IInvoiceDetailsService, InvoiceDetailsService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IServiceWrapper, ServiceWrapper>();

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        builder.WithOrigins("http://localhost:4200/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});






var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseCors(devCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
