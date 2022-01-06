using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Button PauseButtonRef;
    [SerializeField] private Button ResumeButtonRef;
    [SerializeField] private Button ReplayButtonRef;
    [SerializeField] private Button ReturnToMenuButtonRef;
    [SerializeField] private Image PausePopupRef;

    // Start is called before the first frame update
    void Start()
    {
        PauseButtonRef.onClick.AddListener(PauseButtonPressed);
        ResumeButtonRef.onClick.AddListener(ResumeButtonPressed);
        ReplayButtonRef.onClick.AddListener(ReplayButtonPressed);
        ReturnToMenuButtonRef.onClick.AddListener(ReturnToMenuButtonPressed);
    }

    // Update is called once per frame
    private void PauseButtonPressed()
    {
        PausePopupRef.gameObject.SetActive(true);
        GameConstants.Activate = false;
    }
    public void ResumeButtonPressed()
    {
        PausePopupRef.gameObject.SetActive(false);
        GameConstants.Activate = true;
    }
    public void ReplayButtonPressed()
    {
        GameConstants.Activate = true;
        SceneManager.LoadScene(1);
    }
    public void ReturnToMenuButtonPressed()
    {
        GameConstants.Activate = true;
        SceneManager.LoadScene(0);
    }
}
