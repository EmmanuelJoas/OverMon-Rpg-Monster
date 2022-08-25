using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public GameObject SelectOvermonPanel;

    public static FightSysteme CurrentOvermon;

    public static GameManager instance;


    #endregion
    private void Awake()
    {
        instance = this;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        CurrentOvermon = gameObject.transform.GetChild(0).gameObject.GetComponent<FightSysteme>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
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

    public void ActiveSelectPanel()
    {
        SelectOvermonPanel.SetActive(true);
    }
}
