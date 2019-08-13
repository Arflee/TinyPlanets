using System.Linq;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class LinkPlanet : CommonPlanet
{
    private List<GameObject> otherPlanets;
    private LineRenderer planetLine;
    private Vector3[] linePositions;
    private GameObject chosenPlanet;



    private void Awake()
    {
        otherPlanets = GameObject.FindGameObjectsWithTag("LinkPlanet").ToList();
        FindAndDeleteThisPlanet();

        planetLine = GetComponent<LineRenderer>();
        planetLine.positionCount = otherPlanets.Count;
        linePositions = new Vector3[otherPlanets.Count];
    }

    protected override void Start()
    {
        FindGameMaster();
        ChooseRandomPlanet();
    }

    protected override void Update()
    {
        base.Update();
        targetPosition = chosenPlanet.transform.position;
        planetLine.SetPositions(linePositions);
        UpdateLinePosition();
    }



    private void ChooseRandomPlanet()
    {
        int randomIndex = UnityEngine.Random.Range(0, otherPlanets.Count);
        chosenPlanet = otherPlanets[randomIndex];
        targetPosition = chosenPlanet.transform.position;
    }

    private void UpdateLinePosition()
    {
        for (int i = 0; i < otherPlanets.Count; i++)
        {
            linePositions[i] = otherPlanets[i].transform.position;
        }
    }

    private void FindAndDeleteThisPlanet()
    {
        GameObject planetItself = otherPlanets.Find((o) => { return gameObject == o; });
        otherPlanets.Remove(planetItself);
    }
}
