using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
/// <summary>
/// 
/// </summary>
public enum OvermonsTypes
{
    Normal = 1 << 0,// 0-bite shift 0

    Fire = 1 << 1,//1-bite shift 1

    Water = 1 << 2,//2-bite shift 2

    Plant = 1 << 3,//3-bite shift 4

    Ground = 1 << 4,//4-bite shift 8

}
[CreateAssetMenu(fileName ="New Overmon", menuName = "Overmon")]
public class OvermonManager : ScriptableObject
{
    /// <summary>
    /// Reference to the index of the overmon
    /// </summary>
    public int Index = 1;


    [Range(1,100)]
    /// <summary>
    /// 
    /// </summary>
    public int lvl=1;

    /// <summary>
    /// 
    /// </summary>
    public float Xp;

    /// <summary>
    /// Reference to the name of the overmon 
    /// </summary>
    public string OvermonName;


    /// <summary>
    /// Reference to the nick name of the overmon 
    /// </summary>
    public string OvermonNickName;

    /// <summary>
    /// Reference to the hp of the overmon 
    /// </summary>
    public int HP;

    /// <summary>
    /// Reference to the attack of the overmon 
    /// </summary>
    public int Attack;

    /// <summary>
    /// Reference of the defence of the overmon 
    /// </summary>
    public int Defence;

    /// <summary>
    /// Reference to the mana points of the overmon 
    /// </summary>
    public int Mana;

    /// <summary>
    /// Reference of the type(s) of the overmon 
    /// </summary>
    public OvermonsTypes Types;

    public OvermonMove[] Moves;

    [Header("Graphics")]
    public Sprite Front;

    public Sprite back;
}
