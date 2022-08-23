using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton1 : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene(2);
    }
}
