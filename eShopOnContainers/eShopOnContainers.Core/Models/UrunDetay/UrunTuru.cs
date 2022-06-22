namespace eShopOnContainers.Core.Models.UrunDetay
{
    public class UrunTuru
    {
        public int Id { get; set; }
        public string Tur { get; set; }

        public override string ToString()
        {
            return Tur;
        }
    }
}