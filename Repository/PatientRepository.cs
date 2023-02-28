using Auth.Interface;
using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repository
{
    public class PatientRepository : IPatients
    {
        readonly DatabaseContext _dbContext = new();

        public PatientRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Patient> GetPatientDetails()
        {
            try
            {
                return _dbContext.Patients.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Patient GetPatientDetails(int id)
        {
            try
            {
                Patient? Patient = _dbContext.Patients.Find(id);
                if (Patient != null)
                {
                    return Patient;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddPatient(Patient Patient)
        {
            try
            {
                _dbContext.Patients.Add(Patient);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePatient(Patient Patient)
        {
            try
            {
                _dbContext.Entry(Patient).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Patient DeletePatient(int id)
        {
            try
            {
                Patient? Patient = _dbContext.Patients.Find(id);

                if (Patient != null)
                {
                    _dbContext.Patients.Remove(Patient);
                    _dbContext.SaveChanges();
                    return Patient;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckPatient(int id)
        {
            return _dbContext.Patients.Any(e => e.PatientId == id);
        }
    }
}