using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    /// <summary>
    /// Represents a province within the e-commerce system for user addresses.
    /// It contains the name of the province and establishes a relationship with a city.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="AuditableEntityBase"/> to track creation and modification dates.
    /// Relationships are established with the <see cref="City"/> entity.
    /// </remarks>
    public class Province : AuditableEntityBase
    {
        [Length(2,50)]
       public required string Name { get; set; }

       // RelationShips
       public City? City { get; set; }
    }
}
