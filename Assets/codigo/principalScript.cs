using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class principalScript : MonoBehaviour
{

    public static int Score = 0;
    public static int Vida;
    public static int VidaMaxima = 3;
    public static int Enemigos = 0;
    public static int EnemigosTotal;
    public static string ScoreTotal;
    public GUISkin miSkin;
    public GUIStyle VidaTextStyle;
    int Anchopantalla;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Vida: " + Vida);
        Debug.Log("Score: " + Score);
        Debug.Log("Enemigos: " + Enemigos);
        Vida = VidaMaxima;
        Enemigos = EnemigosTotal;

    }

    // Update is called once per frame
    void Update()
    {
        Anchopantalla = Screen.width/2;
    }

    void OnGUI()
    {
        GUI.skin = miSkin;
        GUI.Label(new Rect(20, 20, 150, 80), "Vida: " + Vida.ToString() + "/" + VidaMaxima.ToString(), "estilojuego");
        GUI.Label(new Rect(20, 40, 150, 80), "Score: " + Score.ToString(),"estilojuego");
        GUI.Label(new Rect(20, 60, 150, 80), "Enemigos: " + Enemigos.ToString(),"estilojuego");
        GUI.Label(new Rect(Anchopantalla, 20, 200, 100), "Nombre Juego", "estilojitulo");

    }
    
}
