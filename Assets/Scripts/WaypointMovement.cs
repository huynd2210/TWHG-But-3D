using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float movementSpeed = 7f;
    [SerializeField] float easymodeMovementSpeed = .1f;
    void Update()
    {
        FollowWaypoints(waypoints);
    }

    void FollowWaypoints(GameObject[] waypoints)
    {
        bool isEasyMode = EasyModeToggle.isEasyMode;
        float currentMovementSpeed = isEasyMode ? easymodeMovementSpeed : movementSpeed;
        //
        // Debug.Log("isEasyMode: " + isEasyMode);
        // Debug.Log("currentMovementSpeed: " + currentMovementSpeed);
        //         
        
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
            currentMovementSpeed * Time.deltaTime);
    }
    
}
