using UnityEngine;

public class Normal_AttackButton : MonoBehaviour
{
    public void AttachCallback()
    {
        EventManager.eventManager.OnClickActionNormalAttack();

    }
}
