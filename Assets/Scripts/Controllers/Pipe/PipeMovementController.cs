using System;
using System.Threading.Tasks;
using Data.UnityObjects;
using Data.ValueObjects;
using Enums;
using UnityEngine;

namespace Controllers.Pipe
{
    public class PipeMovementController : MonoBehaviour
    {
        private GameStates _gameStates;

        private PipeData _pipeData;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _pipeData = GetPipeData();
        }

        private PipeData GetPipeData() => Resources.Load<CD_Pipe>("Data/CD_Pipe").PipeData;


        private void Update()
        {
            if (_gameStates == GameStates.Playing)
            {
                Move();
            }
        }

        public void Move()
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - (_pipeData.PipeMovementValue* Time.deltaTime),transform.position.z);
        }
        
        public void SetState(GameStates currentStates)
        {
            _gameStates = currentStates;
        }
    }
}