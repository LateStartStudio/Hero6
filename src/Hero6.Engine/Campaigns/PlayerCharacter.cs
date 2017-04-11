// <copyright file="PlayerCharacter.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using System.ComponentModel;
    using Stats;

    /// <summary> 
    /// A class that represents a player character in a game. 
    /// </summary> 
    public class PlayerCharacter : Character
    {
        private uint health;
        private uint stamina;
        private uint mana;

        private uint strength;
        private uint intelligence;
        private uint agility;
        private uint vitality;
        private uint luck;
        private uint weaponUse;
        private uint parry;
        private uint dodge;
        private uint stealth;
        private uint lockPicking;
        private uint throwing;
        private uint climbing;
        private uint magic;

        private uint humans;
        private uint sidhe;
        private uint giants;

        /// <summary> 
        /// Initializes a new instance of the <see cref="PlayerCharacter"/> class. 
        /// </summary> 
        /// <param name="campaign">The campaign this is instance is associated with.</param> 
        public PlayerCharacter(Campaign campaign) : base(campaign)
        {
            this.Name = string.Empty;
        }

        /// <summary> 
        /// Occurs on stat changed. 
        /// </summary> 
        public event EventHandler<StatChangedEventArgs> StatChanged;

        /// <summary> 
        /// Gets or sets the name of the player character. 
        /// </summary> 
        /// <value> 
        /// The name of the player character. 
        /// </value> 
        public string Name { get; set; }

        /// <summary> 
        /// Gets or sets the health of the player character. 
        /// </summary> 
        /// <value> 
        /// The health of the player character. 
        /// </value> 
        public uint Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value > this.Campaign.StatCap)
                {
                    this.health = (uint)this.Campaign.StatCap;
                }
                else
                {
                    this.health = value;
                }

                this.StatChanged?.Invoke(this, new StatChangedEventArgs(Stat.Health, this.health));
            }
        }

        /// <summary> 
        /// Gets or sets the stamina of the player character. 
        /// </summary> 
        /// <value> 
        /// The stamina of the player character. 
        /// </value> 
        public uint Stamina
        {
            get
            {
                return this.stamina;
            }

            set
            {
                if (value > this.Campaign.StatCap)
                {
                    this.stamina = (uint)this.Campaign.StatCap;
                }
                else
                {
                    this.stamina = value;
                }

                this.StatChanged?.Invoke(this, new StatChangedEventArgs(Stat.Stamina, this.stamina));
            }
        }

        /// <summary> 
        /// Gets or sets the mana of the player character. 
        /// </summary> 
        /// <value> 
        /// The mana of the player character. 
        /// </value> 
        public uint Mana
        {
            get
            {
                return this.mana;
            }

            set
            {
                if (value > this.Campaign.StatCap)
                {
                    this.mana = (uint)this.Campaign.StatCap;
                }
                else
                {
                    this.mana = value;
                }

                this.StatChanged?.Invoke(this, new StatChangedEventArgs(Stat.Mana, this.mana));
            }
        }

        /// <summary> 
        /// Gets the max health of the player character. 
        /// </summary> 
        /// <value> 
        /// The max health of the player character. 
        /// </value> 
        public uint HealthMax => (uint)((this.Strength * 0.4) + (this.Vitality * 0.6));

        /// <summary> 
        /// Gets the max stamina of the player character. 
        /// </summary> 
        /// <value> 
        /// The max stamina of the player character. 
        /// </value> 
        public uint StaminaMax => (uint)((this.Vitality * 0.4) + (this.Agility * 0.6));

        /// <summary> 
        /// Gets the max mana of the player character. 
        /// </summary> 
        /// <value> 
        /// The max mana of the player character. 
        /// </value> 
        public uint ManaMax
        {
            get
            {
                if (this.magic == 0)
                {
                    return 0;
                }

                return (uint)((this.Intelligence * 0.4) + (this.Magic * 0.6));
            }
        }

        /// <summary> 
        /// Gets the strength of the player character. 
        /// </summary> 
        /// <value> 
        /// The strength of the player character. 
        /// </value> 
        public uint Strength => TriangularNumberReverse(this.strength);

        /// <summary> 
        /// Gets the intelligence of the player character. 
        /// </summary> 
        /// <value> 
        /// The intelligence of the player character. 
        /// </value> 
        public uint Intelligence => TriangularNumberReverse(this.intelligence);

        /// <summary> 
        /// Gets the agility of the player character. 
        /// </summary> 
        /// <value> 
        /// The agility of the player character. 
        /// </value> 
        public uint Agility => TriangularNumberReverse(this.agility);

        /// <summary> 
        /// Gets the vitality of the player character. 
        /// </summary> 
        /// <value> 
        /// The vitality of the player character. 
        /// </value> 
        public uint Vitality => TriangularNumberReverse(this.vitality);

        /// <summary> 
        /// Gets the luck of the player character. 
        /// </summary> 
        /// <value> 
        /// The luck of the player character. 
        /// </value> 
        public uint Luck => TriangularNumberReverse(this.luck);

        /// <summary> 
        /// Gets the weapon use of the player character. 
        /// </summary> 
        /// <value> 
        /// The weapon use of the player character. 
        /// </value> 
        public uint WeaponUse => TriangularNumberReverse(this.weaponUse);

        /// <summary> 
        /// Gets the parry of the player character. 
        /// </summary> 
        /// <value> 
        /// The parry of the player character. 
        /// </value> 
        public uint Parry => TriangularNumberReverse(this.parry);

        /// <summary> 
        /// Gets the dodge of the player character. 
        /// </summary> 
        /// <value> 
        /// The dodge of the player character. 
        /// </value> 
        public uint Dodge => TriangularNumberReverse(this.dodge);

        /// <summary> 
        /// Gets the stealth of the player character. 
        /// </summary> 
        /// <value> 
        /// The stealth of the player character. 
        /// </value> 
        public uint Stealth => TriangularNumberReverse(this.stealth);

        /// <summary> 
        /// Gets the lock picking of the player character. 
        /// </summary> 
        /// <value> 
        /// The lock picking of the player character. 
        /// </value> 
        public uint LockPicking => TriangularNumberReverse(this.lockPicking);

        /// <summary> 
        /// Gets the throwing of the player character. 
        /// </summary> 
        /// <value> 
        /// The throwing of the player character. 
        /// </value> 
        public uint Throwing => TriangularNumberReverse(this.throwing);

        /// <summary> 
        /// Gets the climbing of the player character. 
        /// </summary> 
        /// <value> 
        /// The climbing of the player character. 
        /// </value> 
        public uint Climbing => TriangularNumberReverse(this.climbing);

        /// <summary> 
        /// Gets the magic of the player character. 
        /// </summary> 
        /// <value> 
        /// The magic of the player character. 
        /// </value> 
        public uint Magic => TriangularNumberReverse(this.magic);

        /// <summary> 
        /// Gets or sets the relationship between the player character and the Humans. 
        /// </summary> 
        /// <value> 
        /// The relationship between the player character and the Humans. 
        /// </value> 
        public uint Humans
        {
            get
            {
                return this.humans;
            }

            set
            {
                if (value > this.Campaign.StatCap)
                {
                    this.humans = (uint)this.Campaign.StatCap;
                }
                else
                {
                    this.humans = value;
                }

                this.StatChanged?.Invoke(this, new StatChangedEventArgs(Stat.Humans, this.humans));
            }
        }

        /// <summary> 
        /// Gets or sets the relationship between the player character and the Sidhe. 
        /// </summary> 
        /// <value> 
        /// The relationship between the player character and the Sidhe. 
        /// </value> 
        public uint Sidhe
        {
            get
            {
                return this.sidhe;
            }

            set
            {
                if (value > this.Campaign.StatCap)
                {
                    this.sidhe = (uint)this.Campaign.StatCap;
                }
                else
                {
                    this.sidhe = value;
                }

                this.StatChanged?.Invoke(this, new StatChangedEventArgs(Stat.Sidhe, this.sidhe));
            }
        }

        /// <summary> 
        /// Gets or sets the relationship between the player character and the Giants. 
        /// </summary> 
        /// <value> 
        /// The relationship between the player character and the Giants. 
        /// </value> 
        public uint Giants
        {
            get
            {
                return this.giants;
            }

            set
            {
                if (value > this.Campaign.StatCap)
                {
                    this.giants = (uint)this.Campaign.StatCap;
                }
                else
                {
                    this.giants = value;
                }

                this.StatChanged?.Invoke(this, new StatChangedEventArgs(Stat.Giants, this.giants));
            }
        }

        /// <summary>  
        /// Increases the stat of the player character. The increase will go with the Triangular 
        /// number formula, n(n + 1) / 2, so to increase the stat from 0 to 5, you would need to 
        /// input 15 into the function. Any remainding numbers will be stored into a buffer and 
        /// included in the computation on the next time the stat is increased.  
        /// </summary> 
        /// <param name="stat">The stat to increase.</param> 
        /// <param name="value">The factor in which to increase the stat.</param>  
        public void IncreaseStat(Stat stat, uint value)
        {
            StatChangedEventArgs e;

            switch (stat)
            {
                case Stat.Strength:
                    e = new StatChangedEventArgs(Stat.HealthMax, this.HealthMax);

                    this.IncreaseStat(
                        ref this.strength,
                        Stat.Strength,
                        value,
                        () => this.StatChanged?.Invoke(this, e));
                    break;
                case Stat.Intelligence:
                    e = new StatChangedEventArgs(Stat.ManaMax, this.ManaMax);

                    this.IncreaseStat(
                        ref this.intelligence,
                        Stat.Intelligence,
                        value,
                        () => this.StatChanged?.Invoke(this, e));
                    break;
                case Stat.Agility:
                    e = new StatChangedEventArgs(Stat.StaminaMax, this.StaminaMax);

                    this.IncreaseStat(
                        ref this.agility,
                        Stat.Agility,
                        value,
                        () => this.StatChanged?.Invoke(this, e));
                    break;
                case Stat.Vitality:
                    StatChangedEventArgs e1 = new StatChangedEventArgs(Stat.HealthMax, this.HealthMax);
                    StatChangedEventArgs e2 = new StatChangedEventArgs(Stat.StaminaMax, this.StaminaMax);

                    this.IncreaseStat(
                        ref this.vitality,
                        Stat.Vitality,
                        value,
                        () =>
                        {
                            StatChanged?.Invoke(this, e1);
                            StatChanged?.Invoke(this, e2);
                        });
                    break;
                case Stat.Luck:
                    this.IncreaseStat(ref this.luck, Stat.Luck, value, null);
                    break;
                case Stat.WeaponUse:
                    this.IncreaseStat(ref this.weaponUse, Stat.WeaponUse, value, null);
                    break;
                case Stat.Parry:
                    this.IncreaseStat(ref this.parry, Stat.Parry, value, null);
                    break;
                case Stat.Dodge:
                    this.IncreaseStat(ref this.dodge, Stat.Dodge, value, null);
                    break;
                case Stat.Stealth:
                    this.IncreaseStat(ref this.stealth, Stat.Stealth, value, null);
                    break;
                case Stat.LockPicking:
                    this.IncreaseStat(ref this.lockPicking, Stat.LockPicking, value, null);
                    break;
                case Stat.Throwing:
                    this.IncreaseStat(ref this.throwing, Stat.Throwing, value, null);
                    break;
                case Stat.Climbing:
                    this.IncreaseStat(ref this.climbing, Stat.Climbing, value, null);
                    break;
                case Stat.Magic:
                    e = new StatChangedEventArgs(Stat.ManaMax, this.ManaMax);

                    this.IncreaseStat(
                        ref this.magic,
                        Stat.Magic,
                        value,
                        () => this.StatChanged?.Invoke(this, e));
                    break;
                case Stat.Health:
                case Stat.HealthMax:
                case Stat.Stamina:
                case Stat.StaminaMax:
                case Stat.Mana:
                case Stat.ManaMax:
                case Stat.Humans:
                case Stat.Sidhe:
                case Stat.Giants:
                    throw new NotImplementedException(
                        $"Enum {stat} is not intended to be set here, use property instead.");
                default:
                    throw new InvalidEnumArgumentException(nameof(stat), (int)stat, typeof(Stat));
            }
        }

        /// <summary>  
        /// Increases the stat of the player character. The increase will go with the Triangular 
        /// number formula, n(n + 1) / 2, so to increase the stat from 0 to 5, you would need to 
        /// input 15 into the function. Any remainding numbers will be stored into a buffer and 
        /// included in the computation on the next time the stat is increased.  
        /// </summary> 
        /// <param name="stat">The stat to increase.</param> 
        /// <param name="value">The factor in which to increase the stat.</param>  
        public void IncreaseStat(Stat stat, int value)
        {
            this.IncreaseStat(stat, (uint)value);
        }

        // https://en.wikipedia.org/wiki/Triangular_number 
        private static uint TriangularNumber(uint n)
        {
            return (n * (n + 1)) / 2;
        }

        // https://en.wikipedia.org/wiki/Triangular_number 
        private static uint TriangularNumberReverse(uint n)
        {
            return (uint)(Math.Sqrt((8.0 * n) + 1.0) / 2.0);
        }

        private void IncreaseStat(ref uint stat, Stat statType, uint value, Action action)
        {
            stat += value;

            if (TriangularNumberReverse(stat) > this.Campaign.StatCap)
            {
                stat = TriangularNumber((uint)this.Campaign.StatCap);
            }

            this.StatChanged?.Invoke(this, new StatChangedEventArgs(statType, TriangularNumberReverse(value)));
            action?.Invoke();
        }
    }
}