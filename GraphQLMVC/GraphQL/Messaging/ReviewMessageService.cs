using GraphQLMVC.Data.Entities;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace GraphQLMVC.GraphQL.Messaging
{
    public class ReviewMessageService
    {
        private readonly ISubject<ReviewAddedMessage> _messageStream =
            new ReplaySubject<ReviewAddedMessage>(1);

        public ReviewAddedMessage AddReviewAddedMessage(ProductReview productReview)
        {
            var message = new ReviewAddedMessage
            {
                ProductId = productReview.ProductId,
                Title = productReview.Title
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<ReviewAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}
