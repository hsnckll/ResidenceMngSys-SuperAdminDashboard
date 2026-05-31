# 🛡️ ResiEase - Super Admin Dashboard

ResiEase Super Admin Dashboard, ResiEase Rezidans Yönetim Sistemi'nin çok kiracılı (multi-tenant) yapısını yöneten merkezi kontrol panelidir. Yazılım sahibinin tüm apartman/rezidans aboneliklerini, yöneticileri ve sistemi tek bir panel üzerinden yönetmesini sağlar.

---

## 🌐 Genel Bakış

ResiEase, tek bir apartman için değil; **birden fazla apartman, site ve rezidans** tarafından kullanılabilen çok kiracılı (SaaS) bir yapıya sahiptir. Her apartman/rezidans bağımsız bir **tenant** olarak sisteme eklenir. Super Admin Dashboard bu tenant'ları merkezi olarak yönetir.

```
SuperAdmin
    ├── Apartman A  →  Kendi yöneticisi + sakinleri
    ├── Apartman B  →  Kendi yöneticisi + sakinleri
    ├── Rezidans C  →  Kendi yöneticisi + sakinleri
    └── ...
```

---

## 🚀 Özellikler

### 🏢 Tenant Yönetimi
- Sisteme kayıtlı tüm apartman ve rezidansları görüntüleme
- Yeni tenant ekleme / düzenleme / silme
- Tenant bazlı yönetici atama

### 👥 Yönetici Yönetimi
- Tüm apartman yöneticilerini listeleme
- Yönetici hesaplarını aktif/pasif yapma

### 💳 Abonelik Sistemi *(Geliştirme Aşamasında)*
- Aylık ve yıllık abonelik paketleri
- Abonelik başlangıç / bitiş tarihi takibi
- Paket bazlı özellik kısıtlamaları
- Ödeme takip sistemi

### 📊 Genel İstatistikler
- Toplam tenant sayısı
- Aktif / pasif abonelikler
- Sistem geneli kullanım verileri

---

## 🛠️ Teknolojiler

| Teknoloji | Kullanım |
|---|---|
| ASP.NET Core MVC | Web framework |
| Entity Framework Core | ORM / Veritabanı yönetimi |
| SQL Server (SQLEXPRESS) | Veritabanı |
| Bootstrap | Arayüz |

---

## ⚙️ Kurulum

### 1. Gereksinimler
- Visual Studio 2022
- .NET 8 SDK
- SQL Server / SQLEXPRESS
- SSMS (SQL Server Management Studio)

### 2. Repoyu Klonla
```bash
git clone https://github.com/hsnckll/SuperAdminDashboard.git
```

### 3. Veritabanını Kur
- SSMS'i aç
- `database.sql` dosyasını aç ve çalıştır (F5)

### 4. appsettings.json Ayarla
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SENIN_SUNUCU_ADIN\\SQLEXPRESS;Database=SuperAdminDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 5. Projeyi Çalıştır
- `.sln` dosyasını Visual Studio ile aç
- `Ctrl + F5` ile başlat

---

## 🔑 Test Hesabı

> ⚠️ Bu panele yalnızca yazılım sahibi erişebilir. Yetkisiz erişim girişimleri engellenir.

| Rol | E-posta | Şifre |
|---|---|---|
| Super Admin | superadmin@gmail.com | a |

---

## 🗺️ Yol Haritası

- [x] Tenant yönetimi
- [x] Yönetici yönetimi
- [ ] Abonelik paketleri (Aylık / Yıllık)
- [ ] Otomatik fatura oluşturma
- [ ] Ödeme entegrasyonu
- [ ] Abonelik süresi dolunca otomatik pasif yapma
- [ ] Kullanım istatistikleri dashboard'u

---

## 🔗 İlgili Proje

Bu dashboard, **ResiEase Rezidans Yönetim Sistemi** ile birlikte çalışır:
👉 [ResiEase - Rezidans Yönetim Sistemi](https://github.com/hsnckll/Residence_Management_System)

---

## 👨‍💻 Geliştirici

**hsnckll** - Bireysel proje
