using BusinessLayer;
using System;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public class PatientManage : IPatient
    {
        private PatientDBContext db;
        public PatientManage(PatientDBContext _Context)
        {
            db = _Context;
        }

        public void Add(Patient model)
        {
            db.Add(model);
            db.SaveChanges();
        }

        public IEnumerable<Patient> GetPatientDetails()
        {
            return db.Patient;
        }
    }
}
