using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientMangementApi.PensionManagement.Application.command;
using PatientMangementApi.PensionManagement.Application.Interface;
using PatientMangementApi.PensionManagement.Domain;
using PatientMangementApi.PensionManagement.Infrastructure.Repository;

namespace PatientMangementApi.PensionManagement.Application.Implementation
{
    public class PatientRecordService(IRepository<PatientRecord> repository) : IPatientRecordService
    {
        private readonly IRepository<PatientRecord> _repository = repository;

        public async Task<PatientRecord> CreatePatientRecord(CeateRecordCommand command)
        {
            var patientRecord = new PatientRecord
            {
                PatientId = command.PatientId,
                Description = command.Description,  
                RecordDate = DateTime.Now,
                DateCreated = DateTime.Now,
            };

            await _repository.AddAsync(patientRecord);

            return patientRecord;
        }

        public async Task<PatientRecord> GetRecordById(int id)
        {
            var record = await _repository.GetByIdAsync(id);

            return record;
        }

        public async Task<PatientRecord> UpdatePatientRecord(UpdatePatientRecordCommand command)
        {
            var record = await _repository.GetByIdAsync(command.PatientId);

            if (record == null)
                return null;
            
            record.DateModified = DateTime.Now;
            record.Description = command.Description;

            return record;
        }

        public async Task<bool> DeleteRecord(int id)
        {
            var isDeleted = await _repository.SoftDeleteAsync(id);

            return isDeleted;
        }
    }
}