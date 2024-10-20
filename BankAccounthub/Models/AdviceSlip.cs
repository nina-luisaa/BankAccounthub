namespace BankAccounthub.Models
{
        public class AdviceSlip
        {
            public string advice { get; set; }
        }

        public class AdviceResponse
        {
            public AdviceSlip slip { get; set; }
        }
    }
