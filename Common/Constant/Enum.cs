namespace MBBE.Common.Constant
{
    public class Enum
    {
        public enum UserRoles { 
            Customer = 0,
            Admin = 1
        }
        public enum PaymentMethod { 
            Cash = 0,
            Momo = 1,
            Paypal = 2
        }

        public enum PaymentStatus
        {
            Waiting = 0,
            Succeeded = 1,
            Canceled = 2, 
            Expired = 3
        }
    }
}
