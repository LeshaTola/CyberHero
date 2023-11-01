using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Hunter : MonoBehaviour
{
	private NavMeshAgent agent;
	private Player player;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		player = FindAnyObjectByType<Player>();//TODO: remove this
	}

	private void FixedUpdate()
	{
		agent.SetDestination(player.transform.position);
	}
}
