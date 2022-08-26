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

    /// <summary>
    /// 
    /// </summary>
    public Animator OvermonAnim;

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
    private FightManager FightManager;

    /// <summary>
    /// 
    /// </summary>
    public GameObject DamageText;

    /// <summary>
    /// 
    /// </summary>
    public int ManaPoint;

    /// <summary>
    /// 
    /// </summary>
    public int AddMana;

    #endregion

    #region Unity Function

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        OvermonAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
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

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        _OpponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();
        DamageText.SetActive(false);
        DisplayInfoOvermon();
    }

    #endregion

    #region My Private Function 

    /// <summary>
    /// 
    /// </summary>
   public void DisplayInfoOvermon()
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="btn"></param>
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
        IsMagic = false;
        FightManager.NextTurn();
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
            SaveState();
        }

    }  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Heal"></param>
    public void SelectSkills(float Heal)
    {
        if (SliderPvOvermon.value < SliderPvOvermon.maxValue)
        {
            float CurrentHeal = Heal;
            SliderPvOvermon.value += CurrentHeal;
            TextCurrentPvOvermon.text = SliderPvOvermon.value + "" + "/";
        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator LateState()
    {
         yield return new WaitForSeconds(0.9f);
         OvermonAnim.SetTrigger("Hit");
         TextCurrentPvOvermon.text = SliderPvOvermon.value + "" + "/";
         StartCoroutine(DisplayDamage());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator DisplayDamage()
    {
        DamageText.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        DamageText.SetActive(false);
       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool GetDead()
    {
        return Dead;
    }

    /// <summary>
    /// 
    /// </summary>
    void SaveState()
    {
        MyOvermon.HP = SliderPvOvermon.value;
        MyOvermon.Mana = SliderPaOvermon.value;
    }
    #endregion
}
