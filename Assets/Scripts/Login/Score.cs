using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Score
{
    [FirestoreProperty]
    public string Username { get; set; }

    [FirestoreProperty]
    public string Uid { get; set; }

    [FirestoreProperty]
    public int Puntos { get; set; }
}
