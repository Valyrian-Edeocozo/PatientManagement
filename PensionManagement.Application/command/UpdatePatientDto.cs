using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientMangementApi.PensionManagement.Application.command
{
    public class UpdatePatientDto
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}