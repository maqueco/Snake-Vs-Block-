using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
   
    private int lifePointsBox;
    [SerializeField]
    private int minRandomBlockLife = 1;
    [SerializeField]
    private int maxRandomBLockLife = 10;
 
    // Generates a random number for fun
    private int randomizeLifeBox()
    {
        lifePointsBox = Random.Range(minRandomBlockLife, maxRandomBLockLife);
        return lifePointsBox;
    }
    //For Encapsulation
    public int LifeSmasher
    {
        get { return randomizeLifeBox(); }
    }
}
