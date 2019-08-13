using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class LinkPlanet : CommonPlanet
{
    private GameObject[] otherPlanets;
    private LineRenderer planetLine;
    private Vector3[] linePositions;
    private GameObject chosenPlanet;



    private void Awake()
    {
        planetLine = GetComponent<LineRenderer>();
        otherPlanets = GameObject.FindGameObjectsWithTag("LinkPlanet");
        planetLine.positionCount = otherPlanets.Length;
        linePositions = new Vector3[otherPlanets.Length];
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
        int randomIndex = Random.Range(0, otherPlanets.Length);
        chosenPlanet = otherPlanets[randomIndex];
        targetPosition = chosenPlanet.transform.position;
    }

    private void UpdateLinePosition()
    {
        for (int i = 0; i < otherPlanets.Length; i++)
        {
            linePositions[i] = otherPlanets[i].transform.position;
        }
    }
}
