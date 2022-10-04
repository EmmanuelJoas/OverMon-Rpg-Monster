using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//Name space to use the event systems function.
using UnityEngine.EventSystems;
using DG.Tweening;

public class DisplayInfoOfPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    #region Variables

    /// <summary>
    /// Reference to the battle animation of the monster. 
    /// Use to play the battle animation of the monster. 
    /// </summary>
    public Animator OvermonAnim;

    /// <summary>
    /// Reference to the slider of Pv.
    /// Use to display Pv points of the monster in battle.
    /// </summary>
    public Slider SliderPvOvermon;

    /// <summary>
    /// Reference to the slider of Pa.
    /// Use to display Pa points of the monster in battle.
    /// </summary>
    public Slider SliderPaOvermon;

    /// <summary>
    /// Reference to the Text Current Pv Overmon.
    /// Use to display the current Pv points in battle.
    /// </summary>
    public Text TextCurrentPvOvermon;

    /// <summary>
    /// Reference to the max Pv overmon.
    /// Use to display the max Pv of the monster in battle.
    /// </summary>
    public Text TextMaxPvOvermon;

    /// <summary>
    /// Reference to the Text Current Pa Overmon.
    /// Use to display the current Pa points in battle.
    /// </summary>
    public Text TextCurrentPaOvermon;

    /// <summary>
    /// Reference to the max Pa overmon.
    /// Use to display the max Pa of the monster in battle.
    /// </summary>
    public Text TextMaxPaOvermon;

    /// <summary>
    /// Reference to the nam of the overmon
    /// Use to display the name of the monster in battle.
    /// </summary>
    public Text TextNameOvermon;

    /// <summary>
    /// Reference to the face of the overmon.
    /// Use to display the face of the overmon in battle.
    /// </summary>
    public Image OvermonFace;

    public GameObject DamageDisplayText;


    #endregion

    #region

    /// <summary>
    /// 
    /// </summary>
    public static DisplayInfoOfPlayer displayInfoOfPlayer;

    #endregion

    #region UnityMeyhod
    private void Awake()
    {
        displayInfoOfPlayer = this;
        OvermonFace = GameObject.FindGameObjectWithTag("ImageProfile").GetComponent<Image>();
        SliderPvOvermon = GameObject.FindGameObjectWithTag("PvSlider").GetComponent<Slider>();
        SliderPaOvermon = GameObject.FindGameObjectWithTag("ManaSlider").GetComponent<Slider>();
        TextMaxPvOvermon = GameObject.FindGameObjectWithTag("MaxPv").GetComponent<Text>();
        TextCurrentPvOvermon = GameObject.FindGameObjectWithTag("CurrentPv").GetComponent<Text>();
        TextMaxPaOvermon = GameObject.FindGameObjectWithTag("MaxMana").GetComponent<Text>();
        TextCurrentPaOvermon = GameObject.FindGameObjectWithTag("CurrentMana").GetComponent<Text>();
        TextNameOvermon = GameObject.FindGameObjectWithTag("MyOvername").GetComponent<Text>();

    }
   
    #endregion
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_MyOvermon"></param>
    public void OnDisplayInformationOfMonster(OvermonManager _MyOvermon)
    {
        if (gameObject)
        {
            SliderPvOvermon.maxValue = _MyOvermon.MaxHP;
            SliderPvOvermon.value = _MyOvermon.HP;
            SliderPaOvermon.maxValue = _MyOvermon.MaxMana;
            SliderPaOvermon.value = _MyOvermon.Mana;

            TextMaxPvOvermon.text = _MyOvermon.MaxHP + "" + "Pv";
            TextCurrentPvOvermon.text = _MyOvermon.HP + "" + "/";
            TextMaxPaOvermon.text = _MyOvermon.MaxMana + "" + "Pa";
            TextCurrentPaOvermon.text = _MyOvermon.Mana + "" + "/";

            TextNameOvermon.text = _MyOvermon.OvermonNickName;

            OvermonFace.sprite = _MyOvermon.OvermoneSpriteFace;
        }

    }

    /// <summary>
    /// Do this when the cursor enters the rect area of this selectable UI object.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnDisplayInformationOfMonster(transform.GetComponent<FightSysteme>().MyOvermon);
        
    }

    /// <summary>
    /// Do this when the cursor exit the rect area of this selectable UI object.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
       
    }

    /// <summary>
    /// 
    /// </summary>
    public void DisplayDamageInTheScene(float Damage)
    {
        StartCoroutine(SetDammageElement(Damage));
    }
    
    IEnumerator SetDammageElement(float _Damage)
    {
        GameObject Clone = Instantiate(DamageDisplayText,gameObject.transform,gameObject.transform);
        Clone.transform.GetComponent<Text>().text = _Damage +"";
        Clone.transform.SetParent(gameObject.transform);
        Clone.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(0.8f);
        Destroy(Clone);
    }
}

