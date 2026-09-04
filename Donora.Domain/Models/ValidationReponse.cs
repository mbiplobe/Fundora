public sealed record ValidationResponse(
    bool IsValid,
    string Message
);