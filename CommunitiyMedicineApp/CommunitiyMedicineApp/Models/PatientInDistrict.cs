using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models
{
    public class PatientInDistrict
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public int Patient { get; set; }
    }
}