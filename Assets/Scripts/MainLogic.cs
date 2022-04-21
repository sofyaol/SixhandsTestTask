using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;

    [Space][Header("[PERSONALS]")]
    [SerializeField] private List<GameObject> _personalObjects;
    [SerializeField] private List<MonoBehaviour> _personalComponents;

    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (_photonView == null)
        {
            GetComponent<PhotonView>();
        }

        if (!_photonView.IsMine)
        {
            foreach (var item in _personalObjects)
            {
                item.SetActive(false);
            }
            
            foreach(var item in _personalComponents)
            {
                item.enabled = false;
            }

        }
    }

}
