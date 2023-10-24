using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Joystick input;
	[SerializeField] float moveSpeed;
	[SerializeField] float rotationSpeed;

	private CharacterController controller;

	private void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	private void FixedUpdate()
	{
		var moveDir = new Vector3(input.Horizontal, 0, input.Vertical).normalized;
		controller.Move(moveDir * moveSpeed * Time.fixedDeltaTime);

		if (moveDir != Vector3.zero)
		{
			var rotationAngle = Quaternion.LookRotation(moveDir, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationAngle, rotationSpeed * Time.fixedDeltaTime);
		}
	}
}
