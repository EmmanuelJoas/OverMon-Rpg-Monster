//Name space to use the unity base function 
using UnityEngine;

/// <summary>
/// Class use to the mouvement of the camera 
/// </summary>
public class CameraFolow : MonoBehaviour
{
    #region Variables 

    /// <summary>
    /// Reference to the player 
    /// </summary>
    [SerializeField]
    private GameObject player;

    #endregion


    #region Unity function 

    /// <summary>
    /// Reference to the function who  called after all Update functions have been called
    /// </summary>
    void LateUpdate()
    {
        //we move the camera according to the values of our variables 
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);

    }

    #endregion
}
