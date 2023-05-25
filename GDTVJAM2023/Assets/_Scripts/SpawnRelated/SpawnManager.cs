using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float _timeToIncreseDifficulty = 10f;
    [SerializeField] private float _spawnRate = 5f;
    [SerializeField] private float _spawnRateFactor = 1f;
    [SerializeField] private float _timerOffset = .5f;

    [SerializeField] [Range(1, 6)]private int _maxSpawns = 3;
    private float _minRate;
    private float _maxRate;

    [SerializeField] private GameObject _damageBulletPrefab;
    [SerializeField] private GameObject _ghostBulletPrefab;

    [SerializeField] private Spawnner[] _spawners;

    [SerializeField] private bool _isParallelMap = true;

    private float _timeElapsed = 0f;
    private float _timerToNextSpawn = 0f;
    private float _timerToIncrease;

    public static Action<float> DifficultyChanged;

    private void Start()
    {
        _timerToIncrease = _timeToIncreseDifficulty;
        _minRate = _spawnRateFactor;
        _maxRate = _spawnRate;
        _timeElapsed -= _timerOffset;
    }
    private void Update()
    {
        _timeElapsed += Time.deltaTime;
        CalculateNextSpawn();
        
    }

    private void OnEnable()
    {
        MapChanger.ChangeMap += OnMapChange;
    }
    private void OnDisable()
    {
        MapChanger.ChangeMap -= OnMapChange;
    }

    private void CalculateNextSpawn()
    {
        if(!_isParallelMap) 
        {
            if (_timerToNextSpawn > _timeElapsed)
                return;

            DifficultyChanged?.Invoke(_spawnRateFactor);

            if (_timeElapsed >= _timerToIncrease)
            {

                _spawnRate -= _spawnRateFactor;

                if (_spawnRate < _minRate)
                    _spawnRate = _minRate;

                _timerToIncrease += _timeToIncreseDifficulty;
            }

            _timerToNextSpawn += _spawnRate;

            var spawnPoints = GenerateSpawnPoints();

            foreach(var point in spawnPoints)
            {
                _spawners[point].SpawnBullet(_damageBulletPrefab);
            }

        }
        else
        {
            if (_timerToNextSpawn > _timeElapsed)
                return;

            DifficultyChanged?.Invoke(_spawnRateFactor);

            if (_timeElapsed >= _timerToIncrease)
            {
                _spawnRate += _spawnRateFactor;
               
                if (_spawnRate > _maxRate)
                    _spawnRate = _maxRate;

                _timerToIncrease += _timeToIncreseDifficulty;
            }

            _timerToNextSpawn += _spawnRate;

            var spawnPoints = GenerateSpawnPoints();

            foreach (var point in spawnPoints)
            {
                _spawners[point].SpawnBullet(_ghostBulletPrefab);
            }
        }
        

    }


    private List<int> GenerateSpawnPoints()
    {
        List<int> l = Enumerable.Range(0, _spawners.Length).ToList();
        List<int> spawns = new List<int>();
        System.Random rng = new System.Random();

        for(int i = 0; i < _maxSpawns; i++)
        {
            int index = rng.Next(l.Count);
            spawns.Add(l[index]);
            l.RemoveAt(index);
        }
        return spawns;
    }

    public void OnMapChange()
    {
        
        _isParallelMap = !_isParallelMap;
    }
}
