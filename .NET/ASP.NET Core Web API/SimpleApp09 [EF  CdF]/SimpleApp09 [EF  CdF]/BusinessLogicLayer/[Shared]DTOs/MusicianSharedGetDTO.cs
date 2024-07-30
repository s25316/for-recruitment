namespace SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs
{
    public class MusicianSharedGetDTO
    {
        public int IdMusician { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Nickname { get; set; } = null;
    }
}
