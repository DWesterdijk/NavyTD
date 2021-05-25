using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the enemy ships along the given waypoints
/// </summary>
public class EnemyShipControl : MonoBehaviour
{

    Transform[] _wayPoints;

    GameObject WayPointManagerObj;
    WayPointManager wayPointManager;

    private EnemyShipStats _shipStats;

    int _wayPointIndex = 0;

    private void Awake()
    {
        _shipStats = this.gameObject.GetComponent<EnemyShipStats>();

        WayPointManagerObj = GameObject.FindWithTag("WayPoints");
        wayPointManager = WayPointManagerObj.GetComponent<WayPointManager>();
        _wayPoints = wayPointManager.WayPoints;

        Debug.Log(_wayPoints.Length);
    }

    private void Start()
    {
        transform.position = _wayPoints[_wayPointIndex].transform.position;
    }

    private void Update()
    {
        MoveShip();
    }

    //Functions moves the ship
    void MoveShip()
    {
        //Moves the ship to the target waypoint
        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_wayPointIndex].transform.position, _shipStats.speed * Time.deltaTime);

        //Sets the current waypoint to the next one in line
        if (transform.position == _wayPoints [_wayPointIndex].transform.position)
        {
            _wayPointIndex += 1;

            if (_wayPointIndex == _wayPoints.Length)
            {
                ScoringTracker.current.lives -= _shipStats.damage;
                Destroy(this.gameObject);
            }
            else
            {
                //Makes the ship look at next checkpoint
                transform.LookAt(_wayPoints[_wayPointIndex]);
            }
        }
    }
}