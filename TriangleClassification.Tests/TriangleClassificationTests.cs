namespace TriangleClassification.Tests;

public class TriangleClassificationTests
{
	[TestCase(1, 1, 1, typeof(EquilateralTriangle))]
	[TestCase(2, 2, 3, typeof(IsoscelesTriangle))]
	[TestCase(3, 4, 5, typeof(ScaleneTriangle))]
	public void ClassifyTriangle_WithValidSides_ReturnsExpectedTriangleType(float sideALength, float sideBLength, float sideCLength, Type expectedType)
	{
		var result = TriangleClassificationService.ClassifyTriangle(sideALength, sideBLength, sideCLength);

		Assert.That(result, Is.TypeOf(expectedType));
	}

	[TestCase(0, 3, 2, "Side a must be positive.")]
	[TestCase(3, 0, 2, "Side b must be positive.")]
	[TestCase(3, 0, 0, "Sides b and c must be positive.")]
	[TestCase(-1, -3, -6, "Sides a, b, and c must be positive.")]
	public void ClassifyTriangle_WithNonPositiveSides_ReturnsSideLengthsMustBePositiveError(float sideALength, float sideBLength, float sideCLength, string expectedErrorMessage)
	{
		var result = TriangleClassificationService.ClassifyTriangle(sideALength, sideBLength, sideCLength);

		Assert.That(result, Is.EqualTo(new InvalidInput(InputErrorType.SideLengthsMustBePositive, expectedErrorMessage)));
	}

	[TestCase(1, 2, 3, "Length of sides a + b must be greater than c.")]
	[TestCase(1, 3, 2, "Length of sides a + c must be greater than b.")]
	[TestCase(3, 1, 2, "Length of sides b + c must be greater than a.")]
	public void ClassifyTriangle_WhenAnyTwoSidesAreLessThanOrEqualToThird_ReturnsTriangleInequalityError(float sideALength, float sideBLength, float sideCLength, string expectedErrorMessage)
	{
		var result = TriangleClassificationService.ClassifyTriangle(sideALength, sideBLength, sideCLength);

		Assert.That(result, Is.EqualTo(new InvalidInput(InputErrorType.ViolatesTriangleInequality, expectedErrorMessage)));
	}
}
