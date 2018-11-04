using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    Animator underAttacking;
    //Yalnızca Tag için kullanılıyor.

    private void Start()
    {
        underAttacking = GetComponent<Animator>();
    }
   
    
    private void OnTriggerStay2D(Collider2D col)
    {
        Attacker attacker = col.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            underAttacking.SetTrigger("underAttack trigger");
        }
    }
    

   
}
