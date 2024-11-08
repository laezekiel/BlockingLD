using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Door : MonoBehaviour
{
    // Reusable info, fields and properties
    [SerializeField]
    protected bool m_CloseOnStart = false;

    [SerializeField]
    protected DoorLockType m_Type = DoorLockType.None;

    private HashSet<Collider> _PlayersInTrigger = new HashSet<Collider>();

    private CapsuleCollider _Collider;

    public int Count {  get { return _PlayersInTrigger.Count; } }
    public CapsuleCollider Collider { get => _Collider != null ? _Collider : _Collider = GetComponent<CapsuleCollider>(); }

    // Custom info, fields and properties

    [SerializeField]
    protected GameObject m_Door, m_ButtonBlueFront, m_ButtonBlueBack, m_ButtonGreyFront, m_ButtonGreyBack, m_ButtonRedFront, m_ButtonRedBack;


    private void OnValidate()
    {
        // Reusable 
        m_Door?.SetActive(m_CloseOnStart);

        switch (m_Type)
        {
            case DoorLockType.Permanent:
                // Custom 
                m_ButtonGreyFront?.SetActive(true);
                m_ButtonBlueFront?.SetActive(false);
                m_ButtonRedFront?.SetActive(false);
                m_ButtonGreyBack?.SetActive(true);
                m_ButtonBlueBack?.SetActive(false);
                m_ButtonRedBack?.SetActive(false);
                break;
            case DoorLockType.None:
                // Custom 
                m_ButtonGreyFront?.SetActive(false);
                m_ButtonBlueFront?.SetActive(true);
                m_ButtonRedFront?.SetActive(false);
                m_ButtonGreyBack?.SetActive(false);
                m_ButtonBlueBack?.SetActive(true);
                m_ButtonRedBack?.SetActive(false);
                break;
            // Custom 
            default:
                // Custom 
                m_ButtonGreyFront?.SetActive(false);
                m_ButtonBlueFront?.SetActive(false);
                m_ButtonRedFront?.SetActive(true);
                m_ButtonGreyBack?.SetActive(false);
                m_ButtonBlueBack?.SetActive(false);
                m_ButtonRedBack?.SetActive(true);
                break;
        }
    }


    // Reusable Methods
    public virtual void Open()
    {
        m_Door?.SetActive(false);
    }
    public virtual void Close()
    {
        m_Door?.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        // You can change the type
        if (other.TryGetComponent(out ThirdPersonController lPlayer))
        {
            _PlayersInTrigger.Add(other);

            if ((m_Type == DoorLockType.Permanent || (m_Type == DoorLockType.None && m_CloseOnStart == false)) && !m_Door.activeSelf) return;

            if (m_Type == DoorLockType.None) Open();
            else
            {
                switch (m_Type)
                {
                    case DoorLockType.SecurityGuardKey:
                        // Custom
                        break;
                    case DoorLockType.Suits:
                        // Custom
                        break;
                    default: return;
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        // You can change the type
        if (other.TryGetComponent(out ThirdPersonController lPlayer))
        {
            _PlayersInTrigger.Remove(other);

            if ((m_Type == DoorLockType.Permanent || (m_Type == DoorLockType.None && m_CloseOnStart == false)) && m_Door.activeSelf && Count == 0) return;

            if (m_Type == DoorLockType.None) Close();
            else
            {
                switch (m_Type)
                {
                    case DoorLockType.SecurityGuardKey:
                        // Custom
                        break;
                    case DoorLockType.Suits:
                        // Custom
                        break;
                    default: return;
                }
            }
        }
    }

}

/// <summary>
/// Enum for all type of door according to their opening methods 
/// </summary>
public enum DoorLockType
{
    // Reusable Types
    Permanent,
    None,
    // Custom Type
    SecurityGuardKey,
    Suits,
}
