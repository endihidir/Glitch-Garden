using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Attacker))]// Bu Class ın ait olduğu objeyi  "(typeof(Attacker))" tipine bağımlı hale getiriyor
public class Fox : MonoBehaviour {


    private Animator anim;  //Eskiden bu kod (public static Animator anim;) şeklindeydi ve şöyle bir hataya yol açıyordu: Aniamtor sadece 
                            //sahneye ilk atılan tilkiyi algılayıp yalnızca onu Savunmacılara saldırtıyordu diğer tilkiler savunmacıları es geçiyordu isAttacking komutu diğer tilkilerde aktifleşmiyordu.
                            //Belki Unity bugıdır bilmiyorum. Belki sen bu hatanın olup olmadığını aradan epey zmana geçer denersin ve bu hata oluşmaz.
                            // Ve kesin öyle olur sen yalancı konumuna düşersin emin ol :) Ne değişik bir işin var senin aq !!! 
                            //(Aha bunu der demez eski haline döndürdün kodu o hata oluşmadı(derken 2. 3. denemede eskiye döndü) yine de o kadar emin olma derim).
                            //Senin yine de aklında bulunsun. Esas sebebi ne şu anda bilmiyorum cidden.
                            //Ama ilerde kendini geliştirip çok iyi ve tecrübeli bir yazılımcı olunca açıklamasını buraya eski ben için yazarsan sevinirim gardaş. Ha 
                            //bu arda inşallah kendine güzel bir manita yapmışsındır evlenip çoluk çocuk sahibi olmuşsundur. Yoksa ağzına sıçarım senin. Bir de maddi olarak iyi 
                            //kazanıyorsundur inşallah. Ya ben bunu buraya niye yazıyorum ki şimdi? Görüyosun işte 22-23 yaşlarında nasıl kafayı yediğini. Umarım hala böyle değilsindir.
                            //gerçi beterin beteri vardır daha da kötü olma da sen! buna da şükür. Hadi alasmaladık. Ulan alt tarafı hatanın sebebini yazacaktık kendimize geçmişten mektup yazdık iyimi.

    private Attacker attacker;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        // Eğer savunmacı yok ise metoddan ayrıl.
        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jump trigger");
        }
        else
        {
            anim.SetBool("isAttacking",true);
            attacker.Attack(obj);
        }
        

       // Debug.Log("Fox collided with : " + collision);
    }
}
