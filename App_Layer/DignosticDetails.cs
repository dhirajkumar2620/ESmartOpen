using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class DignosticDetails
    {
        public int Id { get; set; }
        public int ParientId { get; set; }
        public int HospitalId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Addres { get; set; }
        public DateTime Date { get; set; }
        public string ReferedByDoctor { get; set; }
        public string ContactNo { get; set; }
        public bool AbdomenPelvis { get; set; }
        public bool Pelvis { get; set; }
        public bool KUB { get; set; }
        public bool Chest { get; set; }
        public bool RoutineObsUSG { get; set; }
        public bool NTScan { get; set; }
        public bool AnomalyUsgWithDoppler { get; set; }
        public bool ObstretricUSG { get; set; }
        public bool VenousSystem { get; set; }
        public bool UpperKimbVS { get; set; }
        public bool LowerLimbVS { get; set; }
        public bool ArterialSystem { get; set; }
        public bool UpperLimbAS { get; set; }
        public bool LowerLimbAS { get; set; }
        public bool CaeotidDoppler { get; set; }
        public bool RenalDoppler { get; set; }
        public bool Thyroid { get; set; }
        public bool Neck { get; set; }
        public bool Scrotum { get; set; }
        public bool Orbit { get; set; }
        public bool Muskeulokeletal { get; set; }
        public bool BreastSono { get; set; }
        public bool LocalParts { get; set; }
        public bool ChestPaAp { get; set; }
        public bool SpineCsDlLs { get; set; }
        public bool Xray_KUB { get; set; }
        public bool AbdomenErectSupine { get; set; }
        public bool JointBone { get; set; }
        public bool PNS { get; set; }
        public bool Other { get; set; }
        public bool IvuRguMcuHsg { get; set; }
        public bool SinogramFistulogram { get; set; }
        public bool PleuralFluidTapping { get; set; }
        public bool AsciticFluidTapping { get; set; }
        public bool FnacBiopsy { get; set; }
        public bool IsActive { get; set; }
        public string ClinicalHistory { get; set; }
    }
}
