namespace StudentManagingSystem.ViewModel
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
    public class SearchRequest
    {
        public string? keyword { get; set; }
        public bool? status { get; set; }
    }
}
