public interface ICounterValueContainer
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
     * This script is not assignable in the inspector.
     * This is a programming interface that must be implemented by the Script from which we want to read the value to be displayed on the screen.
     * When implementing it we must define in the Script a method called GetValue() that returns an integer value.
     * 
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
    * Este Script no se asigna en el inspector.
    * Esta es una interfaz de programación que debe ser implementada por el Script del que queremos leer el valor a mostrar en pantalla.
    * Al implementarla deberemos definir en el Script un método llamado GetValue() que devuelva un valor entero.
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
     * Dieses Skript wird im Inspektor nicht zugewiesen.
     * Dies ist eine Programmierschnittstelle, die von dem Skript implementiert werden muss, aus dem wir den Wert lesen wollen, der auf dem Bildschirm angezeigt werden soll.
     * Bei der Implementierung müssen wir im Script eine Methode namens GetValue() definieren, die einen Integer Wert zurückgibt.
     * 
     */

    int GetValue(string s);

}
