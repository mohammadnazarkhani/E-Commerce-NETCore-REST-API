namespace ECommerce.RestAPI.Data.Configurations.Models
{
    internal class ProvinceData
    {
        public string province { get; set; } = string.Empty;
        public List<string> cities { get; set; } = new List<string>();
    }
}