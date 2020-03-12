using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controllers : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> body = null; //body of the snake
    [SerializeField]
    private GameObject tail = null; //tail for instantiate
    private GameObject newTail; //new tail
    [SerializeField]
    private GameObject helperTexDisable = null; // just for disabling the "Pick Number"
    private int lifeCount = 4;  // starting minimun life
    private float speed = 0.5f; // speed for movement in .y
    private PickUpLife currentPick; // to save the current PickUp
    private Cube currentCube;   // to save the curren cube
    private TextMesh life;      // Player Life
    private TextMesh cubeLife;  // Cube Life
    private bool needWait = false;  // Just for a "wait instance"
    private int auxLifeSmash;   // to save the current random  life smash from the cube
    private int auxPick;      // to save the current random  life smash from the pick
    private Vector2 lastPos;  // saving
    private int length;       // to save the length of the list
    private GameObject aux;  // just for help
    [SerializeField]
    private GameObject auxFinish = null;  // trying to make the "you win or level passed" 



    private void Awake()
    {
        // Initializations, getting components and setting the UI text
        currentCube = GameObject.FindWithTag("Cube").GetComponent<Cube>();  
        currentPick = GameObject.FindWithTag("LifePick").GetComponent<PickUpLife>();
        cubeLife = GameObject.FindWithTag("Number").GetComponent<TextMesh>();
        life = GameObject.FindWithTag("Life").GetComponent<TextMesh>();
        life.text = "4";
        auxLifeSmash = currentCube.LifeSmasher;
        auxPick = currentPick.Lpick;
        cubeLife.text = auxLifeSmash.ToString();
        length = 4;
       
    }
    private void Start()
    {
        addToTail(); //starting the snake tail
    }
        

    private void Update()
    {
        // Checking if wait is needed
        if (needWait)
        {
            //For make wait in a cube
            speed = 0;
            if (lifeCount > 0 && auxLifeSmash > 0)
            {
                auxLifeSmash--;
                lifeCount--;
                length = lifeCount;
                dropTail();
                life.text = lifeCount.ToString();
                cubeLife.text = auxLifeSmash.ToString();
            }
            if (lifeCount != 0)
            {
                speed = 0.5f;
            }
            else
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
    
    //Moving the snake
    private void FixedUpdate()
    {
    transform.position += new Vector3(Input.GetAxis("Horizontal"), speed * Time.deltaTime, 0);

    lastPos = transform.position;

    if (transform.position.x < -3)
    {
        transform.position = new Vector3(-3, transform.position.y);
    }
    else if (transform.position.x > 3)
    {
        transform.position = new Vector3(3, transform.position.y);
    }
    //Moving the tail and body of the snake
    foreach (GameObject tail in body){
        if (tail != body[0])
        {
            var newPosition = new Vector2(lastPos.x, lastPos.y - 0.27f);
            lastPos = tail.transform.position;
            tail.transform.position = newPosition;
        }
    }

    }
    //Camera movement
    private void LateUpdate()
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
            Invoke("hideit", 0.4f); //just for effects
        }
        //Pick detected?
        if (other.gameObject.CompareTag("LifePick"))
        {
            lifeCount = lifeCount + auxPick;
            other.gameObject.SetActive(false);
            helperTexDisable.SetActive(false);
            length = lifeCount;
            addToTail();
            life.text = lifeCount.ToString();
        }
        //Finish detected?
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Here");
            auxFinish.SetActive(true);
        }
    }
    
    //Adding elements to the list
    void addToTail()
    {
        Debug.Log("Here, length: " + length.ToString());
        for (int i = 0; i < length && length != body.Count; i++)
        {
            if (i == 0)   //just for solve a bug
            {
                continue; 
            }
            else
            {
              newTail = Instantiate(tail, new Vector3(transform.position.x, body[i - 1].transform.position.y - 0.27f, 0f), Quaternion.identity);
            }
            body.Add(newTail);
        }
    }

    //Removing elements from the snake
    void dropTail()
    {
        Debug.Log("Here, length: " + length.ToString());
        for (int i = length - 1; i >=  0  && length != body.Count; i--)
        {
            Destroy(body[i]);
            body.Remove(body[i]);
        }
    }

    //Disabling the object
    private void hideit()
    {
        aux.SetActive(false);
    }
}
