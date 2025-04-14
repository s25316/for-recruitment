using GoF.Structural.AdapterFamily.Adapter.Database;
using GoF.Structural.AdapterFamily.Adapter.UserService;

namespace GoF.Structural.AdapterFamily.Adapter
{
    public class NotesAdapter : NoteRepository, IUserNotesService
    {
        public int CreateNote(UserService.Note entity)
        {
            return Create(new Database.Note
            {
                Description = entity.Text,
            });
        }

        public void DeleteNote(int id)
        {
            Delete(id);
        }

        public UserService.Note SelectNote(int id)
        {
            var databse = Select(id);
            return new UserService.Note
            {
                Id = databse.IdNote,
                Text = databse.Description,
            };
        }

        public void UpdateNote(UserService.Note entity)
        {
            if (!entity.Id.HasValue)
            {
                throw new KeyNotFoundException();
            }
            var database = new Database.Note
            {
                IdNote = entity.Id.Value,
                Description = entity.Text,
            };
            Update(database);
        }
    }
}
