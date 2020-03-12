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
    [SerializeField]
    private TextMesh lifeText = null;

    private int RandomizePickUpLife()
    {
        lifePickValue = Random.Range(minRandomLifePickUp, maxRandomLifePickUp);
        lifeText.text = lifePickValue.ToString();
        return lifePickValue;
    }

    public int LifePickValue
    {
        get { return RandomizePickUpLife(); }
    }
}