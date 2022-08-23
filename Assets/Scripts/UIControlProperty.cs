using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlProperty : MonoBehaviour {

    private UILabel nameLabel;
    private UILabel valueLabel;

    public string name;
    public int value;

    private void Awake()
    {
        nameLabel = this.transform.Find("name").GetComponent<UILabel>();
        valueLabel = this.transform.Find("value").GetComponent<UILabel>();
    }

    // Use this for initialization
    void Start ()
    {
        switch (name)
        {
            case "STR":
                value = this.transform.parent.parent.Find("Player").GetComponent<Player>().STR; break;
            case "VIT":
                value = this.transform.parent.parent.Find("Player").GetComponent<Player>().VIT; break;
            case "DEX":
                value = this.transform.parent.parent.Find("Player").GetComponent<Player>().DEX; break;
            case "WIL":
                value = this.transform.parent.parent.Find("Player").GetComponent<Player>().WIL; break;
            case "LUC":
                value = this.transform.parent.parent.Find("Player").GetComponent<Player>().LUC; break;
            case "EVA":
                value = this.transform.parent.parent.Find("Player").GetComponent<Player>().EVA; break;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        nameLabel.text = name;
        valueLabel.text = value + "";
	}
}
