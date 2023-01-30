using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _prePlayPanel;
    [SerializeField] private GameObject _playPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private string[] _tasks;
    [SerializeField] private TextMeshProUGUI _taskText;
    [SerializeField] private TextMeshProUGUI _toCollectText;
    [SerializeField] private TextMeshProUGUI _currentFruitsCountText;
    [SerializeField] private GameObject _bananaImage;
    [SerializeField] private GameObject _orangeImage;
    [SerializeField] private GameObject _appleImage;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ActivatePrePlayMenu()
    {
        _prePlayPanel.SetActive(true);
        _playPanel.SetActive(false);
        _winPanel.SetActive(false);
    }
    public void StartGame()
    {
        int fruitsTaskCount = Random.Range(1, 6);
        int currentTaskIndex = Random.Range(0, _tasks.Length);
        if (currentTaskIndex == 0)
            _appleImage.SetActive(true);
        else if (currentTaskIndex == 1)
            _orangeImage.SetActive(true);
        else if (currentTaskIndex == 2)
            _bananaImage.SetActive(true);
        GameManager.Instance.GetFruitsParameters(fruitsTaskCount, _tasks[currentTaskIndex]);
        _taskText.text = $"COLLECT {fruitsTaskCount} {_tasks[currentTaskIndex]}";
        _toCollectText.text = $"/{fruitsTaskCount}";
        _prePlayPanel.SetActive(false);
        _playPanel.SetActive(true);
        _winPanel.SetActive(false);
        GameManager.Instance.ChangeGameState(GameManager.GameState.Play);
    }

    public void UpdateCurrentFruitsCountText(int count)
    {
        _currentFruitsCountText.text = count.ToString();
    }

    public void ActivateWinPanel()
    {
        _winPanel.SetActive(true);
        _playPanel.SetActive(false);
        _prePlayPanel.SetActive(false);
    }
}
