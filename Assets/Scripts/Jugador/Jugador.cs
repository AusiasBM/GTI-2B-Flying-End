using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float ms = 0.5f;
    public Transform LimiteDerecha;
    public Transform LimiteIzquierda;
    public Transform LimiteUp;
    public Transform LimiteDown;


    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate(){

        float newX = ms * Input.GetAxis(GameConstants.AXE_H) * Time.deltaTime;
        float newY = ms * Input.GetAxis(GameConstants.AXE_V) * Time.deltaTime;

        //Limitar movimientos en el eje X
        if (transform.position.x + newX > LimiteIzquierda.position.x
            && transform.position.x + newX < LimiteDerecha.position.x)
        {
            transform.Translate(newX, 0, 0);
        }


        //Limitar movimientos eje Y
        if (transform.position.y + newY > LimiteDown.position.y
            && transform.position.y + newY < LimiteUp.position.y)
        {
            transform.Translate(0, newY, 0);
        }


        //Evitar que salga de los límites por posibles colisiones
        //Eje z
        if (transform.position.z > 0f
            || transform.position.z < -0.2f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        //Eje x
        if (transform.position.x > LimiteDerecha.position.x)
        {
            transform.position = new Vector3(LimiteDerecha.position.x, transform.position.y, 0);
        }else if(transform.position.x < LimiteIzquierda.position.x)
        {
            transform.position = new Vector3(LimiteIzquierda.position.x, transform.position.y, 0);
        }

        //Eje y
        if (transform.position.y > LimiteUp.position.y)
        {
            transform.position = new Vector3(transform.position.x, LimiteUp.position.y, 0);
        }
        else if (transform.position.y < LimiteDown.position.y)
        {
            transform.position = new Vector3(transform.position.x, LimiteDown.position.y, 0);
        }




        /*if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > limLeft){
            Debug.Log("Left");
            transform.Translate(Vector3.left * ms * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < limRight){
            Debug.Log("Right");
            transform.Translate(Vector3.right * ms * Time.deltaTime);
        }*/

    }
}

public class GameConstants
{
    public const string AXE_H = "Horizontal";
    public const string AXE_V = "Vertical";

}

