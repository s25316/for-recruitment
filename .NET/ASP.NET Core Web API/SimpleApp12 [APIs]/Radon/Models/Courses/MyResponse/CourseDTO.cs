using Radon.Models.Courses.ApiResponse.Level1;
using Radon.Models.Courses.ApiResponse.Level2;
using Radon.Models.Courses.ApiResponse.Level3;

namespace Radon.Models.Courses.MyResponse
{
    public class CourseDTO
    {
        public Guid? CourseUuid { get; set; } = null;
        public int? CourseCode { get; set; } = null;
        public int? CourseOldCode { get; set; } = null;
        public string? CourseName { get; set; } = null;
        public int? LevelCode { get; set; } = null;
        public string? LevelName { get; set; } = null;
        public int? ProfileCode { get; set; } = null;
        public string? ProfileName { get; set; } = null;
        public string? IscedCode { get; set; } = null;
        public string? IscedName { get; set; } = null;
        public DateOnly? CreationDate { get; set; } = null;
        public bool? TeacherTraining { get; set; } = null;
        public bool? Philological { get; set; } = null;
        public List<PhilologicalLanguage> PhilologicalLanguages { get; set; } = new();
        public bool? CoLed { get; set; } = null;
        public int? CurrentStatusCode { get; set; } = null;
        public string? CurrentStatusName { get; set; } = null;
        public DateOnly? TerminationInitializationDate { get; set; } = null;
        public DateOnly? LiquidationDate { get; set; } = null;
        public List<Discipline> Disciplines { get; set; } = new();
        //public Guid? LeadingInstitutionUuid { get; set; } = null;
        //public string? LeadingInstitutionName { get; set; } = null;
        //public bool? LeadingInstitutionIsForeign { get; set; } = null;
        //public string? LeadingInstitutionCity { get; set; } = null;
        //public string? LeadingInstitutionVoivodeship { get; set; } = null;
        //public int? LeadingInstitutionVoivodeshipCode { get; set; } = null;
        //public Guid? MainInstitutionUuid { get; set; } = null;
        //public string? MainInstitutionName { get; set; } = null;
        //public string? MainInstitutionKind { get; set; } = null;
        //public int? MainInstitutionKindCode { get; set; } = null;
        //public Guid? SupervisingInstitutionUuid { get; set; } = null;
        //public string? SupervisingInstitutionName { get; set; } = null;
        public List<CoLeadingInstitution> CoLeadingInstitutions { get; set; } = new();
        public List<OrganizationalUnit> OrganizationalUnits { get; set; } = new();
        //public int? LegalBasisTypeCode { get; set; } = null;
        //public string? LegalBasisTypeName { get; set; } = null;
        //public string? LegalBasisNumber { get; set; } = null;
        public DateOnly? LegalBasisDate { get; set; } = null;
        public List<CourseInstanceDTO> CourseInstances { get; set; } = new();


        //=======================================================================================================
        public static implicit operator CourseDTO(Result result) 
        { 
            return new CourseDTO 
            { 
                CourseUuid = result.CourseUuid,
                CourseCode = result.CourseCode,
                CourseOldCode = result.CourseOldCode,
                CourseName = result.CourseName,
                LevelCode = result.LevelCode,
                LevelName = result.LevelName,
                ProfileCode = result.ProfileCode,
                ProfileName = result.ProfileName,
                IscedCode = result.IscedCode,
                IscedName = result.IscedName,
                CreationDate = result.CreationDate,
                TeacherTraining = result.TeacherTraining,
                Philological = result.Philological,
                PhilologicalLanguages = result.PhilologicalLanguages,
                CoLed = result.CoLed,
                CurrentStatusCode = result.CurrentStatusCode,
                CurrentStatusName = result.CurrentStatusName,
                TerminationInitializationDate = result.TerminationInitializationDate,   
                LiquidationDate = result.LiquidationDate,
                Disciplines = result.Disciplines,
                CoLeadingInstitutions = result.CoLeadingInstitutions,
                OrganizationalUnits = result.OrganizationalUnits,
                LegalBasisDate = result.LegalBasisDate,
                CourseInstances = result.CourseInstances.Select(x => (CourseInstanceDTO) x ).ToList(),
            };
        }
    }
}
