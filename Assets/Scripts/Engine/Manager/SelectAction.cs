using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAction : MonoBehaviour
{
    public FightSysteme hero;
    private string temp;
    public static SelectAction instance;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        temp = gameObject.name;
        UpdateFighter();
        
    }

    public void AttachCallback(string btn,FightSysteme Hero)
    {
        btn = temp;
        Hero = hero;
        if (btn=="Normal_AttckButton")
        {
            UpdateFighter();
            Hero.SelectAttack("Normal_AttckButton");
            
        }
        else if (btn=="Special_AttckButton")
        {
            UpdateFighter();
            Hero.SelectAttack("Special_AttckButton");
           
        }
        else
        {
            Hero.SelectAttack("run");
            
        }
    }

    public void UpdateFighter()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<FightSysteme>();
    }
}
