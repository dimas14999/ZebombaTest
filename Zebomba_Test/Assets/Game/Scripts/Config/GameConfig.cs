using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public int MaxCircles { get; private set; }
    [field: SerializeField] public int CircleCountForDestroy { get; private set; }
}
