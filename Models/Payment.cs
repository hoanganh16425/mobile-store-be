using static MBBE.Common.Constant.Enum;

namespace MBBE.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
