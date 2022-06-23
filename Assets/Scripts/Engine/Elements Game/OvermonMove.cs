using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType
{
    Physic,
    //Special
}


[CreateAssetMenu(fileName ="New move",menuName ="Move")]
public class OvermonMove : ScriptableObject
{
    public int index;

    public string MoveName;

    public OvermonsTypes Type = OvermonsTypes.Normal;

    public MoveType MoveType;

    public int Power = 40;

    public int Precision = 100;

    public int Priority = 0;
 

}
