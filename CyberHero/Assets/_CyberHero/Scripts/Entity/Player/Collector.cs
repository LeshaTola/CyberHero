using UnityEngine;

public class Collector : MonoBehaviour
{
	[SerializeField] Player player;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out ICollectable collectable))
		{
			collectable.Collect(player);
		}
	}
}
