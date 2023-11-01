using System;

public class LevelSystem
{
	public event Action<float> OnExperienceChanged;
	public event Action<int> OnLevelUp;

	private int maxLevel;
	private float expMultiplier;
	//private AnimationCurve expCurve;
	private float expForLevelUp;

	public int Level { get; private set; }
	public float Exp { get; private set; }

	public LevelSystem(int maxLevel, float expMultiplier)
	{
		Level = 0;
		expForLevelUp = CalculateExpForThisLevel();
		this.maxLevel = maxLevel;
		this.expMultiplier = expMultiplier;
		//this.expCurve = expCurve;
	}

	public void AddExperience(float exp)
	{
		if (exp <= 0)
			return;

		Exp += exp;
		if (Level < maxLevel)
		{
			while (Exp >= expForLevelUp)
			{
				LevelUp();
			}
		}
	}

	private void LevelUp()
	{
		Exp -= expForLevelUp;
		OnExperienceChanged?.Invoke(Exp);

		Level++;
		OnLevelUp?.Invoke(Level);

		expForLevelUp = CalculateExpForThisLevel();
	}

	private float CalculateExpForThisLevel()
	{
		float startExp = 100f;
		return startExp += startExp * (expMultiplier) * Level;
		//return expCurve.Evaluate(Level);
	}
}
