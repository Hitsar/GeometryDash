using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStateManager _player;
        
        public override void InstallBindings()
        {
            PlayerStateManager playerStateManager = Container.InstantiatePrefabForComponent<PlayerStateManager>(_player);
            Container.Bind<PlayerStateManager>().FromInstance(playerStateManager).AsSingle();
        }
    }
}