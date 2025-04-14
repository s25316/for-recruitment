namespace GoF.Structural.AdapterFamily.Adapter.UserService
{
    public interface IUserNotesService
    {
        int CreateNote(Note entity);
        void UpdateNote(Note entity);
        Note SelectNote(int id);
        void DeleteNote(int id);
    }
}
