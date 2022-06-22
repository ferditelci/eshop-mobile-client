namespace eShopOnContainers.Core.Models.UrunDetay
{
    public class UrunMarkasi
    {
        public int Id { get; set; }
        public string Marka { get; set; }

        public override string ToString()
        {
            return Marka;
        }
    }
}