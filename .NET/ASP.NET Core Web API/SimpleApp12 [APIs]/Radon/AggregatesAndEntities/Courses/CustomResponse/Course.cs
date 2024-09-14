using Radon.AggregatesAndEntities.Courses.CoreResponse.Level2;
using Radon.AggregatesAndEntities.Courses.CoreResponse.Level3;

namespace Radon.AggregatesAndEntities.Courses.CustomResponse
{
    public class Course
    {
        public Guid? CourseInstanceUuid { get; private set; } = null;
        public string? CourseName { get; private set; } = null;
        public string? IscedName { get; private set; } = null;
        public string? ProfileName { get; private set; } = null;
        public string? FormName { get; private set; } = null;
        public string? TitleName { get; private set; } = null;
        public string? LevelName { get; private set; } = null;
        public string? LanguageName { get; private set; } = null;
        public string? StatusName { get; private set; } = null;
        public int? NumberOfSemesters { get; private set; } = null;
        public DateOnly? EducationStartDate { get; private set; } = null;
        public DateOnly? LiquidationDate { get; private set; } = null;
        public bool? Dual { get; private set; } = null;
        public bool? Bridging { get; private set; } = null;
        public bool? CoopWithVocational { get; private set; } = null;
        public List<Discipline> Disciplines { get; private set; } = new();
        public List<OrganizationalUnit> OrganizationalUnits { get; private set; } = new();
        public List<CoLeadingInstitution> CoLeadingInstitutions { get; private set; } = new();
        public List<PhilologicalLanguage> PhilologicalLanguages { get; private set; } = new();

        public Course(CoreResponse.Level2.CourseInstance course, CoreResponse.Level1.Course courseMain)
        {
            CourseInstanceUuid = course.CourseInstanceUuid;
            CourseName = course.CourseName;
            IscedName = courseMain.IscedName;
            ProfileName = courseMain.ProfileName;
            FormName = course.FormName;
            TitleName = course.TitleName;
            LevelName = courseMain.LevelName;
            LanguageName = course.LanguageName;
            StatusName = course.StatusName;
            NumberOfSemesters = course.NumberOfSemesters;
            EducationStartDate = course.EducationStartDate;
            LiquidationDate = course.LiquidationDate;
            Dual = course.Dual;
            Bridging = course.Bridging;
            CoopWithVocational = course.CoopWithVocational;
            Disciplines = courseMain.Disciplines;
            OrganizationalUnits = courseMain.OrganizationalUnits;
            CoLeadingInstitutions = courseMain.CoLeadingInstitutions;
            PhilologicalLanguages = courseMain.PhilologicalLanguages;
        }
    }
}
