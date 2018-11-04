using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private int count;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject)
        {
            Destroy(col.gameObject);
            count++;
            if (count == 4)
            {
                LevelManager lm = new LevelManager();
                lm.LoadLevel("03b Lose");
            }
        }
    }






}
