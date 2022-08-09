using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimations : MonoBehaviour
{
    public Animator Animator;
    public bool IsAttack;
    public bool IsAttack2;


    private void Start()
    {
        Animator = transform.GetComponent<Animator>();
    }


    public void StartAttk1()
    {
        //IsAttack = true;
        //Animator.SetBool("IsAttack",IsAttack);
        //StartCoroutine(normalState());
        Animator.SetTrigger("IsAttack 0");

    }

   public  void StartAttk2()
   {
        //IsAttack2 = true;
        //Animator.SetBool("IsAttack2",IsAttack2);
        //StartCoroutine(normalState());
        Animator.SetTrigger("IsAttack2 ");
   }

   /* IEnumerator  normalState()
    {
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorClipInfo(0).Length);
        IsAttack = false;
        IsAttack2 = false;
        Animator.SetBool("IsAttack", IsAttack);
        Animator.SetBool("IsAttack2", IsAttack2);
    }*/
}
