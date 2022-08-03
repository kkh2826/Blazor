namespace VideoAppCore.Models.Common
{
    public class AuditableBase
    {
        public string? CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
