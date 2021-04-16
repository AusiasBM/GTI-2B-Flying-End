using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    
    public Transform target;

    public Transform fondo1;
    public Transform fondo2;

    private float size;

    private Vector3 camaraTargetPos = new Vector3();
    private Vector3 fondo1TargetPos = new Vector3();
    private Vector3 fondo2TargetPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        size = fondo1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Cámara
        Vector3 targetPos = SetPos(camaraTargetPos, 0, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);

        //Fondo
        if (transform.position.y >= fondo2.position.y)
        {
            fondo1.position = SetPos(fondo1TargetPos, fondo2.position.y + size, fondo1.position.z);
            MoverFondo();
        }

        if (transform.position.y < fondo1.position.y)
        {
            fondo2.position = SetPos(fondo2TargetPos, fondo1.position.y - size, fondo2.position.z);
            MoverFondo();
        }
    }

    private void MoverFondo(){
        Transform temp = fondo1;
        fondo1 = fondo2;
        fondo2 = temp;
    }

    private Vector3 SetPos(Vector3 pos, float y, float z){
        pos.y = y;
        pos.z = z;
        return pos;
    }
}
