using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracteButton : MonoBehaviour
{
    public GameObject InteractPanel;

   public void IsActive()
   {
       InteractPanel.SetActive(true);
   }
}
