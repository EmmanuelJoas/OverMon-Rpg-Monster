using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject TestObject;
    public GameObject selectHero;

    public void SetObject()
    {
        SceneManager.LoadScene("StartCity");
    }
}
