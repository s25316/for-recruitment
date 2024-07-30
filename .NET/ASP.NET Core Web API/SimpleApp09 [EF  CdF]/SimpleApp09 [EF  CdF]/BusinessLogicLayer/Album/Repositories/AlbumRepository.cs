using Microsoft.EntityFrameworkCore;
using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs;
using SimpleApp09__EF__CdF_.DatabaseLayer;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicDBContext _context;
        public AlbumRepository (MusicDBContext context) { _context = context; }

        public async Task<IEnumerable<AlbumGetDTO>> GetAlbumsAsync() 
        {
            var list = await _context.Albums.Include(a => a.Label)
                .Include(a => a.Songs).ThenInclude(a => a.Musicians)
                .AsNoTracking().Select(a => new AlbumGetDTO 
                { 
                    IdAlbum = a.IdAlbum,
                    NameAlbum = a.NameAlbum,
                    ReleaseDate = a.ReleaseDate,
                    Label = new _Shared_DTOs.LabelSharedGetDTO 
                    { 
                        IdLabel = a.IdLabel,
                        Name = a.Label.Name,
                    },
                    Songs = a.Songs.Select(s => new SongSharedGetDTO 
                    { 
                        IdSong = s.IdSong,
                        SongName = s.SongName,
                        Duration = s.Duration,
                        Musicians =  s.Musicians.Select(m => new MusicianSharedGetDTO 
                        { 
                            IdMusician = m.IdMusician,
                            Name = m.Name,
                            Surname = m.Surname,
                            Nickname = m.Nickname,
                        }).ToList()
                    }).ToList()
                }).ToListAsync();
            return list;
        }

        public async Task<bool> PostAlbumAsync(AlbumPostDTO album) 
        {
            var label = await _context.Labels.FindAsync(album.IdLabel);
            if (label == null) return false;
            await _context.Albums.AddAsync(new DatabaseLayer.Models.Album 
            { 
                NameAlbum = album.NameAlbum,
                ReleaseDate = album.ReleaseDate,
                IdLabel = album.IdLabel,
            });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAlbumAsync(int IdAlbum) 
        { 
            var album = await _context.Albums.FindAsync(IdAlbum);
            if (album == null) return false;
            var list = await _context.Songs.Where(s => s.IdAlbum == IdAlbum).ToListAsync();
            foreach (var item in list) 
            { 
                item.IdAlbum = null;
            }
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
