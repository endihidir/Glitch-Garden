using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Defender : MonoBehaviour {

    private StarDisplay starDisplay;
    public int starCost;
    //Yalnızca Tag için kullanılıyor.

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

    



}
