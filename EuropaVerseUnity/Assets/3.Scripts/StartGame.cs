using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    [SerializeField] private string nextSceneName = "Scene1";
    void Start()
    {
        startButton.onClick.AddListener(OnClickStart);


    }
    

    public void OnClickStart()
    {
        FadeManager.Instance.LoadSceneWithFade(nextSceneName);
    }


}
