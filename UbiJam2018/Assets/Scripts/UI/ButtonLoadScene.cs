using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour {

    public Button reloadMap;
    public Button backTomenu;
    public Button quit;

    public Button buttonLoadSpecificScene;
    public string loadSpecificScene;

    void Start () {
        if(reloadMap != null) 
        reloadMap.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });

        if (backTomenu != null)
            backTomenu.onClick.AddListener(() => { SceneManager.LoadScene(1); });

        if (quit != null)
            quit.onClick.AddListener(() => { Application.Quit(); });

        if (buttonLoadSpecificScene != null)
            buttonLoadSpecificScene.onClick.AddListener(() => { SceneManager.LoadScene(loadSpecificScene); });
    }
	
}
