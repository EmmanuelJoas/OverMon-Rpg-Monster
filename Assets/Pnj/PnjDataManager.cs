using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pnj", menuName = "Pnj")]
public class PnjDataManager : ScriptableObject
{
    public string NamePnj;
    public string FunctionPnj;
    public string InteractionPnj;
    public Sprite PnjFace;
}
