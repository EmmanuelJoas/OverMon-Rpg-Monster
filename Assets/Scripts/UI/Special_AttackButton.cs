using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_AttackButton : MonoBehaviour
{
    #region
    public FightSysteme hero;
    private string temp;

    public static Special_AttackButton instance;
    #endregion
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        temp = gameObject.name;
        UpdateFighter();
    }

    public void AttachCallback(string btn)
    {
        btn = temp;
        if (btn == "Special_AttckButton")
        {
            hero.SelectAttack("Special_AttckButton");

        }
        
    }
    public void UpdateFighter()
    {
        hero = GameManager.CurrentOvermon;
    }
}
