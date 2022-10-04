using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOvermonInTheBattleScene : MonoBehaviour
{
    public GameObject WhereIsHeroInBattle;
    public Transform _WhereIsHeroInBattle;
    public GameObject WhereIsMyOvermon;
    public GameObject SelectedOvermonPanel;
    public FightSysteme fightSysteme;

    /// <summary>
    /// 
    /// </summary>
    public void SetObject()
    {
        if (WhereIsMyOvermon.transform.childCount<=0)
        {
            var clone = Instantiate(this, WhereIsHeroInBattle.transform, _WhereIsHeroInBattle);
            clone.name = "Clone";
            clone.transform.position = _WhereIsHeroInBattle.position;
            clone.transform.SetParent(WhereIsMyOvermon.transform);
            clone.transform.GetComponent<Button>().enabled = false;
            fightSysteme = clone.transform.GetComponent<FightSysteme>();
            EventManager.eventManager.ClickAction_NormalAttack += fightSysteme.Normal_AttckButton;
            EventManager.eventManager.ClickAction_SpecialAttack += fightSysteme.Special_AttckButton;
            DisplayInfoOfPlayer.displayInfoOfPlayer.OnDisplayInformationOfMonster(fightSysteme.MyOvermon);
        }
        else
        {
            Destroy(WhereIsMyOvermon.transform.GetChild(0).gameObject);
            var clone = Instantiate(this, WhereIsHeroInBattle.transform, _WhereIsHeroInBattle);
            clone.name = "Clone";
            clone.transform.position = _WhereIsHeroInBattle.position;
            clone.transform.SetParent(WhereIsMyOvermon.transform);
            clone.transform.GetComponent<Button>().enabled = false;
        }

        EventManager.eventManager.OnUpdateFighterIntheScene();
        SelectedOvermonPanel.SetActive(false);
    }
}
