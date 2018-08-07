using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordEffectAnim;
    
	void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordEffectAnim = transform.GetChild(1).GetComponent<Animator>();
	}

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump (bool jump)
    {
        _anim.SetBool("Jumping", jump);
    }

    public void Attack ()
    {
        _anim.SetTrigger("Attack");
        _swordEffectAnim.SetTrigger("ArcAnimation");
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }
}
