using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolNubesFondo : ObjectPool
{
    public GameObject chooseNube()
    {
        return chooseWeigther();
    }


}
