using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFightSystem : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// 
    /// </summary>
    public OvermonManager OpponentOvermon;

    public FightSysteme _MyOvermon;

    public Animator OpponentAnim;

    /// <summary>
    /// 
    /// </summary>
    public Slider SliderPvOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Slider SliderPaOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Text TextNameOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Image OvermonFace;

    private float Damage = 0.0f;

    private FightSysteme Victim;

    private bool IsSuperAttack=false;

    public GameObject ProfileOponent;

    public bool Dead = false;

    private BattleManager battleManager;

    public GameObject DamageText;

    public int ManaPoint;

    public int AddMana;

    public float XpToGive;

    #endregion

    #region Unity Function 

    // Start is called before the first frame update
    void Start()
    {
        DisplayInfoOvermon();
        battleManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<BattleManager>();
        SliderPaOvermon.maxValue = OpponentOvermon.MaxMana;
        SliderPaOvermon.value = OpponentOvermon.Mana;
    }

    #endregion

    #region Unity Function

    void DisplayInfoOvermon()
    {
        SliderPvOvermon.maxValue = OpponentOvermon.MaxHP;
        SliderPvOvermon.value = OpponentOvermon.HP;
       

        TextNameOvermon.text = OpponentOvermon.name;

        OvermonFace.sprite = OpponentOvermon.OvermoneSpriteFace;
    }

    public void EnemySelectAttack()
    {
        _MyOvermon = BattleManager.battleManager.MyOvermon;
        Victim = _MyOvermon;
       
        if (SliderPaOvermon.value < ManaPoint)
        {
            EnemyAttackAction(Victim);
            OpponentAnim.SetTrigger("Attack1");
            SliderPaOvermon.value += AddMana;
        }
        else 
        {
            IsSuperAttack = true;
            EnemyAttackAction(Victim);
            OpponentAnim.SetTrigger("Attack2");
            SliderPaOvermon.value -= ManaPoint;
        }
        IsSuperAttack = false;
        Victim.IsMyTurn = true;
       BattleManager.battleManager.combatOptionMenu.SetActive(true);
       BattleManager.battleManager.NextTurn();

    }
    public void EnemyAttackAction(FightSysteme victim)
    {

        OvermonManager Attacker = OpponentOvermon;
        victim = _MyOvermon;
       
        
        if (IsSuperAttack == false)
        {
            Damage = Attacker.Attack * (Attacker.Attack + 100) * 0.08f / (victim.MyOvermon.Defence + 8);
            victim.ReceiveDamage(Mathf.Round(Damage));
        }

        if (IsSuperAttack == true)
        {
            Damage = Attacker.MagicAttack * (Attacker.Attack + 100) * 0.08f / (victim.MyOvermon.Defence + 8);
            victim.ReceiveDamage(Mathf.Round(Damage));
        }


    }

    public void ReceiveDamage(float damage)
    {
        float CurrentDamage = damage;
        SliderPvOvermon.value -= CurrentDamage;
        DamageText.GetComponent<Text>().text = CurrentDamage + "";
        if (SliderPvOvermon.value <= 0)
        {
            gameObject.SetActive(false);
            ProfileOponent.SetActive(false);
            Dead = true;
        }
        else
        {
            StartCoroutine(LateState());
        }
    }

    IEnumerator LateState()
    {
        yield return new WaitForSeconds(0.9f);
        OpponentAnim.SetTrigger("Hit");
        StartCoroutine(DisplayDamage());
    }

    IEnumerator DisplayDamage()
    {
        DamageText.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        DamageText.SetActive(false);

    }

    public bool GetDead()
    {
        return Dead;
    }
    #endregion
}
