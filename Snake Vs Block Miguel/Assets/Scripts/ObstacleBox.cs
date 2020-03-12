using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBox : MonoBehaviour
{
   
    public BoxScriptableObject box;
    private int lifePointsBox;
    private SpriteRenderer spriteRendColorBox = null;
    [SerializeField]
    private TextMesh boxText;

    private int randomizeLifeBox()
    {
        lifePointsBox = Random.Range(box.minLifeRange, box.maxLifeRange);
        boxText.text = lifePointsBox.ToString();
        return lifePointsBox;
    }

    public int LifeSmasher
    {
        get { return randomizeLifeBox(); }
    }

    private void Awake()
    {
        spriteRendColorBox = GetComponent<SpriteRenderer>();
        spriteRendColorBox.color = box.colorBox;
    }
}
