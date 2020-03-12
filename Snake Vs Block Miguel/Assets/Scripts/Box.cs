using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box", menuName = "Box" )]
public class Box : ScriptableObject
{ 
    //public TextMesh value;
    public Color BoxColor;
    public int minLifeRange;
    public int maxLifeRange;
}
