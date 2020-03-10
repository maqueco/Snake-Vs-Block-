using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int obstaclePoints;
    public TextMesh textcounter;

    public int ObstaclePoints
        {
            get { return obstaclePoints; }
        }

    private void Start()
    {
        obstaclePoints = Random.Range(1, 50);
    }
    void Update()
    {
        textcounter.text = obstaclePoints.ToString();
    }


}
//Falta que se descuenten al colisionar 
