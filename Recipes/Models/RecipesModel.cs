﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recipes.Models {
    public record Recipe {
        [JsonPropertyName("recipe_id")]
        public string? RecipeId { get; init; }

        [Required]
        public string? Title { get; init; }
        public string? Description { get; init; }
        public IEnumerable<string>? Directions { get; init; }
        public IEnumerable<string>? Tags { get; init; }
        [Required]
        public IEnumerable<Ingredient>? Ingredients { get; init; }
        public DateTime? Updated { get; init; }
    }

    public record Ingredient {
        [Required]
        public string? Name { get; init; }
        public string? Amount { get; init; }
        public string? Unit { get; init; }
    }
}
