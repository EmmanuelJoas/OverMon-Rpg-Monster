using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class FightSysteme : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// 
    /// </summary>
    public OvermonManager MyOvermon;

    /// <summary>
    /// 
    /// </summary>
    private EnemyFightSystem _OpponentOvermon;

    /// <summary>
    /// 
    /// </summary>
    private float Damage=0.0f;

    /// <summary>
    /// 
    /// </summary>
    private EnemyFightSystem Victim;

    /// <summary>
    /// 
    /// </summary>
    private bool IsMagic=false;

    /// <summary>
    /// 
    /// </summary>
    public bool Dead = false;

    /// <summary>
    /// 
    /// </summary>
    public bool IsMyTurn=true;

    /// <summary>
    /// 
    /// </summary>
    public int ManaPoint;

    /// <summary>
    /// 
    /// </summary>
    public int AddMana;

    public Transform BattlePosition;

    #endregion

    #region Unity Function

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        _OpponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();
        Victim = _OpponentOvermon;
    }

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        EventManager.eventManager.ClickAction_NormalAttack -= Normal_AttckButton;
        EventManager.eventManager.ClickAction_SpecialAttack -= Special_AttckButton;
    }


    #endregion

    #region My Private Function 

     /// <summary>
     /// 
     /// </summary>
     public void Normal_AttckButton(object sender , EventArgs e)
     {
         
         DisplayInfoOfPlayer.displayInfoOfPlayer.OvermonAnim.SetTrigger("IsAttack1");
         AttackAction(Victim);
          if (DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPaOvermon.value<DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPaOvermon.maxValue)
          {
             DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPaOvermon.value += AddMana;
          }

        IsMyTurn = false;

        BattleManager.battleManager.NextTurn();

     }

     /// <summary>
     /// 
     /// </summary>
     public void Special_AttckButton(object sender ,EventArgs e)
     {
          if (DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPaOvermon.value >= ManaPoint)
            {
                if (gameObject.name == "Warrior" || gameObject.name == "Warrior2")
                {
                    SelectSkills(Mathf.Round(Damage));
                    DisplayInfoOfPlayer.displayInfoOfPlayer.OvermonAnim.SetTrigger("IsAttack2");
              
                }
                else
                {
                    IsMagic = true;
                    DisplayInfoOfPlayer.displayInfoOfPlayer.OvermonAnim.SetTrigger("IsAttack2");
                    AttackAction(Victim);
                }
                    DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPaOvermon.value -= ManaPoint;
          }
          else
          {
                return;
          }
        DisplayInfoOfPlayer.displayInfoOfPlayer.TextCurrentPaOvermon.text = DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPaOvermon.value + "" + "/";

        IsMyTurn = false;

        IsMagic = false;

        BattleManager.battleManager.NextTurn();
     }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="victim"></param>
    private void AttackAction(EnemyFightSystem victim)
    {
        
        OvermonManager Attacker = MyOvermon;
        victim = _OpponentOvermon;
        if (IsMagic==false)
        {
            Damage = Attacker.Attack * (Attacker.Attack + 100) * 0.08f / (victim.OpponentOvermon.Defence + 8);
            victim.ReceiveDamage(Mathf.Round(Damage));
     
        }
        if (IsMagic==true)
        {
            Damage = Attacker.Attack * (Attacker.MagicAttack + 100) * 0.08f / (victim.OpponentOvermon.Defence + 8);
            victim.ReceiveDamage(Mathf.Round(Damage)); 
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(float damage)
    {
        float CurrentDamage = damage;
        DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.value -= CurrentDamage;
        if (DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.value <= 0)
        {
            Debug.Log("est mort");
            Dead = true;
        }
        else
        {
            StartCoroutine(LateState());
            SaveState();
        }

    }  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Heal"></param>
    public void SelectSkills(float Heal)
    {
        if (DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.value < DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.maxValue)
        {
            float CurrentHeal = Heal;
            DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.value += CurrentHeal;
            DisplayInfoOfPlayer.displayInfoOfPlayer.TextCurrentPvOvermon.text = DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.value + "" + "/";
        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator LateState()
    {
         yield return new WaitForSeconds(0.9f);
        DisplayInfoOfPlayer.displayInfoOfPlayer.OvermonAnim.SetTrigger("Hit");
        DisplayInfoOfPlayer.displayInfoOfPlayer.TextCurrentPvOvermon.text = DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.value + "" + "/";
        //DisplayInfoOfPlayer.displayInfoOfPlayer.DisplayDamageInTheScene(Damage);

    }

    /// <summary>
    /// 
    /// </summary>
    void SaveState()
    {
        //MyOvermon.HP = DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPvOvermon.value;
        //MyOvermon.Mana = DisplayInfoOfPlayer.displayInfoOfPlayer.SliderPaOvermon.value;
    }
    #endregion
}
