using UnityEngine;

namespace DEV205.Interactables
{
    [CreateAssetMenu(fileName = "New Resource Data", menuName = "DEV205/Data/Resource Data")]
    public class ResourceData : ScriptableObject
    {
        [SerializeField] private ResourceType type;
        public ResourceType Type => type;

        [SerializeField, Range(0,100)] private uint amount;
        public uint Amount => amount;
    }
}