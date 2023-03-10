﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentManagingSystem.ViewModel
{
    public class StudentAddRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentCode { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? Phone { get; set; }
        public bool? Status { get; set; }
        public Guid? ClassRoomId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        [JsonPropertyName("authorities")]
        public string Role { get; set; }
    }
}
