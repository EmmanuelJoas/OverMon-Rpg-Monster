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

    private FightSysteme _MyOvermon;

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

    [SerializeField]
    public bool Dead = false;

    private FightManager FightManager;

    public GameObject DamageText;

    public int ManaPoint;

    public int AddMana;




    #endregion

    #region Unity Function 

    // Start is called before the first frame update
    void Start()
    {
        DisplayInfoOvermon();
        OpponentAnim = gameObject.GetComponent<Animator>();
        FightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
        _MyOvermon = GameObject.FindGameObjectWithTag("Hero").GetComponent<FightSysteme>();
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
            float multiplier = Random.Range(0.5f, 1.1f);

            Damage = multiplier * Attacker.Attack;

            float defenseMultiplier = Random.Range(1.2f, 1.5f);
            Damage = Mathf.Max(2, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            victim.ReceiveDamage(Mathf.CeilToInt(Damage));

        }

        else if (IsSuperAttack == true)
        {
            float multiplier = Random.Range(0.6f, 1.2f);
            Damage = multiplier * Attacker.MagicAttack;
            float defenseMultiplier = Random.Range(0.3f, 1.1f);
            Damage = Mathf.Max(5, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            victim.ReceiveDamage(Mathf.CeilToInt(Damage));
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
        yield return new WaitForSeconds(1);
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
