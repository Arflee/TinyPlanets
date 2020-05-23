using System.Linq;
using UnityEngine;


namespace TinyPlanets.Planets
{
    [RequireComponent(typeof(LineRenderer))]
    public class LinkPlanet : CommonPlanet
    {
        private LineRenderer planetsLine;
        private LinkPlanet[] otherLinkPlanets;
        private LinkPlanet choosedPlanet;

        private void Start()
        {
            planetsLine = GetComponent<LineRenderer>();
            otherLinkPlanets = FindObjectsOfType<LinkPlanet>();
            targetPosition = GetTargetPosition();
            choosedPlanet = ChoosePlanet();

            planetsLine.positionCount = 2;
            SetLines();
        }

        protected override void Update()
        {
            targetPosition = choosedPlanet.transform.position;
            base.Update();
        }

        private void LateUpdate()
        {
            SetLines();
        }

        private LinkPlanet ChoosePlanet()
        {
            var withoutItself = otherLinkPlanets.Where(planet => planet != this).ToArray();
            var randomIndex = Random.Range(0, withoutItself.Length - 1);

            return withoutItself[randomIndex];
        }

        private void SetLines()
        {
            planetsLine.SetPosition(0, transform.position);
            planetsLine.SetPosition(1, choosedPlanet.transform.position);
        }
    }
}

