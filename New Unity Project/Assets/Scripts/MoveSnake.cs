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
    private int lifepoints;
    private int lifecount;
    [SerializeField]
    private TextMesh points;
    Rigidbody2D rb;

    private Life lf;
    private Obstacle obstacle;

    

    void Start()
    {
        lifepoints = 4;
    }


    private void Update()
    {
        points.text = lifepoints.ToString();
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Lifes")
        {
            Debug.Log("Detected");
            lifepoints = lifepoints + 1;
            Debug.Log("count " + lifecount);
            //Agregar en el scrip de life el numero de vidas de cada objeto y sumarlo al personaje
        }
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("Detected");
            Destroy(gameObject);
            //Falta reiniciar lvl actual y puntaje, guardar puntaje global, acceder a otro scrip con la durabilidad del bloque
        }
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Detected");
            //Falta collisionar bien
        }
    }
}
