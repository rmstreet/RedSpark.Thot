
using RedSpark.Thot.Api.Domain.Core.CustomEnums;
using RedSpark.Thot.Api.Infra.CrossCutting.Extensions;
using RegexPatterns = RedSpark.Thot.Api.Domain.Const.RegexCustomPattern;
namespace RedSpark.Thot.Api.Domain.Core.ValueObject
{
    public class Phone
    {
        private Phone(string number)
        {
            if (string.IsNullOrEmpty(number))
                return;

            var cleanNumber = number.
                Replace(" ", string.Empty).
                RemoveAllDifferentPattern(RegexPatterns.PatternOnlyNumber).
                RemoveAllDifferentPattern(RegexPatterns.PatternRemovePlus55).
                RemoveAllDifferentPattern(RegexPatterns.PatternRemoveFirstZero);

            if (cleanNumber.Length == 10 || cleanNumber.Length == 11)
            {
                Number = cleanNumber;
                NumberWithMask = Number.SetMask(TypeMaskPhone.Mask2_DD_NineDigits);
            }
        }

        public string Number { get; private set; }
        public string NumberWithMask { get; private set; }

        public Phone ApplyMask(TypeMaskPhone typeMask)
        {
            NumberWithMask = Number?.SetMask(typeMask.Value);

            return this;
        }

        public bool IsValid() => !string.IsNullOrEmpty(Number);

        #region Parses
        public static implicit operator Phone(string input) => new Phone(input);
        public static implicit operator string(Phone phone) => phone?.Number ?? default(string);
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            Phone compareTo = obj as Phone;

            if (compareTo is null)
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            return Number.Equals(compareTo.Number) && (NumberWithMask?.Equals(compareTo.NumberWithMask) ?? compareTo.NumberWithMask == null);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 1621) + Number.GetHashCode() + (NumberWithMask?.GetHashCode() ?? 0);
        }
        public override string ToString()
        {
            return Number;
        }
        #endregion
    }
}
