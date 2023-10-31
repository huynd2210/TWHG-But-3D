using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float movementSpeed = 1f;
    void Update()
    {
        FollowWaypoints(waypoints);
    }

    void FollowWaypoints(GameObject[] waypoints)
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position,
            movementSpeed * Time.deltaTime);
    }
    
}
