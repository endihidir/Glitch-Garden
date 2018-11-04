using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    public float speed, damage;
	// Use this for initialization
	void Start () {
      
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }

    /* Çalışmadı çünkü projectile scripti zuccini içerisindeki body e bağlı değil ve
     * Bu metod da Sprite Renderer a göre çalıştığından dolayı da görseli bulamıyor ve çalışmıyor.
     * 
    void OnBecameInvisible()//Obje Kamera dışına çıktığında çalışır 
    {
        Destroy(gameObject);
    }*/
}
