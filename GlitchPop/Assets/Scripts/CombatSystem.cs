using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Transform attackPoint;
    public CharacterStats stats;
    public float overlapCircleRadius = 0.25f;
    public float currentHealth;

    void Start(){
        stats = gameObject.GetComponent<CharacterManager>().currentCharacter.GetComponent<CharacterStats>();
        currentHealth = stats.maxHealth;
    }

    public void Attack(){
        Collider2D col = Physics2D.OverlapCircle(attackPoint.position, overlapCircleRadius);
        if(col != null){
            if(col.tag == "Player" || col.tag == "Enemy"){
                col.gameObject.GetComponent<CombatSystem>().TakeDamage(stats.attackDamage);
            }
        }
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
    }
}
