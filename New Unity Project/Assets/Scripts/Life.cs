using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int rndLife;
    [SerializeField]
    private TextMesh LifeText;
    public int RndLife
    {
        get { return rndLife; }
    }

    void Start()
    {
        rndLife = Random.Range(1, 10);
    }

    void Update()
    {
        LifeText.text = rndLife.ToString();
    }
    private void OnTriggerEnter2D(Collider2D lifeIcon)
    {
        if (lifeIcon.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
