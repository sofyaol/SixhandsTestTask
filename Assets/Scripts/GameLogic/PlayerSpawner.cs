using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = System.Random;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mainLogicPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    
    void Awake()
    {
        Random random = new Random();
        int randomSpawn = random.Next(0, _spawnPoints.Count); 
        GameObject player = PhotonNetwork.Instantiate(_mainLogicPrefab.name, _spawnPoints[randomSpawn].position, Quaternion.identity);

    }
}
