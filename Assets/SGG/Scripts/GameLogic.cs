// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: GameLogic.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using UnityEngine;

namespace SGG.RTS
{
   public sealed class GameLogic : MonoBehaviour
   {
      #region Static fields

      public static GameLogic Instance;

      #endregion

      #region Public fields

      public Team PlayerTeam;
      public Selection Selection;
      public CameraController CameraController;
      public MouseCursorHandler CursorHandler;

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Instance = this;
      }

      #endregion
   }
}
