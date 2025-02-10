using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientMangementApi.PensionManagement.Domain.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<PatientDto> PatientRecords{ get; set; } = new ();
    }
}