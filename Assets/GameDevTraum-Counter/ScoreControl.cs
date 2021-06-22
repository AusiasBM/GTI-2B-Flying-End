using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour , ICounterValueContainer
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
     * This Script is responsible for managing a certain value, for example a score.
     * It implements the ICounterValueContainer interface, therefore it must have a GetValue() method defined.
     * GetValue() returns an integer with the value that the counter must show.
     * The idea is not to write the counter directly, but the counter reads the value to be displayed from this script and writes itself.
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
     * Este Script se encarga de administrar un determinado valor, por ejemplo una puntuación.
     * Implementa la interfaz ICounterValueContainer, por lo tanto debe tener un método definido que se llame GetValue() y que retorne un valor entero.
     * La idea no es escribir directamente el contador, sino que el contador se encarga de leer el valor que debe mostrar de este script y luego se escribe a sí mismo.
     * 
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
     * Dieses Skript ist zuständig dafür, einen bestimmten Wert, zum Beispiel eine Punktzahl, zu verwalten.
     * Es implementiert die ICounterValueContainer-Schnittstelle, daher muss eine GetValue()-Methode definiert sein.
     * GetValue() gibt eine Integer-Zahl mit dem Wert zurück, den der Zähler anzeigen muss.
     * Die Idee besteht nicht darin, den Counter direkt zu schreiben, sondern der Counter liest den anzuzeigenden Wert aus diesem Skript und schreibt sich selbst.
     */

    public InputField input;
    public GameController gameController;
    public int moneda;
    public int diamante;
    public int metro;


    public void SendScore()
    {            
        bool parseOk = int.TryParse(input.text,out moneda);
        metro = (int)(moneda * Random.Range(1f,2f));
    }

    public int GetValue(string s)
    {
        //You can use the s string in a switch to return different values from the same script
        switch (s)
        {
            case "metros": return metro;
                          break;

            case "monedas": return gameController.Score;
                              break;
            case "diamantes":
                return gameController.ScoreDiamante;
                break;

            default: return 0;
                     break;

        }


    }


}
