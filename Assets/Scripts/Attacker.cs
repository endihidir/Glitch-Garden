using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Ortaya çıkışlar arasındaki ortalama saniye sayısı.")]

    public float seenEverySeconds;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;


	void Start () {
        //Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        //myRigidbody.isKinematic = true;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
        //print(Button.selectedDefener);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name +" Trigger Enter.");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }
    //Attack metodu Fox ve Lizard sınıflarından çağrılıp objeler atanıyor.
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

    
}
