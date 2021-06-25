using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity101.ControlObjetos
{

    [RequireComponent(typeof(Rigidbody))]
    public class EfectoViento : MonoBehaviour
    {
        public float fuerzaViento = 0.1f;

        private float vientoX = 0f;
        private float vientoY = 0f;

        private static EfectoViento instance;
        public static EfectoViento Instance { get => instance; }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;

            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        private new Rigidbody rigidbody;
        Jugador jugador;

        // Start is called before the first frame update
        void Start()
        {
            jugador = Jugador.Instance;
            rigidbody = GetComponent<Rigidbody>();
            Invoke("viento", Random.Range(0f, 2f));
        }

        void FixedUpdate()
        {
            Vector3 viento = new Vector3();
            viento.x = vientoX;
            viento.y = vientoY;
            

            if (jugador.isTormenta)
            {
                viento *= (fuerzaViento*3);
            }
            else
            {
                viento *= fuerzaViento;
            }

            rigidbody.AddForce(viento);

        }

        // Update is called once per frame
        void viento()
        {

            vientoX = Random.Range(-3f, 3f);
            vientoY = Random.Range(-2f, 2f);

            Invoke("viento", Random.Range(3f, 5f));

        }
    }

}