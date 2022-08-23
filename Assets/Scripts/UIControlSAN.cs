using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlSAN : UIControlBar {

	// Use this for initialization
	void Start ()
    {
        initWidth = 200;
        bg.width = real.width = temp.width = initWidth;
        maxVal = this.transform.parent.parent.Find("Player").GetComponent<Player>().maxSAN;
        minVal = this.transform.parent.parent.Find("Player").GetComponent<Player>().minSAN;
        curVal = maxVal;
        tempVal = maxVal;
        value.text = curVal + "/" + maxVal;
    }
}
