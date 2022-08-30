using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// 
    /// </summary>
    public GameObject SelectOvermonPanel;

    /// <summary>
    /// 
    /// </summary>
    public static FightSysteme CurrentOvermon;

    /// <summary>
    /// 
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// 
    /// </summary>
    public GameObject InteractSartPanel;

    /// <summary>
    /// 
    /// </summary>
    public GameObject HeroInBattle;

    /// <summary>
    /// 
    /// </summary>
    public GameObject ActionPanel;

    /// <summary>
    /// 
    /// </summary>
    public GameObject OptionInBattle;

    /// <summary>
    /// 
    /// </summary>
    public Image FaceOponent;

    /// <summary>
    /// 
    /// </summary>
    public Image FaceOvermon;

    /// <summary>
    /// 
    /// </summary>
    public EnemyFightSystem OponentOvermon;

    /// <summary>
    /// 
    /// </summary>
    public GameObject OvermonDataBase;

    /// <summary>
    /// 
    /// </summary>
    public GameObject[] overmonDataBase;

    /// <summary>
    /// 
    /// </summary>
    public Sprite[] BackGrounds;

    #endregion

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < OvermonDataBase.transform.childCount; i++)
        {
            overmonDataBase[i] = OvermonDataBase.transform.GetChild(i).gameObject;
        }
        
        overmonDataBase[0].SetActive(true);
        
        CurrentOvermon = overmonDataBase[0].GetComponent<FightSysteme>();
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        OponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Index"></param>
    public void SelectOvermon(int Index)
    {
        overmonDataBase[Index].SetActive(true);
        CurrentOvermon = overmonDataBase[Index].GetComponent<FightSysteme>();
        CurrentOvermon.DisplayInfoOvermon();
        Special_AttackButton.instance.UpdateFighter();
        Run_Button.instance.UpdateFighter();
        Normal_AttackButton.instance.UpdateFighter();
        FightManager.instance.UpdateFighther();
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetHeroInBattle()
    {
        CurrentOvermon.transform.SetParent(HeroInBattle.transform);
        CurrentOvermon.transform.position = HeroInBattle.transform.position;
        SelectOvermonPanel.SetActive(false);
        StartCoroutine(StartBattle());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator StartBattle()
    {
        FaceOvermon.sprite=CurrentOvermon.MyOvermon.OvermoneSpriteFace;
        FaceOponent.sprite = OponentOvermon.OpponentOvermon.OvermoneSpriteFace;
        yield return new WaitForSeconds(0.5f);
        InteractSartPanel.SetActive(true);
        ActionPanel.SetActive(false);
        OptionInBattle.SetActive(false);
        yield return new WaitForSeconds(2f);
        InteractSartPanel.SetActive(false);
        OptionInBattle.SetActive(true);
        ActionPanel.SetActive(true);

    }
}
