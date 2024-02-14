using System.Collections;
using Game.Scripts.Config;
using UnityEngine;

namespace Game.Scripts.Game.View
{
    public class CircleView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private ParticleSystem _particleSystem;
        
        public CircleContent CircleContent { get; private set; }
        
        public void Init(CircleContent circleContent)
        {
            _spriteRenderer.color = circleContent.Colors;
            CircleContent = circleContent;
        }

        public void DisconnectCircle(Transform parent)
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            transform.parent = parent;
        }

        public void Destroy()
        {
            StartCoroutine(DestroyAnimation());
        }

        private IEnumerator DestroyAnimation()
        {
            _particleSystem.Play();
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
    }
}
