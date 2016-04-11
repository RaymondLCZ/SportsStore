using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "請輸入姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage ="請輸入地址")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage ="請輸入城市")]
        public string City { get; set; }

        public string State { get; set; }

        [Required (ErrorMessage ="請輸入國家")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }

    }
}
