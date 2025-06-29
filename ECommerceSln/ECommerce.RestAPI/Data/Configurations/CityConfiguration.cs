using ECommerce.RestAPI.Data.Configurations.Models;
using ECommerce.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace ECommerce.RestAPI.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasIndex(c => c.Name);

            // Load and seed city data
            var jsonPath = Path.Combine("Resources", "SeedData_Assets", "province_city_iran.json");
            var jsonContent = File.ReadAllText(jsonPath);
            var provinceCityData = JsonSerializer.Deserialize<List<ProvinceData>>(jsonContent);

            var cities = new List<City>();
            foreach (var provinceData in provinceCityData)
            {
                var provinceId = GetProvinceId(provinceData.province);
                foreach (var cityName in provinceData.cities)
                {
                    cities.Add(new City
                    {
                        Id = Guid.NewGuid(),
                        Name = cityName,
                        ProvinceId = provinceId,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = null
                    });
                }
            }

            builder.HasData(cities);
        }

        private Guid GetProvinceId(string provinceName)
        {
            // Create a deterministic GUID based on the province name
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(provinceName));
                return new Guid(hash);
            }
        }
    }
}
