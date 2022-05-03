using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// �j�U�޲z��
/// ���a���U�t����s�}�l�ǰt�ж�
/// </summary>

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField, Header("�s�u���e��")]
    private GameObject goConnectView;
    [SerializeField, Header("��ԫ��s")]
    private Button btnBattle;
    [SerializeField, Header("�s�u�H��")]
    private Text textCountPlayer;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("<color=yellow>�w�i�J����x</color>");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("<color=yellow>�w�i�J�j�U</color>");

        btnBattle.interactable = true;

    }



    // 1. ���Ѥ��}����k Public Method
    // 2. ���s�b�I�� On Click ��]�w�I�s����k

    public void StartConnect()
    {
        print("<color=yellow>�}�l�s�u...</color>");

        goConnectView.SetActive(true);

        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("<color=red>�[�J�H���ж�����</color>");

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 10;
        PhotonNetwork.CreateRoom("",ro);


    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("<color=yellow>�}�Ъ̶i�J�ж�</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;
        textCountPlayer.text = "�s�u�H�� " + currentCount + " / " + maxCount;
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print("<color=yellow>���a�i�J�ж�</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;

        textCountPlayer.text = "�s�u�H�� " + currentCount + " / " + maxCount;
    }



}
