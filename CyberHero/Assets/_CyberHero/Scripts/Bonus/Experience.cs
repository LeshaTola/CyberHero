using UnityEngine;

public class Experience : MonoBehaviour, ICollectable
{
	[field: SerializeField] public float Value { get; private set; }

	public void Collect(Player player)
	{
		player.LevelSystem.AddExperience(Value);
		//Spawn particles
		//PlaySound
		Destroy(gameObject);
	}
}
