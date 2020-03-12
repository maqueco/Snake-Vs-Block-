using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBox : MonoBehaviour
{
   
    public BoxScriptableObject box;
    private int lifePointsBox;
    private SpriteRenderer spriteRendColorBox = null;
    /*[SerializeField]
    private TextMesh boxText;*/

    // Generates a random number for fun

    private int randomizeLifeBox()
    {
        lifePointsBox = Random.Range(box.minLifeRange, box.maxLifeRange);
        //boxText.text = lifePointsBox.ToString();
        return lifePointsBox;
    }
    //For Encapsulation
    public int LifeSmasher
    {
        get { return randomizeLifeBox(); }
    }

    private void Start()
    {
        spriteRendColorBox = GetComponent<SpriteRenderer>();
        spriteRendColorBox.color = box.colorBox;
    }
}
