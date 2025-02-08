using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientMangementApi.PensionManagement.Domain
{
    public class PatientRecord : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}