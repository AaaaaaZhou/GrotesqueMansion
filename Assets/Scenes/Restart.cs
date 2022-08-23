using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    void OnClick()
    {
        PlayerInfo.RefreshMap();
        Application.LoadLevel(0);
    }
}
