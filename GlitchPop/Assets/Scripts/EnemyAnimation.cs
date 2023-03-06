using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator playerAnimator;
    public EnemyBehaviour movementScript;
    public CombatSystem combatScript;
    void Start()
    {
        movementScript = gameObject.GetComponent<EnemyBehaviour>();
        playerAnimator = gameObject.GetComponentInChildren<Animator>();
        combatScript.animator = playerAnimator;
    }

    void FixedUpdate()
    {        
        if(movementScript.moveDir != 0){
            playerAnimator.SetBool("walking", true);
        }
        else{
            playerAnimator.SetBool("walking", false);
        }
    }
}
