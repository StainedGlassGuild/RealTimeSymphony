// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: GameDriver.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using UnityEngine;

namespace SGG.RTS
{
   public sealed class GameDriver : MonoBehaviour
   {
      #region Static fields

      public static World World;

      #endregion

      #region Methods

      private void Initialize()
      {
         // Create game board
         var boardSizeInTiles = new Vector2UInt(50, 40);
         World = this.CreateComponentInNewChildGameObj<World>();
         World.Initialize(boardSizeInTiles);
      }

      [UsedImplicitly]
      private void Update()
      {
         if (World == null)
         {
            // Game initialization must happend in Update() to let initial game objets run their Start()
            Initialize();
         }
      }

      #endregion
   }
}
