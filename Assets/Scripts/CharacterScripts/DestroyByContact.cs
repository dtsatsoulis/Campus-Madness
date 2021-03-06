using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject meleeHit;
	public bool active;

	void Start()
	{
		active = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			return;
		if (other.gameObject.CompareTag("Player"))
			Destroy(gameObject);
		if (other.gameObject.tag == "Enemy" && active) 
		{
            if (gameObject.tag == "Punch")
            {
                PunchMovement tempPunch = gameObject.GetComponent<PunchMovement>();
                float damage = tempPunch.GetDamage();
                other.gameObject.GetComponent<EnemyController>().getHit(damage, 5f);
            }
			if (gameObject.tag == "Arrow") 
			{
				ArrowMovement tempArrow = gameObject.GetComponent<ArrowMovement>();
				float damage = tempArrow.GetDamage();
				other.gameObject.GetComponent<EnemyController> ().getHit (damage, 2.5f);
			}
				
			if (gameObject.tag == "Kunai")
			{
				KunaiMovement tempKunai = gameObject.GetComponent<KunaiMovement>();
				float damage = tempKunai.GetDamage();
				other.gameObject.GetComponent<EnemyController> ().getHit (damage, 2.5f);
			}

			active = false;
			
			GameObject hitObject = Instantiate (meleeHit, other.transform.position, other.transform.rotation) as GameObject;
			Destroy (hitObject, 0.5f);

			if (gameObject.tag == "Arrow" || gameObject.tag == "Kunai")
				Destroy(gameObject);
		}

	}
}
