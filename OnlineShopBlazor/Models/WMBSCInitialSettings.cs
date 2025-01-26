namespace OnlineShopBlazor.Models
{
    public class WMBSCInitialSettings : WMBSCSettings
    {
        public IEnumerable<WMBSCResponsiveSettings> responsive { get; set; } = null;
    }
}
