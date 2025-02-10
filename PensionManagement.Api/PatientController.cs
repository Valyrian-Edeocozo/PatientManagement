using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientMangementApi.PensionManagement.Application;
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
    public class PatientController(AppDbContext context, IPatientService patientService) : ApiControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IPatientService _patientService = patientService;

        [HttpPost("createpatient")]
        public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
        {
            var patient = await _patientService.CreatePatient(command);
            return Ok(new { Name = patient.LastName + " " + patient.FirstName, message = $"Patient creatinon for {patient.FirstName} was successful", });
        }

        [HttpPost("getallpatients")]
        public async Task<IActionResult> GetAllPatient()
        {
            
            var patients = await _patientService.GetAllPatient();
            return Ok(patients);

        }

        [HttpPost("getpatient")]
        public async Task<IActionResult> GetPatient([FromQuery] int id)
        {
            
            var patient = await _patientService.GetPatientById(id);
            return Ok(patient);

        }

        [HttpPost("deletepatient")]
        public async Task<IActionResult> DeletePatient([FromQuery] int id)
        {
            
            var isdeleted = await _patientService.DeletePatient(id);
            if (isdeleted)
               return Ok(new { message = $"Patient with id {id} deleted succesfully" });

            return BadRequest(new { message = "Process failed" });
        }

        [HttpPost("updatepatient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientDto command)
        {
            
            var patient = await _patientService.UpdatePatient(command);

            return Ok(patient);

        }
    }
}