using ErrorOr;

namespace BuberBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {


        // Error comes from ErrorOr package,
        // includes Code, Description, and Type (error type)
        public static Error NotFound => Error.NotFound(code: "Breakfast not found", description: "Breakfast not found");
    }
}