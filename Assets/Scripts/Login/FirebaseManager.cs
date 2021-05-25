using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase.Unity;
using TMPro;

public class FirebaseManager : MonoBehaviour
{

    public static FirebaseManager instance;

    Usuario usuario;

    FirestoreManager firestoreManager;

    [Header("Firebase")]
    public FirebaseAuth auth;
    public FirebaseUser user;
    [Space(5f)]

    [Header("Login References")]
    [SerializeField]
    private TMP_InputField loginEmail;
    [SerializeField]
    private TMP_InputField loginPassword;
    [SerializeField]
    private TMP_InputField loginOutputText;
    [SerializeField]
    private TMP_InputField loginError;
    [Space(5f)]

    [Header("Register References")]
    [SerializeField]
    private TMP_InputField registerUsername;
    [SerializeField]
    private TMP_InputField registerEmail;
    [SerializeField]
    private TMP_InputField registerPassword;
    [SerializeField]
    private TMP_InputField registerConfirmPassword;
    [SerializeField]
    private TMP_InputField registerOutputText;
    [SerializeField]
    private TMP_InputField registerError;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    private void Start()
    {
        firestoreManager = FirestoreManager.Instance;
        StartCoroutine(CheckAndFixDependancies());

    }

    private IEnumerator CheckAndFixDependancies()
    {
        var checkAndFixDependanciesTask = FirebaseApp.CheckAndFixDependenciesAsync();

        yield return new WaitUntil(predicate: () => checkAndFixDependanciesTask.IsCompleted);

        var dependancyResult = checkAndFixDependanciesTask.Result;

        if (dependancyResult == DependencyStatus.Available)
        {
            InitializeFirebase();
        }
        else
        {
            Debug.LogError("Error check dependencias");
        }
    }

    private void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        StartCoroutine(CheckAutoLogin());

        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    private IEnumerator CheckAutoLogin()
    {
        yield return new WaitForEndOfFrame();

        if (user != null)
        {
            var reloadUserTask = user.ReloadAsync();

            yield return new WaitUntil(predicate: () => reloadUserTask.IsCompleted);

            //AutoLogin();
        }
        else
        {
            AuthUIManager.instance.LoginScreen();
        }
    }

    private void AutoLogin()
    {
        if (user != null)
        {
            if (user.IsEmailVerified)
            {
                GameManager.instance.ChangeScene("Menu");
            }
            else
            {
                StartCoroutine(SendVerificationEmail());
            }

        }
    }

    private void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if (!signedIn && user != null)
            {
                Debug.Log("Sesión cerrada");
            }

            user = auth.CurrentUser;

            if (signedIn)
            {
                Debug.Log("");
            }
        }
    }

    public void ClearOutPuts()
    {
        loginOutputText.text = "";
        registerOutputText.text = "";
    }

    public void LoginButton()
    {
        StartCoroutine(LoginLogic(loginEmail.text, loginPassword.text));
    }

    public void RegisterButton()
    {
        StartCoroutine(RegisterLogic(registerUsername.text, registerEmail.text, registerPassword.text, registerConfirmPassword.text));
    }

    private IEnumerator LoginLogic(string _email, string _password)
    {
        Credential credential = EmailAuthProvider.GetCredential(_email, _password);

        var loginTask = auth.SignInWithCredentialAsync(credential);

        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            FirebaseException firebaseException = (FirebaseException)loginTask.Exception.GetBaseException();
            AuthError error = (AuthError)firebaseException.ErrorCode;
            string output = "Unknown Error, Please Try Again";


            switch (error)
            {
                case AuthError.MissingEmail:
                    output = "Introduzca correo electrónico";
                    break;
                case AuthError.MissingPassword:
                    output = "Introduzca contraseña";
                    break;
                case AuthError.InvalidEmail:
                    output = "Usuario incorrecto";
                    break;
                case AuthError.WrongPassword:
                    output = "Usuario incorrecto";
                    break;
                case AuthError.UserNotFound:
                    output = "No existe esta cuenta";
                    break;
            }
            loginError.text = output;
        }
        else
        {
            if (user.IsEmailVerified)
            {
                yield return new WaitForSeconds(1f);

                firestoreManager.cargarInformacionUsuario(user.UserId);

                GameManager.instance.ChangeScene("Menu");
            }
            else
            {

                StartCoroutine(SendVerificationEmail());
            }
        }
    }

    private IEnumerator RegisterLogic(string _username, string _email, string _password, string _confirmPassword)
    {
        if (_username == "")
        {
            registerError.text = "Introduzca un nombre de usuario";
        }
        else if (_password != _confirmPassword)
        {
            registerError.text = "Las contraseñas no coinciden";
        }
        else
        {
            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);

            yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

            if (registerTask.Exception != null)
            {
                FirebaseException firebaseException = (FirebaseException)registerTask.Exception.GetBaseException();
                AuthError error = (AuthError)firebaseException.ErrorCode;
                string output = "Unknown Error, Please Try Again";


                switch (error)
                {
                    case AuthError.InvalidEmail:
                        output = "Correo electrónico no válido";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        output = "Ya existe una cuenta con este correo";
                        break;
                    case AuthError.WeakPassword:
                        output = "Contraseña errónea";
                        break;
                    case AuthError.MissingEmail:
                        output = "Introduzca su correo electrónico";
                        break;
                    case AuthError.MissingPassword:
                        output = "Introduzca su contraseña";
                        break;
                }
                registerError.text = output;
            }
            else
            {
                UserProfile profile = new UserProfile
                {
                    DisplayName = _username,
                };

                var defaultUserTask = user.UpdateUserProfileAsync(profile);

                yield return new WaitUntil(predicate: () => defaultUserTask.IsCompleted);

                if (defaultUserTask.Exception != null)
                {
                    user.DeleteAsync();

                    FirebaseException firebaseException = (FirebaseException)registerTask.Exception.GetBaseException();
                    AuthError error = (AuthError)firebaseException.ErrorCode;
                    string output = "Error inesperado, vuélvalo a intentar";


                    switch (error)
                    {
                        case AuthError.Cancelled:
                            output = "Creación usuario cancelada";
                            break;
                        case AuthError.SessionExpired:
                            output = "La sesión ha caducado";
                            break;
                    }
                    registerError.text = output;
                }
                else
                {
                    Debug.Log("Usuario creado en firebase");

                    //Crear Documento del usuario en la colección "Users" de Firestore
                    usuario = new Usuario
                    {
                        Username = _username,
                        Email = _email,
                        Uid = user.UserId,
                        Monedas = 0,
                        Diamantes = 0
                    };


                    firestoreManager.guardarInformacionUsuario(user.UserId, usuario);

                    StartCoroutine(SendVerificationEmail());

                }
            }
        }

    }


    private IEnumerator SendVerificationEmail()
    {
        if (user != null)
        {
            var emailTask = user.SendEmailVerificationAsync();

            yield return new WaitUntil(predicate: () => emailTask.IsCompleted);

            if (emailTask.Exception != null)
            {
                FirebaseException firebaseException = (FirebaseException)emailTask.Exception.GetBaseException();
                AuthError error = (AuthError)firebaseException.ErrorCode;

                string output = "Error inesperado, vuélvalo a intentar";

                switch (error)
                {
                    case AuthError.Cancelled:
                        output = "Verificación correo cancelada";
                        break;
                    case AuthError.InvalidRecipientEmail:
                        output = "Correo electrónico no válido";
                        break;
                    case AuthError.TooManyRequests:
                        output = "Too many request";
                        break;
                }

                AuthUIManager.instance.AwaitVerification(false, user.Email, output);
            }
            else
            {
                AuthUIManager.instance.AwaitVerification(true, user.Email, null);
                Debug.Log("Correo enviado exitosamente");
            }
        }
    }

}
