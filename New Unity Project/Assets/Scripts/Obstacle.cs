using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int obstaclePoints;
    [SerializeField]
    private TextMesh textcounter;

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
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (obstaclePoints <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }*/
}
