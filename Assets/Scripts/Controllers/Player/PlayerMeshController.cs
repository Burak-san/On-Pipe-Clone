using System;
using Data.UnityObjects;
using Data.ValueObjects;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        
        [SerializeField] private Transform hitHolder;
        [SerializeField] private LayerMask layer;

        private PlayerData _playerData;
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _playerData = GetPlayerData;
            transform.parent.transform.localScale = _playerData.FirstScale;
        }

        private PlayerData GetPlayerData => Resources.Load<CD_Player>("Data/CD_Player").PlayerData;

        public void GetPipeScale()
        {
            RaycastHit hit;
            if (Physics.Raycast(hitHolder.transform.position,Vector3.forward,out hit,Mathf.Infinity,layer))
            {
                transform.parent.transform.localScale = new Vector3(
                    hit.transform.localScale.x / _playerData.ScaleDivisionValue +_playerData.Distance,
                            transform.parent.transform.localScale.y,
                                hit.transform.localScale.z/_playerData.ScaleDivisionValue+_playerData.Distance);
            }
        }

        public void GetFirstScale()
        {
            transform.parent.transform.localScale = _playerData.FirstScale;
        }
    }
}