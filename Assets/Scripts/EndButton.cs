using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour {

    private UILabel label;
    
	// Use this for initialization
	void Start ()
    {
        GameController._instance.onNewRound += this.OnNewRound;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void Awake()
    {
        label = transform.Find("Label").GetComponent<UILabel>();
    }

    public void OnEndButtonClick()
    {
        if (GameController._instance.gamestate == GameState.PlayCard)
            if (label.text == "End")
            {
                label.text = "Enemy's Round";
                GameController._instance.TransformPlayer();
            }
        
    }

    public void OnNewRound(string playerName)
    {
        if(playerName == "Player")
        {
            label.text = "End";
        }
    }
}
