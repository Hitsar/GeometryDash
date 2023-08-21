using System.Collections.Generic;
using Cinemachine;
using Player.States;
using UnityEngine;

namespace Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        [SerializeField] private PlayerStates _initialState = PlayerStates.Cube;
        private CinemachineVirtualCamera _camera;
        private readonly Dictionary<PlayerStates, PlayerMovement> _states = new Dictionary<PlayerStates, PlayerMovement>();
        public PlayerMovement CurrentState { get; private set; }

        private void Awake()
        {
            _states.Add(PlayerStates.Cube, GetComponentInChildren<Cube>(true));
            _states.Add(PlayerStates.Ship, GetComponentInChildren<Ship>(true));
            _states.Add(PlayerStates.Ball, GetComponentInChildren<Ball>(true));
            _states.Add(PlayerStates.Ufo, GetComponentInChildren<Ufo>(true));
            _states.Add(PlayerStates.Wave, GetComponentInChildren<Wave>(true));
            _states.Add(PlayerStates.Robot, GetComponentInChildren<Robot>(true));
            _states.Add(PlayerStates.Spider, GetComponentInChildren<Spider>(true));
            _states.Add(PlayerStates.SwingCopter, GetComponentInChildren<SwingCopter>(true));
            
            _camera = GetComponentInChildren<CinemachineVirtualCamera>();
            CurrentState = _states[PlayerStates.Cube];
            ChangeState(_initialState);
        }

        public void ChangeState(PlayerStates state)
        {
            Transform playerPosition = CurrentState.gameObject.transform;
            CurrentState.gameObject.SetActive(false);
            
            CurrentState = _states[state];
            
            CurrentState.gameObject.SetActive(true);
            CurrentState.transform.position = playerPosition.position;
            _camera.Follow = CurrentState.transform;
        }
    }
}