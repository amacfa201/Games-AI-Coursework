using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raiderScript : MonoBehaviour {
    Vector3 currentTarget = Vector3.zero;
    public GameObject[] waypoints;
    arrivalScript _arrivalScript;

    void Start()
    {
        _arrivalScript = GetComponent<arrivalScript>();
        currentTarget = waypoints[0].transform.position;
    }


    void Update()
    {
        _arrivalScript.ArrivalBehaviour(transform.position, currentTarget);
    }
}
