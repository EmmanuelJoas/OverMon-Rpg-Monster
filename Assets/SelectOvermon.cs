using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOvermon : MonoBehaviour
{
    #region Variables 

    public int Index;

    public GameManager GameManager;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected()
    {
        if (GameObject.FindGameObjectWithTag("Hero"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Hero"));
            GameManager.SelectOvermon(Index);
        }
        else
        {
            GameManager.SelectOvermon(Index);
        }
    }
}
