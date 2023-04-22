using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class parallax : MonoBehaviour
{
    public float speed = 1.2f; // velocidad de movimiento del fondo
    private float xPosition; // posición actual del fondo

    private void Start()
    {
        xPosition = transform.position.x; // obtener la posición inicial del fondo
    }

    private void Update()
    {
        // mover el fondo a la izquierda a una velocidad determinada
        xPosition -= speed * Time.deltaTime;
        // actualizar la posición del fondo
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

        // si el fondo se mueve fuera de la pantalla, lo movemos al final de la imagen
        if (transform.position.x < -19.2f) // 19.2 es el ancho de la imagen de fondo
        {
            xPosition += 19.2f * 2f;
        }
    }
}