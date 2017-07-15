// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Utils.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System;

namespace SGG.RTS.Utils
{
   public static class Algorithms
   {
      #region Static methods

      public static void ForEachElement(Vector2UInt a_Beg,
                                        Vector2UInt a_End,
                                        Action<Vector2UInt> a_Func)
      {
         for (uint y = a_Beg.Y; y < a_End.Y; ++y)
         {
            for (uint x = a_Beg.X; x < a_End.X; ++x)
            {
               a_Func(new Vector2UInt {X = x, Y = y});
            }
         }
      }

      public static void ForEachElement(Vector2UInt a_Vec, Action<Vector2UInt> a_Func)
      {
         ForEachElement(Vector2UInt.ZERO, a_Vec, a_Func);
      }

      #endregion
   }
}
