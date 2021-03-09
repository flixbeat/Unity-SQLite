using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class SQLiteConnection
{
    /*
    sql setup guide: https://answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html
    
    1. Create new folder under Assets Folder Rename it Plugins.
    2. Copy sqlite3.def and sqlite3.dll into Assets/Plugins in your unity project .You can download these files here http://www.sqlite.org/download.html for windows (Precompiled Binaries for Windows)
    3. Download SQLite Browser http://sourceforge.net/projects/sqlitebrowser/ or http://sqliteadmin.orbmu2k.de/ download SQLite Administrator tool
    4. Create Database in Assets folder in your unity project using SQLite Browser.
    5. Copy System.Data.dll and Mono.Data.Sqlite.dll from **C:\Program Files (x86)\Unity \Editor\Data\Mono\lib\mono\2.0* and paste them in your Assets/Plugins* folder in your unity project.
    6. Add these namespaces using Mono.Data.Sqlite; using System.Data; using System;
    7. string conn= "URI=file:" + Application.dataPath + "/PickAndPlaceDatabase.s3db";
        Replace PickAndPlaceDatabase.s3db with your database name
        void Start () {
    */

    IDbConnection idbcon; // class for database connection
    IDbCommand idbcmd; // class for executing sql commands
    string dbPath;

    public SQLiteConnection() {
        ConnectToDB();
    }

    public void ConnectToDB()
    {
        dbPath = "URI=file:" + Application.streamingAssetsPath + "/Database/db_game.db";
        idbcon = (IDbConnection)new SqliteConnection(dbPath);
        idbcon.Open(); //Open connection to the database.
        idbcmd = idbcon.CreateCommand();
    }

    // execute select statements
    public IDataReader ExecuteReader(string sql)
    {
        idbcmd.CommandText = sql;
        IDataReader reader = idbcmd.ExecuteReader();
        return reader;
    }

    public void CloseReader(IDataReader reader)
    {
        reader.Close();
        reader = null;
        idbcmd.Dispose();
        idbcmd = null;
    }

    public void CloseDBConnection()
    {
        idbcon.Close();
        idbcon = null;
    }
}
