using Microsoft.AspNetCore.Components.Forms;

namespace Common.Components;

public class CustomInputSelect<TValue> : InputSelect<TValue>
{
    protected override bool TryParseValueFromString(string? value, out TValue result, out string? validationErrorMessage)
    {
        if (typeof(TValue) == typeof(int))
        {
            if (TryConvertToInt(value, out result))
            {
                validationErrorMessage = null;
                return true;
            }

            validationErrorMessage = $"The selected value {value} is not a valid number.";
            return false;

            /*if (int.TryParse(value, out var intValue))
            {
                result = (TValue) (object) intValue;
                validationErrorMessage = null;
                return true;
            }

            result = default!;
            validationErrorMessage =
                $"The selected value {value} is not a valid number.";
            return false;*/
        }

        return base.TryParseValueFromString(value, out result, out validationErrorMessage);
    }

    private static bool TryConvertToInt(string? value, out TValue result)
    {
        if (int.TryParse(value, out var intValue))
        {
            result = (TValue) Convert.ChangeType(intValue, typeof(TValue));
            // result = (TValue) (object) intValue;
            return true;
        }

        result = default!;
        return false;
    }
}