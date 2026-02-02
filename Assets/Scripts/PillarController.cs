using UnityEngine;

public class PillarController : MonoBehaviour
{
    public GameObject pillar;
    public float spawnTime = 3.0f;

    private float _totalSpawned;
    private float _pillarHeight;
    private float _timeLeft;

    private bool _isInstantiated;

    void Awake()
    {
        Instantiate(pillar, new Vector2(12.0f, 5.5f), Quaternion.identity);
        pillar.GetComponent<MovePillar>().moveSpeed = 5.0f;
    }

    void Update()
    {
        _pillarHeight = Random.Range(3.0f, 8.0f);
        _timeLeft += Time.deltaTime;
        
        if (_timeLeft > spawnTime)
        {
            Spawn();
            _totalSpawned++;
            _timeLeft = 0;
        }

        _isInstantiated = false;
    }

    void Spawn()
    {
        if (_isInstantiated == false)
        {
            Debug.Log($"Total Spawned: {_totalSpawned}, Spawn Time: {spawnTime}, Pillar Speed: {pillar.GetComponent<MovePillar>().moveSpeed}");

            if (spawnTime > 1.0f && _totalSpawned > 1 && _totalSpawned % 5 == 0)
            {
                spawnTime -= 0.20f;
                Debug.Log($"Spawn Increase!");

                pillar.GetComponent<MovePillar>().moveSpeed += 0.10f;
                Debug.Log($"Speed Increase!");
            }

            Instantiate(pillar, new Vector2(12.0f, _pillarHeight), Quaternion.identity);
            _isInstantiated = true;
        }
    }
}
