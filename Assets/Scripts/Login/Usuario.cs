using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Usuario
{
    [FirestoreProperty]
    public string Username { get; set; }

    [FirestoreProperty]
    public string Email { get; set; }

    [FirestoreProperty]
    public string Uid { get; set; }

    [FirestoreProperty]
    public int Monedas { get; set; }

    [FirestoreProperty]
    public int Diamantes { get; set; }

}