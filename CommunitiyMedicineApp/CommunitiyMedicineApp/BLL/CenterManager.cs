using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunitiyMedicineApp.DAL;
using CommunitiyMedicineApp.Models;
using CommunitiyMedicineApp.Models.Entity;

namespace CommunitiyMedicineApp.BLL
{
    public class CenterManager
    {
        CenterGateway centerGateway=new CenterGateway();
        HeadGateway headGateway=new HeadGateway();
        public bool DoesCodeExist(string code)
        {
            return centerGateway.DoesCodeExist(code);
        }

        public Center GetCenterByLogIn(string code, string password)
        {
            return centerGateway.GetCenterByLogIn(code, password);
        }

        public int GetNoOfTreatmentById(string voterId)
        {
            return centerGateway.GetNoOfTreatmentById(voterId);
        }
        public List<Center> GetAllCenters()
        {
            return centerGateway.GetAllCenters();
        }
        public int SaveDoctor(Doctor aDoctor)
        {

            return centerGateway.SaveDoctor(aDoctor);
        }

        public List<CenterMedicineQuantity> GetCenterMedicineQuantity(int centerId)
        {
            List<CenterMedicineQuantity> centerMedicinelList = new List<CenterMedicineQuantity>();
            List<Medicine> medicines = headGateway.GetMedicineList();
            foreach (Medicine medicine in medicines)
            {
                CenterMedicineQuantity centerMedicineQuantity = new CenterMedicineQuantity();
                centerMedicineQuantity.MedicineId = medicine.Id;
                centerMedicineQuantity.MedicineName = medicine.GenericName;
                double sendMedicineQuantity = centerGateway.GetQuantityOfSendMedicineByCenterId(centerId, medicine.Id);
                double treatmentMedicineQuantity = centerGateway.GetQuantityOfTreatmentMedicineByCenterId(centerId, medicine.Id);
                centerMedicineQuantity.Quantity = sendMedicineQuantity-treatmentMedicineQuantity;
                centerMedicineQuantity.CenterId = centerId;
                centerMedicinelList.Add(centerMedicineQuantity);
            }
            return centerMedicinelList;
        }      
        public List<Doctor> GetDoctorList()
        {
            return centerGateway.GetDoctorList();
        }

        public int SaveTreatment(List<Treatment> treatments)
        {
            foreach (Treatment treatment in treatments)
            {
                treatment.NumberTimeServiceGiven = (1+treatment.NumberTimeServiceGiven);
            }
            return centerGateway.SaveTreatment(treatments);
        }

        public List<PatientHistory> GetTreatmentList(string voterId)
        {
            List<Treatment> treatments = centerGateway.GetTreatmentList(voterId);
            List<PatientHistory> patientHistories=new List<PatientHistory>();
            foreach (Treatment treatment in treatments)
            {
                PatientHistory patientHistory=new PatientHistory();
                patientHistory.CenterId = treatment.CenterId;
                Center center = centerGateway.GetCenterById(treatment.CenterId);
                patientHistory.CenterName = center.Name;
                patientHistory.DoctorId = treatment.DoctorId;
                patientHistory.DoctorName = centerGateway.GetDoctorById(treatment.DoctorId).Name;
                patientHistory.DiseaseId = treatment.DiseaseId;
                patientHistory.DiseaseName = headGateway.GetDiseaseNamebyId(treatment.DiseaseId).Name;
                patientHistory.MedicineId = treatment.MedicineId;
                patientHistory.MedicineName = headGateway.GetMedicineNamebyId(treatment.MedicineId).GenericName;
                patientHistory.DistrictName = headGateway.GetDistrictNameById(center.DistrictId);
                patientHistory.ThanaName = headGateway.GetThanaNameById(center.ThanaId);
                patientHistory.Quantity = treatment.Quantity;
                patientHistory.Note = treatment.Note;
                patientHistory.DateTime = (treatment.DateTime).ToString(); ;
                patientHistories.Add(patientHistory);
            }
            return patientHistories;
        }

        public List<AllInformationModel> GiveNameToTreatment(List<Treatment> treatments)
        {
            List<AllInformationModel> allInformationModels=new List<AllInformationModel>();
            foreach (Treatment treatment in treatments)
            {
                AllInformationModel allInformation=new AllInformationModel();
                allInformation.DiseaseName = headGateway.GetDiseaseNamebyId(treatment.DiseaseId).Name;
                allInformation.MedicineName = headGateway.GetMedicineNamebyId(treatment.MedicineId).GenericName;
                allInformation.Dose = GetDoseById(Convert.ToInt32(treatment.Dose));
                allInformation.DoseTimeName = treatment.DoseTime==1 ? "Before Meal" : "After Meal";
                allInformation.Quantity = treatment.Quantity;
                allInformation.Note = treatment.Note;
                allInformationModels.Add(allInformation);
            }
            return allInformationModels;
        }
        public List<Dose> GetDoseList()
        {
            return new List<Dose>()
            {
                new Dose(){Id = 1,Name = "1-0-0"},
                new Dose(){Id = 2,Name = "0-1-0"},
                new Dose(){Id = 3,Name = "0-0-1"},
                new Dose(){Id = 4,Name = "1-1-0"},
                new Dose(){Id = 5,Name = "0-1-1"},
                new Dose(){Id = 6,Name = "1-0-1"},
                new Dose(){Id = 7,Name = "1-1-1"}
            };
        }

        public string GetDoseById(int id)
        {
            List<Dose> doses = GetDoseList();
            foreach (Dose dose in doses)
            {
                if (dose.Id==id)
                {
                    return dose.Name;
                }
            }
            return "";
        }
    }
}