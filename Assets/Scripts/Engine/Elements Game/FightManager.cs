using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    #region Variables 

    public static FightManager instance;

    public List<OvermonManager> MyOvermon;

    public List<OvermonManager> OppenentOvermon;

    public OvermonManager MyCurrentOvermon;

    public OvermonManager OpponentCurrentOvermon;

    private OvermonManager _MyOvermonBase;

    private OvermonManager _MyOpponentOvermonBase;

    public List<(OvermonManager,OvermonMove)> Attacks =new List<(OvermonManager, OvermonMove)>();

    #endregion

    #region Unity function 

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Creates clones across instances to avoid modifying scriptableObject
        MyCurrentOvermon = Instantiate(MyCurrentOvermon);
        OpponentCurrentOvermon = Instantiate(OpponentCurrentOvermon);
        _MyOvermonBase = Instantiate(MyCurrentOvermon);
        _MyOpponentOvermonBase = Instantiate(OpponentCurrentOvermon);

    }

    // Update is called once per frame
    void Update()
    {
        if (Attacks.Count > 0) return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChooseMove(MyCurrentOvermon.Moves[0] , MyCurrentOvermon);
        }

    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="move"></param>
    /// <param name="Attacker"></param>
    void ChooseMove(OvermonMove Move,OvermonManager Attacker)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="move"></param>
    /// <param name="attackerOvermon"></param>
    /// <param name="defenderOvermon"></param>
    void CalculDamages(OvermonMove move, OvermonManager attackerOvermon, OvermonManager defenderOvermon )
    {
        int damage = (int)((((2 * attackerOvermon.lvl / 5) + 2) * move.Power * (attackerOvermon.Attack / defenderOvermon.Defence) / 50) + 2);

    }
}
