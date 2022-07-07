using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _UI;
    [SerializeField] MouseLook _mouselook;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        if (_UI != null)
            _UI.SetActive(true);
        
        if (_mouselook != null)
            _mouselook.ShowMouse();
    }
}