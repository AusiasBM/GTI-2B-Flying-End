using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class FirestoreManager : MonoBehaviour
{

    FirebaseFirestore db;
    public Usuario user;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
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
}
