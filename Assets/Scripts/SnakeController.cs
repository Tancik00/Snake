using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public GameObject tailPref;
    public ObjectGeneration objectGeneration;
    public List<GameObject> snakeTail;

    private float _speed = 4f;
    private float _rotationSpeed = 190f;
    private float _zOffset = 0.8f;

    private void Start()
    {
        snakeTail.Add(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))
        {
            objectGeneration.GenerateFood();
            Destroy(other.gameObject);
            AddTail();
        }

        if (other.CompareTag("lose"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void AddTail()
    {
        Vector3 tailPos = snakeTail[snakeTail.Count - 1].transform.position;
        tailPos.z -= _zOffset;
        snakeTail.Add(Instantiate(tailPref, tailPos, Quaternion.identity));
    }
}
