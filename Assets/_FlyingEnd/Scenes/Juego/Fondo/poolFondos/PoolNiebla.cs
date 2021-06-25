using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolNiebla : ObjectPool
{
    public GameObject chooseNiebla()
    {
        return chooseWeigther();
    }
}
