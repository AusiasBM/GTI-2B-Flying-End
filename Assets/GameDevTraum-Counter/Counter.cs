using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    /**ENGLISH
     * 
     * Solution by GameDevTraum
     * 
     * Website: https://gamedevtraum.com/en/
     * Channel: https://youtube.com/c/GameDevTraum
     * 
     * Visit the website to find more articles, solutions and assets
     * 
     * This script reads a value from other Script and increments or decrements the counter's value frame by frame with an adjustable rate.
     * It must be attached to a Text indicator in the Canvas.
     * The indicator could be a normal UI Text or a TextMesh PRO Text.
     * If you are using Text Mesh PRO, check the "useTextMeshPro" checkbox in the inspector.
     * You can change the increment of the counter in the inspector or using the SetIncrement() method.
     */

    /**ESPAÑOL
     * 
     * Solución por GameDevTraum
     * 
     * Artículo: https://gamedevtraum.com/es/desarrollo-de-videojuegos/tutoriales-y-soluciones-unity/como-hacer-un-contador-frame-a-frame-en-unity/
     * Página: https://gamedevtraum.com/es/
     * Canal: https://youtube.com/c/GameDevTraum
     * 
     * Visita la página para encontrar más soluciones, Assets y artículos
     * 
     * Este Script lee un valor desde otro Script e incrementa o decrementa el valor del contador frame a frame en una proporción ajustable.
     * Debe estar asignado a un indicador tipo Texto en el Canvas. 
     * El indicador puede ser un texto normal o un Text Mesh PRO.
     * Si estás usando Text Mesh PRO, tilda la casilla "useTextMeshPro" en el inspector.
     * Puedes cambiar la tasa de cambio del contador desde el inspector o usando el método SetIncrement().
     */

    /**DEUTSCH
     * 
     * Lösung von GameDevTraum
     * 
     * Webseite: https://gamedevtraum.com/de/
     * Kanal: https://youtube.com/c/GameDevTraum
     * 
     * Besuch die Website, um weitere Artikel, Lösungen und Hilfsmittel zu finden. 
     * 
     * Dieses Skript liest einen Wert aus einem anderen Skript und erhöht oder verringert den Zählerwert Frame für Frame in einem einstellbaren Verhältnis.
     * Er muss einem Texttyp-Indikator im Canvas zugewiesen werden. 
     * Der Indikator kann ein normaler Text oder ein Textmesh PRO sein.
     * Wenn du Text Mesh PRO verwendest, aktiviere das Kästchen "useTextMeshPro" im Inspektor.
     * Du kannst die Zähleränderungsrate vom Inspektor aus oder mit der Methode SetIncrement() ändern.
     */

    public GameObject valueManagerObject;
    public string variableName;
    private ICounterValueContainer valueManager; //This is the reference of the object that has the value, change with the name of your script

    public bool useTextMeshPro;
    public float increment;

    private Text scoreIndicator;
    private TextMeshProUGUI scoreIndicatorTMPro;
    private float currentValue;

   

    void Start()
    {
        valueManager = valueManagerObject.GetComponent<ICounterValueContainer>();
        if (useTextMeshPro)
        {
            scoreIndicatorTMPro = GetComponent<TextMeshProUGUI>();
        }
        else
        {
            scoreIndicator = GetComponent<Text>();
        }

    }


    private void FixedUpdate()
    {
        RefreshCounter();
    }


    private void RefreshCounter()
    {
        int targetValue = valueManager.GetValue(variableName);

        if (currentValue != targetValue)
        {
            //In this region you can make actions when the counter changes its value, for example play a sound

            if (currentValue < targetValue)
            {
                currentValue += increment;
                if (currentValue > targetValue)
                {
                    currentValue = targetValue;
                }
            }
            else
            {
                currentValue -= increment;
                if (currentValue < targetValue)
                {
                    currentValue = targetValue;
                }
            }
        }
        WriteCounter((int)currentValue);

    }

    private void WriteCounter(int s)
    {
        if (useTextMeshPro)
        {
            scoreIndicatorTMPro.text = s.ToString();
        }
        else
        {
            scoreIndicator.text = s.ToString();
        }
    }

    public void SetIncrement(float f)
    {
        increment = f;
    }


}
