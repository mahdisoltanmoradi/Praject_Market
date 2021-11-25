using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs.Message
{
    public class MessageDto
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
