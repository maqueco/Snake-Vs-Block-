using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private int obstaclePoints = 0;
    public Text textcounter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateScore (int points)
    {
        Debug.Log("updateScore"+ points +"y" + obstaclePoints);
        obstaclePoints += points;

    }
}
/*Falta que el bloque tenga vidas y se descuenten al colisionar 
 *Interfaz de texto del bloque
 */ 
