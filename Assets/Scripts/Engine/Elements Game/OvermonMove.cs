using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enum of the move type 
/// </summary>
public enum MoveType
{
    Physic,
    //Special
}


[CreateAssetMenu(fileName ="New move",menuName ="Move")]
public class OvermonMove : ScriptableObject
{
    /// <summary>
    /// Reference to the index of the move rang 
    /// </summary>
    public int index;

    /// <summary>
    /// Reference to the move name 
    /// </summary>
    public string MoveName;

    /// <summary>
    /// Reference to the type move
    /// </summary>
    public OvermonsTypes Type = OvermonsTypes.Normal;

    /// <summary>
    /// Reference to the type of the move 
    /// </summary>
    public MoveType MoveType;

    /// <summary>
    /// Reference to the power of the move 
    /// </summary>
    public int Power = 40;

    /// <summary>
    /// Reference to the precision of the move 
    /// </summary>
    public int Precision = 100;

    /// <summary>
    /// Reference to the priority of the move 
    /// </summary>
    public int Priority = 0;
 

}
