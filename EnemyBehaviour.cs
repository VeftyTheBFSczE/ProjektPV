using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for the enemy's set path
    public float moveSpeed = 3f; // Movement speed of the enemy
    public float chaseRange = 5f; // Range within which the enemy starts chasing the player
    public float stoppingDistance = 1f; // Distance at which the enemy stops when chasing the player
    public Transform player; // Reference to the player's transform
    public KeyCode flashlightKey = KeyCode.F; // Key to toggle the flashlight
    public float flashlightRange = 10f; // Range of the flashlight
    public LayerMask enemyLayer; // Layer mask for the enemy
    public Light flashlight; // Reference to the flashlight
    public float jumpscareDistance = 1f; // Distance threshold for jumpscare

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isChasing = false; // Flag to indicate if the enemy is currently chasing the player

    private void Start()
    {
        // Move the enemy to the first waypoint
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    private void Update()
    {
        if (!isChasing)
        {
            // Move towards the current waypoint
            MoveTowardsWaypoint();
        }
        else
        {
            // Chase the player
            ChasePlayer();
        }

        // Check if the flashlight key is pressed and the enemy is within the flashlight range
        if (Input.GetKeyDown(flashlightKey) && IsEnemyInFlashlightRange())
        {
            // Flashlight is activated and enemy is within range
            ReturnToPath();
        }

        // Check if the enemy is too close to the player
        if (player != null && Vector3.Distance(transform.position, player.position) <= jumpscareDistance)
        {
            Jumpscare();
        }
    }

    private void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        // Calculate direction towards the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.y = 0f; // Ensure movement is along the horizontal plane

        // Move towards the waypoint
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Check if close to the current waypoint, then move to the next one
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // Check if the player is within the chase range
        if (player != null && Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            isChasing = true;
        }
    }

    private void ChasePlayer()
    {
        if (player == null)
            return;

        // Calculate direction towards the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // Ensure movement is along the horizontal plane

        // Move towards the player
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Check if close to the player, then stop chasing
        if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
        {
            isChasing = false;
        }
    }

    private bool IsEnemyInFlashlightRange()
    {
        if (flashlight != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit, flashlightRange, enemyLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void ReturnToPath()
    {
        // Move towards the nearest waypoint to resume the set path
        int nearestWaypointIndex = GetNearestWaypointIndex();
        currentWaypointIndex = nearestWaypointIndex;
        isChasing = false;
    }

    private int GetNearestWaypointIndex()
    {
        int nearestIndex = 0;
        float minDistance = float.MaxValue;
        for (int i = 0; i < waypoints.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, waypoints[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }
        return nearestIndex;
    }

    private void Jumpscare()
    {
        // You can add jumpscare effect here, like playing a sound, showing a scary animation, etc.
        Debug.Log("Jumpscare!");
        // For simplicity, let's just deactivate the player GameObject
        if (player != null)
        {
            player.gameObject.SetActive(false);
        }
    }
}
