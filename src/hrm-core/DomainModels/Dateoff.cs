namespace hrm_core.DomainModels
{
    public class Dateoff : BaseModel
    {
        public Guid DateoffId { get; set; }
        public DateTime OffDate { get; set; }
        public string Name { get; set; }
        public bool MorningFlg { get; set; }
        public bool AfternoonFlg { get; set; }
    }
}
