using ASP_.NET_DTOs_HW.Common;
using ASP_.NET_DTOs_HW.DTOs.Customer_DTOs;

namespace ASP_.NET_DTOs_HW.Services.Interfaces
{

    public interface ICustomerService
    {
        Task<CustomerResponseDto> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest);
        Task<CustomerResponseDto> UpdateCustomerAsync(Guid id, UpdateCustomerRequest createCustomerRequest);
        Task<List<CustomerResponseDto>> GetAllCustomersAsync();
        Task<PagedResult<CustomerResponseDto>> GetPagedAsync(CustomerQueryParams customerQueryParams);
        Task<CustomerResponseDto> GetCustomerByIdAsync(Guid customerId);
        Task<CustomerResponseDto?> ArchiveCustomerAsync(Guid id);
        Task<bool> DeleteCustomerAsync(Guid id);



    }
}