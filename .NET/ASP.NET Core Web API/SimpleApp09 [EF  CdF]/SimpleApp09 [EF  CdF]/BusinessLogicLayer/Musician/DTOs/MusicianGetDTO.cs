namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.DTOs
{
    public class MusicianGetDTO
    {
        public int IdMusician { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Nickname { get; set; } = null;
        public virtual IEnumerable<MusicianSongGetDTO> Songs { get; set; } = new List<MusicianSongGetDTO>();    
    }
}
