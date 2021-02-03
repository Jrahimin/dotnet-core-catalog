using System;
using System.ComponentModel.DataAnnotations;

namespace catalog.Dtos
{
    public record ItemUpdateDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public decimal Price { get; init; }
    }
}