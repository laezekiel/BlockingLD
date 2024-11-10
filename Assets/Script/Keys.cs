using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField]
    private DoorLockType _Type = DoorLockType.None;


    public DoorLockType Type { get { return _Type; } }


    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out ThirdPersonController lPlayer))
        {
            lPlayer.CanOpen[_Type] = true;

            Destroy(gameObject);
        }
    }
}
