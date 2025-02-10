using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientMangementApi.PensionManagement.Application.command;
using PatientMangementApi.PensionManagement.Application.commands;
using PatientMangementApi.PensionManagement.Domain;
using PatientMangementApi.PensionManagement.Domain.Dto;
using PatientMangementApi.PensionManagement.Infrastructure;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;


namespace PatientMangementApi.PensionManagement.Api
{
    [Route("api/v1/patient")]
    [ApiController]
    public class PatientController(AppDbContext context) : ApiControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpPost("createpatient")]
        public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
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

            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();

            return Ok(new { Name = patient.LastName + " " + patient.FirstName, message = $"Patient creatinon for {patient.FirstName} was successful", });
        }

        [HttpPost("getallpatients")]
        public async Task<IActionResult> GetAllPatient()
        {
            
            var patients = _context.Patients.AsParallel().Where(p => p.IsDeleted == false).ToList();
            await Task.CompletedTask;

            return Ok(patients);

        }

        [HttpPost("getpatient")]
        public async Task<IActionResult> GetPatient([FromQuery] int id)
        {
            
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id && p.IsDeleted == false);
            await Task.CompletedTask;

            return Ok(patient);

        }

        [HttpPost("deletepatient")]
        public async Task<IActionResult> DeletePatient([FromQuery] int id)
        {
            
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            patient.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(patient);

        }

        [HttpPost("updatepatient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientDto command)
        {
            
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == command.PatientId);
            patient.LastName = command.LastName;
            patient.FirstName = command.FirstName;
            patient.DateOfBirth = command.DateOfBirth;

            await _context.SaveChangesAsync();

            return Ok(patient);

        }
    }
}