using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _camera;
    [SerializeField] private HealthPresenter _healthPresenter;

    private void Start()
    {
        if(PhotonNetwork.IsConnected)
        {
            var player = PhotonNetwork.Instantiate(_prefab.name, transform.position, Quaternion.identity).GetComponent < Player>();
            _camera.SetParent(player.transform.GetChild(0));
            _camera.transform.localPosition = Vector3.zero;
            _camera.transform.localRotation = Quaternion.identity;
            _healthPresenter.Connect(player);
        }
    }
}
