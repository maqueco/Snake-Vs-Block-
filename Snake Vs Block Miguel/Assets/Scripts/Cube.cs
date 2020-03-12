﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
   
    public Box box;
    private int lifePointsBox;
    private SpriteRenderer colorBox;
    [SerializeField]
    private TextMesh boxText;

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

    private void ChangeColor()
    {
        colorBox.color = box.BoxColor;
    }

    private void SeeNumberText()
    {
        boxText = GetComponentInChildren<TextMesh>();
        boxText.text = lifePointsBox.ToString();
    }
}
