using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientMangementApi.PensionManagement.Domain.Dto;

namespace PatientMangementApi.PensionManagement.Application.commands
{
    public class CreatePatientCommand
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
         public string Description { get; set; }
        public DateTime RecordDate { get; set; }
    }
}