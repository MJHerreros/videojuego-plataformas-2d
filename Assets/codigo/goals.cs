using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(){
        principalScript.Score +=5;
        Destroy(this.gameObject, 0.5f);
    }
}
