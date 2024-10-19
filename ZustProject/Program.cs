using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Zust.Business.Abstract;
using Zust.Business.Concrete;
using Zust.DataAccess.Abstract;
using Zust.DataAccess.Concrete;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;
using ZustProject.Hubs;
using ZustProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
var connString = builder.Configuration.GetConnectionString("Default");


builder.Services.AddDbContext<ZustDbContext>(options =>
{
    options.UseSqlServer(connString,
        sqlOptions => sqlOptions.MigrationsAssembly("ZustProject"))
        .UseLazyLoadingProxies();
});

builder.Services.AddScoped<IChatDal, EFChatDal>();
builder.Services.AddScoped<IChatService, ChatService>();

builder.Services.AddScoped<ICommentDal, EFCommentDal>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IFriendRequestDal, EFFriendRequest>();
builder.Services.AddScoped<IFriendRequestService, FriendRequestService>();

builder.Services.AddScoped<IMessageDal, EFMessageDal>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddScoped<IPostDal, EFPostDal>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<IUserFriendDal, EFUserFriendDal>();
builder.Services.AddScoped<IUserFriendService, UserFriendService>();

builder.Services.AddScoped<ILikeDal, EFLikeDal>();
builder.Services.AddScoped<ILikeService, LikeService>();

builder.Services.AddScoped<INotificationDal, EFNotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddScoped<IMediaService, MediaService>();

builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ZustDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7224")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapHub<UserHub>("/userhub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
