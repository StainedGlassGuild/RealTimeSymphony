// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: MouseCursorHandler.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using SGG.RTS.Resource;

using UnityEngine;

namespace SGG.RTS
{
   public sealed class MouseCursorHandler : MonoBehaviour
   {
      #region Methods

      [UsedImplicitly]
      private void Update()
      {
         // Spawn a unit at middle click
         if (Input.GetButtonUp(InputNames.MIDDLE_CLICK))
         {
            // Get the point in the world where the mouse is
            var clickPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (GameDriver.World.Contains(clickPosWorld))
            {
               GameDriver.World.SpawnUnit(clickPosWorld, GameDriver.PlayerTeam);
            }
         }
      }

      #endregion
   }
}
