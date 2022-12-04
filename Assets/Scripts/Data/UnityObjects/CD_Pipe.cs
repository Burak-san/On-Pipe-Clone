using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Pipe", menuName = "OnPipeClone/CD_Pipe", order = 0)]
    public class CD_Pipe : ScriptableObject
    {
        public PipeData PipeData;
    }
}