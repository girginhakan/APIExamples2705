namespace JWTTokenExample0406.Data.Entities
{
    public class Kullanici
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
    }
}
