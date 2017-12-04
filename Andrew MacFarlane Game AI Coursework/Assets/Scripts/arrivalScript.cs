using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivalScript : MonoBehaviour {

    public float maxSpeed =10f;
    public float arrivalRadius = 15f;
    public Vector3 villagerVelocity = Vector3.zero;
    string villagerName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ArrivalBehaviour(Vector3 agent, Vector3 target)
    {
        

        if (Vector3.Distance(agent, target) > arrivalRadius)
        {
            villagerVelocity = Vector3.Normalize(target - agent) * maxSpeed;
        }
        else
        {
            villagerVelocity = Vector3.Normalize(target - agent) * (maxSpeed * ((Vector3.Distance(agent, target)) / arrivalRadius));
        }


        if (villagerVelocity.sqrMagnitude > 0.0f)
        {
            transform.up = Vector3.Normalize(new Vector3(villagerVelocity.x, villagerVelocity.y, 0));
        }
        transform.position += new Vector3 (villagerVelocity.x, villagerVelocity.y, -0.1f) * Time.deltaTime;

    }
}
