using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    #region Event Handler

    /// <summary>
    /// 
    /// </summary>
    public static EventManager eventManager;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler ClickAction_NormalAttack;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler ClickAction_SpecialAttack;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler ClickAction_Run;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler UpdateFighterInTheScene;

    #endregion
    private void Awake()
    {
        eventManager = this;
    }
    /// <summary>
    /// 
    /// </summary>
    public void OnClickActionNormalAttack()
    {
        ClickAction_NormalAttack?.Invoke(this,EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnClickActionSpecialAttack()
    {
        ClickAction_SpecialAttack?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnClickActionRunk()
    {
        ClickAction_Run?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnUpdateFighterIntheScene()
    {
        UpdateFighterInTheScene?.Invoke(this, EventArgs.Empty);
    }
}
