using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using TestNetCoreSample.Classes;
using TestNetCoreSample.Models;

namespace TestNetCoreSample.Controllers
{
    public class PatientsController : Controller
    {
        private IPatient studentRepository;
        public PatientsController(IPatient context)
        {
            studentRepository = context;
        }

        // GET: Students
        public IActionResult Index()
        {
            var data = studentRepository.GetPatientDetails();
            List<PatientViewModel> students = new List<PatientViewModel>();

            foreach(var item in data)
            {
                var student = Utility.DeserializePatient(item.PatientDetails);
                student.Id = item.PatientId;
                students.Add(student);
            }
            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post : Students/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(PatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                var details = Utility.SerializePatient(patient);
                Patient patients = new Patient() { PatientDetails = details };
                studentRepository.Add(patients);
            }
            return RedirectToAction("Index", "Patients");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
