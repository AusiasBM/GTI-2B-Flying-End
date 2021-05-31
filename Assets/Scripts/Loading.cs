using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    FirestoreManager firestoreManager;
    public Image barraLoading;

    [Range(0, 1)]
    [SerializeField]
    private float carga = 0f;

    // Start is called before the first frame update
    void Start()
    {
        firestoreManager = FirestoreManager.Instance;
        barraLoading.fillAmount = carga;
    }

    // Update is called once per frame
    void Update()
    {
        loading();
        if(carga >= 0.99f)
        {
            //Poner a 0.1f para que al volver al valor inicial la barra no haga efecto de parpadeo
            barraLoading.fillAmount = 0.1f;
            carga = 0.1f;
        }

        if(firestoreManager.user != null)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void loading()
    {
        carga += 0.0075f;
        barraLoading.fillAmount = carga;
    }

}