
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WristMenu : MonoBehaviour
{
    private GameInputs _input;
    [SerializeField] private XRDirectInteractor _directInteractor;
    [SerializeField] private GameObject _wristMenu;
    [SerializeField] private GameObject _rayController;
    // Start is called before the first frame update
    void Start()
    {
        _input = new GameInputs();
        _input.Enable();
        _input.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        DisplayWristMenu();
    }

    public void DisplayWristMenu()
    {
        if(_wristMenu.activeInHierarchy == false)
        {
            _directInteractor.SendHapticImpulse(0.4f,0.6f);
            _wristMenu.SetActive(true);
            _rayController.SetActive(true);
        }
        else
        {
            _wristMenu.SetActive(false);
            _rayController.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleSubtitles()
    {
        UIManager.Instance.ToggleSubtitles();
    }
}
