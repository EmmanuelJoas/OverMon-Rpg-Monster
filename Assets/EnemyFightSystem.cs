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

    private Animator OpponentAnim;

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

    private bool Dead = false;

    private FightManager FightManager;

    


    #endregion

    #region Unity Function 

    // Start is called before the first frame update
    void Start()
    {
        DisplayInfoOvermon();
        OpponentAnim = gameObject.GetComponent<Animator>();
        FightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EnemySelectAttack();
        }
    }

    #endregion

    #region Unity Function

    void DisplayInfoOvermon()
    {
        SliderPvOvermon.maxValue = OpponentOvermon.MaxHP;
        SliderPvOvermon.value = OpponentOvermon.HP;
        SliderPaOvermon.maxValue = OpponentOvermon.MaxMana;
        SliderPaOvermon.value = OpponentOvermon.Mana;

        TextNameOvermon.text = OpponentOvermon.name;

        OvermonFace.sprite = OpponentOvermon.OvermoneSpriteFace;
    }

    public void EnemySelectAttack()
    {
        Victim = _MyOvermon;
       
        if (OpponentOvermon.Mana < 4)
        {
            EnemyAttackAction(Victim);
            OpponentAnim.SetTrigger("Attack1");
        }
        else 
        {
            IsSuperAttack = true;
            EnemyAttackAction(Victim);
            OpponentAnim.SetTrigger("Attack2");
        }

        Victim.IsMyTurn = true;
        FightManager.battleMenu.SetActive(true);
        FightManager.NextTurn();

    }
    public void EnemyAttackAction(FightSysteme victim)
    {

        OvermonManager Attacker = OpponentOvermon;
        victim = _MyOvermon;
       
        
        if (IsSuperAttack == false)
        {
            float multiplier = Random.Range(0.3f, 1.1f);

            Damage = multiplier * Attacker.Attack;

            float defenseMultiplier = Random.Range(0.5f, 1.2f);
            Damage = Mathf.Max(5, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            victim.ReceiveDamage(Mathf.CeilToInt(Damage));

        }

        else if (IsSuperAttack == true)
        {
            float multiplier = Random.Range(0.2f, 1);
            Damage = multiplier * Attacker.MagicAttack;
            float defenseMultiplier = Random.Range(0.3f, 1.1f);
            Damage = Mathf.Max(10, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            victim.ReceiveDamage(Mathf.CeilToInt(Damage));
        }


    }

    public void ReceiveDamage(float damage)
    {
        float CurrentDamage = damage;
        SliderPvOvermon.value -= CurrentDamage;
        if (SliderPvOvermon.value <= 0)
        {
            gameObject.SetActive(false);
            ProfileOponent.SetActive(false);
        }
        else
        {
            StartCoroutine(LateState());
        }
    }

    IEnumerator LateState()
    {
        yield return new WaitForSeconds(1);
        OpponentAnim.SetTrigger("Hit");
    }

    public bool GetDead()
    {
        return Dead;
    }
    #endregion
}
