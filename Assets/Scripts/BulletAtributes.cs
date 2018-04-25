using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAtributes : MonoBehaviour {

	void Start()
	{
		Destroy(gameObject, 3);
	}

	public int getDamage () {
		return Random.Range(20, 70);
	}
}
