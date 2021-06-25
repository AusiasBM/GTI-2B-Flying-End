using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBotin : ObjectPool
{
    public GameObject chooseBotin()
    {
        return chooseWeigther();
    }
}
