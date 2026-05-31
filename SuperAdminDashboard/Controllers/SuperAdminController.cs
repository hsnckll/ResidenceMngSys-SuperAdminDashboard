using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperAdminDashboard.Models;

namespace SuperAdminDashboard.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly AppDbContext db;

        public SuperAdminController(AppDbContext db)
        {
            this.db = db;
        }


        public IActionResult Dashboard()
        {
            var viewmodel = new viewmodel();

            var superadminId = db.UserRoles.Where(x => x.Roles_Id == 3).Select(x => x.User_Id).FirstOrDefault(); //Sona firstordefault ekleyerek tekil bir nesneye çevirdik

            viewmodel.superadminbilgileri = db.Users.FirstOrDefault(x => x.Id == superadminId);





            viewmodel.toplamkayitlisakinsayisi = (db.Users.Count() - 1);

            viewmodel.aktifyoneticisayisi = db.UserRoles.Where(x => x.Roles_Id == 2).Count();

            viewmodel.toplamapartmansayisi = (db.Tenants.Count() - 1);


            viewmodel.yoneticiler = db.Users.Include(x => x.Apartment).Include(x=>x.Tenant).Where(x => db.UserRoles.Any(a => a.User_Id == x.Id && a.Roles_Id == 2)).ToList();


            var apartmanSayisi=db.Apartment.ToList();

            viewmodel.apartmanSayisi = apartmanSayisi;

            return View(viewmodel);
        }


        public IActionResult EklemeSayfasi()
        {
            return View();
        }



        [HttpPost]
        public IActionResult ApartmanveYoneticiEkleme(string ApartmentName, string CityDistrict, string Address, string Name, string Surname, string Mail, string Password, string ConfirmPassword, string PhoneNumber)
        {
            var tenants = new Tenants
            {
                Name= ApartmentName,
                Address=Address,
                CreatedAt= DateTime.Now,
                IsActive= 1
            };

            var mailKontrol = db.Users.Any(x => x.Mail == Mail); // Eğer girilen mailden başka varsa oluşturtmasın
            if (mailKontrol)
            {
                TempData["Error"] = "Bu e-posta adresi zaten kullanılıyor. Lütfen başka bir e-posta girin.";
                return RedirectToAction("EklemeSayfasi");
            }

            db.Tenants.Add(tenants);
            db.SaveChanges();

            var yonetici = new User
            {
                Name = Name,
                Surname = Surname,
                Mail = Mail,
                PhoneNumber = PhoneNumber,
                Password = Password,
                IsActive = 1,
                CreatedAt = DateTime.Now,

                TenantId = tenants.Id,
                Tenant = tenants
            };

            db.Users.Add(yonetici);
            db.SaveChanges();

            var RolAtamasiAdmin = new UserRoles
            {
                Roles_Id = 2,
                User_Id = yonetici.Id
            };

            
            db.UserRoles.Add(RolAtamasiAdmin);
            db.SaveChanges();

            var RolAtamasıEvSakini = new UserRoles
            {
                Roles_Id = 1,
                User_Id = yonetici.Id
            };

            db.UserRoles.Add(RolAtamasıEvSakini);
            db.SaveChanges();
            
            return RedirectToAction("EklemeSayfasi");
        }






        public IActionResult Yoneticiler()
        {

            var yoneticiler = db.Users.Include(x=>x.Apartment).Include(x=>x.Tenant).Where(x => db.UserRoles.Any(a => a.Roles_Id == 2 && a.User_Id == x.Id)).ToList();

            var viewmodel = new viewmodel();
            viewmodel.yoneticiler = yoneticiler;



            return View(viewmodel);
        }



        //public IActionResult YoneticiDuzenle(int duzenlenecekId)
        //{
        //    var DuzenlenecekKisi = db.Users.Include(x=>x.Tenant).Include(x=>x.Apartment).FirstOrDefault(x => x.Id == duzenlenecekId);

        //    var viewmodel = new viewmodel();
        //    viewmodel.users = DuzenlenecekKisi;


        //    return View(viewmodel);
        //}


        [HttpPost]
        public IActionResult YoneticiDurumDegistir(int id)
        {
            var durumudegistirilecekKisi = db.Users.Include(x=>x.Tenant).FirstOrDefault(x => x.Id == id);

            if (durumudegistirilecekKisi.Tenant.IsActive == 1)
            {
                durumudegistirilecekKisi.Tenant.IsActive = 0;
            }
            else { durumudegistirilecekKisi.Tenant.IsActive = 1; }

            db.SaveChanges();




         return RedirectToAction("Yoneticiler");
        }






        public IActionResult Abonelik()
        {
            return View();
        }


        public IActionResult SistemAyarları()
        {
            return View();
        }



    }
}
