# MockSmsProvider

[English Version](./README.en.md)

این پروژه یک سیستم شبیه‌ساز ارائه پیامک برای پروژه تند فروش است.
این سامانه امکانات زیر را فراهم می‌کند:

- ورود کاربران با شماره تلفن یا نام (به عنوان شناسه)
- مشاهده پیام‌های دریافتی در صندوق ورودی
- ارسال پیامک به سایر کاربران از طریق REST API
- ذخیره‌سازی اطلاعات در پایگاه داده SQL Server

# نیازمندی‌ها

- .NET 9.0 SDK
- SQL Server (یا Docker با SQL Server)
- ابزار dotnet-ef

# راهنمای نصب و راه‌اندازی

۱. کلون کردن مخزن
۲. باز کردن ترمینال در مسیر پروژه
۳. اجرای دستور زیر برای بازیابی پکیج‌ها:

```bash
dotnet restore
```

۴. نصب ابزار Entity Framework Core:

- برای بررسی نسخه فعلی:
  ```bash
  dotnet ef --version
  ```
- در صورت نیاز به نصب نسخه سازگار (۹.۰.۵):
  `bash
     dotnet tool uninstall --global dotnet-ef
     dotnet tool install --global dotnet-ef --version 9.0.5
     `
  ۵. پیکربندی پایگاه داده:
- تنظیمات اتصال به پایگاه داده در فایل `appsettings.json` قابل تغییر است
- در صورت استفاده از تنظیمات پیش‌فرض SQL Server نیازی به تغییر نیست
- اجرای دستور زیر برای اعمال مهاجرت‌های پایگاه داده:
  ```bash
  dotnet ef database update
  ```
  نکته: می‌توانید از هر نمونه SQL Server یا Docker استفاده کنید

۶. اجرای برنامه:
`bash
    dotnet run
    `

# ساختار پایگاه داده

نمودار رابطه-موجودیت (ERD) زیر ساختار پایگاه داده را نشان می‌دهد:

![نمودار ERD](../docs/MockSmsProvider/database/erd.drawio.svg)

# تصویر محیط برنامه

نمایی از محیط برنامه:

![تصویر برنامه](./Screenshot.png)

# مستندات API

به زودی تکمیل خواهد شد...
