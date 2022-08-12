using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    private FightSysteme MyOvermon;

    private EnemyFightSystem OpponentOvermon;

    public GameObject battleMenu;

    //public Text battleText;

    private void Awake()
    {
        MyOvermon = GameObject.FindGameObjectWithTag("Hero").GetComponent<FightSysteme>();

        OpponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();
    }
    void Start()
    {
        NextTurn();
    }

    public void NextTurn()
    {
        if (MyOvermon.IsMyTurn==true)
        {
            battleMenu.SetActive(true);

        }
        else if (MyOvermon.IsMyTurn == false)
        {
            StartCoroutine(LateStat());

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
}
