namespace IscaPop.Config
{
    public static class Constants
    {
        public const string DatabaseFilename = "iscapop.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath2 =>  Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        public static string DatabasePath
        {
            get
            {
                var x = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
                int v = 6;
                return x;
            }
        }
    }

}