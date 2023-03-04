﻿namespace StudentManagingSystem.ViewModel
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}