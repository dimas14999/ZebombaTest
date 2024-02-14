using System;
using System.Collections.Generic;
using Game.Scripts.Game.View;
using UnityEngine;

namespace Game.Scripts.Game.Core
{
    public class TriggerZone : MonoBehaviour
    {
        public List<CircleView> CircleViews { get; } = new List<CircleView>();
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!col.TryGetComponent(out CircleView circle))
                return;
          
            CircleViews.Add(circle);
        }

        public void Remove(int index)
        {
            CircleViews.RemoveAt(index);
        }
    }
}
