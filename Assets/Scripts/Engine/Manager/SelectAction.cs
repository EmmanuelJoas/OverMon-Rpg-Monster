using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAction : MonoBehaviour
{
    private GameObject hero;
    private string temp;
    void Start()
    {
        temp = gameObject.name;
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    public void AttachCallback(string btn)
    {
        btn = temp;

        if (btn=="Normal_AttckButton")
        {
            hero.GetComponent<FightSysteme>().SelectAttack("Normal_AttckButton");
            
        }
        else if (btn=="Special_AttckButton")
        {
            hero.GetComponent<FightSysteme>().SelectAttack("Special_AttckButton");
           
        }
        else
        {
            hero.GetComponent<FightSysteme>().SelectAttack("run");
            
        }
    }
}
