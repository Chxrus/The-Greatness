using UnityEngine;

[CreateAssetMenu(fileName = "New KnowledgeCard", menuName = "Cards/New KnowledgeCard", order = 51)]
public class KnowledgeCard : Card
{
    [SerializeField] private int _dollarsCost;
    [SerializeField] private int _countScientists;

    public int DollarsCost => _dollarsCost;
    public int CountScientists => _countScientists;

    public override void ShowInfo()
    {
        Debug.Log($"Card: cost: {_dollarsCost} dollars, addition factories: {_countScientists}");
    }

    public override void Use(Characteristics characteristics)
    {
        Debug.Log("Use knowledge card");

        characteristics.BuildScientificCenter(_countScientists);
    }
}
