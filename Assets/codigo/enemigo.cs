using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour{

    public string clonBala;
    float SpeedEnemigo = 0.6f;
    float DistanciaPlayer = 4f;
    Vector3 posicionInicial;
    public GameObject player;
   

   void Start(){
    player = GameObject.FindGameObjectWithTag("Player");
    posicionInicial = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col){
        clonBala = col.gameObject.name;

        if(clonBala == "balafuego(Clone)"){
            principalScript.Enemigos++;
            Destroy(this.gameObject, 0.3f);
        }
        if(clonBala == "personaje"){
            principalScript.Vida--;
            player.transform.position = new Vector2 (-2.35f,-1.46f);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
      Vector3 Objetivo = posicionInicial;
      float distancia = Vector3.Distance(player.transform.position,transform.position);

      if(distancia < DistanciaPlayer){
        Objetivo = player.transform.position;
      }

      float Velocidafija = SpeedEnemigo*Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position,Objetivo,Velocidafija);
      Debug.DrawLine(transform.position, Objetivo, Color.green);
    }
}
