using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : MonoBehaviour
{
    private bool isSuperpowerAvailable = false;

    WariorMove WariorMoveInvisible, WariorMoveTeleport;

    [SerializeField] GameObject player;

    public bool isPlayerInvisibleNow= false, isPlayerTeleported;

    private void Start()
    {
        WariorMoveInvisible = player.GetComponent<WariorMove>();
        WariorMoveTeleport = player.GetComponent<WariorMove>();
    }

    private void Update()
    {
        isPlayerInvisibleNow = WariorMoveInvisible.GetisInvisibleNow();
        isPlayerTeleported = WariorMoveTeleport.GetisTeleported();
    }

    public bool GetisSuperpowerAvailable()
    {
        return isSuperpowerAvailable;
    }

    public void SetisSuperpowerAvailableFalse()
    {
        isSuperpowerAvailable = false;
    }
    public void SetisSuperpowerAvailableTrue()
    {
        isSuperpowerAvailable = true;
    }

    public void SetisTeleportedFalse()
    {
        WariorMoveTeleport.SetisTeleportedFalse();
    }
}
