﻿using System.Text.Json.Serialization;

namespace WPF_Example.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
}
