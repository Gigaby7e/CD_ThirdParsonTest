namespace Characters
{
    public class Player : CharacterBase
    {
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            Reset();
        }

        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (other.GetComponent<ICollectableObject>() != null)
            {
                if (other.CompareTag(TagManager.MEDKIT))
                {
                    var kit = other.GetComponent<ICollectableObject>();
                    RestoreHealt(kit.Collect());
                    kit.OnCollected();
                }
            }
        }
    }
}