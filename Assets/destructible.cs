using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructible : MonoBehaviour {


    public Sprite dmgWall;
    public Sprite dmgWall2;
    public Sprite dmgWall3;
    public int hp = 4;
    private float damping = 0.7f;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
    public void damageWall()
    {
        //spriteRenderer.sprite = dmgWall;
        damping -= Time.deltaTime;
        if (damping < 0)
        {
            hp--;
            damping = 0.6f;
        }
        if (hp == 3)
            spriteRenderer.sprite = dmgWall;
        else if (hp == 2)
            spriteRenderer.sprite = dmgWall2;
        else if (hp == 1)
            spriteRenderer.sprite = dmgWall3;
        else if (hp <= 0)
            gameObject.SetActive(false);
    }

}
