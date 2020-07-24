using Characters;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public Player PlayerController;

    private List<IDamageRecipient> _damageRecipients = new List<IDamageRecipient>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.ENEMY))
        {
            _damageRecipients.Add(other.GetComponentInParent<IDamageRecipient>());
            PlayerController.SetTarget(other.GetComponentInParent<IDamageRecipient>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagManager.ENEMY))
        {
            if (_damageRecipients.Contains(other.GetComponentInParent<IDamageRecipient>()))
            {
                _damageRecipients.Remove(other.GetComponentInParent<IDamageRecipient>());
            }

            if (_damageRecipients.Count != 0)
            {
                PlayerController.SetTarget(_damageRecipients[Random.Range(0, _damageRecipients.Count)]);
            }
            else
            {
                PlayerController.SetTarget(null);
            }
        }
    }
}
