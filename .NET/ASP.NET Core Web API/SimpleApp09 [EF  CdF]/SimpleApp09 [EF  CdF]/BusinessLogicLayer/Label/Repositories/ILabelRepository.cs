using SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.Repositories
{
    public interface ILabelRepository
    {
        Task<IEnumerable<LabelGetDTO>> GetlabelsAsync();
        Task<bool> PostLabelAsync(string Name);
        Task<bool> DeleteLabelAsync(int IdLabel);
    }
}
