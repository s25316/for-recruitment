using GoF.Structural.AdapterFamily.Adapter.UserService;

namespace GoF.Structural.AdapterFamily.Adapter
{
    public static class AdapterPresenter
    {
        public static void Present()
        {
            IUserNotesService adapter = new NotesAdapter();

            var note1 = new Note
            {
                Text = "Note 1"
            };

            adapter.CreateNote(note1);
            adapter.CreateNote(note1);
            adapter.CreateNote(note1);

            adapter.DeleteNote(3);
        }
    }
}
