using BialaListaVat.ValueObjects.NipValue;
using BialaListaVat.ValueObjects.RegonValue;

namespace BialaListaVatTests
{
    public class UnitTestsValueObjects
    {
        [Theory]
        [InlineData("6282 767 94")]
        [InlineData("381552628")]
        [InlineData("839293628")]
        [InlineData("32200211456555")]
        [InlineData("988-45-169-113-285")]
        [InlineData(" 72920799344497 ")]
        public void Regon_Correct_Theory(string regon)
        {
            //Arrange
            //Act
            var result = new Regon(regon);

            regon = regon
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();
            //Assert
            Assert.Equal(regon, result.Number);
        }
        [Theory]
        [InlineData("")]
        [InlineData("3815526")]
        [InlineData("8392936")]
        [InlineData(" 3220021145655 ")]
        [InlineData("988-45-169-113-2854")]
        [InlineData("72920799344497xx")]
        public void Regon_RegonException_Theory(string regon)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<RegonException>(() => new Regon(regon));
        }
        //=========================================================================================================================================
        //=========================================================================================================================================
        [Theory]
        [InlineData("2458571425")]
        [InlineData(" 3815526286 ")]
        [InlineData(" 83-9-293-62-83 ")]
        public void Nip_Correct_Theory(string nip)
        {
            //Arrange
            //Act
            var result = new Nip(nip);

            nip = nip
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();
            //Assert
            Assert.Equal(nip, result.Number);
        }
        [Theory]
        [InlineData("")]
        [InlineData("3815526")]
        [InlineData("8392936")]
        [InlineData(" 3220021145655 ")]
        [InlineData("988-45-169-113-2854")]
        [InlineData("72920799344497xx")]
        public void Nip_NipException_Theory(string nip)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<NipException>(() => new Nip(nip));
        }
    }
}
