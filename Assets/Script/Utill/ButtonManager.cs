using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("02_InGame");
    }

    public void ReStartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("00_MainDisplay");
    }

    public void seletChNextButton()
    {

    }
    public void seletChBackButton()
    {

    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
