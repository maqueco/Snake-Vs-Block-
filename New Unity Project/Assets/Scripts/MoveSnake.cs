using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    public List<GameObject> snakeParts; //To add more objects
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float speed = .1f;
    private Vector2 lastLocation;
    private static int lifepoints;
    private int scorecount;

    [SerializeField]
    private TextMesh points;
    [SerializeField]
    private Text textUI;
    Rigidbody2D rb;

    private Life life;
    private Obstacle obstacle;
        
    [SerializeField]
    private GameObject part;
    private GameObject newPart;
    private int snakeLength;

    void Start()
    {
        lifepoints = 4;
        scorecount = 0;
        snakeLength = lifepoints;
        AddBodySnake();
    }
    private void Awake()
    {
        obstacle = GameObject.FindWithTag("Block").GetComponent<Obstacle>();
    }

    private void LateUpdate()
    {
        points.text = lifepoints.ToString();
        textUI.text = scorecount.ToString();
    }

    private void FixedUpdate()
    {
        //Tener en cuenta hacer una guarda de seguridad para que no continue avanzando
        snakeParts[0].transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        lastLocation = snakeParts[0].transform.position;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x , lastLocation.y, Camera.main.transform.position.z);
        foreach (GameObject part in snakeParts)
        {
            if (part != snakeParts[0])
            {
                var newPosition = new Vector2(lastLocation.x, lastLocation.y - 0.4f);
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Lifes")
        {
            life = GameObject.FindWithTag("Lifes").GetComponent<Life>();
            Debug.Log("Detected"+ life.RndLife);
            lifepoints = lifepoints + life.RndLife;
            AddBodySnake();
        }
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("Detected" +obstacle.ObstaclePoints);
            scorecount += obstacle.ObstaclePoints;   
            if (lifepoints == 0)
            {
                Destroy(gameObject);
            }
            //Falta reiniciar lvl actual y puntaje, guardar puntaje global
        }
    }
    void AddBodySnake()
    {
    for (int i = 0; i < snakeLength; i++)
    {
        if (i == 0)
        {
            newPart = Instantiate(part, lastLocation, Quaternion.identity);
        }
        else
        {
            newPart = Instantiate(part, new Vector3(snakeParts[i - 1].transform.position.x, snakeParts[i - 1].transform.position.y - 1f, 0f), Quaternion.identity);
        }
        snakeParts.Add(newPart);
    }
    }
}
