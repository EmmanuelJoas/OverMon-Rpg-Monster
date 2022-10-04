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


    public void UpdateFighter()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<FightSysteme>();
    }
}
