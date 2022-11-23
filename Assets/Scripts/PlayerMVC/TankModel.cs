using UnityEngine;

namespace Tanks.tank
{
    public class TankModel
    {
        public TankModel(TankScriptableObjectScript tankScriptObject, int spawnIndex)
        {
            Health = tankScriptObject.tankHealth;
            Damage = tankScriptObject.damageOutput;
            MovSpeed = tankScriptObject.tankSpeed;
            SpawnIndex = spawnIndex;
        }
        public int Health
        {
            get;
        }
        public int Damage
        {
            get;
        }
        public float MovSpeed
        {
            get;
        }

        public int SpawnIndex
        {
            get;
        }
    }
}