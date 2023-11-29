using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightning : StateMachineBehaviour
{
    Boss info;
    GameObject lightning;
    float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        info = animator.GetComponent<Boss>();
        lightning = info.bullet;
        info.callLightning();
        timer = 4;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
            animator.SetBool("BossIdle", true);
        else
            timer -= Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("AttackLightning", false);
    }

}
