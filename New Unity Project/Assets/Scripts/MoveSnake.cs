﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    private static int lifePoints;
    private int scoreCount;

    [SerializeField]
    private TextMesh points = null;
    [SerializeField]
    private Text textUI = null;
    public GameObject textWin;

    private Life life;
    private Obstacle obstacle;
        
    [SerializeField]
    private GameObject part = null;
    private GameObject newPart;
    private int snakeLength;
    bool IsWait = false;

    void Awake()
    {
        lifePoints = 4;
        scoreCount = 0;
        snakeLength = lifePoints;
    }
    private void Start()
    {
        AddBodySnake();
        
    }

    //Text visulization
    private void Update()
    {
        points.text = lifePoints.ToString();
        textUI.text = scoreCount.ToString();
        Move();
        if (IsWait)
        {
            moveSpeed = 0;
            if (lifePoints > 0 && obstacle.ObstaclePoints > 0)
            {
                lifePoints--;
                //points.text = lifePoints.ToString();
                //textUI.text = scoreCount.ToString();
            }
            if ( obstacle.ObstaclePoints == 0)
            {
                moveSpeed = 3f;
                IsWait = false;
            }
            else if(lifePoints == 0) 
            {
                SceneManager.LoadScene("Lose");
            }
        }


    }
    //Snake Movement
    
    private void Move()
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
            if(lifePoints > 0)
            {
                IsWait = true;
                //lifePoints -= obstacle.ObstaclePoints;
                
            }
            /*if (lifepoints <= 0)
            {
                lifepoints -= obstacle.ObstaclePoints;
                Destroy(gameObject);
                SceneManager.LoadScene("Lose");
                
            }*/
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
