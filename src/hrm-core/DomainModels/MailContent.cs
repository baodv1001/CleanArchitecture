namespace hrm_core.DomainModels
{
    public class MailContent
    {
        public List<Guid> To { get; set; }          // Địa chỉ gửi đến
        public string Subject { get; set; }         // Chủ đề (tiêu đề email)
        public string Body { get; set; }            // Nội dung (hỗ trợ HTML) của email
    }
}
