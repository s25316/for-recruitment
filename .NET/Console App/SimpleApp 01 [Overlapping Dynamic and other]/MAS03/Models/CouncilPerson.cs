using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MAS03.Models
{
    internal class CouncilPerson
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        private int _fIghtSkillLevel;
        private int _moneySkillLevel;
        private int _diplomacySkillLevel;
        private int _sanctitySkillLevel;
        private int _intrigueSkillLevel;

        private string _denyAcessForNotMarshall = "Information only for Marshalls";
        private string _denyAcessForNotStewart = "Information only for Stewarts";
        private string _denyAcessForNotChancellor = "Information only for Chancellors";
        private string _denyAcessForNotArchbishop = "Information only for Archbishops";
        private string _denyAcessForNotSpymaster = "Information only for Spymasters";

        public int FightSkillLevel 
        {  get 
            {
                if (CouncilKindList.Contains(CouncilKind.Marshall)) 
                { 
                    return _fIghtSkillLevel;
                } else { throw new Exception(_denyAcessForNotMarshall); }
            }
            set 
            {
                if (CouncilKindList.Contains(CouncilKind.Marshall))
                {
                    _fIghtSkillLevel = value;
                }
                else { throw new Exception(_denyAcessForNotMarshall); }
            }
        }
        public int MoneySkillLevel 
        { 
            get 
            {
                if (CouncilKindList.Contains(CouncilKind.Stewart))
                {
                    return _moneySkillLevel;
                }
                else { throw new Exception(_denyAcessForNotStewart); }
            }
            set
            {
                if (CouncilKindList.Contains(CouncilKind.Stewart))
                {
                    _moneySkillLevel = value;
                }
                else { throw new Exception(_denyAcessForNotStewart); }
            }
        }
        public int DiplomacySkillLevel
        {
            get
            {
                if (CouncilKindList.Contains(CouncilKind.Chancellor))
                {
                    return _diplomacySkillLevel;
                }
                else { throw new Exception(_denyAcessForNotChancellor); }
            }
            set
            {
                if (CouncilKindList.Contains(CouncilKind.Chancellor))
                {
                    _diplomacySkillLevel = value;
                }
                else { throw new Exception(_denyAcessForNotChancellor); }
            }
        }
        public int SanctitySkillLevel
        {
            get
            {
                if (CouncilKindList.Contains(CouncilKind.Archbishop))
                {
                    return _sanctitySkillLevel;
                }
                else { throw new Exception(_denyAcessForNotArchbishop); }
            }
            set
            {
                if (CouncilKindList.Contains(CouncilKind.Archbishop))
                {
                    _sanctitySkillLevel = value;
                }
                else { throw new Exception(_denyAcessForNotArchbishop); }
            }
        }
        public int IntrigueSkillLevel
        {
            get
            {
                if (CouncilKindList.Contains(CouncilKind.Marshall))
                {
                    return _intrigueSkillLevel;
                }
                else { throw new Exception(_denyAcessForNotSpymaster); }
            }
            set
            {
                if (CouncilKindList.Contains(CouncilKind.Marshall))
                {
                    _intrigueSkillLevel = value;
                }
                else { throw new Exception(_denyAcessForNotSpymaster); }
            }
        }

        public List<CouncilKind> CouncilKindList { get; set; } = new List<CouncilKind>();

        public override string ToString()
        {
            var marshallText = (CouncilKindList.Contains(CouncilKind.Marshall) ? 
                $"\nFIght Skill Level - {_fIghtSkillLevel}" : "");
            var stewartText = (CouncilKindList.Contains(CouncilKind.Stewart) ?
                $"\nMoney Skill Level - {_moneySkillLevel}" : "");
            var chancellorText = (CouncilKindList.Contains(CouncilKind.Chancellor) ?
                $"\nDiplomacy Skill Level - {_diplomacySkillLevel}" : "");
            var archbishopText = (CouncilKindList.Contains(CouncilKind.Archbishop) ?
                $"\nSanctity Skill Level - {_sanctitySkillLevel}" : "");
            var spymasterText = (CouncilKindList.Contains(CouncilKind.Spymaster) ?
                $"\nIntrigue Skill Level - {_intrigueSkillLevel}" : "");
            var sumInformation = CouncilKindList.Count() == 0 ? "Person not have Council" : $"{marshallText}{stewartText}{chancellorText}{archbishopText}{spymasterText}";
            return $"Name - {FirstName}, Surname - {LastName}\n{sumInformation}";
        }
    }
    public enum CouncilKind 
    {
        Marshall, Stewart, Chancellor, Archbishop, Spymaster
    }
}
