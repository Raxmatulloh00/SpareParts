using Actions.CarSpareActions;
using Actions.CarSpareActions.CarSpareDataStore;
using DataStore.SQL.MyRepo;
using DataStore.SQL;
using DataStore.SQL.CarSpare;
using FourGreen.DataUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SurveyHub.Admin.Services;
using System.Globalization;
using Web_Hotel.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAntDesign();

builder.Services.AddScoped<UserMenegerServise>();
builder.Services.AddScoped<RoleMenegerServise>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<CookieService>();


builder.Services.AddScoped<ISparePartBrandsRepository, SparePartBrandsRepositorys>();
builder.Services.AddScoped<ISparePartsRepository, SparePartsRepositorys>();
builder.Services.AddScoped<ISparePartsInfoRepository, SparePartsInfoRepositorys>();



builder.Services.AddScoped<ISparePartBrandsActions, SparePartBrandsActions>();
builder.Services.AddScoped<ISparePartsActions, SparePartsActions>();
builder.Services.AddScoped<ISparePartsInfoActions, SparePartsInfoActions>();
builder.Services.AddScoped<BrandImage>();
builder.Services.AddScoped<ImageRepositorys>();
builder.Services.AddScoped<SparePartsRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<BotUserRepository>();

builder.Services.AddDbContext<FourgreenDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FourGreenConnection"));

});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<FourgreenDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var defaultCulture = "en-US";
var ci = new CultureInfo(defaultCulture);
ci.NumberFormat.NumberDecimalSeparator = "."; // Defining my preferrence for number
ci.NumberFormat.CurrencyDecimalSeparator = ".";

// Configuring Number Seperator Using Localization middleware
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ci),
    SupportedCultures = new List<CultureInfo>
    {
        ci,
    },
    SupportedUICultures = new List<CultureInfo>
    {
        ci,
    }
});
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");

});

app.Run();
