using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Clase base para los estados de una máquina de estados finitos.
/// </summary>

public abstract class EstadoFSM : MonoBehaviour
{
    [SerializeField]
    string nombre = "";

    [SerializeField]
    bool inicial = false;

    protected MaquinaFSM maquina;

    public string Nombre { get => nombre; set => nombre = value; }
    public bool Inicial { get => inicial; set => inicial = value; }

    protected virtual void Awake()
    {
        maquina = GetComponent<MaquinaFSM>();
    }

    protected abstract void OnEnable();
    protected abstract void OnDisable();
}
