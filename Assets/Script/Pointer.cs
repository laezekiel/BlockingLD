using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField]
    private Vector3 _TargetPosition = Vector3.zero;

    [SerializeField]
    private PointerDirection _Direction = PointerDirection.Forward;

    private void OnValidate()
    {
        Vector3 directionToTarget = (_TargetPosition - transform.position).normalized;
        transform.LookAt(_TargetPosition);
        switch (_Direction)
        {
            case PointerDirection.Up:
                transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.right * 90);
                break;

            case PointerDirection.Down:
                transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.left * 90);
                break;

            case PointerDirection.Left:
                transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(-transform.eulerAngles.x + transform.eulerAngles.z, 90, -transform.eulerAngles.z + transform.eulerAngles.x));
                break;

            case PointerDirection.Right:
                transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(-transform.eulerAngles.x + transform.eulerAngles.z, -90, -(-transform.eulerAngles.z + transform.eulerAngles.x)));
                break;
            case PointerDirection.Backward:
                transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.left * 180);
                break;

            default:
                break;
        }
    }

    private enum PointerDirection { Up, Down, Left, Right, Forward, Backward }
}

