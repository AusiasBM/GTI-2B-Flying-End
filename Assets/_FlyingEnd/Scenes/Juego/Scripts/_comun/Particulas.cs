using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    GameObject particulas;
    private static Particulas instance;
    public static Particulas Instance { get => instance; }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generarParticulas(GameObject tipoParticulas, Transform objeto)
    {
        Vector3 pos = new Vector3(objeto.transform.position.x, objeto.transform.position.y, 0);
        particulas = Instantiate(tipoParticulas, pos, Quaternion.identity);
        StartCoroutine(delay(particulas, 1));
    }

    IEnumerator delay(GameObject particulas, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(particulas);
    }
}
