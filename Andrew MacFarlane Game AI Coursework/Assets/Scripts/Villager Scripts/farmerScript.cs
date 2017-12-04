using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmerScript : MonoBehaviour {

    Vector3 currentTarget = Vector3.zero;
    public GameObject[] waypoints;


    arrivalScript _arrivalScript;
    basicFunctions _basicFunctions;
    public timeScript _timeScript;
    //i smell
    public float tiredness;
    private float sleepStat = 1f;

    public int hunger;
    public int gold;
    public int foodNum;

    public bool isSleeping;

#region Waypoint ints
    int bed = 0;
    int fields = 1;
#endregion

   protected enum farmerStates
    {
        Traversing, Eating, Farming, Selling, Sleeping, BuyingFood
    }
    private farmerStates currentState;

    void Start()
    {
        _arrivalScript = GetComponent<arrivalScript>();
        _basicFunctions = GetComponent<basicFunctions>();
        _timeScript = GameObject.FindGameObjectWithTag("timeScript").GetComponent<timeScript>();


        // currentTarget = waypoints[bed].transform.position;
    }

    
    void Update()
    {
        #region StateConditions


        //first attempt to eat
        
        

        if (_timeScript.currentTime > 2200 || _timeScript.currentTime > 000 && _timeScript.currentTime < 500)
        {
            currentState = farmerStates.Sleeping;
        }

        if (_timeScript.currentTime > 501 && _timeScript.currentTime < 1900)
        {
            currentState = farmerStates.Farming;
        }

        if (_timeScript.currentTime > 1901 && _timeScript.currentTime < 2159)
        {
            if (hunger >= 50 && foodNum > 0)
            {
                currentState = farmerStates.Eating;
            }
            else if (hunger > 50 && foodNum <= 0)
            {
                currentState = farmerStates.BuyingFood;
            }
        }





        print("CS = " + currentState);



        #endregion

        #region State Actions 
        if (currentState == farmerStates.Traversing)
        {
            _arrivalScript.ArrivalBehaviour(transform.position, currentTarget);
        }

        if (currentState == farmerStates.Eating)
        {
           
        }


        if (currentState == farmerStates.Farming)
        {
            tiredness += 0.025f;
            currentTarget = waypoints[fields].transform.position;
            _arrivalScript.ArrivalBehaviour(transform.position, currentTarget);
        }

        if (currentState == farmerStates.BuyingFood)
        {
            
        }



        if (currentState == farmerStates.Sleeping)
        {
            isSleeping = true;
            currentTarget = waypoints[bed].transform.position;
            _arrivalScript.ArrivalBehaviour(transform.position, currentTarget);
            tiredness = _basicFunctions.Sleep(tiredness, sleepStat);
            if (tiredness == 0)
            {
                isSleeping = false;
                currentState = farmerStates.Farming;
            }

        }

        #endregion

        






        
    }
}
