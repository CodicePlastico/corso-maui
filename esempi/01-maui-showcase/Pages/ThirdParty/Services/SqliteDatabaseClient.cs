using SQLite;

namespace MauiShowcase.Pages.ThirdParty.Services
{
    public class SqliteDatabaseClient
    {
        SQLiteAsyncConnection? database;
        public async Task<List<T>> Query<T>(string sql)
            where T : class, new()
        {
            var db = await GetOrCreateDatabaseConnection();
            return await db.QueryAsync<T>(sql);
        }

        async Task<SQLiteAsyncConnection> GetOrCreateDatabaseConnection()
        {
            string databaseFileName = "sqlite.db";
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseFileName);
            // Read the source file
            if (!File.Exists(databasePath))
            {
                await CopyDatabaseFromResourcesToAppDataDirectory(databaseFileName, databasePath);
            }

            return database ?? CreateDatabaseConnection(databasePath);
        }

        static SQLiteAsyncConnection CreateDatabaseConnection(string databasePath)
        {
            SQLiteOpenFlags flags =
                // open the database in read/write mode
                SQLiteOpenFlags.ReadWrite |
                // create the database if it doesn't exist
                // SQLiteOpenFlags.Create |
                // enable multi-threaded database access
                SQLiteOpenFlags.SharedCache;

            return new SQLiteAsyncConnection(databasePath, flags);
        }

        static async Task CopyDatabaseFromResourcesToAppDataDirectory(string databaseFileName, string databasePath)
        {
            // Leggi il contenuto binario del database dalle risorse
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(databaseFileName);
            // Copialo nella directory appdata
            using FileStream outputStream = File.OpenWrite(databasePath);
            fileStream.CopyTo(outputStream);
        }
    }
}
