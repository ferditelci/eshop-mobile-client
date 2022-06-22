namespace eShopOnContainers.Core.Models.Siparisler
{
    public class CancelSiparisCommand
    {
        public int SiparisNumber { get; }

        public CancelSiparisCommand(int siparisNumber)
        {
            SiparisNumber = siparisNumber;
        }
    }
}