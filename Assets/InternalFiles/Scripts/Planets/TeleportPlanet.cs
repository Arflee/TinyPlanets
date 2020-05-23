using UnityEngine;
using System;

namespace TinyPlanets.Planets
{
    public class TeleportPlanet : Planet
    {
        [SerializeField] float secondsToMaxDifficulty = 60f;
        [SerializeField] float minTimeToTeleport = 1f;
        [SerializeField] GameObject markPrefab = null;

        private Vector2 targetPosition;
        private GameObject markObject;
        private float cooldown = 0f;

        public override float SecondsToMaxDifficulty => secondsToMaxDifficulty;

        public override float MinSpeed => 0f;

        public override float MaxSpeed => minTimeToTeleport;

        public override float CurrentSpeed => IncreaseDifficulty();

        public override Vector2 TargetPosition => GetTargetPosition();

        private void Start()
        {
            ChangeTeleportPoint();
        }

        protected override void Update()
        {
            if (cooldown >= CurrentSpeed)
            {
                cooldown = 0f;
                transform.position = targetPosition;
                Destroy(markObject);

                ChangeTeleportPoint();
            }
            else
            {
                cooldown += Time.deltaTime;
            }
        }

        protected override float IncreaseDifficulty()
        {
            float levelPercentage = base.IncreaseDifficulty();

            return  MaxSpeed * (1 - levelPercentage);
        }

        private void ChangeTeleportPoint()
        {
            targetPosition = GetTargetPosition();
            markObject = Instantiate(markPrefab, targetPosition, Quaternion.identity);
        }
    }
}
