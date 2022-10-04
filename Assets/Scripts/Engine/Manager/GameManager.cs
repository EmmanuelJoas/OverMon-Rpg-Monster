using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// 
    /// </summary>
    public GameObject SelectOvermonPanel;

    public GameObject StartPositionFromMyOvermon;

    public GameObject StartPositionFromMyOpponentOvermon;

    public GameObject OvermonProfile;

    public GameObject OponentProfile;

    public Transform UiPositionOvermonProfile;

    public Transform UiPositionOponentOvermonProfile;

    public Transform UIPositionCombatOptionMenu;

    public GameObject StartButtonBattle;

    public GameObject SelectedOvermonPanel;

    /// <summary>
    /// 
    /// </summary>
    public GameObject InteractSartPanel;

    /// <summary>
    /// 
    /// </summary>
    public GameObject combatOptionMenu;

    /// <summary>
    /// 
    /// </summary>
    public Image FaceOponent;

    /// <summary>
    /// 
    /// </summary>
    public Image FaceOvermon;

    #endregion

    /// <summary>
    /// 
    /// </summary>
    public void StartBattle()
    {
        StartCoroutine(BeginingBattle());
        StartButtonBattle.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator BeginingBattle()
    {

        FightSysteme CurrentOvermon = StartPositionFromMyOvermon.transform.GetChild(0).GetComponent<FightSysteme>();
        EnemyFightSystem OponentOvermon= StartPositionFromMyOpponentOvermon.transform.GetChild(0).GetComponent<EnemyFightSystem>();
        FaceOvermon.sprite = CurrentOvermon.MyOvermon.OvermoneSpriteFace;
        FaceOponent.sprite = OponentOvermon.OpponentOvermon.OvermoneSpriteFace;
        yield return new WaitForSeconds(0.5f);
        InteractSartPanel.SetActive(true);

        combatOptionMenu.SetActive(false);

        yield return new WaitForSeconds(2f);

        InteractSartPanel.SetActive(false);
        combatOptionMenu.SetActive(true);

        BattleManager.battleManager.NextTurn();

        OvermonProfile.transform.DOMove(UiPositionOvermonProfile.position,1.5f);
        OponentProfile.transform.DOMove(UiPositionOponentOvermonProfile.position,1.5f);
        combatOptionMenu.transform.DOMove(UIPositionCombatOptionMenu.position, 1.5f);

    }

    public void ActiveTheSelectOvermonPanel()
    {
       SelectedOvermonPanel.SetActive(true);
    }
}
