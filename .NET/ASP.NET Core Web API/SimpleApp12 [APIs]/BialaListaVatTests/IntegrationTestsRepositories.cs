namespace BialaListaVatTests
{
    public class IntegrationTestsRepositories
    {
        /* [Fact]
         public async Task WhiteListVatRepository_GetCompanyByNipAsync_Correct_Nip5261040828()
         {
             //Arrange
             var url = new UrlRepository();
             var deserialization = new DeserializationRepository();
             var repository = new WhiteListVatRepository(url, deserialization);
             //Act
             var result = await repository.GetCompanyByNipAsync("5261040828", CancellationToken.None, new DateOnly(2024, 08, 08));
             //Assert
             Assert.NotNull(result.Company);
             Assert.Equal("000331501", result.Company.Regon);
         }

         [Fact]
         public async Task WhiteListVatRepository_GetCompanyByNipAsync_Incorrect_Nip526104082()
         {
             //Arrange
             var url = new UrlRepository();
             var deserialization = new DeserializationRepository();
             var repository = new WhiteListVatRepository(url, deserialization);
             //Act
             var result = await repository.GetCompanyByNipAsync("526104082", new CancellationToken(), new DateOnly(2024, 08, 08));
             //Assert
             Assert.Null(result.Company);
             Assert.False(result.IsServerProblem);
             Assert.False(result.IsSuccess);
         }

         [Fact]
         public async Task WhiteListVatRepository_GetCompanyByNipAsync_Incorrect_Nip5261040838()
         {
             //Arrange
             var url = new UrlRepository();
             var deserialization = new DeserializationRepository();
             var repository = new WhiteListVatRepository(url, deserialization);
             //Act
             var result = await repository.GetCompanyByNipAsync("5261040838", new CancellationToken(), new DateOnly(2024, 08, 08));
             //Assert
             Assert.Null(result.Company);
             Assert.False(result.IsServerProblem);
             Assert.False(result.IsSuccess);
         }
         //=====================================================================================================================================
         [Fact]
         public async Task WhiteListVatRepository_GetCompanyByRegonAsync_Correct_Regon000331501()
         {
             //Arrange
             var url = new UrlRepository();
             var deserialization = new DeserializationRepository();
             var repository = new WhiteListVatRepository(url, deserialization);
             //Act
             var result = await repository.GetCompanyByRegonAsync("000331501", new CancellationToken(), new DateOnly(2024, 08, 08));
             //Assert
             Assert.NotNull(result.Company);
             Assert.Equal("5261040828", result.Company.Nip);
         }

         [Fact]
         public async Task WhiteListVatRepository_GetCompanyByRegonAsync_Incorrect_Regon00033150()
         {
             //Arrange
             var url = new UrlRepository();
             var deserialization = new DeserializationRepository();
             var repository = new WhiteListVatRepository(url, deserialization);
             //Act
             var result = await repository.GetCompanyByRegonAsync("00033150", new CancellationToken(), new DateOnly(2024, 08, 08));
             //Assert
             Assert.Null(result.Company);
             Assert.False(result.IsServerProblem);
             Assert.False(result.IsSuccess);
         }

         [Fact]
         public async Task WhiteListVatRepository_GetCompanyByRegonAsync_Incorrect_Regon000331502()
         {
             //Arrange
             var url = new UrlRepository();
             var deserialization = new DeserializationRepository();
             var repository = new WhiteListVatRepository(url, deserialization);
             //Act
             var result = await repository.GetCompanyByRegonAsync("000331503", new CancellationToken(), new DateOnly(2024, 08, 08));
             //Assert
             Assert.Null(result.Company);
             Assert.False(result.IsServerProblem);
             Assert.False(result.IsSuccess);
         }
         //===================================================================================================================================
         //===================================================================================================================================
 */
    }
}
