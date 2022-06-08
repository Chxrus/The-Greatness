using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private int _dollars;
    [SerializeField] private int _knowledge;
    [SerializeField] private int _militaries;

    [SerializeField] private int _dollarsPerHour;
    [SerializeField] private int _knowledgePerHour;
    [SerializeField] private int _militariesPerHour;

    [SerializeField] private TextMeshProUGUI _dollarsText;
    [SerializeField] private TextMeshProUGUI _knowledgeText;
    [SerializeField] private TextMeshProUGUI _militariesText;

    [SerializeField] private TextMeshProUGUI _dollarsPerHourText;
    [SerializeField] private TextMeshProUGUI _knowledgePerHourText;
    [SerializeField] private TextMeshProUGUI _militariesPerHourText;

    private void Awake()
    {
        AddDollars(100);
        AddKnowledge(0);
        AddMilitaries(5);
    }

    private void AddDollars(int count)
    {
        _dollars += count;
        _dollarsText.text = _dollars.ToString();
    }

    private void AddKnowledge(int count)
    {
        _knowledge += count;
        _knowledgeText.text = _knowledge.ToString();
    }

    private void AddMilitaries(int count)
    {
        _militaries += count;
        _militariesText.text = _militaries.ToString();
    }


    public void BuildFactory(int count, int cost)
    {
        if (cost > _knowledge)
            return;

        _knowledge -= cost;
        _dollarsPerHour += count;
        _dollarsPerHourText.text = $"{_dollarsPerHour}/h";
        Debug.Log($"{count} factories were built");
    }

    public void BuildScientificCenter(int count, int cost)
    {
        if (cost > _dollars)
            return;

        _dollars -= cost;
        _knowledgePerHour += count;
        _knowledgePerHourText.text = $"{_knowledgePerHour}/h";
        Debug.Log($"{count} scientific centers were built");
    }

    public void HireMilitaries(int count, int cost)
    {
        if (cost > _dollarsPerHour)
            return;

        _dollarsPerHour -= cost;
        _militariesPerHour += count;
        _militariesPerHourText.text = $"{_militariesPerHour}/h";
        Debug.Log($"{count} militaries were hired");
    }

    public void NextHour()
    {
        AddDollars(_dollarsPerHour);
        AddKnowledge(_knowledgePerHour);
        AddMilitaries(_militariesPerHour);
    }
}
