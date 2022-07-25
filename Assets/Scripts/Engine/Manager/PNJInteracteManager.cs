using UnityEngine.UI;
using UnityEngine;

public class PNJInteracteManager : MonoBehaviour
{
    #region Variables
    public GameObject interactImage;
    public GameObject InteractButton;
    public PnjDataManager Pnj;
    public static PNJInteracteManager instance;
    public Text InteractText;
    public Text NamePnjtText;
    public GameObject FaceImage;
    public GameObject interactPanel;
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
            DisplayInteract();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractButton.SetActive(false);
            interactImage.SetActive(false);
            interactPanel.SetActive(false);
        }
    }

    #endregion

    public void DisplayInteract()
    { 
     
        InteractText.text = Pnj.InteractionPnj;
        NamePnjtText.text = Pnj.NamePnj;
        FaceImage.GetComponent<Image>().sprite = Pnj.PnjFace;
       
    }
}
