namespace StudentManagingSystem.ViewModel
{
    public class NotificationViewModel
    {
        
    }
    public class NotificationAddRequest
    {
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
        public string? Link { get; set; }
        public bool? IsRead { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
    }
}
