using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("Level")]
	[SerializeField] private int maxLevel;
	[SerializeField, Range(0, 2)] private float expMultiplier;
	//[SerializeField] private AnimationCurve expCurve;//it is not useable in 2022.3.4f

	public LevelSystem LevelSystem { get; private set; }

	private void Awake()
	{
		LevelSystem = new LevelSystem(maxLevel, expMultiplier);
	}

}
