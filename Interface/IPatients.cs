using Auth.Models;

namespace Auth.Interface
{
    public interface IPatients
    {
        public List<Patient> GetPatientDetails();
        public Patient GetPatientDetails(int id);
        public void AddPatient(Patient Patient);
        public void UpdatePatient(Patient Patient);
        public Patient DeletePatient(int id);
        public bool CheckPatient(int id);
    }
}