using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Transform attackPoint;
    public Animator animator;
    public CharacterStats stats;
    public float overlapCircleRadius = 0.25f;
    public float currentHealth;

    void Start(){
        stats = gameObject.GetComponentInChildren<CharacterStats>();
        attackPoint = stats.transform.Find("AttackPoint");
        currentHealth = stats.maxHealth;
    }

    void Update(){
        enabled = stats.alive;

        if(currentHealth <= 0){
            animator = gameObject.GetComponentInChildren<Animator>();
            animator.SetTrigger("die");
            stats.alive = false;
        }
    }

    void FixedUpdate(){
        Regen();
    }


    void Regen(){
        if(currentHealth < stats.maxHealth) currentHealth += stats.regenRate * Time.fixedDeltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, stats.maxHealth);
    }

    public void Attack(){
        Collider2D[] cols = Physics2D.OverlapCircleAll(attackPoint.position, overlapCircleRadius);
        foreach(Collider2D col in cols){
            if(col.gameObject.tag == gameObject.tag){
                Debug.Log("Self Hit");
                continue;
            }else if(col.tag == "Player" || col.tag == "Enemy"){
                Debug.Log(col.gameObject.name);
                col.gameObject.GetComponent<CombatSystem>().TakeDamage(stats.attackDamage);
            }
        }
    }

    public void TakeDamage(float damage){
        animator = gameObject.GetComponentInChildren<Animator>();
        animator.SetTrigger("takeDamage");
        currentHealth -= damage;
    }
}
