using Fusion;
using Helpers.Collections;
using JetBrains.Annotations;
using Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameState;

namespace TrapDisabler.Patch
{
    internal class GameManagerPatch
    {
        public static void Patch()
        {
            On.GameManager.SpawnRandomItems += GameManager_SpawnRandomItems;
        }

        private static void GameManager_SpawnRandomItems(On.GameManager.orig_SpawnRandomItems orig, GameManager self)
        {
            if (GameManager.Instance.HuntersCount > 0)
            {
                for (int i = 0; i < self.ItemsSpawnRate * 3; i++)
                {
                    Transform andLockRandomItemSpawn = self.GetAndLockRandomItemSpawn();
                    if (andLockRandomItemSpawn != null)
                    {
                        self.Runner.Spawn(self.bulletPrefab, andLockRandomItemSpawn.position, andLockRandomItemSpawn.rotation);
                    }
                }
            }
            for (int j = 0; j < self.ItemsSpawnRate * 2; j++)
            {
                Item prefab = self.spawnableItemPrefabs.ToList().Grab(1).First();
                Log.Message(prefab);
                Log.Message(self.spawnableItemPrefabs.ToList().Grab(1).First());
                self.spawnableItemPrefabs.ToList().Grab(2).First();
                Transform andLockRandomItemSpawn2 = self.GetAndLockRandomItemSpawn();
                if (andLockRandomItemSpawn2 != null)
                {
                    self.Runner.Spawn(prefab, andLockRandomItemSpawn2.position, andLockRandomItemSpawn2.rotation);
                }
            }
            if (!self.BattleRoyale)
            {
                return;
            }
            int num = PlayerRegistry.Where((PlayerController p) => !p.IsDead).Count();
            for (int k = 0; k < num * 10; k++)
            {
                Transform andLockRandomItemSpawn3 = self.GetAndLockRandomItemSpawn();
                if (andLockRandomItemSpawn3 != null)
                {
                    self.Runner.Spawn(self.bulletPrefab, andLockRandomItemSpawn3.position, andLockRandomItemSpawn3.rotation);
                }
            }
        }
    }
}