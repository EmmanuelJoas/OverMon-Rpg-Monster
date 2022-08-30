using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(test);
      
    }
}
