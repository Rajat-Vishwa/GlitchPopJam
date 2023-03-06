using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform spriteTransform;
    public float moveDir;
    public float moveSpeed = 100;
    public bool attacking = false;
    public float moveRange = 10f;
    public float spawnPoint = 0;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spawnPoint = transform.position.x;
        moveDir = 1;
    }

    void Update()
    {
        //moveDir = Input.GetAxisRaw("Horizontal");
        //attacking = Input.GetMouseButton(0);
        
    }

    void FixedUpdate()
    {
        float xpos = transform.position.x;
        if(xpos >= spawnPoint + moveRange){
            moveDir = -1;
        }else if(xpos <= spawnPoint - moveRange){
            moveDir = 1;
        }
        
        if(moveDir != 0){
            spriteTransform.localScale = new Vector3(-moveDir, 1, 1);
        }
        
        Vector2 vel = Vector2.zero;
        vel.x = !attacking ? moveDir * moveSpeed * Time.fixedDeltaTime : 0;
        vel.y = rb.velocity.y;
        rb.velocity = vel;
    }
}
