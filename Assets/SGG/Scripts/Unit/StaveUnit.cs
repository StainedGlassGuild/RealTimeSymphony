// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: StaveUnit.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System;

using SGG.RTS.Resource;

using UnityEngine;

namespace SGG.RTS.Unit
{
   public sealed class StaveUnit : AUnit
   {
      #region Properties

      public NoteValue Value { get; private set; }

      public UnitFunction Function { get; private set; }

      #endregion

      #region Methods

      public void Initialize(Team a_Team, UnitFunction a_Function, NoteValue a_Value)
      {
         Function = a_Function;
         Value = a_Value;

         Func<SpriteRepository.SpriteType, Sprite> getSprite = a_Type =>
            SpriteRepository.Instance.GetStaveUnitSprite(a_Function, a_Value, a_Type);

         Initialize(a_Team, getSprite(SpriteRepository.SpriteType.MAIN),
            getSprite(SpriteRepository.SpriteType.GLOW));
      }

      #endregion
   }
}
