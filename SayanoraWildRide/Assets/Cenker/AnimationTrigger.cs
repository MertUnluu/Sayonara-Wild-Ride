using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
       
    }


    public void playAnimation(string animationName)
    {
        anim.Play(animationName);
    }
}
