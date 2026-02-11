using ASP_.NET_DTOs_HW.Common;
using ASP_.NET_DTOs_HW.DTOs.Customer_DTOs;
using ASP_.NET_DTOs_HW.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_DTOs_HW.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;


    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCustomerRequest createCustomerRequest)
    {
        var createdCustomer = await _customerService.CreateCustomerAsync(createCustomerRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
    }
    [HttpGet("all")]
    public async Task<ActionResult> GetAll()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<CustomerResponseDto>>> GetPaged([FromQuery] CustomerQueryParams customerQueryParams)
    {
        var customers = await _customerService.GetPagedAsync(customerQueryParams);
        return Ok(customers);
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById([FromRoute]Guid id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        return Ok(customer);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCustomerRequest updateCustomerRequest)
    {
        var updatedCustomer = await _customerService.UpdateCustomerAsync(id, updateCustomerRequest);
        return Ok(updatedCustomer);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _customerService.DeleteCustomerAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("{id:guid}/archive")]
    public async Task<ActionResult> Archive(Guid id)
    {
        var IsArchived = await _customerService.ArchiveCustomerAsync(id);

        if (IsArchived is null)
            return NotFound($"Customer with id {id} Not found");


        return Ok(IsArchived);
    }


}
