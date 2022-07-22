using UnityEngine.UI;
using UnityEngine;

public class InteractiveScript : MonoBehaviour
{
    #region Variables
    public Text InteractText;
    public Text NamePnjtText;
    public GameObject FaceImage;
    public GameObject interactPanel;
    public static InteractiveScript instance;
    #endregion

    #region Unity Function 

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InteractText.text = PNJInteracteManager.instance.Pnj.InteractionPnj;
        NamePnjtText.text = PNJInteracteManager.instance.Pnj.name;
        FaceImage.GetComponent<Image>().sprite = PNJInteracteManager.instance.Pnj.PnjFace;
    }

    #endregion

    #region MyPrivate Function

    public void DisplayInteraction()
    {
        interactPanel.SetActive(true);
    }
    public void DesableInteraction()
    {
        interactPanel.SetActive(false);
    }
    #endregion
}
