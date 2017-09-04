using SQLite.Net;

namespace Carro
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        SQLiteConnection GetConnection(string DBFileName);
        string GetDBPath();
        void SaveDBFile(string fileName, byte[] file);
        bool FileExists(string fileName);
        bool BackupDBTo(string filename);
        bool RestoreDBFrom(string filename);
    }
}