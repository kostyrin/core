﻿using System;
using Bit.Core.Models.Table;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Bit.Core.Models.Data;
using System.Collections.Generic;

namespace Bit.Core.Repositories.SqlServer
{
    public class OrganizationUserRepository : Repository<OrganizationUser, Guid>, IOrganizationUserRepository
    {
        public OrganizationUserRepository(GlobalSettings globalSettings)
            : this(globalSettings.SqlServer.ConnectionString)
        { }

        public OrganizationUserRepository(string connectionString)
            : base(connectionString)
        { }

        public async Task<OrganizationUser> GetByOrganizationAsync(Guid organizationId, Guid userId)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var results = await connection.QueryAsync<OrganizationUser>(
                    "[dbo].[OrganizationUser_ReadByOrganizationIdUserId]",
                    new { OrganizationId = organizationId, UserId = userId },
                    commandType: CommandType.StoredProcedure);

                return results.SingleOrDefault();
            }
        }

        public async Task<OrganizationUserUserDetails> GetDetailsByIdAsync(Guid id)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var results = await connection.QueryAsync<OrganizationUserUserDetails>(
                    "[dbo].[OrganizationUserUserDetails_ReadById]",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return results.SingleOrDefault();
            }
        }

        public async Task<ICollection<OrganizationUserUserDetails>> GetManyDetailsByOrganizationAsync(Guid organizationId)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var results = await connection.QueryAsync<OrganizationUserUserDetails>(
                    "[dbo].[OrganizationUserUserDetails_ReadByOrganizationId]",
                    new { OrganizationId = organizationId },
                    commandType: CommandType.StoredProcedure);

                return results.ToList();
            }
        }

        public async Task<ICollection<OrganizationUserOrganizationDetails>> GetManyDetailsByUserAsync(Guid userId)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var results = await connection.QueryAsync<OrganizationUserOrganizationDetails>(
                    "[dbo].[OrganizationUserOrganizationDetails_ReadByUserId]",
                    new { UserId = userId },
                    commandType: CommandType.StoredProcedure);

                return results.ToList();
            }
        }
    }
}
