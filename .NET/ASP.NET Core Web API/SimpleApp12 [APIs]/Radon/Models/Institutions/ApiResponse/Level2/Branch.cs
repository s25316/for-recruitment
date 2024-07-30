﻿using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse.Level2
{
    public class Branch
    {
        [JsonPropertyName("branchUuid")]
        public Guid? BranchUuid { get; set; } = null;

        [JsonPropertyName("branchName")]
        public string? BranchName { get; set; } = null;

        [JsonPropertyName("branchCity")]
        public string? BranchCity { get; set; } = null;
    }
}
