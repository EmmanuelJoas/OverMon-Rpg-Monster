
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        //we move the camera according to the values of our variables 
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);

    }
}
