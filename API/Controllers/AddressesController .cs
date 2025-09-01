using AutoMapper;
using Core.Models;
using Core.ServicesBll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController : ControllerBase
{
    // - הזרקה של ה bll
    AddressInterfaceBLL Abll;  
    //-הזרקה של ה mapper
    IMapper mapper;

    public AddressesController(AddressInterfaceBLL Abll, IMapper mapper)
    {
        this.Abll = Abll;
        this.mapper = mapper;
    }

    [HttpPut]
    public async Task<int> addAddress(AddressDTO address)
    {
        var q1 = mapper.Map<Address>(address);

        return await Abll.addAddress(q1);

    }
    [HttpGet("{d}")]
    public async Task<List<Address>> GetByMonth(DateTime d)
    {
        return await Abll.GetByMonth(d);
    }

    [HttpGet("nearest")]
    public async Task<List<Address>> GettingNearestPlaces(
    [FromQuery] decimal point1,
    [FromQuery] decimal point2)
    {
        var q1 = await Abll.GettingNearestPlaces(point1, point2);
        return mapper.Map<List<Address>>(q1);
    }


}
