using ECommerce.RestAPI.Data.Configurations.Models;
using ECommerce.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace ECommerce.RestAPI.Data.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasIndex(p => p.Name)
                .IsUnique();

            // Load and seed province data
            var jsonPath = Path.Combine("Resources", "SeedData_Assets", "province_city_iran.json");
            var jsonContent = File.ReadAllText(jsonPath);
            var provinceCityData = JsonSerializer.Deserialize<List<ProvinceData>>(jsonContent);

            var provinces = provinceCityData.Select((p, index) => new Province
            {
                Id = GetProvinceId(p.province),
                Name = p.province,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = null
            }).ToList();

            builder.HasData(provinces);
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
