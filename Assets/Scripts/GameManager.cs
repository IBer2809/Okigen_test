using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState { PrePlay, Play, Win };
    public GameState CurrentState { get; private set; }
    [SerializeField] private int _fruitsCountToWin;
    [SerializeField] private int _collectedFruitsCount = 0;
    [SerializeField] private string _currentFruitName;
    [SerializeField] private Transform _fruitsTransform;
    [SerializeField] private AnimationController _playerAnimationController;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private GameObject _conveyourTable;
    [SerializeField] private CharacterController _characterController;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        CurrentState = GameState.PrePlay;
        UIManager.Instance.ActivatePrePlayMenu();
    }

    public void GetFruitsParameters(int count, string name)
    {
        _fruitsCountToWin = count;
        _currentFruitName = name;
    }

    public void CollectFruit(PickUp pickUp)
    {
        if(pickUp.gameObject.tag == _currentFruitName)
        {
            pickUp.gameObject.tag = "Untagged";
            _collectedFruitsCount++;
            UIManager.Instance.UpdateCurrentFruitsCountText(_collectedFruitsCount);
            if (_collectedFruitsCount == _fruitsCountToWin)
            {
                CurrentState = GameState.Win;
                UIManager.Instance.ActivateWinPanel();
                _fruitsTransform.gameObject.SetActive(false);
                _playerAnimationController.ActivePlayerDance();
                _cameraController.MoveCameraToFinishPoint();
                _conveyourTable.SetActive(false);
                _characterController.CharacterOnFinish();

            }
        }
    }


    public void ChangeGameState(GameState state)
    {
        CurrentState = state;
        if (CurrentState == GameState.Play)
            _playerAnimationController.SetDefaultAnim();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
