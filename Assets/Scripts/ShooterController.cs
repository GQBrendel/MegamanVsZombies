using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shotPoint;
	public int shotSpeed = 10;
    private float fireRate = 0.3f;
    public float actualFireRate = 1f;
    bool fix = false;
 
    void Update() {

        for (int i = 0;i < 20; i++) {
            if(Input.GetKeyDown("joystick 1 button "+i))
            {
                print("joystick 1 button "+i);
            }
        }

        if (/*Input.GetButton("Fire1") && */fireRate == actualFireRate && Time.timeScale != 0)
        {
                Rigidbody clone;
                clone = Instantiate(projectile, shotPoint.position, shotPoint.rotation) as Rigidbody;
                clone.velocity = shotPoint.TransformDirection(Vector3.forward * shotSpeed);
                // FindObjectOfType<AudioManager>().Play("Shoot");

        }
        fireRate -= Time.deltaTime;

        if (fireRate <= 0f)
        {
            fireRate = actualFireRate;
        }
    }
}
