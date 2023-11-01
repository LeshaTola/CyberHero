using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystemUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI expText;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private Slider expSlider;
	[SerializeField] private Player player;

	private LevelSystem levelSystem;

	private void Awake()
	{
		UpdateLevel(0);
		float startExp = 100; //TODO: take it from LevelSystem
		UpdateExp(0, startExp);
	}

	private void Start()
	{
		levelSystem = player.LevelSystem;
		levelSystem.OnExperienceChanged += OnExperienceChanged;
		levelSystem.OnLevelUp += OnLevelUp;
	}

	private void OnDestroy()
	{
		levelSystem.OnExperienceChanged -= OnExperienceChanged;
		levelSystem.OnLevelUp -= OnLevelUp;
	}

	private void UpdateExp(float curExp, float maxExp)
	{
		expText.text = $"{curExp}/{maxExp}";
		var value = curExp / maxExp;
		expSlider.value = value;
	}

	private void UpdateLevel(int curLevel)
	{
		levelText.text = $"{curLevel} level";
	}

	private void OnLevelUp(int curLevel)
	{
		UpdateLevel(curLevel);
	}

	private void OnExperienceChanged(float curExp, float maxExp)
	{
		UpdateExp(curExp, maxExp);
	}
}
