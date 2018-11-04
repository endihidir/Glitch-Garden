using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starPoint;
    private int stars = 500;
    public enum Status
    {
        SUCCESS, FAILURE 
    }

    private void Start()
    {
        starPoint = GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    public Status UseStars(int amount)
    {
        if (stars>=amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

            return Status.FAILURE;
        
       
        
    }

    void UpdateDisplay()
    {
        starPoint.text = stars.ToString();
    }

    internal void UseStars(object starCost)
    {
        throw new NotImplementedException();
    }
}
