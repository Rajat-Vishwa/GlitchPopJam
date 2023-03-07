using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform spriteTransform;
    public float moveDir;
    //public bool isJumping, wantJump, isGrounded;
    //public float jumpSpeed = 100;
    //public float footOverLapCircleRadius = 0.1f;
    public float moveSpeed = 100;
    public bool attacking = false;
    public Animator animator;
    public CombatSystem combatScript;
    public CharacterStats stats;

    public float attackCoolDownTimer;
   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        combatScript = gameObject.GetComponent<CombatSystem>();
        stats = gameObject.GetComponentInChildren<CharacterStats>();
    }

    void Update()
    {
        enabled = stats.alive;

        moveDir = Input.GetAxisRaw("Horizontal");
        attacking = Input.GetMouseButton(0);
        // if(Input.GetKeyDown("space") && isGrounded){
        //     wantJump = true;
        // }

        if(Input.GetMouseButtonDown(0)){
            if(attackCoolDownTimer <= 0){
                animator.SetTrigger("attack");
                combatScript.Attack();
                attackCoolDownTimer = 1/stats.attackRate;
            }
        }


        if(attackCoolDownTimer > 0) attackCoolDownTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        // LayerMask mask = LayerMask.GetMask("Map");
        // if(Physics2D.OverlapCircle(spriteTransform.position, footOverLapCircleRadius, mask)){
        //     isGrounded = true;
        //     isJumping = false;
        // }else{
        //     isGrounded = false;
        // }

        if(moveDir != 0){
            animator.SetBool("walking", true);
            spriteTransform.localScale = new Vector3(-moveDir, 1, 1);
        }else{
            animator.SetBool("walking", false);
        }
        
        Vector2 vel = Vector2.zero;
        vel.x = !attacking ? moveDir * moveSpeed * Time.fixedDeltaTime : 0;
        vel.y = rb.velocity.y;
        // if(wantJump && isGrounded){
        //     wantJump = false;
        //     isJumping = true;
        //     vel.y = jumpSpeed;
        // }else{
        //     vel.y = rb.velocity.y;
        // }
        rb.velocity = vel;
    }


}
