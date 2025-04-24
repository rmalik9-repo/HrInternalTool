using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using MediatR;

namespace HrInternalTool.Application.Commands
{
    public record AddPerformanceReviewCommand(PerformanceReviewsEntity review) : IRequest<PerformanceReviewsEntity>;

    public class AddPerformanceReviewCommandHandler(IPerformanceReviewRepository reviewRepository) : IRequestHandler<AddPerformanceReviewCommand, PerformanceReviewsEntity>
    {
        public async Task<PerformanceReviewsEntity> Handle(AddPerformanceReviewCommand request, CancellationToken cancellationToken)
        {
            return await reviewRepository.AddPerformanceReviewAsync(request.review);
        }
    }
   
}
