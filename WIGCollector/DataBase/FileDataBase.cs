using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIGCollector.Model;

namespace WIGCollector.Database
{
    class FileDatabase : IStockExchangeDatabase
    {
        private const string databaseFolderName = "Database";
        private string basePath;
        private string databasePath;
        private const char separator = ';';

        public FileDatabase()
        {
            basePath = AppDomain.CurrentDomain.BaseDirectory;
            databasePath = basePath + databaseFolderName;
            if (!Directory.Exists(databasePath))
            {
                Directory.CreateDirectory(databasePath);
            }
        }

        public void AddRate(StockExchangeRate rate)
        {
            string databaseFile = databasePath + "\\" + rate.Name + ".txt";
            TextWriter writer;
            if (File.Exists(databaseFile))
            {
                writer = File.AppendText(databaseFile);
            }
            else
            {
                writer = File.CreateText(databaseFile);
            }
            string lineToWrite = rate.Timestamp.ToString() + separator + rate.Value;
            writer.WriteLine(lineToWrite);
            writer.Close();
        }
    }
}
