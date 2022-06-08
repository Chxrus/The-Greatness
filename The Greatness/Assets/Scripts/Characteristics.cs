using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private int _dollars;
    [SerializeField] private int _knowledge;
    [SerializeField] private int _militaries;

    [SerializeField] private TextMeshProUGUI _dollarsText;
    [SerializeField] private TextMeshProUGUI _knowledgeText;
    [SerializeField] private TextMeshProUGUI _militariesText;

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


    public void BuildFactory(int count)
    {
        Debug.Log($"{count} factories were built");
    }

    public void BuildScientificCenter(int count)
    {
        Debug.Log($"{count} scientific centers were built");
    }

    public void HireMilitaries(int count)
    {
        Debug.Log($"{count} militaries were hired");
    }

}
