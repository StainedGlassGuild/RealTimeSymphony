// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Building.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using SGG.RTS.Utils;

namespace SGG.RTS.World.Entity.Building
{
   public sealed class Building : ASpriteEntity
   {
      #region Properties

      public Vector2UInt Size { get; private set; }

      public override string Name
      {
         get { return "TempName"; }
      }

      public override EntityType Type
      {
         get { return EntityType.BUILDING; }
      }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         // Set building tile size
         var scale = transform.localScale;
         scale.x *= Size.X;
         scale.y *= Size.Y;
         transform.localScale = scale;
      }

      public void Initialize(Team a_Team, Vector2UInt a_Size)
      {
         Initialize(a_Team, MainRenderer.sprite, GlowRenderer.sprite);
         Size = a_Size;
      }

      #endregion
   }
}
