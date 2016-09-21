using UnityEngine;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour
{

	[SyncVar]
	int health;

	public void TakeDamage(int amount)
	{
		if (!isServer)
			return;

		health -= amount;
	}
}
