﻿using Xunit;

namespace Savage.Formatters
{
    public class PhoneNumberFormatterTest
    {
        [Fact]
        public void PhoneNumberFormatterConstructor()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("07712345678", "0044");
            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("", pn.AreaCode);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 7712345678", pn.ToInternationalFormat());
            Assert.Equal("0044 7712345678", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("07712345678", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("07712345678", pn.ToDialFormat("+44", "00", "1234", "0"));
        }

        [Fact]
        public void StaticToInternationalFormat()
        {
            string sut = PhoneNumberFormatter.ToInternationalFormat("07712345678", "0044");
            Assert.Equal("+44 7712345678", sut);
        }

        [Fact]
        public void InternationalWithPlusSign()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("+44 1234 123456", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("1234", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (1234) 123456", pn.ToInternationalFormat());
            Assert.Equal("0044 (1234) 123456", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(01234) 123456", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("123456", pn.ToDialFormat("+44", "00", "1234", "0"));
        }

        [Fact]
        public void InternationalWithDoubleZeros()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("0044 1234 123456", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("1234", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (1234) 123456", pn.ToInternationalFormat());
            Assert.Equal("0044 (1234) 123456", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(01234) 123456", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("123456", pn.ToDialFormat("+44", "00", "1234", "0"));
        }

        [Fact]
        public void SingleDigitInternationWithPlusSign()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("+1 1234 123456", "+44");

            Assert.Equal("+1", pn.CountryCode);
            Assert.Equal("1234", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+1 (1234) 123456", pn.ToInternationalFormat());
            Assert.Equal("001 (1234) 123456", pn.ToDialFormat("+44", "00", "1234", "0"));
            Assert.Equal("(01234) 123456", pn.ToDialFormat("+1", "00", "8888", "0"));
            Assert.Equal("123456", pn.ToDialFormat("+1", "00", "1234", "0"));
        }

        [Fact]
        public void SingleDigitInternationalWithDoubleZeros()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("001 1234 123456", "+44");

            Assert.Equal("+1", pn.CountryCode);
            Assert.Equal("1234", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+1 (1234) 123456", pn.ToInternationalFormat());
            Assert.Equal("001 (1234) 123456", pn.ToDialFormat("+44", "00", "1234", "0"));
            Assert.Equal("(01234) 123456", pn.ToDialFormat("+1", "00", "8888", "0"));
            Assert.Equal("123456", pn.ToDialFormat("+1", "00", "1234", "0"));
        }

        [Fact]
        public void InternationalWithBracketsNoSpaces()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("001(1234)123456", "+44");

            Assert.Equal("+1", pn.CountryCode);
            Assert.Equal("1234", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+1 (1234) 123456", pn.ToInternationalFormat());
            Assert.Equal("001 (1234) 123456", pn.ToDialFormat("+44", "00", "1234", "0"));
            Assert.Equal("(01234) 123456", pn.ToDialFormat("+1", "00", "8888", "0"));
            Assert.Equal("123456", pn.ToDialFormat("+1", "00", "1234", "0"));
        }

        [Fact]
        public void NationalWithBracketsAndExtension()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("(01234) 123456 Ext. 123", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("1234", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("123", pn.Extension);

            Assert.Equal("+44 (1234) 123456x123", pn.ToInternationalFormat());
            Assert.Equal("0044 (1234) 123456x123", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(01234) 123456x123", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("123456x123", pn.ToDialFormat("+44", "00", "1234", "0"));
        }

        [Fact]
        public void NationalWithBracketsAndSpaces()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("(01234) 123 4567", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("1234", pn.AreaCode);
            Assert.Equal("1234567", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (1234) 1234567", pn.ToInternationalFormat());
            Assert.Equal("0044 (1234) 1234567", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(01234) 1234567", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("1234567", pn.ToDialFormat("+44", "00", "1234", "0"));
        }

        [Fact]
        public void MobileNumber()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("07712345678", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("", pn.AreaCode);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 7712345678", pn.ToInternationalFormat());
            Assert.Equal("0044 7712345678", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("07712345678", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("07712345678", pn.ToDialFormat("+44", "00", "1234", "0"));
        }

        [Fact]
        public void InternationalMobileNumber()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("+44 7712345678", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("", pn.AreaCode);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 7712345678", pn.ToInternationalFormat());
            Assert.Equal("0044 7712345678", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("07712345678", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("07712345678", pn.ToDialFormat("+44", "00", "1234", "0"));
        }

        [Fact]
        public void InternationalNoBrackets()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("+44 115 123 4567", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("115", pn.AreaCode);
            Assert.Equal("1234567", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (115) 1234567", pn.ToInternationalFormat());
            Assert.Equal("0044 (115) 1234567", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(0115) 1234567", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("1234567", pn.ToDialFormat("+44", "00", "115", "0"));
        }

        [Fact]
        public void InternationalBracketsNoSpaces()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("+44 (115) 123 4567", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("115", pn.AreaCode);
            Assert.Equal("1234567", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (115) 1234567", pn.ToInternationalFormat());
            Assert.Equal("0044 (115) 1234567", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(0115) 1234567", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("1234567", pn.ToDialFormat("+44", "00", "115", "0"));
        }

        [Fact]
        public void InternationalWithThreeDigitNationalNoBrackets()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("+44 115 1234567", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("115", pn.AreaCode);
            Assert.Equal("1234567", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (115) 1234567", pn.ToInternationalFormat());
            Assert.Equal("0044 (115) 1234567", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(0115) 1234567", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("1234567", pn.ToDialFormat("+44", "00", "115", "0"));
        }

        [Fact]
        public void InternationalWithBrackets()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("+44 (115) 1234567", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("115", pn.AreaCode);
            Assert.Equal("1234567", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (115) 1234567", pn.ToInternationalFormat());
            Assert.Equal("0044 (115) 1234567", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(0115) 1234567", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("1234567", pn.ToDialFormat("+44", "00", "115", "0"));
        }

        [Fact]
        public void FourDigitNationalWithBrackets()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("(0115) 123 4567", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("115", pn.AreaCode);
            Assert.Equal("1234567", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (115) 1234567", pn.ToInternationalFormat());
            Assert.Equal("0044 (115) 1234567", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(0115) 1234567", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("1234567", pn.ToDialFormat("+44", "00", "115", "0"));
        }

        [Fact]
        public void FiveDigitNationalWithBrackets()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("(01773) 123456", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("1773", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (1773) 123456", pn.ToInternationalFormat());
            Assert.Equal("0044 (1773) 123456", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(01773) 123456", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("123456", pn.ToDialFormat("+44", "00", "1773", "0"));
        }

        [Fact]
        public void FiveDigitNationalNoBrackets()
        {
            PhoneNumberFormatter pn = new PhoneNumberFormatter("01773 123456", "+44");

            Assert.Equal("+44", pn.CountryCode);
            Assert.Equal("1773", pn.AreaCode);
            Assert.Equal("123456", pn.LocalNumber);
            Assert.Equal("", pn.Extension);

            Assert.Equal("+44 (1773) 123456", pn.ToInternationalFormat());
            Assert.Equal("0044 (1773) 123456", pn.ToDialFormat("+1", "00", "1234", "0"));
            Assert.Equal("(01773) 123456", pn.ToDialFormat("+44", "00", "8888", "0"));
            Assert.Equal("123456", pn.ToDialFormat("+44", "00", "1773", "0"));
        }
    }
}