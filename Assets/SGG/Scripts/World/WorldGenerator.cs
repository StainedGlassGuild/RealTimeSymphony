// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: WorldGenerator.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System;

using JetBrains.Annotations;

using SGG.RTS.Resource;
using SGG.RTS.Utils;
using SGG.RTS.World.Entity;
using SGG.RTS.World.Entity.Building;
using SGG.RTS.World.Entity.Unit;

using UnityEngine;

namespace SGG.RTS.World
{
   public sealed class WorldGenerator : MonoBehaviour
   {
      #region Private fields

      [SerializeField, UsedImplicitly]
      private TextAsset m_GenerationFile;

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         var genScript = JsonUtility.FromJson<WorldGenerationScript>(m_GenerationFile.text);

         foreach (var obj in genScript.Objects)
         {
            var tokens = obj.Type.ToUpper().Split('.');
            Debug.Assert(tokens.Length >= 2);
            var entityType = (EntityType) Enum.Parse(typeof(EntityType), tokens[0]);

            Debug.Assert(obj.Pos.Length == 2);
            var pos = new Vector2UInt(obj.Pos[0], obj.Pos[1]);

            switch (entityType)
            {
            case EntityType.BUILDING:
               var building = new GameObject("Building", typeof(Building)).GetComponent<Building>();
               building.Size = new Vector2UInt(2, 3);
               GameWorld.Instance.SpawnBuilding(building, pos);
               break;

            case EntityType.UNIT:
               Debug.Assert(tokens.Length >= 3);
               var family = (UnitFamily) Enum.Parse(typeof(UnitFamily), tokens[1]);

               switch (family)
               {
               case UnitFamily.STAVE:
                  Debug.Assert(tokens.Length == 4);
                  var function = (UnitFunction) Enum.Parse(typeof(UnitFunction), tokens[2]);
                  var value = (NoteValue) Enum.Parse(typeof(NoteValue), tokens[3]);
                  var unit = Instantiate(Prefabs.Instance.StaveUnit).GetComponent<StaveUnit>();
                  unit.Initialize(GameLogic.Instance.PlayerTeam, function, value);
                  GameWorld.Instance.SpawnUnit(unit, pos.ToVector2() + Vector2.one * 0.5f);
                  break;

               default:
                  throw new ArgumentOutOfRangeException();
               }

               break;

            default:
               throw new ArgumentOutOfRangeException();
            }
         }
      }

      #endregion
   }
}
