using Microsoft.Extensions.Options;

[OptionsValidator]
public partial class OtherOptionsValidator : IValidateOptions<OtherOptions>
{
    public ValidateOptionsResult Validate(string? name,
        OtherOptions options)
    {
        if (string.IsNullOrEmpty(options.Level))
        {
            return ValidateOptionsResult.Fail("Level can't be null");
        }

        return ValidateOptionsResult.Success;
    }
}