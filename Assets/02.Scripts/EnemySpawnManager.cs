using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] RunnerPoints;
    [SerializeField] Transform[] StranikPoints;
    [SerializeField] Transform[] RatnikPoints;
    [SerializeField] Transform[] CrabPoints;
    [SerializeField] Transform[] HunterPoints;
    [SerializeField] GameObject[] enemyPrefebs;

    public float MinSpawnTime { get; set; } = 4.2f;
    public float MaxSpawnTime { get; set; } = 6.2f;
    float _spawnTime = 0;
    float _currentTime = 0;

    int _dazeEnemyCounter = 0;
    int _toDaySpawn = 0;

    private void Start()
    {
        _spawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
        _toDaySpawn = 0;
        _dazeEnemyCounter = DazenKillManager.Instance.DazeEnemyCounter;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _spawnTime && !(_dazeEnemyCounter == _toDaySpawn))
        {
            DnP(DazenKillManager.Instance.Daze);
        }
    }

    private void DnP(int day)
    {
        int odds = Random.Range(0, 101);
        if (day < 4)
        {
            MinSpawnTime = 3.6f;
            MaxSpawnTime = 4.2f;
            if (odds < 70)
            {
                Spawn(0, RunnerPoints);
            }
            else
            {
                Spawn(1, StranikPoints);
            }
        }
        else if (day < 9)
        {
            MinSpawnTime = 3.0f;
            MaxSpawnTime = 3.6f;
            if (odds < 51)
            {
                Spawn(0, RunnerPoints);
            }
            else if (odds < 96)
            {
                Spawn(1, StranikPoints);
            }
            else
            {
                Spawn(2, RatnikPoints);
            }
        }
        else if (day < 13)
        {
            MinSpawnTime = 2.2f;
            MaxSpawnTime = 3.6f;
            if (odds < 21)
            {
                Spawn(0, RunnerPoints);
            }
            else if (odds < 56)
            {
                Spawn(1, StranikPoints);
            }
            else if (odds < 81)
            {
                Spawn(2, RatnikPoints);
            }
            else
            {
                Spawn(3, CrabPoints);
            }
        }
        else if (day < int.MaxValue)
        {
            MinSpawnTime = 2.0f;
            MaxSpawnTime = 2.7f;
            if (odds < 11)
            {
                Spawn(0, RunnerPoints);
            }
            else if (odds < 51)
            {
                Spawn(1, StranikPoints);
            }
            else if (odds < 81)
            {
                Spawn(2, RatnikPoints);
            }
            else if (odds < 98)
            {
                Spawn(3, CrabPoints);
            }
            else
            {
                Spawn(4, HunterPoints);
            }
        }
    }

    private void Spawn(int prenum, Transform[] array)
    {
        Instantiate(enemyPrefebs[prenum], array[Random.Range(0, array.Length)]);
        _currentTime = 0;
        _spawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
        _toDaySpawn++;
    }
}
