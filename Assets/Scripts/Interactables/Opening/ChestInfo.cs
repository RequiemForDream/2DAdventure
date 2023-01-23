using UnityEngine;

[CreateAssetMenu(fileName = "ChestInfo", menuName = "GamePlay/NewChestInfo")]
public class ChestInfo : ScriptableObject
{
    [SerializeField] private string _chestName;
    public string chestName => this._chestName;
    [SerializeField] private int _maxReward;
    [SerializeField] private int _minReward;
    public int reward => Random.Range(this._minReward, this._maxReward);
}
