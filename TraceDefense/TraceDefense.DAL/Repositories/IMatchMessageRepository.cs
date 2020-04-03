﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TraceDefense.Entities.Protos;

namespace TraceDefense.DAL.Repositories
{
    /// <summary>
    /// <see cref="MatchMessage"/> repository definition
    /// </summary>
    public interface IMatchMessageRepository : IRepository<MatchMessage, string>
    {
        /// <summary>
        /// Pulls a list of the latest <see cref="MatchMessage"/> objects, based on client parameters
        /// </summary>
        /// <param name="region">Target <see cref="Region"/></param>
        /// <param name="lastTimestamp">Timestamp of latest client <see cref="MatchMessage"/> for region, in ms since UNIX epoch</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Collection of <see cref="MessageInfo"/> objects</returns>
        Task<IEnumerable<MessageInfo>> GetLatestAsync(Region region, long lastTimestamp, CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieves the data size, in bytes, of a region's latest <see cref="MatchMessage"/> data
        /// </summary>
        /// <param name="region">Target <see cref="Region"/></param>
        /// <param name="lastTimestamp">Timestamp of latest client <see cref="MatchMessage"/> for region, in ms since UNIX epoch</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Data size, in bytes</returns>
        Task<long> GetLatestRegionSizeAsync(Region region, long lastTimestamp, CancellationToken cancellationToken = default);
        /// <summary>
        /// Pulls a collection of <see cref="MatchMessage"/> objects, based on provided identifiers
        /// </summary>
        /// <param name="ids">Collection of <see cref="MatchMessage"/> identifiers</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Collection of <see cref="MatchMessage"/> objects</returns>
        Task<IEnumerable<MatchMessage>> GetRangeAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
        /// <summary>
        /// Store a new <see cref="MatchMessage"/> in the repository
        /// </summary>
        /// <param name="region">Target <see cref="Region"/></param>
        /// <param name="message"><see cref="MatchMessage"/> to store</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Unique identifier of stored object</returns>
        Task<string> InsertAsync(Region region, MatchMessage message, CancellationToken cancellationToken = default);
    }
}