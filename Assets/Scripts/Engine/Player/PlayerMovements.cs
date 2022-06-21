//Name space to use the collection systeme function 
using System.Collections;

//use the systeme collection generique function 
using System.Collections.Generic;

//Name space to use the unity base function 
using UnityEngine;

// the class who reference the mouvement of the player  
public class PlayerMovements : MonoBehaviour
{
    #region Variables 

    /// <summary>
    /// Reference to the speed move of the player 
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// Reference to the sprite renderer of the player 
    /// </summary>
    [SerializeField]
    private SpriteRenderer GraphicsPlayer;

    /// <summary>
    /// Reference to the animation of the player 
    /// </summary>
    [SerializeField]
    private Animator PlayerAnimation;

    /// <summary>
    /// Reference to the vecotor move of the player 
    /// </summary>
    private Vector2 direction;

    #endregion

    #region Unity function 

    /// <summary>
    /// Reference to the function who starts at the start af the game 
    /// </summary>
    private void Start()
    {
        direction = Vector2.zero;
    }

    /// <summary>
    /// Reference to the function who throws it at each frame 
    /// </summary>
    private void Update()
    {
        PlayreMove();
        GetInput();
    }

    #endregion

    #region My Private Function 

    /// <summary>
    /// Reference to the function who called for move the player 
    /// </summary>
    private void PlayreMove()
    {

        transform.Translate(direction*speed*Time.deltaTime);
        
    }

    /// <summary>
    /// Reference to the function who called for get the input of the Keybord 
    /// </summary>
    private void GetInput()
    {
        direction = Vector2.zero;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;

            GraphicsPlayer.flipX = false;
           
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;

            GraphicsPlayer.flipX = true;
        }
        
        AnimationPlayerRun(Mathf.Abs(direction.x));

        AnimationPlayerDown(direction.y);

        AnimationPlayerUp(direction.y);

        Debug.Log(direction);

    }

    /// <summary>
    /// Reference to the function who called for start the animation move "run" of the player 
    /// </summary>
    /// <param name="_direction"></param>
    void AnimationPlayerRun(float _direction)
    {
        PlayerAnimation.SetFloat("IsRun",_direction);
    }

    /// <summary>
    /// Reference to the function who called for start the animation move "Down" of the player 
    /// </summary>
    /// <param name="_direction"></param>
    void AnimationPlayerDown(float _direction)
    {
        PlayerAnimation.SetFloat("IsDown", _direction);
    }

    /// <summary>
    /// Reference to the function who called for start the animation move "Up" of the player 
    /// </summary>
    /// <param name="_direction"></param>
    void AnimationPlayerUp(float _direction)
    {
        PlayerAnimation.SetFloat("IsUp", _direction);
    }

    #endregion
}

