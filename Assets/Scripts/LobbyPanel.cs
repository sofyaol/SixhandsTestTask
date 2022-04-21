using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyPanel : MonoBehaviourPunCallbacks
{
    [Space]
    [SerializeField] private InputField _createField;
    [SerializeField] private InputField _joinField;
    [SerializeField] private byte _maxPlayersNumber = 2;

    public void CreateRoom()
    {
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = _maxPlayersNumber;
        PhotonNetwork.CreateRoom(_createField.text, room);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
