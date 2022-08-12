using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public GameObject[] MyOvermon;

    public GameObject StartMyOvermonPosition;



    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectOvermon(int Index)
    {
        Instantiate(MyOvermon[Index],new Vector3(StartMyOvermonPosition.transform.position.x, StartMyOvermonPosition.transform.position.y,0), Quaternion.identity);
    }
}
