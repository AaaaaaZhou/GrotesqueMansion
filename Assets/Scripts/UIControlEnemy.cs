using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlEnemy : UIControlBar {

	// Use this for initialization
	void Start ()
    {
        initWidth = 400;
        bg.width = real.width = temp.width = initWidth;
        maxVal = this.transform.parent.parent.Find("Enemy").GetComponent<Enemy>().maxHP;
        minVal = this.transform.parent.parent.Find("Enemy").GetComponent<Enemy>().minHP;
        curVal = maxVal;
        tempVal = maxVal;
        value.text = curVal + "/" + maxVal;
    }
}
