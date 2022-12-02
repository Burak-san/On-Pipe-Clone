using System;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        [SerializeField] private Transform hitHolder;
        [SerializeField] private LayerMask layer;

        private Vector3 _firstPlayerScale;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _firstPlayerScale = transform.parent.transform.localScale;
        }

        public void GetPipeScale()
        {
            RaycastHit hit;
            if (Physics.Raycast(hitHolder.transform.position,Vector3.forward,out hit,Mathf.Infinity,layer))
            {
                transform.parent.transform.localScale = new Vector3(hit.transform.localScale.x/2+0.01f,
                    transform.parent.transform.localScale.y, hit.transform.localScale.z/2+0.01f);
            }
        }

        public void GetFirstScale()
        {
            transform.parent.transform.localScale = _firstPlayerScale;
        }
    }
}