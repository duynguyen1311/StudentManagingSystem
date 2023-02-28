﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagingSystem.Model
{
    public class Point : BaseEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public float? ProgessPoint { get; set; }
        public float? MidtermPoint { get; set; }
        public float? FinalPoint { get; set; }
    }
}