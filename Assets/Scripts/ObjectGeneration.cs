using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectGeneration : MonoBehaviour
{
    public GameObject foodPref;
    public GameObject obstaclePref;
    
    private float _xPos = 11f;
    private float _zMinPos = 1f;
    private float _zMaxPos = 18f;

    private void Start()
    {
        GenerateFood();
        GenerateObstacles();
    }

    public void GenerateFood()
    {
        Vector3 _foodPos = new Vector3(Random.Range(-_xPos, _xPos), 0.25f, Random.Range(_zMinPos, _zMaxPos));
        Instantiate(foodPref, _foodPos, Quaternion.identity);
    }

    private void GenerateObstacles()
    {
        for (int i = 0; i < Random.Range(6, 10); i++)
        {
            Vector3 _obstaclePos = new Vector3(Random.Range(-_xPos, _xPos), 0.2f, Random.Range(_zMinPos, _zMaxPos));
            Instantiate(obstaclePref, _obstaclePos, Quaternion.identity);
        }
    }
}
