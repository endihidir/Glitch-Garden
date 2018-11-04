using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;


	void Update () {

        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.Log("Spawn rate capped by frame rate");
        }

        float thresold = spawnsPerSecond * Time.deltaTime / 5;

        /* if (Random.value < thresold)
         {
             return true;
         }
         else
         {
             return false;
         } veya bunun yerine */
        return (Random.value < thresold);

        
    }
    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
}
