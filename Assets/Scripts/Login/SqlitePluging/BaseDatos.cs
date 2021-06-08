using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using System.Data;
using System;

[DefaultExecutionOrder(-1000)]
public class BaseDatos : MonoBehaviour
{
    string conn;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    IDataReader dbr;
    public static BaseDatos instance;

    string DATABASE_NAME = "/flyingEnd.db";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
        else
        {
            DestroyImmediate(gameObject);
        }
       
    }


    void Start()
    {
        string filepath = Application.dataPath + DATABASE_NAME;
        conn = "URI=file:" + filepath;
        Debug.Log(conn);
        dbconn = new SqliteConnection(conn);
        CreateTableUsers();

    }
    private void CreateTableUsers()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "CREATE TABLE IF NOT EXISTS [Users] (" +
                "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                "[username] VARCHAR(255)  NOT NULL, " +
                "[monedas] INTEGER DEFAULT '0' NOT NULL, " +
                "[diamantes] INTEGER DEFAULT '0' NOT NULL, " +
                "[distanciaMaxima] INTEGER DEFAULT '0' NOT NULL )";

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    public void addUser(User user)
    {
        
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "INSERT INTO [Users] (" +
                "[username], " +
                "[monedas], " +
                "[diamantes], " +
                "[distanciaMaxima])" + " VALUES('"
                + user.username + "', '"
                + user.monedas + "', '"
                + user.diamantes + "', '"
                + user.distanciaMaxima + "' )";

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
        Debug.Log("Usuario creado");
    }

    public User getUser(string username)
    {
        try
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "SELECT * FROM [Users] WHERE username = '" +
                    username + "'";

                dbcmd.CommandText = sqlQuery;


                dbr = dbcmd.ExecuteReader();
                while (dbr.Read())
                {

                    User user = new User();
                    user.id = Int32.Parse(dbr[0].ToString());
                    user.username = dbr[1].ToString();
                    user.monedas = Int32.Parse(dbr[2].ToString());
                    user.diamantes = Int32.Parse(dbr[3].ToString());
                    user.distanciaMaxima = Int32.Parse(dbr[4].ToString());
                    return user;
                }

                dbconn.Close();
            }

            Debug.Log("No existe un usuario con ese nombre");
            User u = new User("");
            return u;
        }
        catch
        {
            Debug.Log("Error al cargar el usuario");
            User u = new User("");
            return u;
        }
        
    }

    public List<User> getAllUsers()
    {
        try
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "SELECT * FROM [Users] ";

                dbcmd.CommandText = sqlQuery;


                dbr = dbcmd.ExecuteReader();

                List<User> users = new List<User>();
                while (dbr.Read())
                {

                    User user = new User();
                    user.id = Int32.Parse(dbr[0].ToString());
                    user.username = dbr[1].ToString();
                    user.monedas = Int32.Parse(dbr[2].ToString());
                    user.diamantes = Int32.Parse(dbr[3].ToString());
                    user.distanciaMaxima = Int32.Parse(dbr[4].ToString());
                    users.Add(user);
                }

                return users;
                dbconn.Close();
            }

            return null;
        }
        catch
        {
            Debug.Log("Error al cargar los usuarios");
            return null;
        }

    }



    public void updateUser(User user)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "UPDATE [Users] SET " +
                " monedas =  " + user.monedas +
                ", diamantes = " + user.diamantes +
                ", distanciaMaxima = " + user.distanciaMaxima + " WHERE id = '" +
                user.id + "'";

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
      
    }

    public void deleteUser(string username)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "DELETE FROM [Users] WHERE username = '" +
                    username + "'";

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

    }
}
