namespace GoF.Structural.AdapterFamily.Adapter.Database
{
    public class NoteRepository
    {
        /*
         * Alternatywa 1: _lock = new ReaderWriterLockSlim ();
         * w metodach:
         * _rwLock.EnterWriteLock();
           try
            {
                //logic
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
         * 
         * 
         * Akternatywa 2 : ConcurrentDictionary + TryGetValue / TryRemove
         * ConcurrentDictionary = Dictionary dla wiellowontkowości
         */

        // Properties
        private static readonly object _lock = new object();
        private static List<Note> _notes = [];


        // Methods
        public int Create(Note entity)
        {
            lock (_lock)
            {
                var maxId = _notes.Any()
                    ? _notes.Max(e => e.IdNote)
                    : 0;

                var newNote = new Note
                {
                    IdNote = ++maxId,
                    Description = entity.Description,
                };
                _notes.Add(newNote);

                Console.WriteLine($"Created: {newNote}");
                return newNote.IdNote;
            }
        }

        public Note Select(int id)
        {
            lock (_lock)
            {
                return _notes
                    .FirstOrDefault(e => e.IdNote == id)
                    ?? throw new KeyNotFoundException();
            }
        }

        public void Delete(int id)
        {
            lock (_lock)
            {
                var note = Select(id);
                _notes.Remove(note);
                Console.WriteLine($"Deleted: {note}");
            }
        }

        public void Update(Note entity)
        {
            lock (_lock)
            {
                var note = Select(entity.IdNote);
                note.Description = entity.Description;
                Console.WriteLine($"Updated: {note}");
            }
        }
    }
}
