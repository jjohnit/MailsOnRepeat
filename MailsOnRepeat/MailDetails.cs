using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailsOnRepeat
{
    internal class MailDetails
    {
        public String? FromName { get; set; }
        public String? FromAddress { get; set; }
        public String? Password { get; set; }
        public String? Subject { get; set; }
        public String? Body { get; set; }
        public short MailCount { get; set; }
        public IEnumerable<String> Recipients { get; set; }
    }
}
