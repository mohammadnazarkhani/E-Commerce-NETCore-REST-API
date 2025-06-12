using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class Province : AuditableEntityBase
    {
        [Length(2,50)]
       public required string Name { get; set; }

       // RelationShips
       public City? City { get; set; }
    }
}
