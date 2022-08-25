using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    
    public FightSysteme MyOvermon;

    private EnemyFightSystem OpponentOvermon;

    public GameObject battleMenu;

    private int RoundsNumber = 0;

    public Text RoundText;

    public  GameObject EndFightPanel;

    public Text EndFightText;

    public static FightManager instance;

   

    //public Text battleText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateFighther();
        NextTurn();
    }

    public void NextTurn()
    {
        if(MyOvermon.Dead==false && OpponentOvermon.Dead == false)
        {
            if (MyOvermon.IsMyTurn == true)
            {
                battleMenu.SetActive(true);
               
            }
            else if (MyOvermon.IsMyTurn == false)
            {
                StartCoroutine(LateStat());

            }

           
        }
        else if (MyOvermon.Dead == true)
        {
            EndFightPanel.SetActive(true);
            EndFightText.text = "Defaite";
        }
        else if (OpponentOvermon.Dead==true)
        {
            EndFightPanel.SetActive(true);
            EndFightText.text = "Victoire";
        }
       
    }

    IEnumerator LateStat()
    {
        yield return new WaitForSeconds(1.4f);
        OpponentOvermon.EnemySelectAttack();
        battleMenu.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        MyOvermon.IsMyTurn = true;
        yield return new WaitForSeconds(0.9f);
        RoundsNumber++;
        DisplayRounds(RoundsNumber);
        NextTurn();

    }

    public void UpdateFighther()
    {
        MyOvermon = GameManager.CurrentOvermon;

        OpponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();

    }

    private void DisplayRounds(int Rounds)
    {
        RoundText.text = "Rounds" +" "+ Rounds;
    }
}
