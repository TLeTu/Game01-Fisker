using UnityEngine;

[CreateAssetMenu(fileName = "New Fish Data", menuName = "Fisker/Fish Data", order = 51)]
public class FishData : ScriptableObject {
    [Header("Fish Attributes")]
    [SerializeField] private string _fishName = "New Fish";
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _scoreValue = 10;

    [Header("References")]
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Fish _fishPrefab;

    // public properties to access the private fieds
    public string FishName => _fishName;
    public float MoveSpeed => _moveSpeed;
    public int ScoreValue => _scoreValue;
    public Sprite Sprite => _sprite;
    public Fish FishPrefab => _fishPrefab;
}