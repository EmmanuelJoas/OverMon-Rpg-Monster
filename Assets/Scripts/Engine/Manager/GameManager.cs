using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public GameObject SelectOvermonPanel;

    public static FightSysteme CurrentOvermon;

    public static GameManager instance;

    public GameObject InteractSartPanel;

    public GameObject HeroInBattle;

    public GameObject ActionPanel;

    public GameObject OptionInBattle;

    public Image FaceOponent;

    public Image FaceOvermon;

    public EnemyFightSystem OponentOvermon;

    public GameObject OvermonDataBase;

    public GameObject[] overmonDataBase;




    #endregion
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
    // Start is called before the first frame update
    void Start()
    {
        OponentOvermon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectOvermon(int Index)
    {
        gameObject.transform.GetChild(Index).gameObject.SetActive(true);
        CurrentOvermon=gameObject.transform.GetChild(Index).gameObject.GetComponent<FightSysteme>();
        CurrentOvermon.DisplayInfoOvermon();
        Special_AttackButton.instance.UpdateFighter();
        Run_Button.instance.UpdateFighter();
        Normal_AttackButton.instance.UpdateFighter();
        FightManager.instance.UpdateFighther();
    }

    public void SetHeroInBattle()
    {
        CurrentOvermon.transform.SetParent(HeroInBattle.transform);
        CurrentOvermon.transform.position = HeroInBattle.transform.position;
        SelectOvermonPanel.SetActive(false);
        StartCoroutine(StartBattle());
    }

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
