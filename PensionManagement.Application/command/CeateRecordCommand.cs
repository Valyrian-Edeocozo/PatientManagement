using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientMangementApi.PensionManagement.Application.command
{
    public class CeateRecordCommand
    {
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public int PatientId { get; set; }
    }
}