using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class MapLoader : MonoBehaviourPunCallbacks
{
    [SerializeField] private string _levelName = "Game";

    public override void OnJoinedRoom()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 60;
        LoadScene();
    }

    private void LoadScene()
    {
        PhotonNetwork.LoadLevel(_levelName);
    }
}
