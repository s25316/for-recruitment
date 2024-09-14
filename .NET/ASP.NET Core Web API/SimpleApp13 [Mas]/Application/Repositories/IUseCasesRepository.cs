using Application.Repositories.DTOs;
using Application.Repositories.DTOs.DocumentPart;
using Application.Repositories.DTOs.EmploeePart;
using Application.Repositories.DTOs.EmploeePart.MethodGet;
using Application.Repositories.DTOs.EmploeePart.MethodGetForList;
using Application.Repositories.DTOs.GetPersonByPesel;
using Domain.Entites.DepartmentPart;

namespace Application.Repositories
{
    public interface IUseCasesRepository
    {
        //Person Part
        Task<SingleObjectResponse<PersonDtoResponse>> GetPersonByPeselAsync(string pesel);
        Task<DTOs.Response> PersonCreateProfileAsync(DTOs.PersonCreateProfile.PersonDtoRequest req);
        Task<DTOs.Response> PersonUpdateProfileAsync(Guid id, DTOs.PersonCreateProfile.PersonDtoRequest req);
        Task<DTOs.Response> DeleteProfileAsync(Guid id);

        //Document Part
        Task<DTOs.Response> SetDocumentAsync(Guid personId, DTOs.DocumentPart.DocumentDtoRequest req);
        Task<DTOs.Response> UpdateDocumentAsync(Guid documentId, DTOs.DocumentPart.DocumentDtoRequest req);
        Task<List<DocumentTypeDtoResponse>> GetDocumentTypesAsync();

        //Addess Part
        Task<List<DTOs.AdressPart.AdministrativeDivisionDto>> GetDivisionsAsync(string nazwa);
        Task<List<DTOs.AdressPart.AdministrativeDivisionDto>> GetDivisionsUpByDivisionAsync(int id);
        Task<IList<DTOs.AdressPart.StreetDto>> GetStreetsByDivisionIdAsync(long divisionId);


        //ClientPart
        Task<Response> ClientCreateProfileAsync(Guid id);

        //Emploee Part
        Task<SingleObjectResponse<EmploeeDtoResponse>> GetEmploeeDataAsync(Guid id);
        Task<DTOs.Response> CreateEmploeeAsync(Guid emploeeIdWhichInserted, EmploeeDtoRequest req);
        Task<Response> EmploeeToDepartmentAsync(Guid emploeeId, Guid departmentId);
        Task<DTOs.Response> SetEducationHistoryAsync(EducationHistoryDtoRequest req);
        Task<DTOs.Response> SetEmploymentHistoryAsync(EmploymentHistoryDtoRequest req);
        //create profile
        //
        Task<DTOs.Response> CreateDepartment(DepartmentDtoRequest req);


        Task<List<EmploeeSimpleDataDtoResponse>> GetSimpleDataEmploeesAsync();
        Task<List<PersonDtoResponse>> GetSimpleDataPeopleAsync();
    }
}
