using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : MonoBehaviour
{
    private int lifePickValue;
    [SerializeField]
    private int minRandomLifePickUp = 1;
    [SerializeField]
    private int maxRandomLifePickUp = 10;
    //[SerializeField]
    //private TextMesh lifeText = null;
    
    private int RandomizePickUpLife()
    {
        lifePickValue = Random.Range(minRandomLifePickUp, maxRandomLifePickUp);
        return lifePickValue;
    }

    public int Lpick
    {
        get { return RandomizePickUpLife(); }
    }

}