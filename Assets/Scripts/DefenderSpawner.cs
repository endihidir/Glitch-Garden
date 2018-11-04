using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private StarDisplay starDisplay;
    private Defender def;
    private GameObject defenderParent;
    private int defenderCost;

    private void Start()
    {
        //Defenders objesi varsa bul ve defenderParent a at
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        
        //Eğer Defenders objesi yok ise "new GameObject("Defenders");" ile Defenders objesi yarat ve defenderParent a at
        if (!defenderParent)
        {
           defenderParent = new GameObject("Defenders");
        }
    }

    


    private void OnMouseDown()
    {
        /* Debug.Log(Input.mousePosition);
         print(CalculateWorldPointMouseClick());
         print(SnapToGrid(CalculateWorldPointMouseClick()));*/
        
        Vector2 rawPos = CalculateWorldPointMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefener;
        defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
        


        //Aynı bölgeye tekrar klonlayamamızın sebebi her bir prefab in da kendi Collider ı bulunması sonucu Core Game objesine aynı bölge için erişim engellenmiş oluyor.
        //Dolaysıyla Buradaki OnMouseDown komutu çalışmıyor!!!
    }



    private void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, roundedPos, zeroRot) as GameObject;
        newDefender.transform.parent = defenderParent.transform;
    }

    // Burada da dönüştürdüğümüz (4.1, 5.6) değerini Int değerine yuvarlatarak karelerin tam orta değerlerini yani (4.0, 6.0) ı bulmasını sağlıyoruz.
    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX,newY);
    }
    //ScreenToWorldPoint ile 3D mouse pozisyonunu 2D pozisyonuna dönüştürüyoruz.((85.0, 300.0) dan (4.1, 5.6) ya gibi). 
    Vector2 CalculateWorldPointMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }
    

}
