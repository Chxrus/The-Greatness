using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _windowMenu;

    [Header("Indicators")]
    [SerializeField] private TextMeshProUGUI _textDollars;
    [SerializeField] private TextMeshProUGUI _textKnowledge;
    [SerializeField] private TextMeshProUGUI _textMilitaries;
    [SerializeField] private TextMeshProUGUI _textDollarsPerHour;
    [SerializeField] private TextMeshProUGUI _textKnowledgePerHour;

    [Header("Base")]
    [SerializeField] private TextMesh _textBaseHealth;

    [Header("Waves&Time")]
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _timeText;

    public void ShowMenu()
    {
        _windowMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        _windowMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateIndicators(int dollars, int knowledge, int militaries, int dollarsPerMinute, int knowledgePerMinute)
    {
        _textDollars.text = dollars.ToString();
        _textKnowledge.text = knowledge.ToString();
        _textMilitaries.text = militaries.ToString();

        _textDollarsPerHour.text = $"{dollarsPerMinute.ToString()}/ h";
        _textKnowledgePerHour.text = $"{knowledgePerMinute.ToString()}/h";
    }

    public void UpdateBaseHealth(int value)
    {
        _textBaseHealth.text = value.ToString();
    }

    public void UpdateTime(string value)
    {
        _timeText.text = value;
    }

    public void UpdateWave(string value)
    {
        _waveText.text = value;
    }

    public void UpdateTimeSlider(int value)
    {
        _timeSlider.value = value;
    }
}
