using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CommunitiyMedicineApp.Models;
using CommunitiyMedicineApp.Models.Entity;

namespace CommunitiyMedicineApp.DAL
{
    public class CenterGateway
    {
        public bool DoesCodeExist(string code)
        {
            CMAContext db = new CMAContext();
            bool result = db.Centers.Any(c => c.Code == code);
            return result;
        }

        public Center GetCenterByLogIn(string code, string password)
        {
            CMAContext db = new CMAContext();
            var existingCenter = db.Centers.FirstOrDefault(p => p.Code == code && p.Password == password);
            return existingCenter;
        }

        public List<Center> GetAllCenters()
        {
            CMAContext dbContext = new CMAContext();
            var centers = dbContext.Centers.ToList();
            return centers;
        }
        public int SaveDoctor(Doctor aDoctor)
        {
            CMAContext db = new CMAContext();
            db.Doctors.Add(aDoctor);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }
        public List<SendMedicine> GetMedicineByCenterId(int centerId)
        {
            CMAContext db = new CMAContext();
            var existingCenter = db.SendMedicines.Where(p => p.CenterId == centerId).OrderBy(p => p.MedicineId).AsNoTracking().ToList();
            return existingCenter;
        }
        public Medicine GetMedicineById(int id)
        {
            CMAContext db = new CMAContext();
            var existingMedicine = db.Medicines.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();
            return existingMedicine;
        }
        public List<Doctor> GetDoctorList()
        {
            CMAContext dbContext = new CMAContext();
            var existingDoctor = dbContext.Doctors.ToList();
            return existingDoctor;
        }
        public int SaveTreatment(List<Treatment> treatments)
        {
            CMAContext db = new CMAContext();
            foreach (Treatment treatment in treatments)
            {
                db.Treatments.Add(treatment);
            }          
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }
        public List<Treatment> GetTreatmentList(string voterId)
        {
            CMAContext dbContext = new CMAContext();
            var existingTreatments = dbContext.Treatments.Where(c => c.VoterIdNo == voterId).ToList();
            return existingTreatments;
        }
        public int GetQuantityOfTreatmentMedicineByCenterId(int centerId,int medicineId)
        {
            CMAContext dbContext = new CMAContext();
            var quantities = dbContext.Treatments.Where(c => c.CenterId == centerId && c.MedicineId == medicineId).Select(p => p.Quantity).ToList();
            int quantity = 0;
            foreach (int d in quantities)
            {
                quantity = quantity + d;
            }
            return quantity;
        }
        public double GetQuantityOfSendMedicineByCenterId(int centerId, int medicineId)
        {
            CMAContext dbContext = new CMAContext();
            var quantities = dbContext.SendMedicines.Where(c => c.CenterId == centerId && c.MedicineId == medicineId).Select(p => p.Quantity).ToList();
            double quantity = 0;
            foreach (double d in quantities)
            {
                quantity = quantity + d;
            }
            return quantity;
        }
        public Center GetCenterById(int id)
        {
            CMAContext db = new CMAContext();
            var existingCenter = db.Centers.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();
            return existingCenter;
        }
        public int GetNoOfTreatmentById(string voterId)
        {
            CMAContext db = new CMAContext();
            var treatment = db.Treatments.Where(c => c.VoterIdNo == voterId).AsNoTracking().ToList();
            if (treatment.Count==0)
            {
                return 0;
            }
            else
            {
                int count = 0;
                foreach (Treatment newTreatment in treatment)
                {
                    count=newTreatment.NumberTimeServiceGiven;
                }
                return count;
            }
        }
        public Doctor GetDoctorById(int id)
        {
            CMAContext db = new CMAContext();
            var existingDoctor = db.Doctors.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();
            return existingDoctor;
        }
    }
}