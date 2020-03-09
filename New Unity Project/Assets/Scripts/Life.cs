using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D lifeIcon)
    {
        if (lifeIcon.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
/*Falta agregar variable global para poder sumar las vidas que se agregen
*agregar texto con el numero de vida
*/ 