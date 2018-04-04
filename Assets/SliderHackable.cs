using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHackable : Hackable {

    [SerializeField]
    GameObject SliderHackPanel;
    [SerializeField]
    float threshold;
    [Range(.1f,3f)]
    public float difficulty = 1;
    GameObject s1, s2, s3;
    Slider Slide1, Slide2, Slide3;
    Button stopButton;

    bool go, success = false;
    float a, b, c, aa, bb, cc;
    

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") > 0)
        {
            EndHack();
        }

        if (go == true)
        {
            Slide1.value = Mathf.Sin(((float)(2 * 3.14) / a)*difficulty * Time.time);
            Slide2.value = Mathf.Sin(((float)(2 * 3.14) / b)*difficulty * Time.time);
            Slide3.value = Mathf.Sin(((float)(2 * 3.14) / c)*difficulty * Time.time);
        }


    }

    public void stopSliders()
    {
        go = false;

        aa = Slide1.value;

        bb = Mathf.Abs(aa) - Mathf.Abs(Slide2.value);
        cc = Mathf.Abs(aa) - Mathf.Abs(Slide3.value);

        if(Mathf.Abs(bb) < threshold && Mathf.Abs(cc) < threshold)
        {
            Debug.Log("Hack success");
            success = true;
            EndHack();
        }

        

    }

    public override void Hack()
    {
        //Debug.Log("I am a slider hackable");

        SliderHackPanel.SetActive(true);
        SliderHackPanel.transform.position = transform.position;
        

        a = Random.Range(.5f, 2.0f);
        b = Random.Range(.5f, 2.0f);
        c = Random.Range(.5f, 2.0f);

        do
        {
            b *= Random.Range(1.2f, 2.0f);
            c *= Random.Range(1.2f, 2.0f);
        } while (b == c);

        Debug.Log(a +" "+ b +" "+ c);

        s1 = SliderHackPanel.transform.GetChild(0).gameObject;
        s2 = SliderHackPanel.transform.GetChild(1).gameObject;
        s3 = SliderHackPanel.transform.GetChild(2).gameObject;

        Slide1 = s1.GetComponent<Slider>();
        Slide2 = s2.GetComponent<Slider>();
        Slide3 = s3.GetComponent<Slider>();
        stopButton = SliderHackPanel.GetComponent<Button>();

        go = true;

    }


    public void EndHack()
    {
        SliderHackPanel.SetActive(false);
        
    }
}
