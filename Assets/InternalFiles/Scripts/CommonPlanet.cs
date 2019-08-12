using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonPlanet : MonoBehaviour
{
    [Header("Outer position values")]
    [SerializeField] private float minX = 1f;
    [SerializeField] private float minY = 1f;
    [SerializeField] private float maxX = 1f;
    [SerializeField] private float maxY = 1f;

    [Space]

    [SerializeField] private float speed = 5f;

    private Vector2 targetPosition;



    private void Start()
    {
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = 
                Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Planet"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



    private Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}
