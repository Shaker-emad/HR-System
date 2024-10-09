﻿using Microsoft.EntityFrameworkCore;
using project12.Models;

var builder = WebApplication.CreateBuilder(args);

// إضافة خدمات التحكم مع العروض
builder.Services.AddControllersWithViews();

// إضافة DbContext مع سلسلة الاتصال
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// إعداد خط الأنابيب
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
