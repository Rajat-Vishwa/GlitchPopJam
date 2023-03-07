using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal connectsTo;
    public Transform player;
    public float distThreshold = 1f;
    public float coolDownTime = 1f;
    public float timer;
    void Start(){
        player = GameObject.Find("Player").transform;
    }
    void Update(){
        if(Mathf.Abs(player.position.x - transform.position.x) <= distThreshold){    
            if(Input.GetKeyDown(KeyCode.E) && timer <= 0){
                player.position = connectsTo.transform.position;
                connectsTo.timer = coolDownTime;
                timer = coolDownTime;
            }
        }
        
        if(timer > 0) timer -= Time.deltaTime;
    }
}
