using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Enemy.Data
{
    public struct EnemyViewInfo
    {
        public Vector3 SpawnPosition;
        public Vector3 TargetPosition;
        public SpriteLibraryAsset SpriteLibrary;
        public float InterfaceShiftDistance;
    }
}