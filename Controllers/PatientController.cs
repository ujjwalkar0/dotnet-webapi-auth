using Auth.Interface;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.Controllers
{
    // [Authorize]
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatients _IPatient;

        public PatientController(IPatients IPatient)
        {
            _IPatient = IPatient;
        }

        // GET: api/Patient>
        [HttpGet]
        // [Authorize("Authorization")]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            return await Task.FromResult(_IPatient.GetPatientDetails());
        }

        // GET api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            var Patients = await Task.FromResult(_IPatient.GetPatientDetails(id));
            if (Patients == null)
            {
                return NotFound();
            }
            return Patients;
        }

        // POST api/Patient
        [HttpPost]
        public async Task<ActionResult<Patient>> Post(Patient Patient)
        {
            _IPatient.AddPatient(Patient);
            return await Task.FromResult(Patient);
        }

        // PUT api/Patient/5
        // [HttpPut("{id}")]
        // public async Task<ActionResult<Patient>> Put(int id, Patient Patient)
        // {
        //     if (id != Patient.PatientId)
        //     {
        //         return BadRequest();
        //     }
        //     try
        //     {
        //         _IPatient.UpdatePatient(Patient);
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!PatientExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //     return await Task.FromResult(Patient);
        // }

        // DELETE api/Patient/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Patient>> Delete(int id)
        // {
        //     var Patient = _IPatient.DeletePatient(id);
        //     return await Task.FromResult(Patient);
        // }

        // private bool PatientExists(int id)
        // {
        //     return _IPatient.CheckPatient(id);
        // }
    }
}
