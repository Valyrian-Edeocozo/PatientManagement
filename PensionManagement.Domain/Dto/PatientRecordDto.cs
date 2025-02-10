using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientMangementApi.PensionManagement.Domain.Dto
{
    public class PatientRecordDto
    {
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public int PatientId { get; set; }
        public PatientDto PatientDto { get; set; }
    }
}