using UnityEngine;
using UnityEngine.SceneManagement;

public class TailController : MonoBehaviour
{
    private SnakeController _snakeController;
    private GameObject _tailDestinationObj;
    private Vector3 _tailDestination;

    private float _speed = 6.5f;
    private int _tailIndex;

    private void Start()
    {
        _snakeController = GameObject.FindGameObjectWithTag("snake").GetComponent<SnakeController>();
        _tailDestinationObj = _snakeController.snakeTail[_snakeController.snakeTail.Count - 2];
        _tailIndex = _snakeController.snakeTail.IndexOf(gameObject);
    }

    private void Update()
    {
        _tailDestination = _tailDestinationObj.transform.position;
        transform.LookAt(_tailDestination);
        transform.position = Vector3.Lerp(transform.position, _tailDestination, Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snake"))
        {
            if (_tailIndex > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
