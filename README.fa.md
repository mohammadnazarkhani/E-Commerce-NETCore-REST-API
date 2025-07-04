<div dir="rtl">

# API تجارت الکترونیک در .NET Core

[See English version of this doc](./README.md)

یک پیاده‌سازی قدرتمند REST API برای اپلیکیشن‌های تجارت الکترونیک که با .NET Core ساخته شده است. این API نقاط پایانی برای مدیریت محصولات، سفارشات، مشتریان و احراز هویت را فراهم می‌کند.

## ویژگی‌ها

- 🛍️ مدیریت محصولات (عملیات CRUD)
- 🛒 عملکرد سبد خرید
- 👤 احراز هویت و مجوزدهی کاربران
- 📦 پردازش و مدیریت سفارش
- 💳 یکپارچه‌سازی پرداخت پایه
- 🔐 نقاط پایانی API امن با احراز هویت JWT

## پیش‌نیازها

- .NET Core SDK نسخه 6.0 یا بالاتر
- SQL Server (LocalDB یا بالاتر)
- Visual Studio 2019/2022 یا VS Code

## شروع به کار

1. کلون کردن مخزن:

   ```bash
   git clone https://github.com/yourusername/E-Commerce-NETCore-REST-API.git
   cd E-Commerce-NETCore-REST-API
   ```

2. رفتن به دایرکتوری راه‌حل:

   ```bash
   cd ECommerceSln
   ```

3. بازیابی وابستگی‌های پروژه:

   ```bash
   dotnet restore
   ```

4. به‌روزرسانی پایگاه داده:

   ```bash
   dotnet ef database update
   ```

5. اجرای پروژه:
   ```bash
   dotnet run
   ```

API به صورت پیش‌فرض در آدرس `https://localhost:5001` در دسترس خواهد بود.

## مستندات API

مستندات API در نقطه پایانی `/swagger` هنگام اجرای برنامه در دسترس است. برای مستندات دقیق‌تر، دایرکتوری [docs](./docs) را بررسی کنید.

## مشارکت

مشارکت‌های شما مورد استقبال قرار می‌گیرد! چه در زمینه:

- 🐛 رفع باگ‌ها
- ✨ ویژگی‌های جدید
- 📝 بهبود مستندات
- 🎨 بهبود رابط کاربری/تجربه کاربری

لطفاً قبل از ارسال PR، [راهنمای مشارکت](./CONTRIBUTING.md) ما را مطالعه کنید.

## مجوز

این پروژه تحت مجوز MIT منتشر شده است - برای جزئیات بیشتر [فایل مجوز](./LICENSE) را مشاهده کنید.

</div>
