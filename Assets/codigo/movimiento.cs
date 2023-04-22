using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{

    public static float Speed = 3f;
    public bool ActivaSalto = true;
    public float Salto = 3.5f;
    public Animator controlAnimacion;
    private bool enElSuelo = false;
    private int saltosRestantes = 0;
    public static bool direccionBala = false;
    public static bool ParardireccionBala = false;
    //public parallax parallax;

    // Start is called before the first frame update
    void Start()
    {
        saltosRestantes = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(principalScript.Vida > 0){
            float H = Input.GetAxis("Horizontal") * Speed;
            H *= Time.deltaTime;
            transform.Translate(H, 0, 0);

            // INPUTS DE CONTROL NO PREDEFINIDOS
            if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
            {
                saltosRestantes--;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, Salto);
                Debug.Log("SALTOS RESTANTES: " + saltosRestantes);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector3(1, 1, 1);
                controlAnimacion.SetBool("activacamina", true);
                direccionBala = true;
                ParardireccionBala = false;
                //parallax.direccionPersonaje = "derecha";
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                controlAnimacion.SetBool("activacamina", true);
                direccionBala = false;
                ParardireccionBala = true;
                //parallax.direccionPersonaje = "izquierda";

            }
           


            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                controlAnimacion.SetBool("activacamina", false);
                ParardireccionBala = false;
                //parallax.direccionPersonaje = "parado";
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                controlAnimacion.SetBool("activacamina", false);
                ParardireccionBala = false; 
                //parallax.direccionPersonaje = "parado";
            }

            if (enElSuelo)
            {
                saltosRestantes = 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "suelo")
        {
            enElSuelo = true;
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "suelo")
        {
            enElSuelo = false;
        }
    }
}
