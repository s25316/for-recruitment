using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.DTOs;
using SimpleApp09__EF__CdF_.DatabaseLayer;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;
using System.Linq;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly MusicDBContext _context;
        public LabelRepository(MusicDBContext context) { _context = context; }

        public async Task<IEnumerable<LabelGetDTO>> GetlabelsAsync() 
        {
            var list = await _context.Labels.Include(l => l.Albums)
                .ThenInclude(l => l.Songs).ThenInclude(l => l.Musicians)
                .AsNoTracking().Select(l => new LabelGetDTO 
                { 
                    IdLabel = l.IdLabel,
                    Name = l.Name,
                    Albums = l.Albums.Select(a => new LabelAlbumGetDTO 
                    { 
                        IdAlbum = a.IdAlbum,
                        NameAlbum = a.NameAlbum,
                        ReleaseDate = a.ReleaseDate,
                        Songs = a.Songs.Select(s => new SongSharedGetDTO
                        { 
                            IdSong = s.IdSong,
                            SongName = s.SongName,
                            Duration = s.Duration,
                            Musicians = s.Musicians.Select(m => new MusicianSharedGetDTO 
                            { 
                                IdMusician = m.IdMusician,
                                Name = m.Name,
                                Surname = m.Surname,
                                Nickname = m.Nickname,
                            }).ToList(),
                        }).ToList(),
                    }).ToList(),
                }).ToListAsync();
            return list;
        }

        public async Task<bool> PostLabelAsync(string Name) 
        {
            await _context.Labels.AddAsync(new DatabaseLayer.Models.Label 
            { 
                Name = Name,
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLabelAsync(int IdLabel) 
        {
            var label = await _context.Labels.FindAsync(IdLabel);
            if (label == null) return false;
            var listAlbums = await _context.Albums.Where(a => a.IdLabel == IdLabel).ToListAsync();
            foreach (var item in listAlbums) 
            { 
                var listSongs = await _context.Songs.Where(s => s.IdAlbum == item.IdAlbum).ToListAsync();
                foreach(var song in listSongs) 
                {
                    song.IdAlbum = null;
                }
                _context.Albums.Remove(item);
            }
            _context.Labels.Remove(label);
            await _context.SaveChangesAsync(); 
            return true;
        }

    }
}
