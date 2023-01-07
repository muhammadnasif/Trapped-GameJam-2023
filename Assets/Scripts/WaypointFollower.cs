/*
    This script is for when there are exactly two waypoints
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public float moveSpeed = 8;

    [SerializeField] GameObject[] waypoints;
    
    private int curWaypointIndex = 0;

    void Update() {
        move();
    }

    void move() {
        Vector3 nextWaypointPosition = new Vector3(
            waypoints[curWaypointIndex].transform.position.x,
            transform.position.y,
            transform.position.z
        );

        if(Vector2.Distance(transform.position, nextWaypointPosition) < 0.01f) {
            curWaypointIndex = 1 - curWaypointIndex;
            flipHorizontal();
        }


        Vector3 to = new Vector3(waypoints[curWaypointIndex].transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector2.MoveTowards(
            transform.position,
            to,
            moveSpeed * Time.deltaTime                    
        );
    }

    
    private void flipHorizontal() {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
