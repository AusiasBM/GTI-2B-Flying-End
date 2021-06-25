using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolNubesElectricas : ObjectPool
{
    public GameObject chooseNube()
    {
        return chooseWeigther();
    }
}
