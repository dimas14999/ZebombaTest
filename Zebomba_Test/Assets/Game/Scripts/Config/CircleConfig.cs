using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Config
{
    [CreateAssetMenu(fileName = "CircleConfig", menuName = "Config/CircleConfig")]
    public class CircleConfig : ScriptableObject
    {
        [field: SerializeField] public List<CircleContent> CircleContents { get; private set; }
    }

    [Serializable]
    public class CircleContent
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public int Score { get; private set; }
        [field: SerializeField] public Color Colors { get; private set; }
    }
}
