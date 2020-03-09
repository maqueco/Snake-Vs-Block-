using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    private float moveSpeed = 1f;
    private float speed = .1f;
    public List<GameObject> snakeParts; //To add more objects
    private Vector2 lastLocation;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        snakeParts[0].transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        lastLocation = snakeParts[0].transform.position;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x , lastLocation.y, Camera.main.transform.position.z);
        foreach (GameObject part in snakeParts)
        {
            if (part != snakeParts[0])
            {
                var newPosition = new Vector2(lastLocation.x, lastLocation.y - 1);
                lastLocation = part.transform.position;
                part.transform.position = newPosition;
            }
        }

            if (Input.GetAxis("Horizontal") > 0)
            {
                if (transform.position.x < 3)
                {
                    snakeParts[0].transform.Translate(Vector2.right * speed);
                }
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                if(transform.position.x > -3)
                {
                    snakeParts[0].transform.Translate(Vector2.left * speed);
                }
            }
        //}
    }
}
