using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WebSaveLoad : MonoBehaviour, IDataSaveLoad
{
    public string urlBase;
    public UnityEvent onLoad;
    public UnityEvent onSave;
    public UnityEvent onError;
    public string Error { get; private set; } = "";
    object _data;
    public Distancia[] distancias;
    public bool completado;

    public void Load<T>(string resource, ref T data)
    {
        _data = data;
        StartCoroutine(GetRequestRanking(resource));
    }
    public void Save(string resource, object data)
    {
        StartCoroutine(PostRequestRanking(resource, data));
    }

    public void Clear(string resource)
    {

    }

    IEnumerator GetRequestRanking(string resource)
    {
        Error = ""; 
        using (UnityWebRequest webRequest = UnityWebRequest.Get(urlBase + resource))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Error = webRequest.error;
                completado = false;
                onError?.Invoke();
            }
            else
            {
                distancias = JSONHelper.getJsonArray<Distancia>(webRequest.downloadHandler.text);
                completado = true;
                onLoad?.Invoke();
            }
        }
    }

    IEnumerator PostRequestRanking(string resource, object data)
    {
        Error = "";
        WWWForm form = new WWWForm();
        
        form.AddField("data", JsonUtility.ToJson(data));
        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlBase + resource + "/", form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Error = webRequest.error;
                onError?.Invoke();
            }
            else
            {
                Debug.Log(JsonUtility.ToJson(data));
                onSave?.Invoke();
                
            }
        }
    }
}
