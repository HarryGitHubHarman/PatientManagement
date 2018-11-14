using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IPatient
    {
        void Add(Patient model);
        IEnumerable<Patient> GetPatientDetails();
    }
}
