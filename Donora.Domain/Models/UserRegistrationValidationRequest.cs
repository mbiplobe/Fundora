public sealed record UserRegistrationValidationRequest(
    string Email,
    string Mobile,
    string UserName
);