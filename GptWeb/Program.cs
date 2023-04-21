using GptWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IPedidoService, PedidoService>();
builder.Services.AddSingleton<ISetorService, SetorService>();
builder.Services.AddSingleton<IVendedorService, VendedorService>();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vendedor}/{action=Index}/{id?}");

app.Run();
