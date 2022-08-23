using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCard : MonoBehaviour {
    
    public Transform card01;
    private GameObject card;

    private float stopTime = 0.5f;
    private float showTime = 0.5f;
    private float timer = 0;
    private bool isShow = false;
    

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isShow)
        {
            timer += Time.deltaTime;
            if(timer >= stopTime)
            {
                if (timer < showTime + stopTime)
                {
                    card.GetComponent<UISprite>().alpha = (showTime + stopTime - timer) / showTime;
                }
                else
                {
                    timer = 0;
                    isShow = false;
                    Destroy(card);
                }
            }
        }
	}

    // 添加卡牌，把卡牌拖到战斗区域
    public void AddCard(GameObject go)
    {
        card = go;
        go.transform.parent = this.transform;
        
        Vector3 pos = card01.position;
        iTween.MoveTo(go, pos, 0.5f);
        isShow = true;
    }

}
