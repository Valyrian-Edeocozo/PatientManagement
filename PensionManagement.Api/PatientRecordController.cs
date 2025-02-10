using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientMangementApi.PensionManagement.Application.command;
using PatientMangementApi.PensionManagement.Application.commands;
using PatientMangementApi.PensionManagement.Application.Implementation;
using PatientMangementApi.PensionManagement.Application.Interface;
using PatientMangementApi.PensionManagement.Domain;
using PatientMangementApi.PensionManagement.Infrastructure;
using PatientMangementApi.PensionManagement.Infrastructure.Repository;

namespace PatientMangementApi.PensionManagement.Api
{
    [Route("api/v1/patientrecord")]
    [ApiController]
    public class PatientRecordController(AppDbContext context, IPatientRecordService patientRecordService) : ApiControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IPatientRecordService _patientRecordService = patientRecordService;

        [HttpPost("createpatientrecord")]
        public async Task<IActionResult> CreateRecord(CeateRecordCommand command)
        {
            var patientRecord = await _patientRecordService.CreatePatientRecord(command);
            return Ok(patientRecord);
        }

        [HttpPost("getpatientrecord")]
        public async Task<IActionResult> GetPatientRecord(int id)
        {
            var record = await _patientRecordService.GetRecordById(id);
            return Ok(record);
        }

        [HttpPost("updatepatientrecord")]
        public async Task<IActionResult> UpdatePatientRecord(UpdatePatientRecordCommand command)
        {
            var record = await _patientRecordService.UpdatePatientRecord(command);

            return Ok(record);
        }

        [HttpPost("deletepatientrecord")]
        public async Task<IActionResult> DeletePatientRecord(int id)
        {
            var record = await _patientRecordService.DeleteRecord(id);

            return Ok(record);
        }
        
    }
}