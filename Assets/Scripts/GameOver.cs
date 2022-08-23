using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameOver _instance;

    private UILabel gameOver;

    private void Awake()
    {
        _instance = this;
        gameOver = this.GetComponent<UILabel>();
        gameOver.alpha = 0;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowResult(bool isPlayerWin)
    {
        this.gameObject.SetActive(true);
        if (isPlayerWin)
        {
            gameOver.text = "You Win";
        }
        else
        {
            gameOver.text = "You Lose";
        }
        gameOver.alpha = 1;
        gameOver.depth = 100;
    }
}
