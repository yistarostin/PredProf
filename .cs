using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TestingDBSQLite
{
    static class DataBaseCreation
    {
        static void Zapopolnit()
        {
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=D:\PredProfile\DB\DB\DB.db; Version=3;");
            SQLiteCommand Command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Employees (Fio TEXT, BirthDate TEXT, Depatrute TEXT, Position TEXT, Grade INTEGER, ID_Employee INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL)", Connect);
            //
            
        }
        static void Main()
        {

            if (!File.Exists(@"D:\PredProfile\DB\DB\DB.db")) 
            {
                SQLiteConnection.CreateFile(@"D:\PredProfile\DB\DB\DB.db"); 
            }
            
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=D:\PredProfile\DB\DB\DB.db; Version=3;")) 
            {
                Connect.Open();
                SQLiteCommand Command = new SQLiteCommand("SELECT * FROM 'Employees';", Connect);
                SQLiteDataReader workers = Command.ExecuteReader();
                while (workers.Read())
                {
                    Console.WriteLine(workers[0].ToString() + "\t" + workers[1].ToString());
                }
                Connect.Close(); // закрыть соединение
            }
            return;
          }
    };

}
