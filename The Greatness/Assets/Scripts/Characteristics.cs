using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Barrack))]
public class Characteristics : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private Barrack _barrack;
    [SerializeField] private GameUI _gameUI;

    [Header("Data")]
    [SerializeField] private int _dollars;
    [SerializeField] private int _knowledge;
    [SerializeField] private int _militaries;

    [SerializeField] private int _dollarsPerHour;
    [SerializeField] private int _knowledgePerHour;
    [SerializeField] private int _militariesPerHour;


    private void Awake()
    {
        AddDollars(100);
        AddKnowledge(0);
        AddMilitaries(5);
    }
    public void BuildFactory(int count, int cost)
    {
        if (cost > _knowledge)
            return;
        _dollarsPerHour += count;
        AddKnowledge(-cost);
    }

    public void BuildScientificCenter(int count, int cost)
    {
        if (cost > _dollars)
            return;
        _knowledgePerHour += count;
        AddDollars(-cost);
    }

    public void HireMilitaries(int count, int cost)
    {
        if (cost > _dollarsPerHour)
            return;
        _dollarsPerHour -= cost;
        AddMilitaries(count);
    }

    public void NextHour()
    {
        AddDollars(_dollarsPerHour);
        AddKnowledge(_knowledgePerHour);
    }

    private void UpdateUI()
    {
        _gameUI.UpdateIndicators(_dollars, _knowledge, _militaries, _dollarsPerHour, _knowledgePerHour);
    }

    private void AddDollars(int count)
    {
        _dollars += count;
        UpdateUI();
    }

    private void AddKnowledge(int count)
    {
        _knowledge += count;
        UpdateUI();
    }

    private void AddMilitaries(int count)
    {
        _militaries += count;
        _barrack.HireMilitary(count);
        UpdateUI();
    }
}
