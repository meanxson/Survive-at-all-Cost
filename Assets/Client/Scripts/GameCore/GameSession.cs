using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utils.GameSession
{
   public class GameSession : MonoBehaviour
   {
      public static GameSession Instance { get; private set; }
      
      private List<PlayerBase> _players;

      private void Awake()
      {
         if (ReferenceEquals(Instance, null)) 
            Instance = this;

         _players = new List<PlayerBase>();
      }

      private void Start()
      {
         if (gameObject != null) DontDestroyOnLoad(this);
         else
            DestroyImmediate(gameObject);
      }

      public void RegisterPlayer(PlayerBase player)
      {
         if (_players.Contains(player))
            return;
         
         _players.Add(player);
      }

      public PlayerBase GetRandomPlayer() => _players[Random.Range(0, _players.Count)];

      [Button]
      public void LogPlayers()
      {
         Debug.Log(string.Join(Environment.NewLine, _players.Select(p => p.Model)));
      }
   }
}
