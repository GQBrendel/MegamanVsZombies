using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject zombie;
    public float spawnTimeRate = 3f;
    private GameObject ship;

    void Start () {
        InvokeRepeating("Spawn", spawnTimeRate, spawnTimeRate);
       // ship = gameObject.transform.Find("spaceCraft3").gameObject;
    }

    void Update()
    {
       // if (!ship.gameObject.activeInHierarchy) {
      //      CancelInvoke("Spawn");
       // }
    }

    void Spawn()
    {
        Instantiate(zombie, transform.position, transform.rotation);
    }
}
