using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour
{

    public GameObject Personaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(){
        Debug.Log("HAS MUERTO!!!!");
        principalScript.Vida--;
        Personaje.transform.position = new Vector2 (-2.35f,-1.46f);
    }
}
