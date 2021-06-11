using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPiezas : ObjectPool
{
    public GameObject choosePieza()
    {
        return chooseWeigther();
    }
}
