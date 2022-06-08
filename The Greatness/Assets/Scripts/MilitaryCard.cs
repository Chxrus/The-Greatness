using UnityEngine;

[CreateAssetMenu(fileName = "New MilitaryCard", menuName = "Cards/New MilitaryCard", order = 51)]
public class MilitaryCard : Card
{
    [SerializeField] private int _laborersCost;
    [SerializeField] private int _countMilitaries;

    public int LaborersCost => _laborersCost;
    public int CountMilitaries => _countMilitaries;

    public override void ShowInfo()
    {
        Debug.Log($"Card: cost: {_laborersCost} laborer, addition militaries: {_countMilitaries}");
    }

    public override void Use(Characteristics characteristics)
    {
        Debug.Log("Use military card");
    }
}
