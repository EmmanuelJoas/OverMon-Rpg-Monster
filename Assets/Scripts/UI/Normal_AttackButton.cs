using UnityEngine;

public class Normal_AttackButton : MonoBehaviour
{
    #region
    public FightSysteme hero;
    private string temp;

    public static Normal_AttackButton instance;
    #endregion

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        temp = gameObject.name;
        UpdateFighter();
    }

    public void AttachCallback(string btn)
    {
        btn = temp;
        if (btn == "Normal_AttckButton")
        {
            hero.SelectAttack("Normal_AttckButton");
        }

    }
    public void UpdateFighter()
    {
        hero = GameManager.CurrentOvermon;
    }

}
