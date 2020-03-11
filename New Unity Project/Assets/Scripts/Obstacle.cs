using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int obstaclePoints;
    [SerializeField]
    private TextMesh textcounter = null;
    bool IsSmash = false;
    public int ObstaclePoints

        {
            get { return obstaclePoints; }
        }

    private void Start()
    {
        obstaclePoints = Random.Range(1, 15);
    }
    void Update()
    {
        textcounter.text = obstaclePoints.ToString();
        if (IsSmash)
        {
            if (obstaclePoints > 0)
            {
                obstaclePoints -= 1;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (obstaclePoints >= 0)
            {
                IsSmash = true;
            }
            Invoke("waitToDestroy", .2f);
        }
    }

    private void waitToDestroy()
    {
        Destroy(gameObject);
    }
}
