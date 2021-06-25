using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBoost : ObjectPool
{
    public GameObject chooseBoost()
    {
        return chooseWeigther();
    }
}
