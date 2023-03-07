using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform spriteTransform;
    public float moveDir;
    public bool attacking = false;
    public float spawnPoint = 0;
    public Animator animator;
    public CombatSystem combatScript;
    public CharacterStats stats;
    public Transform player;
    public float attackCoolDownTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        combatScript = gameObject.GetComponent<CombatSystem>();
        stats = gameObject.GetComponentInChildren<CharacterStats>();
        spriteTransform = stats.transform;
        combatScript.animator = animator;
        spawnPoint = transform.position.x;
        moveDir = 1;
    }

    void Update()
    {
        enabled = stats.alive;

        float xpos = transform.position.x;
        
        if(Mathf.Abs(player.position.x - transform.position.x) <= stats.moveRange){
            float dist = player.position.x - transform.position.x;
            moveDir = Mathf.Sign(dist);
            dist = Mathf.Abs(dist);
            if(dist <= stats.attackDist){
                if(attackCoolDownTimer <= 0){
                    moveDir = 0;
                    animator.SetTrigger("attack");
                    combatScript.Attack();
                    attackCoolDownTimer = 1/stats.attackRate;
                }
            }

        }else if(xpos >= spawnPoint + stats.moveRange){
            moveDir = -1;
        }else if(xpos <= spawnPoint - stats.moveRange){
            moveDir = 1;
        }

        if(moveDir != 0){
            animator.SetBool("walking", true);
            spriteTransform.localScale = new Vector3(-moveDir, 1, 1);
        }else{
            animator.SetBool("walking", false);
        }
        
        if(attackCoolDownTimer > 0) attackCoolDownTimer -= Time.deltaTime;
    }

    void FixedUpdate(){
        Vector2 vel = Vector2.zero;
        vel.x = !attacking ? moveDir * stats.moveSpeed * Time.fixedDeltaTime : 0;
        vel.y = rb.velocity.y;
        rb.velocity = vel;
    }
}
