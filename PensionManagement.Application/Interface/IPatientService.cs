using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientMangementApi.PensionManagement.Application.command;
using PatientMangementApi.PensionManagement.Application.commands;
using PatientMangementApi.PensionManagement.Domain;

namespace PatientMangementApi.PensionManagement.Application
{
    public interface IPatientService
    {
        Task<Patient> CreatePatient(CreatePatientCommand command);
        Task<IEnumerable<Patient>> GetAllPatient();
        Task<Patient> GetPatientById(int id);
        Task<bool> DeletePatient(int id);
        Task<Patient> UpdatePatient(UpdatePatientDto command);
    }
}