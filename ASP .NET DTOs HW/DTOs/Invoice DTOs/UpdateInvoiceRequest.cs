namespace ASP_.NET_DTOs_HW.DTOs.Invoice_DTOs;

public class UpdateInvoiceRequest
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string? Comment { get; set; }

    public List<UpdateInvoiceRowRequest> Rows { get; set; } = new();
}

