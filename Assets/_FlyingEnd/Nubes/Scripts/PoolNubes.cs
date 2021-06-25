using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolNubes : ObjectPool
{
    public GameObject chooseNube()
    {
        return chooseWeigther();
    }
}
