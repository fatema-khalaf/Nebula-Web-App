using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nebula.Enum;

namespace Nebula.Models
{
    public class Attachments: BaseEntity<Guid>
    {
        public string FileName { get; set; }
        public string RecordId { get; set; }
        public RecordType  RecordType { get; set; }
        public string Ext { get; set; }
    }
}
