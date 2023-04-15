﻿using ExpandedContent.Config;
using ExpandedContent.Extensions;
using ExpandedContent.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.Formations.Facts;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic;
using Kingmaker.Assets.UnitLogic.Mechanics.Properties;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.RuleSystem.Rules;
using UnityEngine.Rendering;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Utility;

namespace ExpandedContent.Tweaks.Classes {
    internal class StargazerClass {
        public static void AddStargazerClass() {


            var BABMedium = Resources.GetBlueprint<BlueprintStatProgression>("4c936de4249b61e419a3fb775b9f2581");
            var SavesPrestigeHigh = Resources.GetBlueprint<BlueprintStatProgression>("1f309006cd2855e4e91a6c3707f3f700");
            var SavesPrestigeLow= Resources.GetBlueprint<BlueprintStatProgression>("dc5257e1100ad0d48b8f3b9798421c72");
            var PuluraFeature = Resources.GetBlueprint<BlueprintFeature>("ebb0b46f95dbac74681c78aae895dbd0");

            var StargazerProgression = Helpers.CreateBlueprint<BlueprintProgression>("StargazerProgression", bp => {
                bp.SetName("Stargazer");
                bp.SetDescription("The empyreal lord Pulura, the Shimmering Maiden, is said to dance among the lights " +
                    "of the aurora. Some of her worshipers seek her guidance in the starry skies, attuning themselves to the constellations of the Cosmic Caravan. Beyond the " +
                    "stargazers’ interests in the heavens, though, they also train for the inevitable conflict with demons. Pulura’s bastion of worship in the Inner Sea region " +
                    "has traditionally been in the land of Sarkoris, which was consumed from within by the Worldwound at the advent of the Age of Lost Omens. Many of Pulura’s " +
                    "worshipers perished during that disastrous invasion from the Abyss, but those who survived remained behind and, over the past several decades, have grown in power.");
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            var StargazerClass = Helpers.CreateBlueprint<BlueprintCharacterClass>("StargazerClass", bp => {
                bp.LocalizedName = Helpers.CreateString($"StargazerClass.Name", "Stargazer");
                bp.LocalizedDescription = Helpers.CreateString($"StargazerClass.Description", "The empyreal lord Pulura, the Shimmering Maiden, is said to dance among the lights " +
                    "of the aurora. Some of her worshipers seek her guidance in the starry skies, attuning themselves to the constellations of the Cosmic Caravan. Beyond the " +
                    "stargazers’ interests in the heavens, though, they also train for the inevitable conflict with demons. Pulura’s bastion of worship in the Inner Sea region " +
                    "has traditionally been in the land of Sarkoris, which was consumed from within by the Worldwound at the advent of the Age of Lost Omens. Many of Pulura’s " +
                    "worshipers perished during that disastrous invasion from the Abyss, but those who survived remained behind and, over the past several decades, have grown in power.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"StargazerClass.Description", "The empyreal lord Pulura, the Shimmering Maiden, is said to dance among the lights " +
                    "of the aurora. Some of her worshipers seek her guidance in the starry skies, attuning themselves to the constellations of the Cosmic Caravan. Beyond the " +
                    "stargazers’ interests in the heavens, though, they also train for the inevitable conflict with demons. Pulura’s bastion of worship in the Inner Sea region " +
                    "has traditionally been in the land of Sarkoris, which was consumed from within by the Worldwound at the advent of the Age of Lost Omens. Many of Pulura’s " +
                    "worshipers perished during that disastrous invasion from the Abyss, but those who survived remained behind and, over the past several decades, have grown in power.");
                bp.SkillPoints = 4;
                bp.HitDie = Kingmaker.RuleSystem.DiceType.D6;
                bp.HideIfRestricted = false;
                bp.PrestigeClass = true;
                bp.IsMythic = false;                
                bp.m_BaseAttackBonus = BABMedium.ToReference<BlueprintStatProgressionReference>();
                bp.m_FortitudeSave = SavesPrestigeLow.ToReference<BlueprintStatProgressionReference>();                
                bp.m_ReflexSave = SavesPrestigeHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_WillSave = SavesPrestigeHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_Progression = StargazerProgression.ToReference<BlueprintProgressionReference>();
                bp.m_Spellbook = null;
                bp.ClassSkills = new StatType[] {
                    StatType.SkillMobility,
                    StatType.SkillAthletics,
                    StatType.SkillPersuasion,
                    StatType.SkillKnowledgeWorld,
                    StatType.SkillKnowledgeArcana,
                    StatType.SkillPerception,
                    StatType.SkillLoreReligion,
                    StatType.SkillLoreNature,
                };
                bp.IsDivineCaster = false;
                bp.IsArcaneCaster = false;
                bp.StartingGold = 0;
                bp.m_StartingItems = new BlueprintItemReference[] {};
                bp.PrimaryColor = 0;
                bp.SecondaryColor = 0;
                bp.m_EquipmentEntities = new KingmakerEquipmentEntityReference[] {};
                bp.MaleEquipmentEntities = new Kingmaker.ResourceLinks.EquipmentEntityLink[] {};
                bp.FemaleEquipmentEntities = new Kingmaker.ResourceLinks.EquipmentEntityLink[] {};
                bp.m_Difficulty = 1;
                bp.RecommendedAttributes = new StatType[] {};
                bp.NotRecommendedAttributes = new StatType[] {};
                bp.m_DefaultBuild = null;
                bp.m_Archetypes = new BlueprintArchetypeReference[] { };
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.m_Feature = PuluraFeature.ToReference<BlueprintFeatureReference>();
                    c.Group = Prerequisite.GroupType.All;
                });
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = AlignmentMaskType.NeutralGood | AlignmentMaskType.ChaoticGood | AlignmentMaskType.ChaoticNeutral;
                });
                bp.AddComponent<PrerequisiteStatValue>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.CheckInProgression = false;
                    c.HideInUI = false;
                    c.Stat = StatType.SkillKnowledgeWorld;
                    c.Value = 5;
                });
                bp.AddComponent<PrerequisiteCasterTypeSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.CheckInProgression = false;
                    c.HideInUI = false;
                    c.IsArcane = false;
                    c.OnlySpontaneous = false;
                    c.RequiredSpellLevel = 3;
                });
                bp.AddComponent<PrerequisiteCasterTypeSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.CheckInProgression = false;
                    c.HideInUI = false;
                    c.IsArcane = true;
                    c.OnlySpontaneous = false;
                    c.RequiredSpellLevel = 3;
                });
                bp.AddComponent<PrerequisiteIsPet>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.Not = true;
                    c.HideInUI = true;
                });
            });
            StargazerProgression.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                new BlueprintProgression.ClassWithLevel {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                }
            };
            //Guiding Light
            var WitchFamiliarSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("29a333b7ccad3214ea3a51943fa0d8e9");
            var StargazerGuidingLightFeatureSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("StargazerGuidingLightFeatureSelection", bp => {
                bp.SetName("Guiding Light");
                bp.SetDescription("At 1st level the stargazer gains familiar. A familiar is a magic pet that enhances the stargazer's {g|Encyclopedia:Skills}skills{/g} and senses.");
                bp.m_Icon = WitchFamiliarSelection.m_Icon;
                bp.IsClassFeature = true;
                bp.Mode = SelectionMode.Default;
                bp.Group = FeatureGroup.Familiar;
                bp.m_AllFeatures = WitchFamiliarSelection.m_AllFeatures;
            });
            #region Hex Stuff
            //Mystery Magic - Hex
            var WitchHexSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("9846043cf51251a4897728ed6e24e76f");
            var WitchClass = Resources.GetBlueprint<BlueprintCharacterClass>("1b9873f1e7bfe5449bc84d03e9c8e3cc");
            var MagusClass = Resources.GetBlueprint<BlueprintCharacterClass>("45a4607686d96a1498891b3286121780");
            var RogueClass = Resources.GetBlueprint<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var WinterWitchClass = Resources.GetBlueprint<BlueprintCharacterClass>("eb24ca44debf6714aabe1af1fd905a07");
            var HexCrafterArchetype = Resources.GetBlueprint<BlueprintArchetype>("79ccf7a306a5d5547bebd97299f6fc89");
            var SylvanTricksterArchetype = Resources.GetBlueprint<BlueprintArchetype>("490394869f666c141bf8647b1a365220");
            var WitchHexDCProperty = Resources.GetBlueprint<BlueprintUnitProperty>("bdc230ce338f427ba74de65597b0d57a");
            var WitchHexCasterLevelProperty = Resources.GetBlueprint<BlueprintUnitProperty>("2d2243f4f3654512bdda92e80ef65b6d");
            var WitchHexSpellLevelProperty = Resources.GetBlueprint<BlueprintUnitProperty>("75efe8b64a3a4cd09dda28cef156cfb5");
            //Guiding Star
            var GuidingStarIcon = AssetLoader.LoadInternal("Skills", "Icon_GuidingStar.png");
            var WitchSpellbook = Resources.GetBlueprint<BlueprintSpellbook>("44f16931dabdff643bfe2a48138e769f");
            var WitchHexGuidingStarSkillBuff = Helpers.CreateBuff("WitchHexGuidingStarSkillBuff", bp => {
                bp.SetName("");
                bp.SetDescription("");
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageDice;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Stat = StatType.Charisma;
                    c.m_SpecificModifier = ModifierDescriptor.None;
                    c.m_Progression = ContextRankProgression.AsIs;
                    c.m_StartLevel = 0;
                    c.m_StepLevel = 0;
                    c.m_UseMin = true;
                    c.m_Min = 0;
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.SkillLoreNature;
                    c.Multiplier = 1;
                    c.Value = new ContextValue() {
                        ValueType = ContextValueType.Rank,
                        Value = 0,
                        ValueRank = AbilityRankType.DamageDice,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = UnitProperty.None
                    };
                    c.HasMinimal = false;
                    c.Minimal = 0;
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.SkillLoreReligion;
                    c.Multiplier = 1;
                    c.Value = new ContextValue() {
                        ValueType = ContextValueType.Rank,
                        Value = 0,
                        ValueRank = AbilityRankType.DamageDice,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = UnitProperty.None
                    };
                    c.HasMinimal = false;
                    c.Minimal = 0;
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.SkillPerception;
                    c.Multiplier = 1;
                    c.Value = new ContextValue() {
                        ValueType = ContextValueType.Rank,
                        Value = 0,
                        ValueRank = AbilityRankType.DamageDice,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = UnitProperty.None
                    };
                    c.HasMinimal = false;
                    c.Minimal = 0;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.UseKineticistMainStat = false;
                    c.Stat = StatType.Charisma;
                });
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
                bp.Stacking = StackingType.Replace;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            var WitchHexGuidingStarSkillFeature = Helpers.CreateBlueprint<BlueprintFeature>("WitchHexGuidingStarSkillFeature", bp => {
                bp.SetName("Guiding Star - Skill Bonus");
                bp.SetDescription("The stars themselves hold many answers, you may add your Charisma modifier to your Wisdom modifier on all Wisdom-based checks.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { WitchHexGuidingStarSkillBuff.ToReference<BlueprintUnitFactReference>() };
                });
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
            });
            var WitchHexGuidingStarResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("WitchHexGuidingStarResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    LevelIncrease = 0,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = false,
                    ResourceBonusStat = StatType.Unknown,
                };
            });
            var WitchHexGuidingStarMetamagicBuffEmpower = Helpers.CreateBuff("WitchHexGuidingStarMetamagicBuffEmpower", bp => {
                bp.SetName("Guiding Star - Empower Spell");
                bp.SetDescription("Once per day you can cast one spell as if it were modified by the Empower Spell feat without increasing the spell’s casting time or level.");
                bp.m_Icon = GuidingStarIcon;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Empower;
                    c.Abilities = new List<BlueprintAbilityReference> { }; //?
                    c.Descriptor = SpellDescriptor.None;
                    c.Once = false;
                    c.MaxSpellLevel = 10;
                    c.School = SpellSchool.None;
                    c.CheckSpellbook = false;
                    c.m_Spellbook = new BlueprintSpellbookReference();
                });
                bp.AddComponent<AddAbilityUseTrigger>(c => {
                    c.ActionsOnAllTargets = false;
                    c.AfterCast = true;
                    c.ActionsOnTarget = false;
                    c.FromSpellbook = false;
                    c.m_Spellbooks = new BlueprintSpellbookReference[] { };
                    c.ForOneSpell = false;
                    c.m_Ability = new BlueprintAbilityReference();
                    c.ForMultipleSpells = false;
                    c.Abilities = new List<BlueprintAbilityReference>();
                    c.MinSpellLevel = false;
                    c.MinSpellLevelLimit = 0;
                    c.ExactSpellLevel = false;
                    c.ExactSpellLevelLimit = 0;
                    c.CheckAbilityType = true;
                    c.Type = AbilityType.Spell;
                    c.CheckDescriptor = false;
                    c.SpellDescriptor = new SpellDescriptor();
                    c.CheckRange = false;
                    c.Range = AbilityRange.Touch;
                    c.Action = Helpers.CreateActionList(new ContextActionRemoveSelf());
                });
                bp.m_Flags = BlueprintBuff.Flags.RemoveOnRest;
                bp.Stacking = StackingType.Replace;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = false;
            });
            var WitchHexGuidingStarMetamagicBuffExtend = Helpers.CreateBuff("WitchHexGuidingStarMetamagicBuffExtend", bp => {
                bp.SetName("Guiding Star - Extend Spell");
                bp.SetDescription("Once per day you can cast one spell as if it were modified by the Extend Spell feat without increasing the spell’s casting time or level.");
                bp.m_Icon = GuidingStarIcon;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Extend;
                    c.Abilities = new List<BlueprintAbilityReference> { }; //?
                    c.Descriptor = SpellDescriptor.None;
                    c.Once = false;
                    c.MaxSpellLevel = 10;
                    c.School = SpellSchool.None;
                    c.CheckSpellbook = false;
                    c.m_Spellbook = new BlueprintSpellbookReference();
                });
                bp.AddComponent<AddAbilityUseTrigger>(c => {
                    c.ActionsOnAllTargets = false;
                    c.AfterCast = true;
                    c.ActionsOnTarget = false;
                    c.FromSpellbook = false;
                    c.m_Spellbooks = new BlueprintSpellbookReference[] { };
                    c.ForOneSpell = false;
                    c.m_Ability = new BlueprintAbilityReference();
                    c.ForMultipleSpells = false;
                    c.Abilities = new List<BlueprintAbilityReference>();
                    c.MinSpellLevel = false;
                    c.MinSpellLevelLimit = 0;
                    c.ExactSpellLevel = false;
                    c.ExactSpellLevelLimit = 0;
                    c.CheckAbilityType = true;
                    c.Type = AbilityType.Spell;
                    c.CheckDescriptor = false;
                    c.SpellDescriptor = new SpellDescriptor();
                    c.CheckRange = false;
                    c.Range = AbilityRange.Touch;
                    c.Action = Helpers.CreateActionList(new ContextActionRemoveSelf());
                });
                bp.m_Flags = BlueprintBuff.Flags.RemoveOnRest;
                bp.Stacking = StackingType.Replace;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = false;
            });
            var WitchHexGuidingStarMetamagicAbilityBase = Helpers.CreateBlueprint<BlueprintAbility>("WitchHexGuidingStarMetamagicAbilityBase", bp => {
                bp.SetName("Guiding Star");
                bp.SetDescription("Once per day you can cast one spell as if it were modified by the Empower Spell or Extend Spell feat without increasing the spell’s casting time or level.");
                bp.m_Icon = GuidingStarIcon;
                // Ability Variants added later
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = WitchHexGuidingStarResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Hex;
                });
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = 0;
                bp.LocalizedDuration = new Kingmaker.Localization.LocalizedString();
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
            });
            var WitchHexGuidingStarMetamagicAbilityEmpower = Helpers.CreateBlueprint<BlueprintAbility>("WitchHexGuidingStarMetamagicAbilityEmpower", bp => {
                bp.SetName("Guiding Star - Empower Spell");
                bp.SetDescription("Once per day you can cast one spell as if it were modified by the Empower Spell feat without increasing the spell’s casting time or level.");
                bp.m_Icon = GuidingStarIcon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionApplyBuff() {
                            m_Buff = WitchHexGuidingStarMetamagicBuffEmpower.ToReference<BlueprintBuffReference>(),
                            UseDurationSeconds = false,
                            DurationValue = new ContextDurationValue() {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 1,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage
                                },
                                m_IsExtendable = true
                            },
                            DurationSeconds = 0,
                            IsFromSpell = false,
                            ToCaster = false,
                            AsChild = true,
                        }
                        );
                });
                bp.AddComponent<AbilityCasterHasNoFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        WitchHexGuidingStarMetamagicBuffEmpower.ToReference<BlueprintUnitFactReference>(),
                        WitchHexGuidingStarMetamagicBuffExtend.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = WitchHexGuidingStarResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.m_Parent = WitchHexGuidingStarMetamagicAbilityBase.ToReference<BlueprintAbilityReference>();
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = 0;
                bp.LocalizedDuration = new Kingmaker.Localization.LocalizedString();
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
            });
            var WitchHexGuidingStarMetamagicAbilityExtend = Helpers.CreateBlueprint<BlueprintAbility>("WitchHexGuidingStarMetamagicAbilityExtend", bp => {
                bp.SetName("Guiding Star - Extend Spell");
                bp.SetDescription("Once per day you can cast one spell as if it were modified by the Extend Spell feat without increasing the spell’s casting time or level.");
                bp.m_Icon = GuidingStarIcon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionApplyBuff() {
                            m_Buff = WitchHexGuidingStarMetamagicBuffExtend.ToReference<BlueprintBuffReference>(),
                            UseDurationSeconds = false,
                            DurationValue = new ContextDurationValue() {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 1,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage
                                },
                                m_IsExtendable = true
                            },
                            DurationSeconds = 0,
                            IsFromSpell = false,
                            ToCaster = false,
                            AsChild = true,
                        }
                        );
                });
                bp.AddComponent<AbilityCasterHasNoFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        WitchHexGuidingStarMetamagicBuffEmpower.ToReference<BlueprintUnitFactReference>(),
                        WitchHexGuidingStarMetamagicBuffExtend.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = WitchHexGuidingStarResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.m_Parent = WitchHexGuidingStarMetamagicAbilityBase.ToReference<BlueprintAbilityReference>();
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = 0;
                bp.LocalizedDuration = new Kingmaker.Localization.LocalizedString();
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
            });
            WitchHexGuidingStarMetamagicAbilityBase.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    WitchHexGuidingStarMetamagicAbilityEmpower.ToReference<BlueprintAbilityReference>(),
                    WitchHexGuidingStarMetamagicAbilityExtend.ToReference<BlueprintAbilityReference>()
                };
            });
            var WitchHexGuidingStarFeature = Helpers.CreateBlueprint<BlueprintFeature>("WitchHexGuidingStarFeature", bp => {
                bp.SetName("Guiding Star");
                bp.SetDescription("The stars themselves hold many answers, you may add your Charisma modifier to your Wisdom modifier on all Wisdom-based checks. In addition, once per day you can " +
                    "cast one spell as if it were modified by the Empower Spell or Extend Spell feat without increasing the spell’s casting time or level.");
                bp.m_Icon = GuidingStarIcon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        WitchHexGuidingStarSkillFeature.ToReference<BlueprintUnitFactReference>(),
                        WitchHexGuidingStarMetamagicAbilityBase.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = WitchHexGuidingStarResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<PrerequisiteClassLevel>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.CheckInProgression = false;
                    c.HideInUI = false;
                    c.m_CharacterClass = StargazerClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.Groups = new FeatureGroup[] { FeatureGroup.WitchHex };
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
                bp.HideNotAvailibleInUI = true;
            });
            WitchTools.RegisterWitchHex(WitchHexGuidingStarFeature);
            //Lure of the Heavens
            var LureOfTheHeavensIcon = AssetLoader.LoadInternal("Skills", "Icon_LureOfTheHeavens.png");
            var WitchHexLureOfTheHeavensResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("WitchHexLureOfTheHeavensResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 0,
                    IncreasedByLevel = true,
                    LevelIncrease = 1,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 1,
                    StartingIncrease = 1,
                    LevelStep = 0,
                    PerStepIncrease = 1,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = false,
                    ResourceBonusStat = StatType.Unknown,
                    m_Class = new BlueprintCharacterClassReference[] {
                        WitchClass.ToReference<BlueprintCharacterClassReference>(),
                        MagusClass.ToReference<BlueprintCharacterClassReference>(),
                        RogueClass.ToReference<BlueprintCharacterClassReference>(),
                        WinterWitchClass.ToReference<BlueprintCharacterClassReference>(),
                        StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    },
                    m_Archetypes = new BlueprintArchetypeReference[] {
                        HexCrafterArchetype.ToReference<BlueprintArchetypeReference>(),
                        SylvanTricksterArchetype.ToReference<BlueprintArchetypeReference>()
                    }
                };
                bp.m_UseMax = true;
                bp.m_Max = 20;
            });
            var WitchHexLureOfTheHeavensHoverFeature = Helpers.CreateBlueprint<BlueprintFeature>("WitchHexLureOfTheHeavensHoverFeature", bp => {
                bp.SetName("Lure of the Heavens");
                bp.SetDescription("");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.DifficultTerrain;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Ground;
                });
                bp.HideInUI = true;
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            var WitchHexLureOfTheHeavensFlyBuff = Helpers.CreateBuff("WitchHexLureOfTheHeavensFlyBuff", bp => {
                bp.SetName("Lure of the Heavens");
                bp.SetDescription("Your connection to the skies above is so strong that your feet barely touch the ground. At 1st level, you no longer leave tracks gaining a +1 to stealth. At 5th level, " +
                    "you can hover up to 6 inches above the ground, avoiding difficult terrain. At 10th level you gain the ability to fly along the ground, gaining a +3 dodge bonus to AC against melee attacks, " +
                    "for a number of minutes per day equal to your shaman level. This duration does not need to be consecutive, but it must be spent in 1-minute increments.");
                bp.m_Icon = LureOfTheHeavensIcon;
                bp.AddComponent<ACBonusAgainstAttacks>(c => {
                    c.AgainstMeleeOnly = true;
                    c.AgainstRangedOnly = false;
                    c.OnlySneakAttack = false;
                    c.NotTouch = false;
                    c.IsTouch = false;
                    c.OnlyAttacksOfOpportunity = false;
                    c.Value = new ContextValue();
                    c.ArmorClassBonus = 3;
                    c.Descriptor = ModifierDescriptor.Dodge;
                    c.CheckArmorCategory = false;
                    c.NoShield = false;
                });
                bp.AddComponent<FormationACBonus>(c => {
                    c.UnitProperty = false;
                    c.Bonus = 3;
                });
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.Stacking = StackingType.Replace;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            var WitchHexLureOfTheHeavensFlyAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("WitchHexLureOfTheHeavensFlyAbility", bp => {
                bp.SetName("Lure of the Heavens");
                bp.SetDescription("Your connection to the skies above is so strong that your feet barely touch the ground. At 1st level, you no longer leave tracks gaining a +1 to stealth. At 5th level, " +
                    "you can hover up to 6 inches above the ground, avoiding difficult terrain. At 10th level you gain the ability to fly along the ground, gaining a +3 dodge bonus to AC against melee attacks, " +
                    "for a number of minutes per day equal to your shaman level. This duration does not need to be consecutive, but it must be spent in 1-minute increments.");
                bp.m_Icon = LureOfTheHeavensIcon;
                bp.AddComponent<ActivatableAbilityResourceLogic>(c => {
                    c.SpendType = ActivatableAbilityResourceLogic.ResourceSpendType.OncePerMinute;
                    c.m_RequiredResource = WitchHexLureOfTheHeavensResource.ToReference<BlueprintAbilityResourceReference>();
                });
                bp.m_Buff = WitchHexLureOfTheHeavensFlyBuff.ToReference<BlueprintBuffReference>();
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Hex;
                });
                bp.DeactivateIfOwnerDisabled = true;
                bp.ActivationType = AbilityActivationType.WithUnitCommand;
                bp.m_ActivateWithUnitCommand = UnitCommand.CommandType.Standard;
                bp.DeactivateIfCombatEnded = false;
            });
            var WitchHexLureOfTheHeavensFlyFeature = Helpers.CreateBlueprint<BlueprintFeature>("WitchHexLureOfTheHeavensFlyFeature", bp => {
                bp.SetName("Lure of the Heavens");
                bp.SetDescription("Your connection to the skies above is so strong that your feet barely touch the ground. At 1st level, you no longer leave tracks gaining a +1 to stealth. At 5th level, " +
                    "you can hover up to 6 inches above the ground, avoiding difficult terrain. At 10th level you gain the ability to fly along the ground, gaining a +3 dodge bonus to AC against melee attacks, " +
                    "for a number of minutes per day equal to your shaman level. This duration does not need to be consecutive, but it must be spent in 1-minute increments.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { WitchHexLureOfTheHeavensFlyAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.HideInUI = true;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            var WitchHexLureOfTheHeavensProgression = Helpers.CreateBlueprint<BlueprintProgression>("WitchHexLureOfTheHeavensProgression", bp => {
                bp.SetName("");
                bp.SetDescription("");
                bp.HideInUI = true;
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = WitchClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    },
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = MagusClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    },
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = RogueClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    },
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = WinterWitchClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    },
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    }
                };
                bp.m_Archetypes = new BlueprintProgression.ArchetypeWithLevel[] {
                    new BlueprintProgression.ArchetypeWithLevel {
                        m_Archetype = HexCrafterArchetype.ToReference<BlueprintArchetypeReference>(),
                        AdditionalLevel = 0
                    },
                    new BlueprintProgression.ArchetypeWithLevel {
                        m_Archetype = SylvanTricksterArchetype.ToReference<BlueprintArchetypeReference>(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.LevelEntry(5, WitchHexLureOfTheHeavensHoverFeature),
                    Helpers.LevelEntry(10, WitchHexLureOfTheHeavensFlyFeature)
                };
                bp.GiveFeaturesForPreviousLevels = true;
            });
            var WitchHexLureOfTheHeavensFeature = Helpers.CreateBlueprint<BlueprintFeature>("WitchHexLureOfTheHeavensFeature", bp => {
                bp.SetName("Lure of the Heavens");
                bp.SetDescription("Your connection to the skies above is so strong that your feet barely touch the ground. At 1st level, you no longer leave tracks gaining a +1 to stealth. At 5th level, " +
                    "you can hover up to 6 inches above the ground, avoiding difficult terrain. At 10th level you gain the ability to fly along the ground, gaining a +3 dodge bonus to AC against melee attacks, " +
                    "for a number of minutes per day equal to your shaman level. This duration does not need to be consecutive, but it must be spent in 1-minute increments.");
                bp.m_Icon = LureOfTheHeavensIcon;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.SkillStealth;
                    c.Value = 1;
                });
                bp.AddComponent<AddFeatureOnApply>(c => {
                    c.m_Feature = WitchHexLureOfTheHeavensProgression.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = WitchHexLureOfTheHeavensResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<PrerequisiteClassLevel>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.CheckInProgression = false;
                    c.HideInUI = false;
                    c.m_CharacterClass = StargazerClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.Groups = new FeatureGroup[] { FeatureGroup.WitchHex };
                bp.HideNotAvailibleInUI = true;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            WitchTools.RegisterWitchHex(WitchHexLureOfTheHeavensFeature);
            //Starburn
            var MageLightBuff = Resources.GetBlueprint<BlueprintBuff>("571baa4cf65bbcb4996fe429ca77d1a5");
            var WitchHexStarburnResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("WitchHexStarburnResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 0,
                    IncreasedByLevel = false,
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
                };
                bp.m_Min = 1;
            });
            var WitchHexStarburnBuff = Helpers.CreateBuff("WitchHexStarburnBuff", bp => {
                bp.SetName("Starburn");
                bp.SetDescription("As a standard action, the stargazer causes one creature within 30 feet to burn like a star. The creature takes 1d6 points of fire damage for every " +
                    "2 levels the stargazer possesses and emits bright light for 1 round. A successful Fortitude saving throw halves the damage and negates the emission of bright light. " +
                    "The Witch can use this hex a number of times per day equal to her Charisma modifier (minimum 1), but must wait 1d4 rounds between uses.");
                bp.m_Icon = MageLightBuff.Icon;
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.GreaterInvisibility;
                });
                bp.FxOnStart = new PrefabLink() { AssetId = "72938ec0a6e4a10459ea374d65aecfa5" };
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = false;
                bp.m_Flags = BlueprintBuff.Flags.RemoveOnRest;
                bp.Stacking = StackingType.Replace;
            });
            var WitchHexStarburnAbility = Helpers.CreateBlueprint<BlueprintAbility>("WitchHexStarburnAbility", bp => {
                bp.SetName("Starburn");
                bp.SetDescription("As a standard action, the stargazer causes one creature within 30 feet to burn like a star. The creature takes 1d6 points of fire damage for every " +
                    "2 levels the stargazer possesses and emits bright light for 1 round. A successful Fortitude saving throw halves the damage and negates the emission of bright light. " +
                    "The stargazer can use this hex a number of times per day equal to her Charisma modifier (minimum 1), but must wait 1d4 rounds between uses.");
                bp.m_Icon = MageLightBuff.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Fortitude;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionDealDamage() {
                            m_Type = ContextActionDealDamage.Type.Damage,
                            DamageType = new DamageTypeDescription() {
                                Type = DamageType.Energy,
                                Common = new DamageTypeDescription.CommomData() {
                                    Reality = 0,
                                    Alignment = 0,
                                    Precision = false
                                },
                                Physical = new DamageTypeDescription.PhysicalData() {
                                    Material = 0,
                                    Form = 0,
                                    Enhancement = 0,
                                    EnhancementTotal = 0
                                },
                                Energy = DamageEnergyType.Fire
                            },
                            Drain = false,
                            AbilityType = StatType.Unknown,
                            EnergyDrainType = EnergyDrainType.Temporary,
                            Duration = new ContextDurationValue() {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                                DiceCountValue = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 0,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = UnitProperty.None
                                },
                                BonusValue = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 0,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = UnitProperty.None
                                },
                                m_IsExtendable = true,
                            },
                            PreRolledSharedValue = AbilitySharedValue.Damage,
                            Value = new ContextDiceValue() {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue() {
                                    ValueType = ContextValueType.Rank,
                                    Value = 0,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = UnitProperty.None
                                },
                                BonusValue = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 0,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = UnitProperty.None
                                },
                            },
                            IsAoE = false,
                            HalfIfSaved = true,
                            UseMinHPAfterDamage = false,
                            MinHPAfterDamage = 0,
                            ResultSharedValue = AbilitySharedValue.Damage,
                            CriticalSharedValue = AbilitySharedValue.Damage
                        },
                        new ContextActionConditionalSaved() {
                            Succeed = Helpers.CreateActionList(),
                            Failed = Helpers.CreateActionList(
                                new ContextActionApplyBuff() {
                                    m_Buff = WitchHexStarburnBuff.ToReference<BlueprintBuffReference>(),
                                    UseDurationSeconds = false,
                                    DurationValue = new ContextDurationValue() {
                                        Rate = DurationRate.Rounds,
                                        DiceType = DiceType.Zero,
                                        DiceCountValue = 0,
                                        BonusValue = 1,
                                        m_IsExtendable = true
                                    },
                                    DurationSeconds = 0
                                }
                                )
                        }
                        );
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = WitchHexStarburnResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Stat = StatType.Unknown;
                    c.m_SpecificModifier = ModifierDescriptor.None;
                    c.m_Progression = ContextRankProgression.Div2;
                    c.m_StartLevel = 0;
                    c.m_StepLevel = 2;
                    c.m_UseMin = true;
                    c.m_Min = 1;
                    c.m_Class = new BlueprintCharacterClassReference[] {
                        WitchClass.ToReference<BlueprintCharacterClassReference>(),
                        MagusClass.ToReference<BlueprintCharacterClassReference>(),
                        RogueClass.ToReference<BlueprintCharacterClassReference>(),
                        WinterWitchClass.ToReference<BlueprintCharacterClassReference>(),
                        StargazerClass.ToReference<BlueprintCharacterClassReference>()
                    };
                    c.Archetype = SylvanTricksterArchetype.ToReference<BlueprintArchetypeReference>();
                    c.m_AdditionalArchetypes = new BlueprintArchetypeReference[] { HexCrafterArchetype.ToReference<BlueprintArchetypeReference>() };
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Hex;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.Add10ToDC = false;
                    c.DC = new ContextValue() {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = WitchHexDCProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.CasterLevel = new ContextValue() {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = WitchHexCasterLevelProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.Concentration = 0;
                    c.SpellLevel = new ContextValue() {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = WitchHexSpellLevelProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                });
                bp.m_AllowNonContextActions = false;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = false;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.HasFastAnimation = false;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = 0;
                bp.LocalizedDuration = new Kingmaker.Localization.LocalizedString();
                bp.LocalizedSavingThrow = Helpers.CreateString("WitchHexStarburnAbility.SavingThrow", "Fortitude partial");
            });
            var WitchHexStarburnFeature = Helpers.CreateBlueprint<BlueprintFeature>("WitchHexStarburnFeature", bp => {
                bp.SetName("Starburn");
                bp.SetDescription("As a standard action, the stargazer causes one creature within 30 feet to burn like a star. The creature takes 1d6 points of fire damage for every " +
                    "2 levels the stargazer possesses and emits bright light for 1 round. A successful Fortitude saving throw halves the damage and negates the emission of bright light. " +
                    "The stargazer can use this hex a number of times per day equal to her Charisma modifier (minimum 1), but must wait 1d4 rounds between uses.");
                bp.m_Icon = MageLightBuff.m_Icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        WitchHexStarburnAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = WitchHexStarburnResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<PrerequisiteClassLevel>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.CheckInProgression = false;
                    c.HideInUI = false;
                    c.m_CharacterClass = StargazerClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.Groups = new FeatureGroup[] { FeatureGroup.WitchHex };
                bp.HideNotAvailibleInUI = true;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            WitchTools.RegisterWitchHex(WitchHexStarburnFeature);
            var StargazerMysteryMagicHexFeatureSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("StargazerMysteryMagicHexFeatureSelection", bp => {
                bp.SetName("Mystery Magic - Hex");
                bp.SetDescription("At 1st, 7th and 9th levels, the stargazer gains a hex from the witch’s list of hexes. His stargazer levels count as (and stack with) witch levels when " +
                    "determining the effects of hexes. In addition, the stargazer adds all hexes available to a shaman with the heavens spirit to the witch list.");
                bp.m_Icon = WitchHexSelection.m_Icon;
                bp.IsClassFeature = true;
                bp.Mode |= SelectionMode.Default;
                bp.Group = FeatureGroup.WitchHex;
                bp.m_AllFeatures = WitchHexSelection.m_Features;
            });
            //Hooking Stargazer into the shared witchhex params
            var WitchHexDCPropertyLevel = Resources.GetBlueprint<BlueprintUnitProperty>("bdc230ce338f427ba74de65597b0d57a").GetComponent<SummClassLevelGetter>();
            WitchHexDCPropertyLevel.m_Class = WitchHexDCPropertyLevel.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WitchHexCasterLevelPropertyLevel = Resources.GetBlueprint<BlueprintUnitProperty>("2d2243f4f3654512bdda92e80ef65b6d").GetComponent<SummClassLevelGetter>();
            WitchHexCasterLevelPropertyLevel.m_Class = WitchHexCasterLevelPropertyLevel.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WitchHexSpellLevelPropertyLevel = Resources.GetBlueprint<BlueprintUnitProperty>("75efe8b64a3a4cd09dda28cef156cfb5").GetComponent<SummClassLevelGetter>();
            WitchHexSpellLevelPropertyLevel.m_Class = WitchHexSpellLevelPropertyLevel.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Hooking Stargazer into the ContextRankConfigs of the witchhexs
            WitchTools.AddClassToHexConfigs(StargazerClass);
            #endregion
            #region Domain Stuff
            //Hooking Stargazer into the Domains
            //Domains
            var AirDomainProgression = Resources.GetBlueprint<BlueprintProgression>("750bfcd133cd52f42acbd4f7bc9cc365");
            var AirDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("d7169e8978d9e9d418398eab946c49e5");
            var AnimalDomainProgression = Resources.GetBlueprint<BlueprintProgression>("23d2f87aa54c89f418e68e790dba11e0");
            var AnimalDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("f13eb6be93dd5234c8126e5384040009");
            var ArtificeDomainProgression = Resources.GetBlueprint<BlueprintProgression>("6454b37f50e10ae41bca83aaaa81ffc2");
            var ArtificeDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("988f3e10cc2fd8f48915acdc640a65b3");
            var ChaosDomainProgression = Resources.GetBlueprint<BlueprintProgression>("5a5d19c246961484a97e1e5dded98ab2");
            var ChaosDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("85e8db7e938d4f947a084a21d3535adf");
            var CharmDomainProgression = Resources.GetBlueprint<BlueprintProgression>("b5c056787d1bf544588ec3a150ed0b3b");
            var CharmDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("242eba70a5e2317479de39de3c1e64ad");
            var CommunityDomainProgression = Resources.GetBlueprint<BlueprintProgression>("b8bbe42616d61ac419971b7910d79fc8");
            var CommunityDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("3a397e27682edfd409cb73ff12de7c51");
            var DarknessDomainProgression = Resources.GetBlueprint<BlueprintProgression>("1e1b4128290b11a41ba55280ede90d7d");
            var DarknessDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("bfdc224a1362f2b4688b57f70adcc26f");
            var DeathDomainProgression = Resources.GetBlueprint<BlueprintProgression>("710d8c959e7036448b473ffa613cdeba");
            var DeathDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("023794a8386506c49aad142846700594");
            var DestructionDomainProgression = Resources.GetBlueprint<BlueprintProgression>("269ff0bf4596f5248864bc2653a2f0e0");
            var DestructionDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("8edced7121849414f8b1dc77a119b4a2");
            var EarthDomainProgression = Resources.GetBlueprint<BlueprintProgression>("08bbcbfe5eb84604481f384c517ac800");
            var EarthDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("4132a011b835a36479d6bc19a1b962e6");
            var EvilDomainProgression = Resources.GetBlueprint<BlueprintProgression>("a8936d29b6051a1418682da1878b644e");
            var EvilDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("82b654d68ea6ce143be5f7df646d6385");
            var FireDomainProgression = Resources.GetBlueprint<BlueprintProgression>("881b2137a1779294c8956fe5b497cc35");
            var FireDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("2bd6aa3c4979fd045bbbda8da586d3fb");
            var GloryDomainProgression = Resources.GetBlueprint<BlueprintProgression>("f0a61a043bcdf0f4c8efc59962afafb8");
            var GloryDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("434531fa0827f4c4a97482ffc71e7234");
            var GoodDomainProgression = Resources.GetBlueprint<BlueprintProgression>("243ab3e7a86d30243bdfe79c83e6adb4");
            var GoodDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("efc4219c7894afc438180737adc0b7ac");
            var HealingDomainProgression = Resources.GetBlueprint<BlueprintProgression>("b0a26ee984b6b6945b884467aa2f1baa");
            var HealingDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("599fb0d60358c354d8c5c4304a73e19a");
            var KnowledgeDomainProgression = Resources.GetBlueprint<BlueprintProgression>("28edbdbefca579b4ab4992e98af71981");
            var KnowledgeDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("72c0d2f6379114947a6072278baedb90");
            var LawDomainProgression = Resources.GetBlueprint<BlueprintProgression>("a723d11a5ae5df0488775e31fac9117d");
            var LawDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("0d9749df9d68ded438ecdf8527085963");
            var LiberationDomainProgression = Resources.GetBlueprint<BlueprintProgression>("df2f14ced8710664ba7db914880c4a02");
            var LiberationDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("34b0e4bb90e3a4f4183b095f0d44ca5d");
            var LuckDomainProgression = Resources.GetBlueprint<BlueprintProgression>("8bd8cfad69085654b9118534e4aa215e");
            var LuckDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("1ba7fc652568a524db218ccff2f9ed90");
            var MadnessDomainProgression = Resources.GetBlueprint<BlueprintProgression>("9ebe166b9b901c746b1858029f13a2c5");
            var MadnessDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("ae9c936c86d248848b2fb90b32b3b41d");
            var MagicDomainProgression = Resources.GetBlueprint<BlueprintProgression>("8f90e7129b0f3b742921c2c9c9bd64fc");
            var MagicDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("9c5053b1ad83a9742839b3ab824abbd2");
            var NobilityDomainProgression = Resources.GetBlueprint<BlueprintProgression>("8480f2d1ca764774895ee6fd610a568e");
            var NobilityDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("6bddbc86f5ee80146ac0fc51923ef4fd");
            var PlantDomainProgression = Resources.GetBlueprint<BlueprintProgression>("467d2a1d2107da64395b591393baad17");
            var PlantDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("22f3a592849c06e4c8869e2132e11597");
            var ProtectionDomainProgression = Resources.GetBlueprint<BlueprintProgression>("b750650400d9d554b880dbf4c8347b24");
            var ProtectionDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("6be37e1316160d949aa2e5a0be99404a");
            var ReposeDomainProgression = Resources.GetBlueprint<BlueprintProgression>("a2ab5a696d0dd134d94b2631151a15ee");
            var ReposeDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("a12fa2f458841ca4bb4ef666e1fbceef");
            var RuneDomainProgression = Resources.GetBlueprint<BlueprintProgression>("6d4dac497c182754d8b1f49071cca3fd");
            var RuneDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("8d176f8fe5616a64ca37835be7c2ccfe");
            var StrenthDomainProgression = Resources.GetBlueprint<BlueprintProgression>("07854f99c8d029b4cbfdf6ae6c7bc452");
            var StrenthDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("2ed973db1af2c8e428ce404fb1e9a20d");
            var SunDomainProgression = Resources.GetBlueprint<BlueprintProgression>("c85c8791ee13d4c4ea10d93c97a19afc");
            var SunDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("0877f33e01ba9884daed94cc7633e09c");
            var TravelDomainProgression = Resources.GetBlueprint<BlueprintProgression>("d169dd2de3630b749a2363c028bb6e7b");
            var TravelDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("9dc676c4ab1d0c643bb2293696375fcf");
            var TrickeryDomainProgression = Resources.GetBlueprint<BlueprintProgression>("cc2d330bb0200e840aeb79140e770198");
            var TrickeryDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("720cb8ed96386d24d8dfe38cad153cbd");
            var WarDomainProgression = Resources.GetBlueprint<BlueprintProgression>("8d454cbb7f25070419a1c8eaf89b5be5");
            var WarDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("2d2b61d86f93ce84f8375f9e59489072");
            var WaterDomainProgression = Resources.GetBlueprint<BlueprintProgression>("e63d9133cebf2cf4788e61432a939084");
            var WaterDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("f05fb4f417465f94fb1b4d6c48ea42cf");
            var WeatherDomainProgression = Resources.GetBlueprint<BlueprintProgression>("c18a821ee662db0439fb873165da25be");
            var WeatherDomainProgressionSecondary = Resources.GetBlueprint<BlueprintProgression>("d124d29c7c96fc345943dd17e24990e8");
            //Allowing Progression on normal Domains
            AirDomainProgression.m_Classes = AirDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });            
            AnimalDomainProgression.m_Classes = AnimalDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            ArtificeDomainProgression.m_Classes = ArtificeDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            CharmDomainProgression.m_Classes = CharmDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            CommunityDomainProgression.m_Classes = CommunityDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            DarknessDomainProgression.m_Classes = DarknessDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            DeathDomainProgression.m_Classes = DeathDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            DestructionDomainProgression.m_Classes = DestructionDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            EarthDomainProgression.m_Classes = EarthDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            FireDomainProgression.m_Classes = FireDomainProgression.m_Classes.AppendToArray(
                 new BlueprintProgression.ClassWithLevel() {
                     m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                     AdditionalLevel = 0
                 });
            GloryDomainProgression.m_Classes = GloryDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            GoodDomainProgression.m_Classes = GoodDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            HealingDomainProgression.m_Classes = HealingDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            KnowledgeDomainProgression.m_Classes = KnowledgeDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            LawDomainProgression.m_Classes = LawDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            LiberationDomainProgression.m_Classes = LiberationDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            LuckDomainProgression.m_Classes = LuckDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            MadnessDomainProgression.m_Classes = MadnessDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            MagicDomainProgression.m_Classes = MagicDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            NobilityDomainProgression.m_Classes = NobilityDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            PlantDomainProgression.m_Classes = PlantDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            ProtectionDomainProgression.m_Classes = ProtectionDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            ReposeDomainProgression.m_Classes = ReposeDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            RuneDomainProgression.m_Classes = RuneDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            StrenthDomainProgression.m_Classes = StrenthDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            SunDomainProgression.m_Classes = SunDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            TravelDomainProgression.m_Classes = TravelDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            TrickeryDomainProgression.m_Classes = TrickeryDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            WarDomainProgression.m_Classes = WarDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            WaterDomainProgression.m_Classes = WaterDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            WeatherDomainProgression.m_Classes = WeatherDomainProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });

            //Allowing Prgression on Secondary Domains
            AirDomainProgressionSecondary.m_Classes = AirDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            AnimalDomainProgressionSecondary.m_Classes = AnimalDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            ArtificeDomainProgressionSecondary.m_Classes = ArtificeDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            CharmDomainProgressionSecondary.m_Classes = CharmDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            CommunityDomainProgressionSecondary.m_Classes = CommunityDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            DarknessDomainProgressionSecondary.m_Classes = DarknessDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            DeathDomainProgressionSecondary.m_Classes = DeathDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            DestructionDomainProgressionSecondary.m_Classes = DestructionDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            EarthDomainProgressionSecondary.m_Classes = EarthDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            FireDomainProgressionSecondary.m_Classes = FireDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            GloryDomainProgressionSecondary.m_Classes = GloryDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            GoodDomainProgressionSecondary.m_Classes = GoodDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            HealingDomainProgressionSecondary.m_Classes = HealingDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            KnowledgeDomainProgressionSecondary.m_Classes = KnowledgeDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            LawDomainProgressionSecondary.m_Classes = LawDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            LiberationDomainProgressionSecondary.m_Classes = LiberationDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            LuckDomainProgressionSecondary.m_Classes = LuckDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            MadnessDomainProgressionSecondary.m_Classes = MadnessDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            MagicDomainProgressionSecondary.m_Classes = MagicDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            NobilityDomainProgressionSecondary.m_Classes = NobilityDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            PlantDomainProgressionSecondary.m_Classes = PlantDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            ProtectionDomainProgressionSecondary.m_Classes = ProtectionDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            ReposeDomainProgressionSecondary.m_Classes = ReposeDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            RuneDomainProgressionSecondary.m_Classes = RuneDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            StrenthDomainProgressionSecondary.m_Classes = StrenthDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            SunDomainProgressionSecondary.m_Classes = SunDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            TravelDomainProgressionSecondary.m_Classes = TravelDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            TrickeryDomainProgressionSecondary.m_Classes = TrickeryDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            WarDomainProgressionSecondary.m_Classes = WarDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            WaterDomainProgressionSecondary.m_Classes = WaterDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            WeatherDomainProgressionSecondary.m_Classes = WeatherDomainProgressionSecondary.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                });
            //Air Domain Hooks
            var AirDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("39b0c7db785560041b436b558c9df2bb").GetComponent<AddFeatureOnClassLevel>();
            AirDomainBaseFeatureConfig.m_AdditionalClasses = AirDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var AirDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("b3494639791901e4db3eda6117ad878f").GetComponent<ContextRankConfig>();
            AirDomainBaseAbilityConfig.m_Class = AirDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Animal Domain Hooks
            var AnimalDomainBaseFeatureComp0 = Resources.GetBlueprint<BlueprintFeature>("d577aba79b5727a4ab74627c4c6ba23c").GetComponent<AddFeatureOnClassLevel>();
            AnimalDomainBaseFeatureComp0.m_AdditionalClasses = AnimalDomainBaseFeatureComp0.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var AnimalDomainBaseFeatureComp2 = Resources.GetBlueprint<BlueprintFeature>("d577aba79b5727a4ab74627c4c6ba23c").GetComponent<ContextRankConfig>();
            AnimalDomainBaseFeatureComp2.m_Class = AnimalDomainBaseFeatureComp2.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var DomainAnimalCompanionProgression = Resources.GetBlueprint<BlueprintProgression>("125af359f8bc9a145968b5d8fd8159b8");
            DomainAnimalCompanionProgression.m_Classes = DomainAnimalCompanionProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = -3
                });
            //Artifice Domain Hooks
            var ArtificeDomainBaseAuraConfig = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("f042f2d62e6785d4e8612a027de1f298").GetComponent<ContextRankConfig>();
            ArtificeDomainBaseAuraConfig.m_Class = ArtificeDomainBaseAuraConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ArtificeDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("01025d876ac28d349ac42d69ba462059").GetComponent<AddFeatureOnClassLevel>();
            ArtificeDomainBaseFeatureConfig.m_AdditionalClasses = ArtificeDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ArtificeDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("d2c3c7c7efbc71c438dc4e0c3f216407");
            ArtificeDomainBaseResource.m_MaxAmount.m_Class = ArtificeDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ArtificeDomainGreaterEffectConfig = Resources.GetBlueprint<BlueprintBuff>("9d4a139cb5605fa409b1be3ad6e87ba9").GetComponent<ContextRankConfig>();
            ArtificeDomainGreaterEffectConfig.m_Class = ArtificeDomainGreaterEffectConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Charm Domain Hooks
            var CharmDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("84cd24a110af59140b066bc2c69619bd").GetComponent<ContextRankConfig>();
            CharmDomainBaseAbilityConfig.m_Class = CharmDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var CharmDomainBaseFeatureComnfig = Resources.GetBlueprint<BlueprintFeature>("4847d450fbef9b444abcc3a82337b426").GetComponent<AddFeatureOnClassLevel>();
            CharmDomainBaseFeatureComnfig.m_AdditionalClasses = CharmDomainBaseFeatureComnfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var CharmDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("d49f0e3460fd52d4e9660a8ce52142a0");
            CharmDomainGreaterResource.m_MaxAmount.m_Class = CharmDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Community Domain Hooks
            var CommunityDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("b1b8efd70ba5dd84aa6985d46dc299d5").GetComponent<ContextRankConfig>();
            CommunityDomainBaseAbilityConfig.m_Class = CommunityDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var CommunityDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("102d61a114786894bb2b30568943ef1f").GetComponent<AddFeatureOnClassLevel>();
            CommunityDomainBaseFeatureConfig.m_AdditionalClasses = CommunityDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var CommunityDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("76291e62d2496ad41824044aba3077ea").GetComponent<ContextRankConfig>();
            CommunityDomainGreaterAbilityConfig.m_Class = CommunityDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Darkness Domain Hooks
            var DarknessDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("39ed9d4b1e033e042aac4f9eb9c7315f").GetComponent<ContextRankConfig>();
            DarknessDomainBaseAbilityConfig.m_Class = DarknessDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var DarknessDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("9dc5863168155854fa8daf4a780f6663").GetComponent<AddFeatureOnClassLevel>();
            DarknessDomainBaseFeatureConfig.m_AdditionalClasses = DarknessDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //If multiple Components with same name use ".ForEach"
            var DarknessDomainGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("31acd268039966940872c916782ae018");
            DarknessDomainGreaterAbility.GetComponents<ContextRankConfig>().ForEach(c => {
                c.m_Class = c.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var DarknessDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("55efb511a2290b94bb218e2d56a51f1f");
            DarknessDomainGreaterResource.m_MaxAmount.m_ClassDiv = DarknessDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Death Domain Hooks
            var DeathDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("979f63920af22344d81da5099c9ec32e").GetComponent<ContextRankConfig>();
            DeathDomainBaseAbilityConfig.m_Class = DeathDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var DeathDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("9809efa15e5f9ad478594479af575a5d").GetComponent<AddFeatureOnClassLevel>();
            DeathDomainBaseFeatureConfig.m_AdditionalClasses = DeathDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Destruction Domain Hooks
            var DestructionDomainBaseBuffConfig = Resources.GetBlueprint<BlueprintBuff>("0dfe08afb3cf3594987bab12d014e74b").GetComponent<ContextRankConfig>();
            DestructionDomainBaseBuffConfig.m_Class = DestructionDomainBaseBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var DestructionDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("2d3b9491bc05a114ab10e5b1b30dc86a").GetComponent<AddFeatureOnClassLevel>();
            DestructionDomainBaseFeatureConfig.m_AdditionalClasses = DestructionDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var DestructionDomainGreaterEffectConfig = Resources.GetBlueprint<BlueprintBuff>("f9de414e53a9c23419fa3cfc0daabde7").GetComponent<ContextRankConfig>();
            DestructionDomainGreaterEffectConfig.m_Class = DestructionDomainGreaterEffectConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var DestructionDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("2f9b00619b54bed4ba0c3b02298f9c34").GetComponent<ContextRankConfig>();
            DestructionDomainGreaterAbilityConfig.m_Class = DestructionDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var DestructionDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("98f07eabe9cb4f34cb1127de625f4bee");
            DestructionDomainGreaterResource.m_MaxAmount.m_Class = DestructionDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Earth Domain Hooks
            var EarthDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("828d82a0e8c5a944bbdb6b12f802ff02").GetComponent<AddFeatureOnClassLevel>();
            EarthDomainBaseFeatureConfig.m_AdditionalClasses = EarthDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var EarthDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("3ff40918d33219942929f0dbfe5d1dee").GetComponent<ContextRankConfig>();
            EarthDomainBaseAbilityConfig.m_Class = EarthDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Fire Domain Hooks
            var FireDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("42cc125d570c5334c89c6499b55fc0a3").GetComponent<AddFeatureOnClassLevel>();
            FireDomainBaseFeatureConfig.m_AdditionalClasses = FireDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var FireDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("4ecdf240d81533f47a5279f5075296b9").GetComponent<ContextRankConfig>();
            FireDomainBaseAbilityConfig.m_Class = FireDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Glory Domain Hooks
            var GloryDomainBaseBuffConfig = Resources.GetBlueprint<BlueprintBuff>("55edcfff497a1e04a963f72c485da5cb").GetComponent<ContextRankConfig>();
            GloryDomainBaseBuffConfig.m_Class = GloryDomainBaseBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var GloryDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("d018241b5a761414897ad6dc4df2db9f").GetComponent<ContextRankConfig>();
            GloryDomainBaseAbilityConfig.m_Class = GloryDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var GloryDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("17e891b3964492f43aae44f994b5d454").GetComponent<AddFeatureOnClassLevel>();
            GloryDomainBaseFeatureConfig.m_AdditionalClasses = GloryDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var GloryDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("c89e92387e940e541b02c1969cd1fe2a").GetComponent<ContextRankConfig>();
            GloryDomainGreaterAbilityConfig.m_Class = GloryDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Good Domain Hooks
            var GoodDomainBaseBuffConfig = Resources.GetBlueprint<BlueprintBuff>("f185e4585bda72b479956772944ee665").GetComponent<ContextRankConfig>();
            GoodDomainBaseBuffConfig.m_Class = GoodDomainBaseBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var GoodDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("f27684b3b72c2f546abf3ef2fb611a05").GetComponent<AddFeatureOnClassLevel>();
            GoodDomainBaseFeatureConfig.m_AdditionalClasses = GoodDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var GoodDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("017afe6934e10c3489176e759a5f01b0").GetComponent<ContextRankConfig>();
            GoodDomainBaseAbilityConfig.m_Class = GoodDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var GoodDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("7fc3e743ba28fd64f977fb55b7536053").GetComponent<ContextRankConfig>();
            GoodDomainGreaterAbilityConfig.m_Class = GoodDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var GoodDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("8d45a527ce4d3ec47853faaa972c2362");
            GoodDomainGreaterResource.m_MaxAmount.m_ClassDiv = GoodDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Healing Domain Hooks
            var HealingDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("18f734e40dd7966438ab32086c3574e1").GetComponent<ContextRankConfig>();
            HealingDomainBaseAbilityConfig.m_Class = HealingDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var HealingdDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("303cf1c933f343c4d91212f8f4953e3c").GetComponent<AddFeatureOnClassLevel>();
            HealingdDomainBaseFeatureConfig.m_AdditionalClasses = HealingdDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Knowledge Domain Hooks
            var KnowledgeDomainBaseBuffConfig = Resources.GetBlueprint<BlueprintBuff>("35fa55fe2c60e4442b670a88a70c06c3").GetComponent<ContextRankConfig>();
            KnowledgeDomainBaseBuffConfig.m_Class = KnowledgeDomainBaseBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var KnowledgeDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("02a79a205bce6f5419dcdf26b64f13c6").GetComponent<ContextRankConfig>();
            KnowledgeDomainBaseAbilityConfig.m_Class = KnowledgeDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var KnowledgedDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("5335f015063776d429a0b5eab97eb060");
            KnowledgedDomainBaseFeatureConfig.GetComponents<AddFeatureOnClassLevel>().ForEach(c => {
                c.m_AdditionalClasses = c.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var KnowledgeDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("f88f616a4b6bd5f419025115c52cb329");
            KnowledgeDomainBaseResource.m_MaxAmount.m_Class = KnowledgeDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var KnowledgeDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("ec582b195ccb2ef4ea8dcd96a5a6e009").GetComponent<ContextRankConfig>();
            KnowledgeDomainGreaterAbilityConfig.m_Class = KnowledgeDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var KnowledgesDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("34f0a288ff5106645a88440b800686ca");
            KnowledgesDomainGreaterResource.m_MaxAmount.m_ClassDiv = KnowledgesDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Law Domain Hooks
            var LawDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("9bd2d216e56a0db44be0df48ffc515af").GetComponent<AddFeatureOnClassLevel>();
            LawDomainBaseFeatureConfig.m_AdditionalClasses = LawDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var LawDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("0b1615ec2dabc6f4294a254b709188a4").GetComponent<ContextRankConfig>();
            LawDomainGreaterAbilityConfig.m_Class = LawDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var LawDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("de7945c4cc6a0a24790941d7e2b85838");
            LawDomainGreaterResource.m_MaxAmount.m_ClassDiv = LawDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Liberation Domain Hooks
            var LiberationDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("7cc934aa505172a40b4a10c14c7681c4").GetComponent<AddFeatureOnClassLevel>();
            LiberationDomainBaseFeatureConfig.m_AdditionalClasses = LiberationDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var LiberationDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("8ddc7f532cf2b3b4c877497856cc5b97");
            LiberationDomainBaseResource.m_MaxAmount.m_Class = LiberationDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var LiberationDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("d19e900012a69954c93f3b7533bc3911");
            LiberationDomainGreaterResource.m_MaxAmount.m_Class = LiberationDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Luck Domain Hooks
            var LuckDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("2b3818bf4656c1a41b93467755662c78").GetComponent<AddFeatureOnClassLevel>();
            LuckDomainBaseFeatureConfig.m_AdditionalClasses = LuckDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var LuckDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("0e0668a703fbfcf499d9aa9d918b71ea").GetComponent<ContextRankConfig>();
            LuckDomainGreaterAbilityConfig.m_Class = LuckDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var LuckDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("b209ca75fbea5144c9d73ecb29055a08");
            LuckDomainGreaterResource.m_MaxAmount.m_ClassDiv = LuckDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Madness Domain Hooks
            var MadnessDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("84bf46e8086dbdc438bac875ab0e5c2f").GetComponent<AddFeatureOnClassLevel>();
            MadnessDomainBaseFeatureConfig.m_AdditionalClasses = MadnessDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("a3d470a27ec5e4540aeaf9723e9b8ae7").GetComponent<ContextRankConfig>();
            MadnessDomainGreaterAbilityConfig.m_Class = MadnessDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("3289ee86c57f6134d81770865c315e8b");
            MadnessDomainGreaterResource.m_MaxAmount.m_ClassDiv = MadnessDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainBaseAttackRollsBuffConfig = Resources.GetBlueprint<BlueprintBuff>("6c69ec7a32190d44d99e746588de4a9c").GetComponent<ContextRankConfig>();
            MadnessDomainBaseAttackRollsBuffConfig.m_Class = MadnessDomainBaseAttackRollsBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainBaseSkillChecksBuffConfig = Resources.GetBlueprint<BlueprintBuff>("3e42877e5e481894880df63ad924e320").GetComponent<ContextRankConfig>();
            MadnessDomainBaseSkillChecksBuffConfig.m_Class = MadnessDomainBaseSkillChecksBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainBaseSavingThrowsBuffConfig = Resources.GetBlueprint<BlueprintBuff>("53c721d7519ac3047b818516bb28b20f").GetComponent<ContextRankConfig>();
            MadnessDomainBaseSavingThrowsBuffConfig.m_Class = MadnessDomainBaseSavingThrowsBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainBaseAbilitySkillChecksConfig = Resources.GetBlueprint<BlueprintAbility>("d92b2eac4dbf31f439e5bc9d2d467ff1").GetComponent<ContextRankConfig>();
            MadnessDomainBaseAbilitySkillChecksConfig.m_Class = MadnessDomainBaseAbilitySkillChecksConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainBaseAbilityAttackRollsConfig = Resources.GetBlueprint<BlueprintAbility>("c3e4ff89950f1d748be6f5958b1aa19c").GetComponent<ContextRankConfig>();
            MadnessDomainBaseAbilityAttackRollsConfig.m_Class = MadnessDomainBaseAbilityAttackRollsConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MadnessDomainBaseAbilitySavingThrowsConfig = Resources.GetBlueprint<BlueprintAbility>("c09446b861bac7b4b83877db863150d9").GetComponent<ContextRankConfig>();
            MadnessDomainBaseAbilitySavingThrowsConfig.m_Class = MadnessDomainBaseAbilitySavingThrowsConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Magic Domain Hooks
            var MagicDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("90f939eb611ac3743b5de3dd00135e22").GetComponent<AddFeatureOnClassLevel>();
            MagicDomainBaseFeatureConfig.m_AdditionalClasses = MagicDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MagicDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("da9e93791894b9d49a1f2bebd80e8085");
            MagicDomainBaseResource.m_MaxAmount.m_ClassDiv = MagicDomainBaseResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var MagicDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("3aecc0c5d17390443b30774309145854");
            MagicDomainGreaterResource.m_MaxAmount.m_ClassDiv = MagicDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Nobility Domain Hooks
            var NobilityDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("7a305ef528cb7884385867a2db410102").GetComponent<ContextRankConfig>();
            NobilityDomainBaseAbilityConfig.m_Class = NobilityDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var NobilityDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("a1a7f3dd904ed8e45b074232f48190d1").GetComponent<AddFeatureOnClassLevel>();
            NobilityDomainBaseFeatureConfig.m_AdditionalClasses = NobilityDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var NobilityDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("3fc6e1f3acbcb0e4c83badf7709ce53d");
            NobilityDomainBaseResource.m_MaxAmount.m_Class = NobilityDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var NobilityDomainGreaterAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("2972215a5367ae44b8ddfe435a127a6e").GetComponent<ContextRankConfig>();
            NobilityDomainGreaterAbilityConfig.m_Class = NobilityDomainGreaterAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var NobilityDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("cb3efe82596c908418c0dba4ef6f4210");
            NobilityDomainGreaterResource.m_MaxAmount.m_ClassDiv = NobilityDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Plant Domain Hooks
            var PlantDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("e433267d36089d049b34900fde38032b").GetComponent<AddFeatureOnClassLevel>();
            PlantDomainBaseFeatureConfig.m_AdditionalClasses = PlantDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var PlantDomainGreaterBuffConfig = Resources.GetBlueprint<BlueprintBuff>("58d86cc848805024abbbefd6abe2d433").GetComponent<ContextRankConfig>();
            PlantDomainGreaterBuffConfig.m_Class = PlantDomainGreaterBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var PlantDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("8942e816a533a4a40b04745c516d085a");
            PlantDomainBaseResource.m_MaxAmount.m_Class = PlantDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var PlantDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("881d696940ec99041aefafd5b2fda189");
            PlantDomainGreaterResource.m_MaxAmount.m_Class = PlantDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Protection Domain Hooks
            var ProtectionDomainBaseBuffConfig = Resources.GetBlueprint<BlueprintBuff>("2ddb4cfc3cfd04c46a66c6cd26df1c06").GetComponent<ContextRankConfig>();
            ProtectionDomainBaseBuffConfig.m_Class = ProtectionDomainBaseBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ProtectionDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("c5815bd0bf87bdb4fa9c440c8088149b").GetComponent<ContextRankConfig>();
            ProtectionDomainBaseAbilityConfig.m_Class = ProtectionDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ProtectionDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("a05a8959c594daa40a1c5add79566566").GetComponent<AddFeatureOnClassLevel>();
            ProtectionDomainBaseFeatureConfig.m_AdditionalClasses = ProtectionDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ProtectionDomainBaseSelfBuffConfig = Resources.GetBlueprint<BlueprintBuff>("74a4fb45f23705d4db2784d16eb93138").GetComponent<ContextRankConfig>();
            ProtectionDomainBaseSelfBuffConfig.m_Class = ProtectionDomainBaseSelfBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ProtectionDomainGreaterEffect = Resources.GetBlueprint<BlueprintBuff>("fea7c44605c90f14fa40b2f2f5ae6339");
            ProtectionDomainGreaterEffect.GetComponents<ContextRankConfig>().ForEach(c => {
                c.m_Class = c.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var ProtectionDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("f3d878f77d0ee854b864f5ea1c80e752");
            ProtectionDomainGreaterResource.m_MaxAmount.m_Class = ProtectionDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Repose Domain Hooks
            var ReposeDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("8526bc808c303034cb2b7832bccf1482").GetComponent<AddFeatureOnClassLevel>();
            ReposeDomainBaseFeatureConfig.m_AdditionalClasses = ReposeDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var ReposeDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("aefe627a3a2f8d94ea9d2b3961261282");
            ReposeDomainGreaterResource.m_MaxAmount.m_Class = ReposeDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Rune Domain Hooks
            var RuneDomainGreaterAreaConfig = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("e26de8b0164db23458eb64c21fac2846").GetComponent<ContextRankConfig>();
            RuneDomainGreaterAreaConfig.m_Class = RuneDomainGreaterAreaConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var RuneDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("b74c64a0152c7ee46b13ecdd72dda6f3").GetComponent<AddFeatureOnClassLevel>();
            RuneDomainBaseFeatureConfig.m_AdditionalClasses = RuneDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var RuneDomainGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("9171a3ce8ea8cac44894b240709804ce");
            RuneDomainGreaterAbility.GetComponents<ContextRankConfig>().ForEach(c => {
                c.m_Class = c.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var RuneDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("cb3efe82596c908418c0dba4ef6f4210");
            RuneDomainGreaterResource.m_MaxAmount.m_ClassDiv = RuneDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var RuneDomainBaseAbilityFire = Resources.GetBlueprint<BlueprintAbility>("eddfe26a8a3892b47add3cb08db7069d");
            RuneDomainBaseAbilityFire.GetComponents<ContextRankConfig>().ForEach(c => {
                c.m_Class = c.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var RuneDomainBaseAbilityCold = Resources.GetBlueprint<BlueprintAbility>("2b81ff42fcbe9434eaf00fb0a873f579");
            RuneDomainBaseAbilityCold.GetComponents<ContextRankConfig>().ForEach(c => {
                c.m_Class = c.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var RuneDomainBaseAbilityAcid = Resources.GetBlueprint<BlueprintAbility>("92c821ecc8d73564bad15a8a07ed40f2");
            RuneDomainBaseAbilityAcid.GetComponents<ContextRankConfig>().ForEach(c => {
                c.m_Class = c.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var RuneDomainBaseAbilityFireAreaConfig = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("9b786945d2ec1884184235a488e5cb9e").GetComponent<ContextRankConfig>();
            RuneDomainBaseAbilityFireAreaConfig.m_Class = RuneDomainBaseAbilityFireAreaConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var RuneDomainBaseAbilityColdAreaConfig = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("8b8e98e8e0000f643ad97c744f3f850b").GetComponent<ContextRankConfig>();
            RuneDomainBaseAbilityColdAreaConfig.m_Class = RuneDomainBaseAbilityColdAreaConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var RuneDomainBaseAbilityAcidAreaConfig = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("98c3a36f2a3636c49a3f77c001a25f29").GetComponent<ContextRankConfig>();
            RuneDomainBaseAbilityAcidAreaConfig.m_Class = RuneDomainBaseAbilityAcidAreaConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var RuneDomainBaseAbilityElectricity = Resources.GetBlueprint<BlueprintAbility>("b67978e3d5a6c9247a393237bc660339");
            RuneDomainBaseAbilityElectricity.GetComponents<ContextRankConfig>().ForEach(c => {
                c.m_Class = c.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            });
            var RuneDomainBaseAbilityElectricityAreaConfig = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("db868c576c69d0e4a8462645267c6cdc").GetComponent<ContextRankConfig>();
            RuneDomainBaseAbilityElectricityAreaConfig.m_Class = RuneDomainBaseAbilityElectricityAreaConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Strength Domain Hooks
            var StrengthDomainBaseBuffConfig = Resources.GetBlueprint<BlueprintBuff>("94dfcf5f3a72ce8478c8de5db69e752b").GetComponent<ContextRankConfig>();
            StrengthDomainBaseBuffConfig.m_Class = StrengthDomainBaseBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var StrengthDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("1d6364123e1f6a04c88313d83d3b70ee").GetComponent<ContextRankConfig>();
            StrengthDomainBaseAbilityConfig.m_Class = StrengthDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var StrengthDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("526f99784e9fe4346824e7f210d46112").GetComponent<AddFeatureOnClassLevel>();
            StrengthDomainBaseFeatureConfig.m_AdditionalClasses = StrengthDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var StrengthDomainGreaterFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("3298fd30e221ef74189a06acbf376d29").GetComponent<ContextRankConfig>();
            StrengthDomainGreaterFeatureConfig.m_Class = StrengthDomainGreaterFeatureConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Sun Domain Hooks
            var SunDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("3d8e38c9ed54931469281ab0cec506e9").GetComponent<AddFeatureOnClassLevel>();
            SunDomainBaseFeatureConfig.m_AdditionalClasses = SunDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var SunDomainBaseFeatureDamageConfig = Resources.GetBlueprint<BlueprintFeature>("3d8e38c9ed54931469281ab0cec506e9").GetComponent<IncreaseSpellDamageByClassLevel>();
            SunDomainBaseFeatureDamageConfig.m_AdditionalClasses = SunDomainBaseFeatureDamageConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var SunDomainGreaterAuraConfig = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("cfe8c5683c759f047a56a4b5e77ac93f").GetComponent<ContextRankConfig>();
            SunDomainGreaterAuraConfig.m_Class = SunDomainGreaterAuraConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var SunDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("6bea29e2257fa6742923ba757435aba8");
            SunDomainGreaterResource.m_MaxAmount.m_Class = SunDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            SunDomainGreaterResource.m_MaxAmount.m_ClassDiv = SunDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Travel Domain Hooks
            var TravelDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("3079cdfba971d614ab4f49220c6cd228").GetComponent<AddFeatureOnClassLevel>();
            TravelDomainBaseFeatureConfig.m_AdditionalClasses = TravelDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var TravelDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("52ee1ad8d1ac94d4b92a62acfa8931ad");
            TravelDomainBaseResource.m_MaxAmount.m_Class = TravelDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var TravelDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("657bfb21544642e4f8aef532c9f04ac2");
            TravelDomainGreaterResource.m_MaxAmount.m_Class = TravelDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            TravelDomainGreaterResource.m_MaxAmount.m_ClassDiv = TravelDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Trickery Domain Hooks
            var TrickeryDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("ee7eb5b9c644a0347b36eec653d3dfcb").GetComponent<ContextRankConfig>();
            TrickeryDomainBaseAbilityConfig.m_Class = TrickeryDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var TrickeryDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("cd1f4a784e0820647a34fe9bd5ffa770").GetComponent<AddFeatureOnClassLevel>();
            TrickeryDomainBaseFeatureConfig.m_AdditionalClasses = TrickeryDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var TrickeryDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("148c9ad7e47f4284b9c3686bb440c08c");
            TrickeryDomainBaseResource.m_MaxAmount.m_Class = TrickeryDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var TrickeryDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("520ad6381e09f8349a237ac4b247082e");
            TrickeryDomainGreaterResource.m_MaxAmount.m_Class = TrickeryDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            TrickeryDomainGreaterResource.m_MaxAmount.m_ClassDiv = TrickeryDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //War Domain Hooks
            var WarDomainBaseBuffConfig = Resources.GetBlueprint<BlueprintBuff>("aefec65136058694ab20cd71941eec81").GetComponent<ContextRankConfig>();
            WarDomainBaseBuffConfig.m_Class = WarDomainBaseBuffConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WarDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("fbef6b2053ab6634a82df06f76c260e3").GetComponent<ContextRankConfig>();
            WarDomainBaseAbilityConfig.m_Class = WarDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WarDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("640c20da7d6fcbc43b0d30a0a762f122").GetComponent<AddFeatureOnClassLevel>();
            WarDomainBaseFeatureConfig.m_AdditionalClasses = WarDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Water Domain Hooks
            var WaterDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("4c21ad24f55f64d4fb722f40720d9ab0").GetComponent<AddFeatureOnClassLevel>();
            WaterDomainBaseFeatureConfig.m_AdditionalClasses = WaterDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WaterDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("5e1db2ef80ff361448549beeb7785791").GetComponent<ContextRankConfig>();
            WaterDomainBaseAbilityConfig.m_Class = WaterDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            //Weather Domain Hooks
            var WeatherDomainBaseFeatureConfig = Resources.GetBlueprint<BlueprintFeature>("1c37869ee06ca33459f16f23f4969e7d").GetComponent<AddFeatureOnClassLevel>();
            WeatherDomainBaseFeatureConfig.m_AdditionalClasses = WeatherDomainBaseFeatureConfig.m_AdditionalClasses.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WeatherDomainBaseAbilityConfig = Resources.GetBlueprint<BlueprintAbility>("f166325c271dd29449ba9f98d11542d9").GetComponent<ContextRankConfig>();
            WeatherDomainBaseAbilityConfig.m_Class = WeatherDomainBaseAbilityConfig.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WeatherDomainBaseResource = Resources.GetBlueprint<BlueprintAbilityResource>("53dd76c7053469541b99e01cb25711d6");
            WeatherDomainBaseResource.m_MaxAmount.m_Class = WeatherDomainBaseResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            var WeatherDomainGreaterResource = Resources.GetBlueprint<BlueprintAbilityResource>("5c88b557e79eaee41a4190712b178970");
            WeatherDomainGreaterResource.m_MaxAmount.m_Class = WeatherDomainGreaterResource.m_MaxAmount.m_Class.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            WeatherDomainGreaterResource.m_MaxAmount.m_ClassDiv = WeatherDomainGreaterResource.m_MaxAmount.m_ClassDiv.AppendToArray(StargazerClass.ToReference<BlueprintCharacterClassReference>());
            #endregion
            var StargazerMysteryMagicStarsDomainBackupDomainSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("StargazerMysteryMagicStarsDomainBackupDomainSelection", bp => {
                bp.SetName("Pulura's Domains");
                bp.SetDescription("If the stargazer already has the stars subdomain he may select another domain granted by Pulura. His stargazer levels count as (and stack with) cleric " +
                    "levels when determining which domain abilities he gains and their effects. ");
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.HideInUI = false;
                bp.HideNotAvailibleInUI = false;
                bp.ReapplyOnLevelUp = false;
                bp.Mode = SelectionMode.OnlyNew;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AirDomainProgressionSecondary.ToReference<BlueprintFeatureReference>(),
                    ChaosDomainProgressionSecondary.ToReference<BlueprintFeatureReference>(),
                    GoodDomainProgressionSecondary.ToReference<BlueprintFeatureReference>(),
                    WeatherDomainProgressionSecondary.ToReference<BlueprintFeatureReference>()
                };
            });
            var StargazerMysteryMagicStarsDomainFeatureSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("StargazerMysteryMagicStarsDomainFeatureSelection", bp => {
                bp.SetName("Mystery Magic - Stars Subdomain");
                bp.SetDescription("At 3rd level, the stargazer gains the stars subdomain in addition to any domains he already has, if he already has the stars subdomain he may select another domain granted " +
                    "by Pulura. His stargazer levels count as (and stack with) cleric levels when determining which domain abilities he gains and their effects. He can use the stars are right ability regardless " +
                    "of his spellcasting class.");
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.HideInUI = false;
                bp.HideNotAvailibleInUI = false;
                bp.ReapplyOnLevelUp = false;
                bp.Mode = SelectionMode.OnlyNew;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    StargazerMysteryMagicStarsDomainBackupDomainSelection.ToReference<BlueprintFeatureReference>() //Starsdomain added on it's own page
                };
            });
            //Mystery Magic - Coat of many Stars
            var EdictOfImpenetrableFortress = Resources.GetBlueprint<BlueprintAbility>("d7741c08ccf699e4a8a8f8ab2ed345f8");
            var StargazerMysteryMagicCOMSResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("StargazerMysteryMagicCOMSResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 0,
                    IncreasedByLevel = true,
                    m_Class = new BlueprintCharacterClassReference[] {
                        StargazerClass.ToReference<BlueprintCharacterClassReference>(),
                    },
                    LevelIncrease = 1,
                    StartingIncrease = 1,
                };
            });
            var StargazerMysteryMagicCOMSBuff = Helpers.CreateBuff("StargazerMysteryMagicCOMSBuff", bp => {
                bp.SetName("Mystery Magic - Coat of Many Stars");
                bp.SetDescription("You conjure a coat of starry radiance that grants you a +4 armor {g|Encyclopedia:Bonus}bonus{/g} along with " +
                    "{g|Encyclopedia:Damage_Reduction}DR{/g} 5/{g|Encyclopedia:Damage_Type}slashing{/g}. At 7th  and 9th level, the armor " +
                    "bonus increases by +2. You can use this coat for 1 hour number of times per day equal to stargazer level.");
                bp.m_Icon = EdictOfImpenetrableFortress.Icon;
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Stat = StatType.Unknown;
                    c.m_SpecificModifier = ModifierDescriptor.None;
                    c.m_Progression = ContextRankProgression.DelayedStartPlusDivStep;
                    c.m_StartLevel = 7;
                    c.m_StepLevel = 2;
                    c.m_Class = new BlueprintCharacterClassReference[] { StargazerClass.ToReference<BlueprintCharacterClassReference>() };
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.Heal;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.Zero,
                        DiceCountValue = new ContextValue() {
                            ValueType = ContextValueType.Simple,
                            Value = 0,
                            ValueRank = AbilityRankType.Default,
                            ValueShared = AbilitySharedValue.Damage,
                            Property = UnitProperty.None
                        },
                        BonusValue = new ContextValue() {
                            ValueType = ContextValueType.Rank,
                            Value = 0,
                            ValueRank = AbilityRankType.Default,
                            ValueShared = AbilitySharedValue.Damage,
                            Property = UnitProperty.None
                        }
                    };
                    c.Modifier = 2;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.Damage;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.One,
                        DiceCountValue = new ContextValue() {
                            ValueType = ContextValueType.Simple,
                            Value = 4,
                            ValueRank = AbilityRankType.Default,
                            ValueShared = AbilitySharedValue.Damage,
                            Property = UnitProperty.None
                        },
                        BonusValue = new ContextValue() {
                            ValueType = ContextValueType.Shared,
                            Value = 0,
                            ValueRank = AbilityRankType.Default,
                            ValueShared = AbilitySharedValue.Heal,
                            Property = UnitProperty.None
                        }
                    };
                    c.Modifier = 1;
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Armor;
                    c.Stat = StatType.AC;
                    c.Multiplier = 1;
                    c.Value = new ContextValue() {
                        ValueType = ContextValueType.Shared,
                        Value = 0,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = UnitProperty.None
                    };
                    c.HasMinimal = false;
                    c.Minimal = 0;
                });
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = new ContextValue() {
                        ValueType = ContextValueType.Simple,
                        Value = 5,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = UnitProperty.None
                    };
                    c.UsePool = false;
                    c.Pool = new ContextValue();
                    c.Or = false;
                    c.BypassedByMaterial = false;
                    c.Material = PhysicalDamageMaterial.Adamantite;
                    c.BypassedByForm = true;
                    c.Form = PhysicalDamageForm.Slashing;
                    c.BypassedByMagic = false;
                    c.MinEnhancementBonus = 1;
                    c.BypassedByAlignment = false;
                    c.Alignment = DamageAlignment.Good;
                    c.BypassedByReality = false;
                    c.Reality = DamageRealityType.Ghost;
                    c.BypassedByWeaponType = false;
                    c.m_WeaponType = new BlueprintWeaponTypeReference();
                    c.BypassedByEpic = false;
                    c.m_CheckedFactMythic = new BlueprintUnitFactReference();
                });
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.Stacking = StackingType.Replace;
                bp.m_AllowNonContextActions = false;
            });
            var StargazerMysteryMagicCOMSAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("StargazerMysteryMagicCOMSAbility", bp => {
                bp.SetName("Mystery Magic - Coat of Many Stars");
                bp.SetDescription("You conjure a coat of starry radiance that grants you a +4 armor {g|Encyclopedia:Bonus}bonus{/g} along with " +
                    "{g|Encyclopedia:Damage_Reduction}DR{/g} 5/{g|Encyclopedia:Damage_Type}slashing{/g}. At 7th  and 9th level, the armor " +
                    "bonus increases by +2. You can use this coat for 1 hour number of times per day equal to stargazer level.");
                bp.m_Icon = EdictOfImpenetrableFortress.Icon;
                bp.AddComponent<ActivatableAbilityResourceLogic>(c => {
                    c.SpendType = ActivatableAbilityResourceLogic.ResourceSpendType.OncePerHour;
                    c.m_RequiredResource = StargazerMysteryMagicCOMSResource.ToReference<BlueprintAbilityResourceReference>();
                });
                bp.m_Buff = StargazerMysteryMagicCOMSBuff.ToReference<BlueprintBuffReference>();
                bp.DeactivateIfOwnerDisabled = false;
                bp.ActivationType = AbilityActivationType.WithUnitCommand;
                bp.m_ActivateWithUnitCommand = UnitCommand.CommandType.Standard;
                bp.DeactivateIfCombatEnded = false;
            });
            var StargazerMysteryMagicCOMSFeature = Helpers.CreateBlueprint<BlueprintFeature>("StargazerMysteryMagicCOMSFeature", bp => {
                bp.SetName("Mystery Magic - Coat of Many Stars");
                bp.SetDescription("You conjure a coat of starry radiance that grants you a +4 armor {g|Encyclopedia:Bonus}bonus{/g} along with " +
                    "{g|Encyclopedia:Damage_Reduction}DR{/g} 5/{g|Encyclopedia:Damage_Type}slashing{/g}. At 7th  and 9th level, the armor " +
                    "bonus increases by +2. You can use this coat for 1 hour number of times per day equal to stargazer level.");
                bp.m_Icon = EdictOfImpenetrableFortress.Icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        StargazerMysteryMagicCOMSAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = StargazerMysteryMagicCOMSResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            #region Sidereal Arcana











            var StargazerSiderealArcanaSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("StargazerSiderealArcanaSelection", bp => {
                bp.SetName("Sidereal Arcana");
                bp.SetDescription("As he studies the skies, the stargazer binds himself to constellations from the Cosmic Caravan, drawing on their unearthly power. At 2nd level and every 2 " +
                    "class levels thereafter, the stargazer gains one sidereal arcana of his choice.");
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.None;
                bp.m_AllowNonContextActions = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    

                };
            });
            var StargazerStarsDanceFeature = Helpers.CreateBlueprint<BlueprintFeature>("StargazerStarsDanceFeature", bp => {
                bp.SetName("Stars’ Dance");
                bp.SetDescription("At 10th level, the stargazer’s mastery of the Cosmic Caravan reaches its zenith. Once per day, the stargazer can replace one of his sidereal arcana with any other one.");
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
            });
            #endregion


            StargazerProgression.LevelEntries = new LevelEntry[] {
                Helpers.LevelEntry(1, StargazerGuidingLightFeatureSelection, StargazerMysteryMagicHexFeatureSelection),
                Helpers.LevelEntry(2, StargazerSiderealArcanaSelection),
                Helpers.LevelEntry(3, StargazerMysteryMagicStarsDomainFeatureSelection),
                Helpers.LevelEntry(4, StargazerSiderealArcanaSelection),
                Helpers.LevelEntry(5, StargazerMysteryMagicCOMSFeature),
                Helpers.LevelEntry(6, StargazerSiderealArcanaSelection),
                Helpers.LevelEntry(7, StargazerMysteryMagicHexFeatureSelection),
                Helpers.LevelEntry(8, StargazerSiderealArcanaSelection),
                Helpers.LevelEntry(9, StargazerMysteryMagicHexFeatureSelection),
                Helpers.LevelEntry(10, StargazerSiderealArcanaSelection, StargazerStarsDanceFeature)
            };
            StargazerProgression.UIGroups = new UIGroup[] {};
            if (ModSettings.AddedContent.Classes.IsDisabled("Stargazer")) { return; }
            Helpers.RegisterClass(StargazerClass);
        }
    }
}
