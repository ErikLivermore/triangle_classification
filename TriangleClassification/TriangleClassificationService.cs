namespace TriangleClassification;

public static class TriangleClassificationService
{
	public static TriangleClassificationResult ClassifyTriangle(float sideALength, float sideBLength, float sideCLength)
	{
		var validationError = ValidateInput(sideALength, sideBLength, sideCLength);
		if (validationError != null)
		{
			return validationError;
		}

		if (FloatsAreEqual(sideALength, sideBLength) && FloatsAreEqual(sideBLength, sideCLength))
		{
			return new EquilateralTriangle();
		}

		if (FloatsAreEqual(sideALength, sideBLength) || FloatsAreEqual(sideBLength, sideCLength) || FloatsAreEqual(sideCLength, sideALength))
		{
			return new IsoscelesTriangle();
		}

		return new ScaleneTriangle();
	}

	private static InvalidInput? ValidateInput(float sideALength, float sideBLength, float sideCLength)
	{
		// Check for valid side lengths
		var nonPositiveSides = new List<string>();
		if (sideALength <= 0) nonPositiveSides.Add("a");
		if (sideBLength <= 0) nonPositiveSides.Add("b");
		if (sideCLength <= 0) nonPositiveSides.Add("c");
		if (nonPositiveSides.Count > 0)
		{
			return new InvalidInput(InputErrorType.SideLengthsMustBePositive, $"{FormatSideList(nonPositiveSides)} must be positive.");
		}

		// Validate the triangle inequality theorem
		// The Triangle Inequality Theorem states that the sum of any 2 sides of a triangle must be greater than the length of the third side.
		// 	The triangle inequality is only checked if all sides are positive to avoid unhelpful errors
		// 	When all sides are positive, there can at most be one violation of the theorem
		if (sideALength + sideBLength <= sideCLength)
		{
			return new InvalidInput(InputErrorType.ViolatesTriangleInequality, "Length of sides a + b must be greater than c.");
		}
		if (sideALength + sideCLength <= sideBLength)
		{
			return new InvalidInput(InputErrorType.ViolatesTriangleInequality, "Length of sides a + c must be greater than b.");
		}
		if (sideBLength + sideCLength <= sideALength)
		{
			return new InvalidInput(InputErrorType.ViolatesTriangleInequality, "Length of sides b + c must be greater than a.");
		}

		return null;
	}

	public static bool FloatsAreEqual(float x, float y, float tolerance = 1e-6f)
	{
		return Math.Abs(x - y) <= tolerance;
	}

	private static string FormatSideList(List<string> sides)
	{
		return sides.Count switch
		{
			0 => "",
			1 => $"Side {sides[0]}",
			2 => $"Sides {sides[0]} and {sides[1]}",
			_ => $"Sides {string.Join(", ", sides.Take(sides.Count - 1))}, and {sides[^1]}"
		};
	}
}
