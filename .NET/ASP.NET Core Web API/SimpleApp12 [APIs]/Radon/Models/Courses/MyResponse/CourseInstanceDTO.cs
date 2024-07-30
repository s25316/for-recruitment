using Radon.Models.Courses.ApiResponse.Level2;

namespace Radon.Models.Courses.MyResponse
{
    public class CourseInstanceDTO
    {
        public Guid? CourseInstanceUuid { get; set; } = null;
        public int? CourseInstanceCode { get; set; } = null;
        public int? CourseInstanceOldCode { get; set; } = null;
        public string? CourseName { get; set; } = null;
        public int? FormCode { get; set; } = null;
        public string? FormName { get; set; } = null;
        public int? TitleCode { get; set; } = null;
        public string? TitleName { get; set; } = null;
        public string? LanguageCode { get; set; } = null;
        public string? LanguageName { get; set; } = null;
        //public List<PhilologicalLanguage> PhilologicalLanguages { get; set; } = new();
        public DateOnly? EducationStartDate { get; set; } = null;
        public int? NumberOfSemesters { get; set; } = null;
        //public int? Ects { get; set; } = null;
        public bool? Dual { get; set; } = null;
        public bool? Bridging { get; set; } = null;
        public int? StatusCode { get; set; } = null;
        public string? StatusName { get; set; } = null;
        public DateOnly? LiquidationDate { get; set; } = null;
        public bool? CoopWithVocational { get; set; } = null;

        //=======================================================================================================
        public static implicit operator CourseInstanceDTO(CourseInstance course) 
        {
            return new CourseInstanceDTO 
            { 
                CourseInstanceUuid = course.CourseInstanceUuid,
                CourseInstanceCode = course.CourseInstanceCode,
                CourseInstanceOldCode = course.CourseInstanceOldCode,
                CourseName = course.CourseName,
                FormCode = course.FormCode,
                FormName = course.FormName,
                TitleCode = course.TitleCode,
                TitleName = course.TitleName,
                LanguageCode = course.LanguageCode,
                LanguageName = course.LanguageName,
                EducationStartDate = course.EducationStartDate,
                NumberOfSemesters = course.NumberOfSemesters,
                Dual = course.Dual,
                Bridging = course.Bridging, 
                StatusCode = course.StatusCode,
                StatusName = course.StatusName,
                LiquidationDate = course.LiquidationDate,
                CoopWithVocational = course.CoopWithVocational,
            };
        }
    }
}
