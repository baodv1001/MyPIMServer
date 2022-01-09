using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Core.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Name_en { get; set; }
        public string Code { get; set; }
    }
}
