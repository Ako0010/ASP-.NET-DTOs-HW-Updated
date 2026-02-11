using ASP_.NET_DTOs_HW.DTOs.Invoice_DTOs;
using FluentValidation;

namespace ASP_.NET_DTOs_HW.Validator;

public class UpdateInvoiceValidator : AbstractValidator<UpdateInvoiceRequest>
{
    public UpdateInvoiceValidator()
    {
        RuleFor(x => x.Comment)
               .MinimumLength(3).WithMessage("Comment must be at least 3 characters long");

    }
}
