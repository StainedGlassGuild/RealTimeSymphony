// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: ASpriteEntityAppearanceUpdater.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using SGG.RTS.UI.Input;

using UnityEngine;

namespace SGG.RTS.World.Entity
{
   public sealed class ASpriteEntityAppearance : AEntityAppearance
   {
      #region Compile-time constants

      private const float BLINK_FREQUENCY = 2f;
      private const float BLINK_INTENSITY = 0.2f;
      private const float GLOW_FREQUENCY = Mathf.PI;
      private const float MIN_GLOW_INTENSITY = 0.7f;

      #endregion

      #region Properties

      private ASpriteEntity Entity
      {
         get { return transform.parent.GetComponent<ASpriteEntity>(); }
      }

      #endregion

      #region Methods

      protected override void StopSelection()
      {
         Entity.Color = Entity.Team.Color;
         Entity.GlowColor = Color.clear;
      }

      protected override void UpdateSelection()
      {
         float sctime = Inputs.Instance.Selection.SelectionCreationTime;

         // Update unit main sprite blinking color
         float blink = Mathf.Sin((Time.time - sctime) * BLINK_FREQUENCY);
         var teamColor = Entity.Team.Color;
         Entity.Color = blink > 0
            ? Color.Lerp(teamColor, Color.black, blink * BLINK_INTENSITY)
            : Color.Lerp(teamColor, Color.white, -blink * BLINK_INTENSITY);

         // Update glow color around units
         var glowColor = new Color(1, 1, 1) - teamColor;
         float glow = Mathf.Sin((Time.time - sctime) * GLOW_FREQUENCY) * 0.5f +
                      0.5f;
         glowColor.a = MIN_GLOW_INTENSITY + glow * (1 - MIN_GLOW_INTENSITY);
         Entity.GlowColor = glowColor;
      }

      #endregion
   }
}
