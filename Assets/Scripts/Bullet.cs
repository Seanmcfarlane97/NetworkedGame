using UnityEngine;


public class Bullet : MonoBehaviour {

    public Combat combat; 

	void OnCollisionEnter(Collision col)
	{
		combat = col.gameObject.GetComponent<Combat>(); //Get the script "Combat"
		if (combat != null) //If the object as the Combat script attatched 
		{
			combat.TakeDamage(10); //Deduct a set amount from the objects health
		}

		Destroy(gameObject); //Destroy the bullet
	}

}
