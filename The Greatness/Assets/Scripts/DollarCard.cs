using UnityEngine;

[CreateAssetMenu(fileName ="New DollarCard", menuName ="Cards/New DollarCard", order =51)]
public class DollarCard : Card
{
    [SerializeField] private int _knowledgeCost;
    [SerializeField] private int _countFactories;

    public int KnowledgeCost => _knowledgeCost;
    public int CountFactories => _countFactories;

    public override void ShowInfo()
    {
        Debug.Log($"Card: cost: {_knowledgeCost} knowledge, addition factories: {_countFactories}");
    }

    public override void Use(Characteristics characteristics)
    {
        Debug.Log("Use dollar card");

        characteristics.BuildFactory(_countFactories);
    }
}
