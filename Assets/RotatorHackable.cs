using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorHackable : Hackable {

    [SerializeField]
    GameObject RotatorHackPanel;
    
    public GameObject ballSpinner;
    Sprite img;

    public float threshhold;

    float rotValue, targetValue, magVal;
    Quaternion zz;

	// Use this for initialization
	void Start ()
    {

        //ballSpinner = RotatorHackPanel.transform.GetChild(0).gameObject;

        img = ballSpinner.GetComponent<Sprite>();

	}

    void Awake()
    {
        targetValue = Random.Range(0f, 360f);
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        Debug.Log(ballSpinner.transform.rotation);
        //rotValue += Input.GetAxis("MouseX");

        float degrees = Input.mousePosition.x / Screen.width * 4 * 360;

        ballSpinner.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degrees));
      

    }

    public override void Hack()
    {

        

    }


}


