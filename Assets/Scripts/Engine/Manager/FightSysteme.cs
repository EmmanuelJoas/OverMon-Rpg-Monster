using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightSysteme : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// 
    /// </summary>
    public OvermonManager MyOvermon;

    private Animator OvermonAnim;

    /// <summary>
    /// 
    /// </summary>
    private EnemyFightSystem _OpponentOvermon;

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
    [SerializeField]
    public bool Dead = false;

    public bool IsMyTurn=true;

    private FightManager FightManager;

    public GameObject DamageText;

    public int ManaPoint;

    public int AddMana;

    #endregion

    #region Unity Function

    private void Awake()
    {
        OvermonAnim = gameObject.GetComponent<Animator>();
        FightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
        DamageText = GameObject.FindGameObjectWithTag("DamageDisplayText");
        OvermonFace = GameObject.FindGameObjectWithTag("ImageProfile").GetComponent<Image>();
        SliderPvOvermon = GameObject.FindGameObjectWithTag("PvSlider").GetComponent<Slider>();
        SliderPaOvermon = GameObject.FindGameObjectWithTag("ManaSlider").GetComponent<Slider>();
        TextMaxPvOvermon = GameObject.FindGameObjectWithTag("MaxPv").GetComponent<Text>();
        TextCurrentPvOvermon = GameObject.FindGameObjectWithTag("CurrentPv").GetComponent<Text>();
        TextMaxPaOvermon = GameObject.FindGameObjectWithTag("MaxMana").GetComponent<Text>();
        TextCurrentPaOvermon = GameObject.FindGameObjectWithTag("CurrentMana").GetComponent<Text>();
        TextNameOvermon = GameObject.FindGameObjectWithTag("MyOvername").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        DamageText.SetActive(false);
        DisplayInfoOvermon();
    }

    private void LateUpdate()
    {
        SelectedEnemy();
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

    public void SelectedEnemy()
    {
        _OpponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();

    }

    public void SelectAttack(string btn)
    {
        Victim = _OpponentOvermon;
        
        if (btn == "Normal_AttckButton")
        {

            OvermonAnim.SetTrigger("IsAttack1");
            AttackAction(Victim);
            if (SliderPaOvermon.value < SliderPaOvermon.maxValue)
            {
                SliderPaOvermon.value += AddMana;
            }
        }


        else if (btn == "Special_AttckButton")
        {
            if (SliderPaOvermon.value >= ManaPoint)
            {
                if (gameObject.name == "Warrior" || gameObject.name == "Warrior2")
                {
                SelectSkills(Mathf.Round(Damage));
                OvermonAnim.SetTrigger("IsAttack2");
              
                }
                else
                {   
                IsMagic = true;
                OvermonAnim.SetTrigger("IsAttack2");
                AttackAction(Victim);
                }
                SliderPaOvermon.value -= ManaPoint;
            }
            
        }
        else
        {
            Debug.Log("Run");
        }
        TextCurrentPaOvermon.text = SliderPaOvermon.value + "" + "/";
        IsMyTurn = false;
        FightManager.NextTurn();
    }

    private void AttackAction(EnemyFightSystem victim)
    {
        
            OvermonManager Attacker = MyOvermon;
             victim = _OpponentOvermon;
            if (IsMagic==false)
            {
                float multiplier = Random.Range(1.2f,1.5f);

                Damage = multiplier * Attacker.Attack;

                float defenseMultiplier = Random.Range(0.5f, 1.1f);
                Damage = Mathf.Max(5, (defenseMultiplier * victim.OpponentOvermon.Defence) - Damage);
                victim.ReceiveDamage(Mathf.CeilToInt(Damage));
              
            }
            else if (IsMagic==true)
            {
                float multiplier = Random.Range(1.5f, 2);
                Damage = multiplier * Attacker.MagicAttack*2;
                float defenseMultiplier = Random.Range(0.3f, 1f);
                Damage = Mathf.Max(10, (defenseMultiplier * victim.OpponentOvermon.Defence) - Damage);
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
            Debug.Log("est mort");
            Dead = true;
        }
        else
        {
            StartCoroutine(LateState());
        }

    }  

    public void SelectSkills(float Heal)
    {
        if (SliderPvOvermon.value < SliderPvOvermon.maxValue)
        {
            float CurrentHeal = Heal;
            SliderPvOvermon.value += CurrentHeal;
            TextCurrentPvOvermon.text = SliderPvOvermon.value + "" + "/";
        }
       
    }

    IEnumerator LateState()
    {
         yield return new WaitForSeconds(1);
         OvermonAnim.SetTrigger("Hit");
         TextCurrentPvOvermon.text = SliderPvOvermon.value + "" + "/";
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
