using System;
using System.ComponentModel.DataAnnotations;

namespace catalog.Dtos
{
    public record ItemCreateDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public decimal Price { get; init; }
    }
}