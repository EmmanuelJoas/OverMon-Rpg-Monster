using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSysteme : MonoBehaviour
{
    #region

    /// <summary>
    /// 
    /// </summary>
    public OvermonManager MyOvermon;

    private Animator OvermonAnim;

    /// <summary>
    /// 
    /// </summary>
    public EnemyFightSystem _OpponentOvermon;

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
    public Text TextCurrentPvOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Text TextMaxPvOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Text TextCurrentPaOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Text TextMaxPaOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Text TextNameOvermon;

    /// <summary>
    /// 
    /// </summary>
    public Image OvermonFace;

    private float Damage=0.0f;

   private EnemyFightSystem Victim;

   [SerializeField]
    private bool IsMagic=false;

    private bool Dead = false;

    public bool IsMyTurn=true;

    private FightManager FightManager;

    #endregion

    #region Unity Function
    // Start is called before the first frame update
    void Start()
    {
        DisplayInfoOvermon();
        OvermonAnim = gameObject.GetComponent<Animator>();
        FightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
    }

    #endregion

    #region My Private Function 

    void DisplayInfoOvermon()
    {
         SliderPvOvermon.maxValue=MyOvermon.MaxHP;
         SliderPvOvermon.value = MyOvermon.HP;
         SliderPaOvermon.maxValue = MyOvermon.MaxMana;
         SliderPaOvermon.value = MyOvermon.Mana;

         TextMaxPvOvermon.text = MyOvermon.MaxHP + "" + "Pv";
         TextCurrentPvOvermon.text = MyOvermon.HP + "" + "/";
         TextMaxPaOvermon.text = MyOvermon.MaxMana + "" + "Pa";
         TextCurrentPaOvermon.text = MyOvermon.Mana + "" + "/";

         TextNameOvermon.text = MyOvermon.OvermonNickName;

         OvermonFace.sprite = MyOvermon.OvermoneSpriteFace;
    }
    
    public void SelectAttack(string btn)
    {
        Victim = _OpponentOvermon;
        
        if (btn == "Normal_AttckButton")
        {
            OvermonAnim.SetTrigger("IsAttack1");
            AttackAction(Victim);

        }
        else if (btn == "Special_AttckButton")
        {
            IsMagic = true;
            OvermonAnim.SetTrigger("IsAttack2");
            AttackAction(Victim);
        }
        else
        {
            Debug.Log("Run");
        }
    }

    private void AttackAction(EnemyFightSystem victim)
    {
        
            OvermonManager Attacker = MyOvermon;
             victim = _OpponentOvermon;
            if (IsMagic==false)
            {
                float multiplier = Random.Range(0.3f,1.1f);

                Damage = multiplier * Attacker.Attack;

                float defenseMultiplier = Random.Range(0.5f, 1.2f);
                Damage = Mathf.Max(5, (defenseMultiplier * victim.OpponentOvermon.Defence) - Damage);
                victim.ReceiveDamage(Mathf.CeilToInt(Damage));
              
            }
            else if (IsMagic==true)
            {
                float multiplier = Random.Range(0.2f, 1);
                Damage = multiplier * Attacker.MagicAttack*2;
                float defenseMultiplier = Random.Range(0.3f, 1.1f);
                Damage = Mathf.Max(10, (defenseMultiplier * victim.OpponentOvermon.Defence) - Damage);
                victim.ReceiveDamage(Mathf.CeilToInt(Damage));
                
            }

        IsMyTurn = false;
        FightManager.NextTurn();
    }

    public void ReceiveDamage(float damage)
    {
        float CurrentDamage = damage;
        SliderPvOvermon.value -= CurrentDamage;
        if (SliderPvOvermon.value <= 0)
        {
            Debug.Log("est mort");
        }
        else
        {
            StartCoroutine(LateState());
        }

    }  

    IEnumerator LateState()
    {
            yield return new WaitForSeconds(1);
            OvermonAnim.SetTrigger("Hit");
            TextCurrentPvOvermon.text = SliderPvOvermon.value + "" + "/";
    }

    public bool GetDead()
    {
        return Dead;
    }
    #endregion
}
