using UnityEngine.UI;
using UnityEngine;

public class PNJInteracteManager : MonoBehaviour
{
    #region Variables
    public GameObject interactImage;
    public GameObject InteractButton;
    public PnjDataManager Pnj;
    public static PNJInteracteManager instance;
    #endregion

    #region Unity Function

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            InteractButton.SetActive(true);
            interactImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            InteractButton.SetActive(false);
            interactImage.SetActive(false);
            InteractiveScript.instance.DesableInteraction();
        }
    }

    #endregion

}
