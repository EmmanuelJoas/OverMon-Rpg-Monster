using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public GameObject SelectOvermonPanel;

    public FightSysteme CurrentOvermon;

    #endregion
    private void Awake()
    {
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        CurrentOvermon = gameObject.transform.GetChild(0).gameObject.GetComponent<FightSysteme>();
        CurrentOvermon.SelectedEnemy();
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
        CurrentOvermon.SelectedEnemy();
    }

    public void ActiveSelectPanel()
    {
        SelectOvermonPanel.SetActive(true);
    }
}
