// Copyright 2017 Trekking for Charity
// This file is part of TrekkingForCharity.Api.
// TrekkingForCharity.Api is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// TrekkingForCharity.Api is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
// You should have received a copy of the GNU General Public License along with TrekkingForCharity.Api. If not, see http://www.gnu.org/licenses/.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResultMonad;
using TrekkingForCharity.Api.Client.Models;

namespace TrekkingForCharity.Api.Client
{
    public interface IApiClient
    {
        /// <summary>
        /// Gets the trek.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <returns></returns>
        Task<Result<Trek>> GetTrek(Guid trekId);

        /// <summary>
        /// Posts the trek.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="whenToStart">The when to start.</param>
        /// <param name="bannerImage">The banner image.</param>
        /// <returns></returns>
        Task<ExecutionResult> PostTrek(string name, string description, int whenToStart, string bannerImage);

        /// <summary>
        /// Gets the waypoints for trek.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <returns></returns>
        Task<Result<ICollection<Waypoint>>> GetWaypointsForTrek(Guid trekId);

        /// <summary>
        /// Gets the updates for trek.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <returns></returns>
        Task<Result<ICollection<Update>>> GetUpdatesForTrek(Guid trekId);

        /// <summary>
        /// Puts the trek.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="whenToStart">The when to start.</param>
        /// <param name="bannerImage">The banner image.</param>
        /// <returns></returns>
        Task<ExecutionResult> PutTrek(Guid trekId, string name, string description, int whenToStart, string bannerImage);

        /// <summary>
        /// Posts the waypoint.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <param name="lng">The LNG.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="whenToReach">The when to reach.</param>
        /// <returns></returns>
        Task<ExecutionResult> PostWaypoint(Guid trekId, double lng, double lat, int whenToReach);

        /// <summary>
        /// Puts the waypoint.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <param name="waypointId">The waypoint identifier.</param>
        /// <param name="lng">The LNG.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="whenToReach">The when to reach.</param>
        /// <returns></returns>
        Task<ExecutionResult> PutWaypoint(Guid trekId, int waypointId, double lng, double lat,
            int whenToReach);

        /// <summary>
        /// Deletes the waypoint.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <param name="waypointId">The waypoint identifier.</param>
        /// <returns></returns>
        Task<ExecutionResult> DeleteWaypoint(Guid trekId, int waypointId);

        /// <summary>
        /// Posts the update.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <param name="lng">The LNG.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task<ExecutionResult> PostUpdate(Guid trekId, double lng, double lat, string title,
            string message);

        /// <summary>
        /// Hits the waypoint.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <param name="waypointId">The waypoint identifier.</param>
        /// <returns></returns>
        Task<ExecutionResult> HitWaypoint(Guid trekId, int waypointId);

        /// <summary>
        /// Starts the trek.
        /// </summary>
        /// <param name="trekId">The trek identifier.</param>
        /// <returns></returns>
        Task<ExecutionResult> StartTrek(Guid trekId);
    }
}