using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> bodySnake = null; //body of the snake
    [SerializeField]
    private GameObject snakeTail = null; //tail for instantiate
    private GameObject nextSnakeTail; //new tail

    [SerializeField]
    private int lifePointsSnake = 4;  // starting minimun life
    [SerializeField]
    private float moveSpeedY = 1f; // moveSpeedY for movement in .y

    [SerializeField]
    private TextMesh snakeLifeText;      // Player Life
    private TextMesh boxLifeText;  // Cube Life

    private bool needWait = false;  // Just for a "wait instance"
    private int auxLifeSmash;   // to save the current random  life smash from the cube
    private int auxPick;      // to save the current random  life smash from the pick
    private Vector2 lastPosition;  // saving
    private GameObject aux;  // just for help
    private PickUpLife pickUpLife; // to save the current PickUp
    private ObstacleBox obstacelBox;   // to save the curren cube



    private void Awake()
    {
        // Initializations, getting components and setting the UI text
        obstacelBox = GameObject.FindWithTag("Cube").GetComponent<ObstacleBox>();  
        pickUpLife = GameObject.FindWithTag("LifePick").GetComponent<PickUpLife>();
        boxLifeText = GameObject.FindWithTag("Number").GetComponent<TextMesh>();
        snakeLifeText = GameObject.FindWithTag("Life").GetComponent<TextMesh>();
        snakeLifeText.text = lifePointsSnake.ToString();
        auxLifeSmash = obstacelBox.LifeSmasher;
        boxLifeText.text = auxLifeSmash.ToString();
        auxPick = pickUpLife.LifePickValue;
    }
    private void Start()
    {
        AddToTail(); //starting the snake tail
    }
        

    private void Update()
    {
        Move();
        // Checking if wait is needed
        if (needWait)
        {
            //For make wait in a cube
            moveSpeedY = 0;
            if (lifePointsSnake > 0 && auxLifeSmash > 0)
            {
                auxLifeSmash--;
                lifePointsSnake--;
                DropTail();
                snakeLifeText.text = lifePointsSnake.ToString();
                boxLifeText.text = auxLifeSmash.ToString();
            }
            if (lifePointsSnake != 0)
            {
                moveSpeedY = 1f;
            }
            else
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
    
    //Moving the snake
    private void Move()
    {
        CameraMove();
        transform.position += new Vector3(Input.GetAxis("Horizontal"), moveSpeedY * Time.deltaTime, 0);
        lastPosition = transform.position;

        if (transform.position.x < -3.7)
        {
            transform.position = new Vector3(-3.7f, transform.position.y);
        }
        else if (transform.position.x > 3.7)
        {
            transform.position = new Vector3(3.7f, transform.position.y);
        }
        //Moving the tail and body of the snake
        foreach (GameObject tail in bodySnake){
            if (tail != bodySnake[0])
            {
                var newPosition = new Vector2(lastPosition.x, lastPosition.y - 0.27f);
                lastPosition = tail.transform.position;
                tail.transform.position = newPosition;
            }
        }
    }

    //Camera movement
    private void CameraMove()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Cube detected?
        if (other.gameObject.CompareTag("Cube"))
        {
            needWait = true;
            aux = other.gameObject;
            Invoke("DisableObjects", 0.4f); //just for effects
        }
        //Pick detected?
        if (other.gameObject.CompareTag("LifePick"))
        {
            lifePointsSnake = lifePointsSnake + auxPick;
            other.gameObject.SetActive(false);
            AddToTail();
            snakeLifeText.text = lifePointsSnake.ToString();
        }
        //Finish detected?
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Here");
        }
    }
    
    //Adding elements to the list
    void AddToTail()
    {
        Debug.Log("Here, length: " + lifePointsSnake.ToString());
        for (int i = 0; i < lifePointsSnake && lifePointsSnake != bodySnake.Count; i++)
        {
            if (i == 0)   //just for solve a bug
            {
                continue; 
            }
            else
            {
              nextSnakeTail = Instantiate(snakeTail, new Vector3(transform.position.x, bodySnake[i - 1].transform.position.y - 0.27f, 0f), Quaternion.identity);
            }
            bodySnake.Add(nextSnakeTail);
        }
    }

    //Removing elements from the snake
    void DropTail()
    {
        Debug.Log("Here, length: " + lifePointsSnake.ToString());
        for (int i = lifePointsSnake; i >=  0  && lifePointsSnake != bodySnake.Count; i--)
        {
            Destroy(bodySnake[i]);
            bodySnake.Remove(bodySnake[i]);
        }
    }

    //Disabling the object
    private void DisableObjects()
    {
        aux.SetActive(false);
    }
}
