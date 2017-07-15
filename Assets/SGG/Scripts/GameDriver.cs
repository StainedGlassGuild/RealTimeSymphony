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

using SGG.RTS.UI;

using UnityEngine;

namespace SGG.RTS
{
   public sealed class GameDriver : MonoBehaviour
   {
      #region Static fields

      public static GameDriver Instance;

      #endregion

      #region Properties

      public World World { get; private set; }
      public Team PlayerTeam { get; private set; }
      public Selection Selection { get; private set; }

      #endregion

      #region Methods

      private void Initialize()
      {
         // Create game board
         var boardSizeInTiles = new Vector2UInt(50, 40);
         World = this.CreateComponentInNewChildGameObj<World>();
         World.Initialize(boardSizeInTiles);

         // Create the team of the player
         PlayerTeam = new Team();

         // Create game element selection
         Selection = this.CreateComponentInNewChildGameObj<Selection>();

         // Create mouse cursor handler
         this.CreateComponentInNewChildGameObj<MouseCursorHandler>();

         // Create camera controller
         var camCtrl = this.CreateComponentInNewChildGameObj<CameraController>();
         camCtrl.Initialize(boardSizeInTiles, new Vector2UInt(2, 3));

         Instance = this;

         // Initialize GUI
         MainGUI.Instance.Initialize();
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
