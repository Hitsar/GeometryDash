using Cinemachine;
using Player.States;
using UnityEngine;

namespace Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        [SerializeField] private PlayerStates _initialState = PlayerStates.Cube;
        private CinemachineVirtualCamera _camera;
        private Cube _cubeState;
        private Ship _shipState;
        private Ball _ballState;
        private Ufo _ufoState;
        private Wave _waveState;
        private Robot _robotState;
        private Spider _spiderState;
        private SwingCopter _swingCopterState;
        public PlayerMovement CurrentState { get; private set; }

        private void Awake()
        {
            _camera = GetComponentInChildren<CinemachineVirtualCamera>();
            _cubeState = GetComponentInChildren<Cube>(true);
            _shipState = GetComponentInChildren<Ship>(true);
            _ballState = GetComponentInChildren<Ball>(true);
            _ufoState = GetComponentInChildren<Ufo>(true);
            _waveState = GetComponentInChildren<Wave>(true);
            _robotState = GetComponentInChildren<Robot>(true);
            _spiderState = GetComponentInChildren<Spider>(true);
            _swingCopterState = GetComponentInChildren<SwingCopter>(true);
            CurrentState = _cubeState;
            ChangeState(_initialState);
        }

        public void ChangeState(PlayerStates state)
        {
            Transform playerPosition = CurrentState.gameObject.transform;
            CurrentState.gameObject.SetActive(false);
            
            CurrentState = state switch
            {
                PlayerStates.Cube => _cubeState,
                PlayerStates.Ship => _shipState,
                PlayerStates.Ball => _ballState,
                PlayerStates.Ufo => _ufoState,
                PlayerStates.Wave => _waveState,
                PlayerStates.Robot => _robotState,
                PlayerStates.Spider => _spiderState,
                PlayerStates.SwingCopter => _swingCopterState
            };
            
            CurrentState.gameObject.SetActive(true);
            CurrentState.transform.position = playerPosition.position;
            _camera.Follow = CurrentState.transform;
        }
    }
}