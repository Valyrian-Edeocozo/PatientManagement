using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientMangementApi.PensionManagement.Application.command;
using PatientMangementApi.PensionManagement.Domain;

namespace PatientMangementApi.PensionManagement.Application.Interface
{
    public interface IPatientRecordService
    {
        Task<PatientRecord> CreatePatientRecord(CeateRecordCommand command);
        Task<PatientRecord> GetRecordById(int id);
        Task<PatientRecord> UpdatePatientRecord(UpdatePatientRecordCommand command);
        Task<bool> DeleteRecord(int id);
    }
}