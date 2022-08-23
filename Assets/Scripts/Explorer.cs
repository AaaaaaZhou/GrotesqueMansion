using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorer : MonoBehaviour {

    public int maxHP;                  // 最大生命值
    public int minHP;                   // 最小生命值

    protected UISprite sprite;
    
    protected int hpCount;               // 当前生命值，缺省为30

    /*
    private void Awake()
    {
        sprite = this.GetComponent<UISprite>();
    }
    */

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlusHP(1);
        }
	}

    public void TakeDamage(int damage)
    {
        hpCount -= damage;
        if(hpCount <= minHP)
        {
            // Game Over
            hpCount = 0;
        }
    }

    public void PlusHP(int hp)
    {
        hpCount += hp;
        if(hpCount >= maxHP)
        {
            hpCount = maxHP;
        }
        this.transform.parent.Find("PlayerInformation").Find("hpInformation").GetComponent<UIControlHP>().UpdatShow(hpCount, maxHP);
    }

    public bool isDead()
    {
        return hpCount <= 0;
    }
}
