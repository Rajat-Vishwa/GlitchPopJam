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

    void Update()
    {
        if(movementScript.moveDir != 0){
            playerAnimator.SetBool("walking", true);
        }else{
            playerAnimator.SetBool("walking", false);
        }
    }
}
