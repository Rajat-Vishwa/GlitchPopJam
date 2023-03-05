using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimator;
    public PlayerMovement movementScript;
    void Start()
    {
        movementScript = gameObject.GetComponent<PlayerMovement>();
        playerAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        playerAnimator.SetBool("attacking", movementScript.attacking);
        
        if(movementScript.moveDir != 0){
            playerAnimator.SetBool("walking", true);
        }
        else{
            playerAnimator.SetBool("walking", false);
        }
    }
}
