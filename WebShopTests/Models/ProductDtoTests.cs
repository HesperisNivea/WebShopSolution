using System.ComponentModel.DataAnnotations;
using WebShop.Models;

namespace WebShop.Tests.Models;

public class ProductDtoTests
{
    [Fact]
    public void Name_ShouldBeRequired()
    {
        // Arrange
        var product = new ProductDto { Name = null };

        // Act
        var validationResults = ValidateModel(product);

        // Assert
        Assert.Contains(validationResults,
            v => v.MemberNames.Contains(nameof(ProductDto.Name))
                 && v.ErrorMessage.Contains("required"));
    }

    [Fact]
    public void Name_ShouldNotExceedMaxLength()
    {
        // Arrange
        var product = new ProductDto { Name = new string('a', 51) };

        // Act
        var validationResults = ValidateModel(product);

        // Assert
        Assert.Contains(validationResults,
            v => v.MemberNames.Contains(nameof(ProductDto.Name))
                 && v.ErrorMessage.Contains("maximum length"));
    }

    [Fact]
    public void Description_ShouldNotExceedMaxLength()
    {
        // Arrange
        var product = new ProductDto { Description = new string('a', 251) };

        // Act
        var validationResults = ValidateModel(product);

        // Assert
        Assert.Contains(validationResults,
            v => v.MemberNames.Contains(nameof(ProductDto.Description))
                 && v.ErrorMessage.Contains("maximum length"));
    }

    private IList<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}