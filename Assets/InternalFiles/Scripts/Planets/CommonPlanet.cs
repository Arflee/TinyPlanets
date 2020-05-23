using UnityEngine;

namespace TinyPlanets.Planets
{
    public class CommonPlanet : Planet
    {
        [SerializeField] private float secondsToMaxDifficulty = 60f;
        [SerializeField] private float minSpeed = 0f;
        [SerializeField] private float maxSpeed = 10f;

        protected Vector2 targetPosition;

        public override float SecondsToMaxDifficulty => secondsToMaxDifficulty;
        public override float MinSpeed => minSpeed;
        public override float MaxSpeed => maxSpeed;
        public override float CurrentSpeed => Mathf.Lerp(minSpeed, maxSpeed, IncreaseDifficulty());

        public override Vector2 TargetPosition => targetPosition;

        private void Start()
        {
            targetPosition = GetTargetPosition();
        }

        protected override void Update()
        {
            if ((Vector2)transform.position != TargetPosition)
                base.Update();
            else
                targetPosition = GetTargetPosition();
        }
    }
}


