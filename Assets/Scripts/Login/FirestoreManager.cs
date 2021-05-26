using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using System;
using System.Globalization;

public class FirestoreManager : MonoBehaviour
{

    FirebaseFirestore db;
    public Usuario user;
    public Score score;


    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    private static FirestoreManager instance;
    public static FirestoreManager Instance { get => instance; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HOLA2");
        db = FirebaseFirestore.DefaultInstance;
    }

    public void guardarInformacionUsuario(string uid, Usuario user)
    {
        db.Collection("Users").Document(uid).SetAsync(user).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Guardado");
            }
            else
            {
                Debug.Log("Error al guardar");
            }
        });
    }

    public void cargarInformacionUsuario(string uid)
    {

        db.Collection("Users").Document(uid).GetSnapshotAsync().ContinueWith((task) =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    //Debug.Log("Document data for {0} document:" + snapshot.Id);
                    user = snapshot.ConvertTo<Usuario>();
                    Debug.Log(string.Format("Name: {0}", user.Username));
                }
                else
                {
                    // Debug.Log("Document {0} does not exist!" + snapshot.Id);
                }
            }


        });

    }

    public void guardarPuntosUsuario(Score score)
    {
        long t = CurrentTimeMillis();
        db.Collection("Scores").Document(t.ToString()).SetAsync(score).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Puntuacion");
            }
            else
            {
                Debug.Log("Error al guardar Puntuacion");
            }
        });
    }

    public long CurrentTimeMillis()
    {
        DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (long) (DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
    }

}

