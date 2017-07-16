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

namespace SGG.RTS.World.Entity.Unit
{
   public sealed class StaveUnit : AUnit
   {
      #region Properties

      public NoteValue Value { get; private set; }

      public UnitFunction Function { get; private set; }

      public override string Name
      {
         get
         {
            string functionStr = Function.ToString();
            string valueStr = Value.ToString();
            functionStr = functionStr.Substring(0, 1) + functionStr.Substring(1).ToLower();
            valueStr = valueStr.Substring(0, 1) + valueStr.Substring(1).ToLower();
            return functionStr + " " + valueStr;
         }
      }

      #endregion

      #region Methods

      public void Initialize(Team a_Team, UnitFunction a_Function, NoteValue a_Value)
      {
         Function = a_Function;
         Value = a_Value;

         Func<Sprites.SpriteType, Sprite> getSprite = a_Type =>
            Sprites.Instance.GetStaveUnitSprite(a_Function, a_Value, a_Type);

         Initialize(a_Team, getSprite(Sprites.SpriteType.MAIN),
            getSprite(Sprites.SpriteType.GLOW));
      }

      #endregion
   }
}
