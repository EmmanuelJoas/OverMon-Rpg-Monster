using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class EndBattleScript : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
