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

    public Text LvlText;

    public Slider XpSlider;

    public Image FaceImageOvermon;

    public Text NameTextOvermon;

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
            StartCoroutine(EndBattleDefaite());
        }
        else if (OpponentOvermon.Dead==true)
        {
            StartCoroutine(EndBattleVictoire());
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

        LvlText.text = "" + MyOvermon.MyOvermon.lvl;

        NameTextOvermon.text = MyOvermon.MyOvermon.name;

        FaceImageOvermon.sprite = MyOvermon.MyOvermon.OvermoneSpriteFace;

        XpSlider.value = MyOvermon.MyOvermon.Xp;

        XpSlider.maxValue = MyOvermon.MyOvermon.MaxXp;

    }

    private void DisplayRounds(int Rounds)
    {
        RoundText.text = "Rounds" +" "+ Rounds;
    }

    IEnumerator EndBattleVictoire()
    {
        yield return new WaitForSeconds(0.5f);
        EndFightPanel.SetActive(true);
        EndFightText.text = "Victoire";
        yield return new WaitForSeconds(0.2f);
        AddXp(OpponentOvermon.XpToGive);
    }

    IEnumerator EndBattleDefaite()
    {
        yield return new WaitForSeconds(0.5f);
        EndFightPanel.SetActive(true);
        EndFightText.text = "Defaite";
        NameTextOvermon.text = MyOvermon.MyOvermon.name;

        FaceImageOvermon.sprite = MyOvermon.MyOvermon.OvermoneSpriteFace;

        XpSlider.value = MyOvermon.MyOvermon.Xp;

        XpSlider.maxValue = MyOvermon.MyOvermon.MaxXp;
    }

    private void AddXp(float _XpToGive)
    {
        MyOvermon.MyOvermon.Xp += _XpToGive;
        XpSlider.value = MyOvermon.MyOvermon.Xp;
        LvlText.text = ""+MyOvermon.MyOvermon.lvl;
        if (MyOvermon.MyOvermon.Xp >= MyOvermon.MyOvermon.MaxXp)
        {
            MyOvermon.MyOvermon.lvl += 1;
            LvlText.text = "" + MyOvermon.MyOvermon.lvl;
            MyOvermon.MyOvermon.Xp = 0;
            MyOvermon.MyOvermon.MaxXp *= 2;
            XpSlider.value = MyOvermon.MyOvermon.Xp;

        }
    }
}
