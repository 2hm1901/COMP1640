using AutoMapper;
using DataAccess.Repository.Core;

namespace BusinessLogic;
public class InteractionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public InteractionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }







}
