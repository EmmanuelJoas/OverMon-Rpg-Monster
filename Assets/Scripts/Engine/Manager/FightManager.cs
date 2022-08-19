using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    
    public FightSysteme MyOvermon;

    private EnemyFightSystem OpponentOvermon;

    public GameObject battleMenu;

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
       
    }

    IEnumerator LateStat()
    {
        yield return new WaitForSeconds(1.4f);
        OpponentOvermon.EnemySelectAttack();
        battleMenu.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        MyOvermon.IsMyTurn = true;
        NextTurn();

    }

    public void UpdateFighther()
    {
        MyOvermon = GameObject.FindGameObjectWithTag("Hero").GetComponent<FightSysteme>();

        OpponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();

    }
}
