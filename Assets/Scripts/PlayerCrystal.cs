using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrystal : MonoBehaviour {

    public int useableNumber; // 可用水晶
    public int totalNumber; // 暗色调水晶
    public int maxNumber; // 最大数目

    public UISprite[] Crystals; // 存储所有水晶

    private UILabel label; // 用于显示useableNumber/totalNumber

	// Use this for initialization
	void Start ()
    {
        GameController._instance.onNewRound += this.OnNewRound;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateShow();
	}

    private void Awake()
    {
        maxNumber = Crystals.Length;
        label = this.GetComponent<UILabel>();
    }

    public void RefreshCrystalNumber()
    {
        useableNumber = totalNumber = 5;
        UpdateShow();
    }

    public bool GetCrystal(int number) // 用来消耗水晶，返回值表示数目是否充足
    {
        if(useableNumber >= number)
        {
            useableNumber -= number;
            UpdateShow();
            return true;
        }
        else // 水晶不足
        {
            return false;
        }
    }

    void UpdateShow()
    {
        for(int i = totalNumber; i < maxNumber; i++)
        {
            Crystals[i].gameObject.SetActive(false);
        }
        for(int i = 0; i < totalNumber; i++)
        {
            Crystals[i].gameObject.SetActive(true);
        }
        // 控制暗色调水晶
        for(int i = useableNumber; i < totalNumber; i++)
        {
            Crystals[i].spriteName = "TextInlineImages_normal";
        }
        for(int i = 0; i < useableNumber; i++)
        {
            if(i == 9)
            {
                Crystals[i].spriteName = "TextInlineImages_" + (i + 1);
            }
            else
            {
                Crystals[i].spriteName = "TextInlineImages_0" + (i + 1);
            }
        }
        label.text = useableNumber + "/" + totalNumber;
    }

    public void OnNewRound(string playerName)
    {
        if(playerName == "Player")
        {
            RefreshCrystalNumber();
        }
    }

    public void addCrystal(int num)
    {
        useableNumber += num;
        totalNumber += num;
        if(totalNumber >= maxNumber)
        {
            totalNumber = maxNumber;
        }
        if(useableNumber >= totalNumber)
        {
            useableNumber = totalNumber;
        }
    }

}
