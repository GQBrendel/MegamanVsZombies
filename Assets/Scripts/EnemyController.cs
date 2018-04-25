using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private Transform destination;
    GameObject gate;
	private NavMeshAgent navAgent;
	private Image lifeBar;
    public Animator animator;
 
    bool attackState = false;
    [Header("Attributes")]
    public float maxLifePoints = 100;
    private float lifePoints;
    public float atkFrequency;
    float atkUpdater;
    public int atkDamage;
    public int pointValue = 5;

    private Text pointsText;
    private GameObject player;

    void Start () {
		navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = Random.Range(5f, 10f);
        string name;
        int rng = Random.Range(0, 3);
        name = "Destination" + rng;
        destination = GameObject.Find(name).GetComponent<Transform>();
        gate = GameObject.FindWithTag("Gate");
        player = GameObject.FindWithTag("Player");
        pointsText = GameObject.Find("Points").GetComponent<Text>();

		lifePoints = maxLifePoints;

		Image[] childrens = GetComponentsInChildren<Image>();

		foreach (Image children in childrens)
		{
			if (children.gameObject.name == "LifeBar") {
				lifeBar = children;
			}
		}
	}
	
	void Update () {
        if (!attackState)
        {
            navAgent.SetDestination(destination.position);
            return;
        }            
        else
        {
            navAgent.velocity = new Vector3(0, 0, 0);
            atkUpdater += Time.deltaTime;
            if(atkUpdater >= atkFrequency)
            {
              //  gate.GetComponent<CastleLife>().damage(atkDamage);
                atkUpdater = 0;
            }
            transform.LookAt(gate.transform.position);
        }
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Bullet") {

			lifePoints -= other.gameObject.GetComponent<BulletAtributes>().getDamage();
           // FindObjectOfType<AudioManager>().Play("Damage");
            
			//if (lifePoints <= 0) {
             //   player.gameObject.GetComponent<GameController>().setPoints(pointValue);
            //    pointsText.text = "Points: " + player.gameObject.GetComponent<GameController>().getPoints();

				Destroy(gameObject);
		//	}

			//float actualLife = lifePoints / maxLifePoints;
			//lifeBar.transform.localScale = new Vector3(actualLife, 1f,1f);

			Destroy(other.gameObject);
		}
    }
    void OnTriggerEnter(Collider other)
    {
      //  if(other.gameObject.name == "attackArea")
        {
       //     attackState = true;
      //      animator.SetBool("attack", true);
        }
    }
}
