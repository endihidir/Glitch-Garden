using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
        
    }
    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>(); // 5 adet Spawner GameObject olduğu için onları içine atıyor.
        foreach (Spawner spawner in spawnerArray)//spawner a burada Spawner GameObjectlerin hepsi aktarılıyor.
        {
            //Buradaki if komutu herhangi bir savunmacı sahneye konulduğunda eğer o savunmacının y pozisyonuyla eşdeğer herhangi bir saldırgana ait y pozisyonu varsa if komutunun içerisine girer
            //Eğer sen Spawner(saldırgan) objelerinden birini silersen ve onun ile aynı hizaya bir savunmacı yerleştirirsen hata mesajı alırsın çünkü y ler eşleşmediğinden if komutu çalışmaz.
            //ve foreach döngüsü boş kalır.
            
            if (spawner.transform.position.y == transform.position.y)//spawner.transform.position.y = Saldıranların y pozisyonu. transform.position.y= Savunmacıların y pozisyonu
            {
                // Her Savunmacı oyuna yerleştirildiğinde Spawner(Saldırganın üretildiği obje Saldırgan değil yani) ın y pozisyonu savunmacının y pozisyonu ile eşleşiyor. Yani her savunmacı 
                // yerleştirildiğinde if komutu içerisine giriliyor. 
                // Burada hangi spawner(saldırgan ın üretildiği yer) objesinin y pozisyonu, defansın objesinin y pozisyonu ile eşleştiyse O Saldırganın üretildiği objeyi myLaneSpawner a atamış oluyor.
                // yani myLaneSpawner aslında saldırganın üretildiği obje(spawner) olmuş oluyor.
                myLaneSpawner = spawner;
                return;
            }
        }
    }

    bool IsAttackerAheadInLane()
    {
        // Sahnede saldırganlar yok ise
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        //Saldırganlar savunmacıların önündeyse 
        foreach (Transform attackers in myLaneSpawner.transform)
        {
            if (attackers.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        // Saldırganlar savunmacıların arkasında kaldıysa.
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
