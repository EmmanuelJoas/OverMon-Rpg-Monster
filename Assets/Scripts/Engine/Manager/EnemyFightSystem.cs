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

    [SerializeField]
    public bool Dead = false;

    private FightManager FightManager;

    public GameObject DamageText;

    public int ManaPoint;

    public int AddMana;

    public static EnemyFightSystem instance;




    #endregion

    #region Unity Function 

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayInfoOvermon();
        FightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
        OpponentAnim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _MyOvermon = GameManager.CurrentOvermon;
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
            /*float multiplier = Random.Range(1.1f, 1.5f);

            Damage = multiplier * Attacker.Attack;

            float defenseMultiplier = Random.Range(0.5f, 1.5f);
            //Damage = Mathf.Max(5, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            Damage -= Mathf.Abs((defenseMultiplier * victim.MyOvermon.Defence)*-1);
            //victim.ReceiveDamage(Mathf.CeilToInt(Damage));
            victim.ReceiveDamage(Mathf.Abs(Mathf.Round(Damage)));*/

            float multiplierAttack = 0.5f;

             multiplierAttack *= Attacker.Attack;

            float defenseMultiplier = 0.5f;
            //Damage = Mathf.Max(5, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            Damage =(multiplierAttack-(defenseMultiplier * victim.MyOvermon.Defence))/5;
            //victim.ReceiveDamage(Mathf.CeilToInt(Damage));
            victim.ReceiveDamage(Mathf.Abs(Mathf.Round(Damage)));

        }

        else if (IsSuperAttack == true)
        {
            /*float multiplier = Random.Range(1.5f, 2f);
            Damage = multiplier * Attacker.MagicAttack;
            float defenseMultiplier = Random.Range(1.5f, 1.9f);
            //Damage = Mathf.Max(10, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            Damage -= Mathf.Abs((defenseMultiplier * victim.MyOvermon.Defence)*-1);
            //victim.ReceiveDamage(Mathf.CeilToInt(Damage));
            victim.ReceiveDamage(Mathf.Abs(Mathf.Round(Damage)));*/

            float multiplierAttack = 0.5f;

            multiplierAttack *= Attacker.Attack;

            float defenseMultiplier = 0.5f;
            //Damage = Mathf.Max(5, (defenseMultiplier * victim.MyOvermon.Defence) - Damage);
            Damage = (multiplierAttack-(defenseMultiplier * victim.MyOvermon.Defence) )/5;
            //victim.ReceiveDamage(Mathf.CeilToInt(Damage));
            victim.ReceiveDamage(Mathf.Abs(Mathf.Round(Damage)));
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
