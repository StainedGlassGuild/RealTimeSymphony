// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: AUnit.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using UnityEngine;

namespace SGG.RTS.World.Entity.Unit
{
   public abstract class AUnit : ASpriteEntity
   {
      #region Properties

      public override EntityType Type
      {
         get { return EntityType.UNIT; }
      }

      #endregion

      #region Methods

      public new void Initialize(Team a_Team, Sprite a_MainSprite, Sprite a_GlowSprite)
      {
         base.Initialize(a_Team, a_MainSprite, a_GlowSprite);
      }

      #endregion
   }
}
