using UnityEngine;
using UnityEngine.Networking;

public class PlayerNet : NetworkBehaviour
{
	public Camera childCam;
	public GameObject bullet;
	public GameObject barrel;
	public override void OnStartLocalPlayer()
	{
        //Enable an example player controller
		GetComponent<FPSInputController>().enabled = true; 
		GetComponent<CharacterMotor>().enabled = true;
        GetComponent<MouseLook>().enabled = true; 

        //Set the camera to active
        childCam.gameObject.SetActive(true);
		childCam.enabled = true;

	}

	void Update()
	{
		if (!isLocalPlayer)
			return;

		if (Input.GetMouseButtonDown(0))
		{
			CmdShoot();
		}
	}

	[Command]
	void CmdShoot()
	{
		// create bullets on each client, not spawned on server
		RpcShoot();
	}

	[ClientRpc]
	void RpcShoot()
	{
		GameObject b = Instantiate(bullet, barrel.transform.position, transform.rotation) as GameObject; //Spawn the prefab as a gameobject
		b.GetComponent<Rigidbody>().velocity = transform.forward * 20; //Send the gameobject forward
		Destroy(b, 3.0f); //Destroy the gameobject after a time
	}
}
