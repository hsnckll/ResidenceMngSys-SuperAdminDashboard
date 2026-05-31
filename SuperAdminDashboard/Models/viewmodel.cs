    namespace SuperAdminDashboard.Models
{
    public class viewmodel
    {


        public Tenants tenants { get; set; }
        public User users { get; set; }

        public User superadminbilgileri { get; set; }
        public List<User> yoneticiler { get; set; }
        public int toplamapartmansayisi { get; set; }
        public int aktifyoneticisayisi { get; set; }
        public int toplamkayitlisakinsayisi { get; set; }

        public List<Apartment> apartmanSayisi { get; set; }
    }
}
