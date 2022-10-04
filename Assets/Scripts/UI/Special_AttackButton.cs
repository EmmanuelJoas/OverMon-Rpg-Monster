using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_AttackButton : MonoBehaviour
{

    public void AttachCallback()
    {
        EventManager.eventManager.OnClickActionSpecialAttack();
    }
   
}
