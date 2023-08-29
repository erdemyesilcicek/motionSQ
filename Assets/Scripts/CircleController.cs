using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] GameObject circlePrefab;
    [SerializeField] int circleStartNumber;
    [SerializeField] float circleSpeed;
    [SerializeField] float circleIncrease;
    [SerializeField] Transform squareLocation;
    [SerializeField] float randomMinX, randomMaxX;
    [SerializeField] float randomMinY, randomMaxY;
    public float waitingTime = 2f;
    private GameObject[] circles;
    private bool isStart = false;
    public float spawnInterval = 3f;
    public void Start()
    {
        circles = new GameObject[circleStartNumber];
        for (int i = 0; i < circleStartNumber; i++)
        {
            circles[i] = Instantiate(circlePrefab, RondomLocation(), Quaternion.identity);
            circles[i].SetActive(false);
        }
        InvokeRepeating("StartCircle", 0f, spawnInterval);
    }
    void StartCircle()
    {
        isStart = true;
        for (int i = 0; i < circles.Length; i++)
        {
            if (circles[i] != null)
            {
                circles[i].SetActive(true);
            }
        }
    }
    Vector2 RondomLocation()
    {
        float x = Random.Range(randomMinX, randomMaxX); // -9 - 9
        float y = Random.Range(randomMinY, randomMaxY); // 14-17
        return new Vector2(x, y);
    }
    void Update()
    {
        FallowSquare();
    }
    public void FallowSquare()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            if (circles[i] != null)
            {
                Vector2 motion = (squareLocation.position - circles[i].transform.position).normalized;
                circles[i].transform.Translate(motion * circleSpeed * Time.deltaTime);

                if (Vector2.Distance(circles[i].transform.position, squareLocation.position) < 0.2f)
                {
                    Time.timeScale = 0;
                    Destroy(circlePrefab);
                }
            }
        }
    }
}