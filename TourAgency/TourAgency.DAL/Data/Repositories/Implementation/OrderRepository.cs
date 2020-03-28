﻿using Microsoft.EntityFrameworkCore;
using System;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Add(Order entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.CreatedAt = DateTime.UtcNow;
            _dbContext.Set<Order>().Add(entity);
        }

        public override void Delete(Order entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}