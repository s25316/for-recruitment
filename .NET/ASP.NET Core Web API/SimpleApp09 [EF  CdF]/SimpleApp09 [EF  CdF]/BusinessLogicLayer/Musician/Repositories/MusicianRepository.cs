using Microsoft.EntityFrameworkCore;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.DTOs;
using SimpleApp09__EF__CdF_.DatabaseLayer;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.Repositories
{
    public class MusicianRepository : IMusicianRepository
    {
        private readonly MusicDBContext _context;
        public MusicianRepository(MusicDBContext context) { _context = context; }

        public async Task<IEnumerable<MusicianGetDTO>> GetMusicanAsync() 
        {
            var list = await _context.Musicians.Include(m => m.Songs)
                .ThenInclude(m => m.Album).ThenInclude(m => m.Label)
                .AsNoTracking().Select(m => new MusicianGetDTO 
                { 
                    IdMusician = m.IdMusician,
                    Name = m.Name,
                    Surname = m.Surname,
                    Nickname = m.Nickname,
                    Songs = m.Songs.Select(s => new MusicianSongGetDTO 
                    { 
                        IdSong = s.IdSong,
                        SongName = s.SongName,
                        Duration = s.Duration,
                        Album = (s.Album == null || s.IdAlbum == null)? null : new _Shared_DTOs.AlbumSharedGetDTO
                        {
                            IdAlbum = s.Album.IdAlbum,
                            NameAlbum = s.Album.NameAlbum,
                            ReleaseDate = s.Album.ReleaseDate,
                            Label = new _Shared_DTOs.LabelSharedGetDTO 
                            { 
                                IdLabel = s.Album.Label.IdLabel,
                                Name = s.Album.Label.Name,
                            }
                        },
                    }).ToList(),
                }).ToListAsync();
            return list;
        }


        public async Task<bool> PostMusicianAsync(MusicianPostDTO musician) 
        {
            await _context.Musicians.AddAsync(new DatabaseLayer.Models.Musician
            { 
                Name = musician.Name,
                Surname=musician.Surname,
                Nickname=musician.Nickname,
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMusicianAsync(int IdMusician) 
        {
            var musician = await _context.Musicians.FindAsync(IdMusician);
            if (musician == null) { return false; }
            musician.Songs.Clear();
            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostMusicianSongAsync(int IdMusician, int IdSong) 
        {
            var musician = await _context.Musicians.FindAsync(IdMusician);
            if (musician == null) { return false; }
            var song = await _context.Songs.FindAsync(IdSong);
            if (song == null) { return false; }
            musician.Songs.Add(song);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
