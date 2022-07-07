using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _introDirector;
    [SerializeField] GameObject _controlDirector;
    [SerializeField] Canvas _canvasIntro;
    [SerializeField] Canvas _canvasControls;

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnControlTransition()
    {
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
        _introDirector.SetActive(true);
        _controlDirector.SetActive(false);
        _canvasControls.enabled = false;
    }

    public void ShowIntro()
    {
        _canvasIntro.enabled = true;
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}