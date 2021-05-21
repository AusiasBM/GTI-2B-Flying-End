using System;
using TMPro;
using UnityEngine;

public class AuthUIManager : MonoBehaviour
{

    public static AuthUIManager instance;

    [Header("References")]
    [SerializeField]
    private GameObject checkingForAccountUI;
    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject registerUI;
    [SerializeField]
    private GameObject verifyEmailUI;
    [SerializeField]
    private TMP_Text verifyEmailText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void ClearUI()
    {
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        verifyEmailUI.SetActive(false);
        FirebaseManager.instance.ClearOutPuts();
        checkingForAccountUI.SetActive(false);
    }

    public void LoginScreen()
    {
        ClearUI();
        loginUI.SetActive(true);
    }

    public void RegisterScreen()
    {
        ClearUI();
        registerUI.SetActive(true);
    }

    public static implicit operator AuthUIManager(FirebaseManager v)
    {
        throw new NotImplementedException();
    }
   public void AwaitVerification(bool _emailSent, string _email, string _output)
    {
        ClearUI();
        verifyEmailUI.SetActive(true);
        if (_emailSent)
        {
            verifyEmailText.text = $"Correo enviado!\nPor favor, verifique {_email}";
        }
        else
        {
            verifyEmailText.text = $"Correo no enviado: {_output}\nPor favor, verifique {_email}";
        }
    }
}
