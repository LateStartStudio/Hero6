// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerCharacterTests.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the PlayerCharacterTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;
    using System.ComponentModel;
    using NUnit.Framework;
    using Stats;

    [TestFixture]
    public class PlayerCharacterTests
    {
        private PlayerCharacter pc;

        [SetUp]
        public void Init()
        {
            this.pc = new PlayerCharacter(MockCampaign.Instance);
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.pc);
        }

        [Test]
        public void NameGetAndSet()
        {
            Assert.AreEqual(string.Empty, this.pc.Name);

            this.pc.Name = "Hero";

            Assert.AreEqual("Hero", this.pc.Name);
        }

        [Test]
        public void HealthGetAndSet()
        {
            Assert.AreEqual(0, this.pc.Health);

            this.pc.Health = 25;
            Assert.AreEqual(25, this.pc.Health);

            this.pc.Health = 101;
            Assert.AreEqual(100, this.pc.Health);
        }

        [Test]
        public void StaminaGetAndSet()
        {
            Assert.AreEqual(0, this.pc.Stamina);

            this.pc.Stamina = 25;
            Assert.AreEqual(25, this.pc.Stamina);

            this.pc.Stamina = 101;
            Assert.AreEqual(100, this.pc.Stamina);
        }

        [Test]
        public void ManaGetAndSet()
        {
            Assert.AreEqual(0, this.pc.Mana);

            this.pc.Mana = 25;
            Assert.AreEqual(25, this.pc.Mana);

            this.pc.Mana = 101;
            Assert.AreEqual(100, this.pc.Mana);
        }

        [Test]
        public void HealthMaxGetAndSet()
        {
            Assert.AreEqual(0, this.pc.HealthMax);

            this.pc.IncreaseStat(Stat.Strength, (10 * (10 + 1)) / 2);
            Assert.AreEqual(4, this.pc.HealthMax);

            this.pc.IncreaseStat(Stat.Vitality, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.HealthMax);
        }

        [Test]
        public void StaminaMaxGetAndSet()
        {
            Assert.AreEqual(0, this.pc.StaminaMax);

            this.pc.IncreaseStat(Stat.Vitality, (10 * (10 + 1)) / 2);
            Assert.AreEqual(4, this.pc.StaminaMax);

            this.pc.IncreaseStat(Stat.Agility, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.StaminaMax);
        }

        [Test]
        public void ManaMaxGetAndSet()
        {
            Assert.AreEqual(0, this.pc.ManaMax);

            this.pc.IncreaseStat(Stat.Magic, (10 * (10 + 1)) / 2);
            Assert.AreEqual(6, this.pc.ManaMax);

            this.pc.IncreaseStat(Stat.Intelligence, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.ManaMax);
        }

        [Test]
        public void StrengthGet()
        {
            Assert.AreEqual(0, this.pc.Strength);

            this.pc.IncreaseStat(Stat.Strength, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Strength);
        }

        [Test]
        public void IntelligenceGet()
        {
            Assert.AreEqual(0, this.pc.Intelligence);

            this.pc.IncreaseStat(Stat.Intelligence, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Intelligence);
        }

        [Test]
        public void AgilityGet()
        {
            Assert.AreEqual(0, this.pc.Agility);

            this.pc.IncreaseStat(Stat.Agility, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Agility);
        }

        [Test]
        public void VitalityGet()
        {
            Assert.AreEqual(0, this.pc.Vitality);

            this.pc.IncreaseStat(Stat.Vitality, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Vitality);
        }

        [Test]
        public void LuckGet()
        {
            Assert.AreEqual(0, this.pc.Luck);

            this.pc.IncreaseStat(Stat.Luck, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Luck);
        }

        [Test]
        public void WeaponUseGet()
        {
            Assert.AreEqual(0, this.pc.WeaponUse);

            this.pc.IncreaseStat(Stat.WeaponUse, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.WeaponUse);
        }

        [Test]
        public void ParryGet()
        {
            Assert.AreEqual(0, this.pc.Parry);

            this.pc.IncreaseStat(Stat.Parry, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Parry);
        }

        [Test]
        public void DodgeGet()
        {
            Assert.AreEqual(0, this.pc.Dodge);

            this.pc.IncreaseStat(Stat.Dodge, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Dodge);
        }

        [Test]
        public void StealthGet()
        {
            Assert.AreEqual(0, this.pc.Stealth);

            this.pc.IncreaseStat(Stat.Stealth, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Stealth);
        }

        [Test]
        public void LockPickingGet()
        {
            Assert.AreEqual(0, this.pc.LockPicking);

            this.pc.IncreaseStat(Stat.LockPicking, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.LockPicking);
        }

        [Test]
        public void ThrowingGet()
        {
            Assert.AreEqual(0, this.pc.Throwing);

            this.pc.IncreaseStat(Stat.Throwing, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Throwing);
        }

        [Test]
        public void ClimbingGet()
        {
            Assert.AreEqual(0, this.pc.Climbing);

            this.pc.IncreaseStat(Stat.Climbing, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Climbing);
        }

        [Test]
        public void MagicGet()
        {
            Assert.AreEqual(0, this.pc.Magic);

            this.pc.IncreaseStat(Stat.Magic, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Magic);
        }

        [Test]
        public void HumansGet()
        {
            Assert.AreEqual(0, this.pc.Humans);

            this.pc.Humans = 10;
            Assert.AreEqual(10, this.pc.Humans);

            this.pc.Humans = 101;
            Assert.AreEqual(100, this.pc.Humans);
        }

        [Test]
        public void SidheGet()
        {
            Assert.AreEqual(0, this.pc.Sidhe);

            this.pc.Sidhe = 10;
            Assert.AreEqual(10, this.pc.Sidhe);

            this.pc.Sidhe = 101;
            Assert.AreEqual(100, this.pc.Sidhe);
        }

        [Test]
        public void GiantsGet()
        {
            Assert.AreEqual(0, this.pc.Giants);

            this.pc.Giants = 10;
            Assert.AreEqual(10, this.pc.Giants);

            this.pc.Giants = 101;
            Assert.AreEqual(100, this.pc.Giants);
        }

        [Test]
        public void IncreaseStat()
        {
            Assert.AreEqual(0, this.pc.Strength);

            this.pc.IncreaseStat(Stat.Strength, (10 * (10 + 1)) / 2);
            Assert.AreEqual(10, this.pc.Strength);

            this.pc.IncreaseStat(Stat.Strength, (100 * (100 + 1)) / 2);
            Assert.AreEqual(100, this.pc.Strength);

            this.pc.IncreaseStat(Stat.Strength, (100 * (100 + 1)) / 2);
            Assert.AreEqual(100, this.pc.Strength);
        }

        [TestCase(Stat.Health)]
        [TestCase(Stat.HealthMax)]
        [TestCase(Stat.Stamina)]
        [TestCase(Stat.StaminaMax)]
        [TestCase(Stat.Mana)]
        [TestCase(Stat.ManaMax)]
        [TestCase(Stat.Humans)]
        [TestCase(Stat.Sidhe)]
        [TestCase(Stat.Giants)]
        public void IncreaseStatNotImplementedException(Stat stat)
        {
            Assert.Throws<NotImplementedException>(() => this.pc.IncreaseStat(Stat.Health, 1));
        }

        [Test]
        public void IncreaseStatInvalidEnumException()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => this.pc.IncreaseStat((Stat)9999, 1));
        }
    }
}