using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models
{
    public class AllInformationModel
    {
        public int VoterIdNo { set; get; }
        public string Observation { set; get; }
        public string DateTime { get; set; }
        public int DoctorId { get; set; }
        public int DiseaseId { get; set; }
        public int MedicineId { get; set; }
        public int CenterId { get; set; }
        public string DoctorName { get; set; }
        public string DiseaseName { get; set; }
        public string MedicineName { get; set; }
        public string CenterName { get; set; }
        public string Dose { get; set; }
        public int DoseTime { get; set; }
        public string DoseTimeName { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

    }
}