using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int rndlife;
    public TextMesh lifetext;

    private void Start()
    {
        rndlife = Random.Range(1, 10);
    }

    void Update()
    {
        lifetext.text = rndlife.ToString();
    }
    private void OnTriggerEnter2D(Collider2D lifeIcon)
    {
        if (lifeIcon.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
/*Falta sumar las vidas que se agregen
*agregar texto con el numero de vida
*/ 