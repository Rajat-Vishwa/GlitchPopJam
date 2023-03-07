using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] Characters;
    public GameObject currentCharacter;
    public int maxCharacters;
    public bool Switch = false;
    public PlayerMovement movementScript;
    public CombatSystem combatScript;
    void Start()
    {
        maxCharacters = Characters.Length;
        movementScript = gameObject.GetComponent<PlayerMovement>();
        combatScript = gameObject.GetComponent<CombatSystem>();
        ChangeCharacter();
    }

    void Update()
    {
        enabled = combatScript.stats.alive;

        if(Switch){
            ChangeCharacter();
            Switch = false;
        }
    }

    public void ChangeCharacter(){
        int index = Random.Range(0, maxCharacters);
        for(int i=0; i<maxCharacters; i++){
            if(i == index){
                Characters[i].SetActive(true);
            }else{
                Characters[i].SetActive(false);
            }
        }
        currentCharacter = Characters[index];
        movementScript.spriteTransform = currentCharacter.transform;
        movementScript.animator = currentCharacter.GetComponent<Animator>();
        combatScript.stats = currentCharacter.GetComponent<CharacterStats>();
        movementScript.stats = currentCharacter.GetComponent<CharacterStats>();
    }
}
