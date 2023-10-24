using System;
using UnityEngine;

public class Health : IDamageable
{
	public event Action<float> OnHealthChanged;

	[SerializeField] private float maxHealth;

	public float Value { get; private set; }

	public void TakeDamage(float damage)
	{
		if (damage < 0)
		{
			damage = 0;
		}

		Value -= damage;
		if (Value <= 0)
		{
			Value = 0;
		}

		OnHealthChanged?.Invoke(Value);
	}
}
