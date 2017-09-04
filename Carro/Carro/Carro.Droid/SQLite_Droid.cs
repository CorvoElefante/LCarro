using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Carro.Droid.SQLite_Droid))]
namespace Carro.Droid
{
    public class SQLite_Droid : ISQLite
    {
        const string DBNAME = "db_name.db";

        public bool BackupDBTo(string filename)
        {
            try
            {
                File.Copy(GetDBPath(), filename, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        public SQLiteConnection GetConnection()
        {
            return GetConnection(DBNAME);
        }

        public SQLiteConnection GetConnection(string DBFileName)
        {
            return new SQLiteConnection(
                new SQLitePlatformAndroid(),
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    DBFileName
                )
            );
        }

        public string GetDBPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        public bool RestoreDBFrom(string filename)
        {
            try
            {
                File.Copy(filename, GetDBPath(), true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SaveDBFile(string fileName, byte[] file)
        {
            File.WriteAllBytes(Path.Combine(GetDBPath(), fileName), file);
        }

    }
}
