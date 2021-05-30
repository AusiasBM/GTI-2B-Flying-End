using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity101.ControlObjetos
{

    [RequireComponent(typeof(Rigidbody))]
    public class MoverRigidbody : MonoBehaviour
    {

        public float fuerza = 4f;

        private new Rigidbody rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 impulso = new Vector3();
            impulso.x = Input.GetAxis("Horizontal");
            impulso.y = Input.GetAxis("Vertical");
            impulso *= fuerza;

            rigidbody.AddForce(impulso);
        }
    }

}