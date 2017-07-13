// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Vector2UInt.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System;

using UnityEngine;

namespace SGG.RTS
{
   [Serializable]
   public struct Vector2UInt
   {
      #region Runtime constants

      public static readonly Vector2UInt ZERO = new Vector2UInt(0, 0);

      #endregion

      #region Public fields

      public uint X;
      public uint Y;

      #endregion

      #region Constructors

      public Vector2UInt(uint a_X, uint a_Y)
      {
         X = a_X;
         Y = a_Y;
      }

      public Vector2 ToVector2()
      {
         return new Vector2(X, Y);
      }

      public static Vector2 operator +(Vector2UInt a_VecA, Vector2 a_VecB)
      {
         return a_VecA.ToVector2() + a_VecB;
      }

      public static Vector2 operator *(Vector2UInt a_Vec, float a_Scalar)
      {
         return a_Vec.ToVector2() * a_Scalar;
      }

      public static Vector2 operator /(Vector2UInt a_Vec, float a_Scalar)
      {
         return a_Vec.ToVector2() / a_Scalar;
      }

      #endregion
   }
}
