using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientMangementApi.PensionManagement.Application.command;
using PatientMangementApi.PensionManagement.Application.commands;
using PatientMangementApi.PensionManagement.Domain;
using PatientMangementApi.PensionManagement.Infrastructure.Repository;

namespace PatientMangementApi.PensionManagement.Application.Implementation
{
    public class PatientService(IRepository<Patient> repository) : IPatientService
    {
        private readonly IRepository<Patient> _repository = repository;

        public async Task<Patient> CreatePatient(CreatePatientCommand command)
        {
              var patient = new Patient
            {
                LastName = command.LastName,
                FirstName = command.FirstName,
                DateOfBirth = command.DateOfBirth,
                PatientRecords = new List<PatientRecord>
                {
                    new PatientRecord
                    {
                        Description = command.Description,
                        RecordDate = DateTime.Now,
                    }
                }
            };

            await _repository.AddAsync(patient);
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetAllPatient()
        {
            var patients = await _repository.GetAllAsync();
            return patients;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            return patient;
        }

         public async Task<bool> DeletePatient(int id)
        {
            var result = await _repository.SoftDeleteAsync(id);
            return result;
        }

         public async Task<Patient> UpdatePatient(UpdatePatientDto command)
        {
            var patient = await _repository.GetByIdAsync(command.PatientId);
            patient.LastName = command.LastName;
            patient.FirstName = command.FirstName;
            patient.DateOfBirth = command.DateOfBirth;

            await _repository.UpdateAsync(patient);
            return patient;

        }
    }
}