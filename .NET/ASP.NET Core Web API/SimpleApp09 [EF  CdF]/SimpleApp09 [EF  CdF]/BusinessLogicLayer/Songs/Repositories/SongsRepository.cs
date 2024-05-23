using Microsoft.EntityFrameworkCore;
using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Songs.DTOs;
using SimpleApp09__EF__CdF_.DatabaseLayer;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.Repositories
{
    public class SongsRepository : ISongsRepository
    {
        private readonly MusicDBContext _context;
        public SongsRepository(MusicDBContext context) { _context = context; }

        public async Task<IEnumerable<SongGetDTO>> GetSongsAsync() 
        {
            var list = await _context.Songs.Include(s => s.Musicians)
                .Include(s => s.Album).ThenInclude(s => s.Label)
                .AsNoTracking().Select(s => new SongGetDTO 
                { 
                    IdSong = s.IdSong,
                    SongName = s.SongName,
                    Duration = s.Duration,
                    Album = (s.Album == null || s.IdAlbum == null)? null : new AlbumSharedGetDTO
                    { 
                        IdAlbum = s.Album.IdAlbum,
                        NameAlbum = s.Album.NameAlbum,
                        ReleaseDate = s.Album.ReleaseDate,
                        Label = new LabelSharedGetDTO 
                        { 
                            IdLabel = s.Album.Label.IdLabel,
                            Name = s.Album.Label.Name,
                        }
                    },
                    Musicians = s.Musicians.Select(m => new _Shared_DTOs.MusicianSharedGetDTO 
                    { 
                        IdMusician = m.IdMusician,
                        Name = m.Name,
                        Surname = m.Surname,
                        Nickname = m.Nickname,
                    }).ToList(),
                }).ToListAsync();
            return list;
        }

        public async Task<bool> PostSongAsync(SongPostDTO song) 
        {
            if (song.IdAlbum != null) 
            { 
                var album = await _context.Albums.FindAsync(song.IdAlbum);
                if (album == null) return false;
            }

            await _context.Songs.AddAsync(new Song 
            { 
                Duration = song.Duration,
                SongName= song.SongName,
                IdAlbum = song.IdAlbum,
            });
            await _context.SaveChangesAsync();  
            return true;
        }

        public async Task<bool> DeleteSongAsync(int IdSong) 
        {
            var song = await _context.Songs.FindAsync(IdSong);
            if (song == null) return false; 
            song.Musicians.Clear();
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
