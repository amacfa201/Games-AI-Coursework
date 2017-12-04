using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFunctions : MonoBehaviour {
    public float tirednessDecrease;
    private float decreaseFactor = 0.15f;

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {

       

	}


    public float Sleep(float tiredness, float sleepStat)
    {

        
        if (tiredness > 0)
        {
            //print("tiredness = " + tirednessDecrease + "  " + "decreaseFactor = " + decreaseFactor);
            if (tirednessDecrease > decreaseFactor)
            {
                tirednessDecrease = 0;
                tiredness -= sleepStat;
            }
            
            tirednessDecrease += Time.deltaTime;
            
            
        }

        return tiredness;
    }


    //IEnumerator Sleeping(bool _isSleeping, int _tiredness)
    //{
       
    //    if (_isSleeping)
    //    {
    //         yield return new WaitForSeconds(0.2f);
            
    //            _tiredness--;
                
    //    }
    //    yield return _tiredness;
    //}
}
