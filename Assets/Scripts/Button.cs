using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefener;

    private Button[] buttonArray;
    private Text costText;
    

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
            
        
        if(!costText)
        {
            Debug.LogWarning("costText is not exist.");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {

        //print(name+ " PRESSED.");
        //Buradaki foreach komutu herhangi bir Savunmacıya tıklandığında çalışıyor ve thisButton içerisine buttonArray içerisinde bulunan tüm butonları atıyor. 
        //thisButton.GetComponent<SpriteRenderer>().color komutu ile tüm savunmacıların buronlarının SpriteRendererlarını siyah yapıyor.
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
            //print(thisButton);
        }
        // Yukarıdaki işlemin gerçekleşmesinin hemen ardından hemen aşağıdaki komut çalışıyor ve yalnızca tıklanan obje beyaza döndürülmüş oluyor ve her yeni tıklamada aynı döngü gerçekleştiğinden 
        // Beyaz olanlar 2. veya 3. tıklanma esnasında siyah oluyor. Eğer bunu foreach önüne yazarsak tıklanan obje beyaz olacak ardından tüm objeler siyaha dönüşecektir 
        // dolayısıyla hiçbir obje beyaz olarak gözükmeyecektir. 
        GetComponent<SpriteRenderer>().color = Color.white;

        selectedDefener = defenderPrefab;
       // print(selectedDefener);
    }
}
