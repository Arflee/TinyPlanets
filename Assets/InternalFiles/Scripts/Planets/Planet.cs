using UnityEngine;
using System;

namespace TinyPlanets.Planets
{
    [RequireComponent(typeof(DragAndDrop))]
    public abstract class Planet : MonoBehaviour
    {
        public static Action OnCollision;

        public abstract float SecondsToMaxDifficulty { get; }

        public abstract float MinSpeed { get; }

        public abstract float MaxSpeed { get; }

        public abstract float CurrentSpeed { get; }

        public abstract Vector2 TargetPosition { get; }

        protected virtual Vector2 GetTargetPosition()
        {
            var height = Camera.main.orthographicSize * 2f;
            var width = height * Camera.main.aspect;

            var planetSize = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);

            var randomX = UnityEngine.Random.Range(planetSize.x, width - planetSize.x) - width / 2;
            var randomY = UnityEngine.Random.Range(planetSize.y, height - planetSize.y) - height / 2;

            var targetVector = new Vector2(randomX, randomY);

            return targetVector;
        }

        protected virtual float IncreaseDifficulty()
        {
            return Mathf.Clamp01(Time.timeSinceLevelLoad / SecondsToMaxDifficulty);
        }

        protected virtual void Update()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, TargetPosition, CurrentSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollision?.Invoke();
        }
    }
}
