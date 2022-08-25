using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Button : MonoBehaviour
{
    #region
    public FightSysteme hero;
    private string temp;

    public static Run_Button instance;
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
        if (btn == "Run_Button")
        {
            hero.SelectAttack("run");

        }

    }
    public void UpdateFighter()
    {
        hero = GameManager.CurrentOvermon;
    }
}
