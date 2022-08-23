using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCard : MonoBehaviour {

    public GameObject cardPrefab;
    public Transform card01;
    public Transform card02;

    private float xOffset;

    private List<GameObject> cards = new List<GameObject>();
    private int startDepth = 5;

    public string[] cardNames;

	// Use this for initialization
	void Start ()
    {
        xOffset = card02.position.x - card01.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Q))
        {
            GetCard();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            LoseCard();
        }
	}

    public void GetCard(GameObject cardGo = null)
    {
        //GameObject go = NGUITools.AddChild(this.gameObject, cardPrefab);
        //go.GetComponent<UISprite>().spriteName = cardNames[Random.Range(0, cardNames.Length)];
        
        GameObject go = null;
        if (cardGo == null)
        {
            // 这个方法是传递过来的卡牌为null是自动生成，用于测试
            go = NGUITools.AddChild(this.gameObject, cardPrefab);
            go.GetComponent<UISprite>().spriteName = cardNames[Random.Range(0, cardNames.Length)];
        }
        else
        {
            go = cardGo;
            go.transform.parent = this.transform;
        }

        go.GetComponent<UISprite>().width = 100;
        go.GetComponent<UISprite>().height = 145;

        Vector3 toPosition = card01.position + new Vector3(xOffset, 0, 0) * cards.Count;

        iTween.MoveTo(go, toPosition, 1f);

        cards.Add(go);
        //go.GetComponent<UISprite>().depth = (startDepth + cards.Count - 1) * 2;
        go.GetComponent<Card>().SetDepth((startDepth + cards.Count - 1) * 2);
    }

    public void LoseCard()
    {
        int index = Random.Range(0, cards.Count);
        Destroy(cards[index]);
        cards.RemoveAt(index);
        UpdateShow();
    }

    public void UpdateShow()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            Vector3 toPosition = card01.position + new Vector3(xOffset, 0, 0) * i;
            iTween.MoveTo(cards[i], toPosition, 1f);

            //cards[i].GetComponent<UISprite>().depth = startDepth + i * 2;
            cards[i].GetComponent<Card>().SetDepth(startDepth + i * 2);
        }
    }

    public void RemoveCard(GameObject go)
    {
        cards.Remove(go);
        UpdateShow();
    }

    public void RemoveAll()
    {
        int count = cards.Count;
        for(int i = 0; i < count; i++)
        {
            LoseCard();
        }
    }
}
