using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box", menuName = "Box" )]
public class BoxScriptableObject : ScriptableObject
{ 
    public Color colorBox;
    public int minLifeRange;
    public int maxLifeRange;
}
