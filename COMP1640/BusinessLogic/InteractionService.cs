using AutoMapper;
using Common.DTOs.InteractionDtos;
using Common.ViewModels.InteractionVMs;
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
    public async Task<IEnumerable<InteractionVM>> GetAllInteractions(GetAllInteractionsDto dto)
    {
        var interactions = await _unitOfWork.Interactions.GetAllAsync();
        return _mapper.Map<IEnumerable<InteractionVM>>(interactions);
    }

    public async Task<InteractionDetailVM> GetInteractionById(int id)
    {
        var interaction = await _unitOfWork.Interactions.GetByIdAsync(id); 
        return _mapper.Map<InteractionDetailVM>(interaction); 
    }

}









