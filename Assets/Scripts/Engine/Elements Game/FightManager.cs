using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    public List<OvermonManager> MyOvermon;
    public List<OvermonManager> OppenentOvermon;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalcDamages(OvermonMove move, OvermonManager attackerOvermon, OvermonManager defenderOvermon )
    {
        int damage = (int)((((2 * attackerOvermon.lvl / 5) + 2) * move.Power * (attackerOvermon.Attack / defenderOvermon.Defence) / 50) + 2);
    }
}
