using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlBar : MonoBehaviour {

    protected UISprite real;
    protected UISprite temp;
    protected UISprite bg;
    protected UILabel value;
    protected int curWidth;
    protected int tempWidth;

    protected bool isShow = false;
    protected int maxVal;
    protected int minVal;
    protected int curVal;
    protected int initWidth;
    protected float tempVal;
    protected float timer;
    protected float showTime = 0.5f;
    protected float stopTime = 0.5f;

    private void Awake()
    {
        bg = this.transform.Find("bg").GetComponent<UISprite>();
        real = this.transform.Find("real").GetComponent<UISprite>();
        temp = this.transform.Find("temp").GetComponent<UISprite>();
        value = this.transform.Find("value").GetComponent<UILabel>();
        timer = 0;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow)
        {
            timer += Time.deltaTime;
            if (timer >= stopTime)
            {
                if (timer < stopTime + showTime)
                {
                    temp.width = tempWidth - (int)((tempWidth - curWidth) * (timer - stopTime) / (showTime));
                }
                else
                {
                    isShow = false;
                    tempVal = curVal;
                    tempWidth = curWidth;
                    temp.width = real.width;
                    timer = 0;
                }
            }
        }
    }

    public void UpdatShow(int currentHP, int maxHP)
    {
        isShow = true;
        curVal = currentHP;
        real.width = curWidth = initWidth * currentHP / maxHP;
        value.text = currentHP + "/" + maxHP;
    }
}
