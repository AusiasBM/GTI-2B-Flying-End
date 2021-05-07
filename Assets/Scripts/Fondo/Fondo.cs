using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public float velocidad = 3f;
    public float posRecolocar = -43f;
    public GameObject fondo1;
    public GameObject fondo2;
    private bool estaFondo2 = false;
    private bool estaFondo1 = false;

    public GameObject CarrilDownNiebla;

    public Sprite sprite1;

    private SpriteRenderer spriteRenderer1;

    public Sprite sprite2;

    private SpriteRenderer spriteRenderer2;


    void Start()
    {
        estaFondo1 = true;
        spriteRenderer1 = fondo2.GetComponent<SpriteRenderer>();
        spriteRenderer2 = fondo1.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
        fondo1.transform.Translate(fondo1.transform.up * velocidad * Time.deltaTime);
        fondo2.transform.Translate(fondo2.transform.up * velocidad * Time.deltaTime);

        GameController.ScoreMetros += 0.1f;

        if (fondo2.transform.position.y >= 0 && !estaFondo2)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo1.transform.Translate(0, posRecolocar, 0);
            //fondo1.position = new Vector3(0, posRecolocar, fondo1.position.z);
            estaFondo2 = true;
            estaFondo1 = false;
            //spriteRenderer1.sprite = sprite1;

        }

        if (fondo1.transform.position.y >= 0 && !estaFondo1)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo2.transform.Translate(0, posRecolocar, 0);
            estaFondo1 = true;
            estaFondo2 = false;
            //spriteRenderer2.sprite = sprite2;
        }

        if (GameController.ScoreMetros >= 10f && GameController.ScoreMetros <= 20f)
        {
            CarrilDownNiebla.GetComponent<CrearNiebla>().activo = true;
        }
        else
        {
            try
            {
                CarrilDownNiebla.GetComponent<CrearNiebla>().activo = false;
            }
            catch
            {
                //Destruir objeto cuando se ponga la escena de Game Over
                Destroy(gameObject);
            }
            
        }
    }

}
