using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    public CombatSystem combatScript;
    void Start()
    {
        combatScript = gameObject.GetComponentInParent<CombatSystem>();
        bar = transform.Find("Bar");
    }

    void Update()
    {
        float scl = Mathf.Abs(combatScript.currentHealth / combatScript.stats.maxHealth);
        bar.localScale = new Vector3(scl, bar.localScale.y, bar.localScale.z);    
    }
}
