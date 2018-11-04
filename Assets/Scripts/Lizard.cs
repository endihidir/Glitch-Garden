using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Bu Class ın ait olduğu objeyi  "(typeof(Rigidbody2D))" tipine bağımlı hale getiriyor.
                                        // Yani siz bu kodu silmediğiniz takdirde istesenizde Lizard Objesinden Rigidbody2D yi silemiyorsunuz.
public class Lizard : MonoBehaviour {
    private Animator anim;
    private Attacker attacker;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        // Eğer savunmacı yok ise metoddan ayrıl.

        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        anim.SetBool("isAttacking", true);
        attacker.Attack(obj);
    }
}
