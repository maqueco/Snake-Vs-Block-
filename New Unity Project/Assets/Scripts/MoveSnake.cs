using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    public List<GameObject> snakeParts; //To add more objects
    [SerializeField]
    private float moveSpeed = 1f; //Speed in Y axis
    [SerializeField]
    private float speed = .1f; // Speed in X axis
    private Vector2 lastLocation;  // last location from Snake
    private static int lifePoints; // Snake life points
    private int scoreCount; // Score

    [SerializeField]
    private TextMesh points = null; // Text for Snake life points
    [SerializeField]
    private Text textUI = null; // Text for Score
    public GameObject textWin; // To Activate Win Text

    private Life life; // Class life
    private Obstacle obstacle; // Class obstacle
        
    [SerializeField]
    private GameObject part = null; // Body Snake
    private GameObject newPart; // Body Snake
    private int snakeLength;
    bool IsWait = false;

    void Awake()
    {
        //Some inicializations
        lifePoints = 4;
        scoreCount = 0;
        snakeLength = lifePoints;
    }
    private void Start()
    {
        AddBodySnake();
        
    }

    private void Update()
    {
        //Text visulization
        points.text = lifePoints.ToString();
        textUI.text = scoreCount.ToString();
        Move();
        //Stop snake,substract points and continue or lose
        if (IsWait)
        {
            moveSpeed = 0;
            if (lifePoints > 0 && obstacle.ObstaclePoints > 0)
            {
                lifePoints--;
            }
            if ( obstacle.ObstaclePoints == 0)
            {
                moveSpeed = 3f;
                IsWait = false;
            }
            else if(lifePoints <= 0) 
            {
                SceneManager.LoadScene("Lose");
            }
        }


    }
    
    //Snake Movement
    private void Move()
    {
        //Position for Snake Head
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
        //Move in X
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
        //PickUp
        if (other.gameObject.tag == "Lifes")
        {
            life = GameObject.FindWithTag("Lifes").GetComponent<Life>();
            lifePoints = lifePoints + life.RndLife;
            AddBodySnake();
        }
        if(other.gameObject.tag == "FinishLine")
        {
            textWin.gameObject.SetActive(true);
        }

        //Collision whit block
        if (other.gameObject.tag == "Block")
        {
            obstacle = GameObject.FindWithTag("Block").GetComponent<Obstacle>();
            scoreCount += obstacle.ObstaclePoints;
            IsWait = true;

        }
    }
    //Spawner 
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
