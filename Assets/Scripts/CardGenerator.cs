using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {
    
    public GameObject cardPrefab;
    public Transform fromCard;
    public Transform toCard;

    public string[] cardNames;
    private UISprite nowGenericCard;

    private float timer = 0;
    private float transformTime = 0.5f;
    private bool isTransforming = false;

    private int transformSpeed = 20;
    private int cardNumber;

	// Use this for initialization
	void Start ()
    {
        //cardNumber = cardNames.Length;
        cardNumber = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            RandomGenericCard();
        }
        if(isTransforming)
        {
            timer += Time.deltaTime;

            int index = (int)(timer / (1f / transformSpeed));
            index %= cardNames.Length;
            nowGenericCard.spriteName = cardNames[index];

            if(timer > transformTime)
            {
                // 变换结束
                isTransforming = false;
                timer = 0;
                // 随机生成一个卡牌的名字
                string cardName = cardNames[Random.Range(0, cardNames.Length)];
                nowGenericCard.spriteName = cardName;

                nowGenericCard.GetComponent<Card>().InitProperty();
            }
        }
	}

    public GameObject RandomGenericCard()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, cardPrefab);
        go.transform.position = fromCard.position;
        nowGenericCard = go.GetComponent<UISprite>();
        iTween.MoveTo(go, toCard.position, 1f);
        isTransforming = true;
        return go;
    }
}
