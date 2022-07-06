using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class UIManager : MonoBehaviour
{
    //[SerializeField] PlayableDirector _controlsDirector;
    //[SerializeField] PlayableDirector _introDirector;
    [SerializeField] GameObject _introDirector;
    [SerializeField] GameObject _controlDirector;
    [SerializeField] Canvas _canvasIntro;
    [SerializeField] Canvas _canvasControls;

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnControlTransition()
    {
        //_controlsDirector.enabled = true;
        //_introDirector.enabled = false;
        _introDirector.SetActive(false);
        _controlDirector.SetActive(true);
        _canvasIntro.enabled = false;
    }

    public void ShowControls()
    {
        _canvasControls.enabled = true;
    }

    public void OnIntroTransition()
    {
        //_controlsDirector.enabled = false;
        //_introDirector.enabled = true;
        _introDirector.SetActive(true);
        _controlDirector.SetActive(false);
        _canvasControls.enabled = false;
    }

    public void ShowIntro()
    {
        _canvasIntro.enabled = true;
    }
}