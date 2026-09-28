using System.Threading;
using System.Threading.Tasks;

namespace NimBus.Core.Messages;

/// <summary>
/// Interface for processing deferred messages from the non-session subscription.
/// </summary>
public interface IDeferredMessageProcessor
{
    /// <summary>
    /// Processes all deferred messages for the specified session.
    /// Messages are retrieved from the session-enabled deferred subscription
    /// via <c>AcceptSessionAsync(sessionId)</c>, sorted by DeferralSequence,
    /// and re-published to the main topic for normal processing. If the session is
    /// blocked again during the drain, the remaining messages stay parked for the
    /// next unblock.
    /// </summary>
    /// <param name="sessionId">The session ID to process deferred messages for.</param>
    /// <param name="topicName">The topic name to re-publish messages to.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task ProcessDeferredMessagesAsync(string sessionId, string topicName, CancellationToken cancellationToken = default);
}
